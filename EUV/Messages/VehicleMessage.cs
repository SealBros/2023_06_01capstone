using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace EUV.Messages
{
    public class VehicleMessage
    {
        [JsonInclude]
        public bool? selected;
        [JsonInclude]
        public int id;
        [JsonInclude]
        public bool connect;
        [JsonInclude]
        public int? gps_fix_type;
        [JsonInclude]
        public int? gps_count;
        [JsonInclude]
        public double gps_c_lat;
        [JsonInclude]
        public double gps_c_lng;
        [JsonInclude]
        public double gps_c_alt;
        [JsonInclude]
        public double heading;
        [JsonInclude]
        public double battery_voltage;
        [JsonInclude]
        public double? battery_current;
        [JsonInclude]
        public double? battery_level;
        [JsonInclude]
        public int? wlan_quality;
        [JsonInclude]
        public string mode;
        [JsonInclude]
        public bool arm;
    }
}
