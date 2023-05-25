﻿using QueueManager.Domain.Models.BusinessModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QueueManager.Application.Interfaces.common
{
    public interface IClinicRepository:IGenericRepository<Clinic>
    {
    }
}