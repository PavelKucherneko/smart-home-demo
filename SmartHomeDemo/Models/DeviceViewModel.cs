﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SmartHomeDemo.Models
{
    public class DeviceViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DeviceStatus Status { get; set; }
    }
}