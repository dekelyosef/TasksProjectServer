﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TasksProjectServer.Models.Request
{
    public class EditTaskStatusRequest
    {
        public int Id { get; set; }
        public string Status { get; set; }
    }
}
