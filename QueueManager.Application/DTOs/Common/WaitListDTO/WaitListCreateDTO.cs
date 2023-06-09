﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QueueManager.Application.DTOs.Common.WaitListDTO
{
    public class WaitListCreateDTO
    {
        public  Guid DoctorId { get; set; }
        public Guid PatientId { get; set; }
        public bool IsCompleted { get; set; }
        public DateTimeOffset JoinedTime { get; set; }= DateTime.Now;
        public DateTimeOffset CompletedTime { get; set; }

    }
}
