using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TasksProjectServer.Models.Request
{
    public class GetTasksRequest
    {
        public string Status { get; set; }
        public string StartDate { get; set; }
        public string EndDate { get; set; }
        public string Order { get; set; }
    }
}
