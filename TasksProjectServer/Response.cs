using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TasksProjectServer
{
    public class Response
    {
        [JsonProperty(PropertyName = "responseType")]
        public string ResponseType { get; set; }
        public Response()
        {
            ResponseType = this.GetType().Name;
        }
    }
}
