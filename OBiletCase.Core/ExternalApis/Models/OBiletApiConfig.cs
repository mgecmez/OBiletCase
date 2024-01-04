using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OBiletCase.Core.ExternalApis.Models
{
    public class OBiletApiConfig
    {
        public string BaseUrl { get; set; }
        public string Token { get; set; }
        public string ClientApi { get; set; }
        public string LocationApi { get; set; }
        public string JourneyApi { get; set; }
    }
}
