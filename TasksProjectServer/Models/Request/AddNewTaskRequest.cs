using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TasksProjectServer.Models.Request
{
    public class AddNewTaskRequest
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Date { get; set; }
        public string Description { get; set; }
        public string Status { get; set; }
    }
}
