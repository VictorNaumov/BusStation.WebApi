﻿namespace BusStation.Data.RequestFeatures
{
    public abstract class RequestParameters
    {
        const int maxPageSize = 1000;

        public int PageNumber { get; set; } = 1;

        private int _pageSize = 100;

        public int PageSize
        {
            get
            {
                return _pageSize;
            }
            set
            {
                _pageSize = (value > maxPageSize) ? maxPageSize : value;
            }
        }

        public string OrderBy { get; set; }
    }
}
