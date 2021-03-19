using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Part8.Data.Models.Abstract
{
    public class Resource
    {
        [JsonProperty(Order = -1)]
        public string Href { get; set; }
    }
}
