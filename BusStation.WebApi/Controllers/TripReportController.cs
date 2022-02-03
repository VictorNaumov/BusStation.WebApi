﻿using AutoMapper;
using BusStation.Contracts;
using BusStation.Data.DataTransferObjects.Outgoing;
using BusStation.Data.Models;
using BusStation.Data.RequestFeatures;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Products.Controllers
{
    [Route("api/schedules")]
    [ApiController]
    public class TripReportController : ControllerBase
    {
        private readonly IRepositoryManager _repository;
        private readonly IMapper _mapper;

        public TripReportController(IRepositoryManager repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet(Name = "CreateReportAboutAllTrips")]
        public async Task<IActionResult> CreateReportAboutAllTrips([FromQuery] TripReportParameters tripReportParameters)
        {
            var tripReportsEntities = await _repository.TripReport.GetAllTripReportsAsync(tripReportParameters, trackChanges: false);
            var tripReportsDTO = _mapper.Map<IEnumerable<TripReportOutgoingDTO>>(tripReportsEntities);

            foreach (var tripReport in tripReportsDTO)
            {
                var routeBusStopsEntities = await _repository.RouteBusStop.GetRouteBusStopByRouteIdAsync(tripReport.RouteId, trackChanges: false);
                var destination = routeBusStopsEntities.OrderBy(bs => bs.Order).Last().BusStop.Name;

                tripReport.Destination = destination;
                tripReport.MinutesInWay = routeBusStopsEntities.Sum(bs => bs.MinutesInWay);
                tripReport.Price = tripReport.RouteTypeId == 3 ? tripReport.MinutesInWay / 5 :
                                   tripReport.RouteTypeId == 2 ? tripReport.MinutesInWay / 10 : 3;
                tripReport.ArrivalTime = tripReport.DepartureTime.AddMinutes(tripReport.MinutesInWay + routeBusStopsEntities.Sum(bs => bs.WaitingTime));

                var time = tripReport.DepartureTime;
                tripReport.BusStops = new List<BusStopForReportOutgoingDTO>();
                foreach (var routeBusStop in routeBusStopsEntities.OrderBy(bs => bs.Order))
                {
                    var busStopEntity = await _repository.BusStop.GetBusStopByIdAsync(routeBusStop.BusStopId, trackChanges: false);
                    var busStopDTO = _mapper.Map<BusStopForReportOutgoingDTO>(busStopEntity);
                    busStopDTO.Order = routeBusStop.Order;
                    busStopDTO.WaitingTime = routeBusStop.WaitingTime;
                    busStopDTO.ArrivalTime = time.AddMinutes(routeBusStop.MinutesInWay);
                    busStopDTO.DepartureTime = time.AddMinutes(routeBusStop.MinutesInWay + routeBusStop.WaitingTime);
                    time = time.AddMinutes(routeBusStop.MinutesInWay + routeBusStop.WaitingTime);

                    tripReport.BusStops.Add(busStopDTO);
                }
            }

            return Ok(tripReportsDTO);
        }
    }
}