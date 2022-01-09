using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TasksProjectServer.Models
{
    public class TaskObj
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Date { get; set; }
        public string Description { get; set; }
        public string Status { get; set; }
    }
}
