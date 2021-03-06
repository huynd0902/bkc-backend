﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bkc_backend.Data.Entities
{
    public class DriverCar: BaseEntity
    {
        public int DriverId { get; set; }
        public string DriverName { get; set; }
        public string DriverPhone { get; set; }
        public string DriverEmail { get; set; }

        public int CarId { get; set; }
        public string CarNumber { get; set; }
        public int CarTotalSeat { get; set; }
        public int CarAvailableSeat { get; set; }
        public string CarBuId { get; set; }
        public string CarBuName { get; set; }
        public bool CarStatus { get; set; }
    }
}
