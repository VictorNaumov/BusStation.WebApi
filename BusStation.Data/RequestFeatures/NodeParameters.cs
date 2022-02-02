﻿namespace BusStation.Data.RequestFeatures
{
    public class NodeParameters : RequestParameters
    {
        public NodeParameters()
        {
            OrderBy = "name";
        }

        public string SearchTerm { get; set; }
        public string BusStop { get; set; }
        public string MinPrice { get; set; }
        public string MaxPrice { get; set; }
    }
}
