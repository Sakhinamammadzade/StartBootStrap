﻿namespace StartBootstrap.Models
{
    public class Services:Base
    {
        public string Icon { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }

        public static implicit operator Services(List<Services> v)
        {
            throw new NotImplementedException();
        }
    }
}
