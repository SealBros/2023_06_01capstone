using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EUV.Messages
{
    class AllAboutMessages
    {
        private static AllAboutMessages _instance;
        private List<VehicleMessage> vehicleMessages = new List<VehicleMessage>();

        public AllAboutMessages()
        {

        }

        public List<VehicleMessage> VehicleMessages
        {
            get => vehicleMessages;
            //set => vehicleMessages = value;
        }

        public static AllAboutMessages _getInstance()
        {
            if (_instance == null)
            {
                _instance = new AllAboutMessages();
            }
            return _instance;
        }
    }

    class SendMessage
    {
        public int id { get; set; }
        public string cmd { get; set; } //cmd = "ARM";
        public string param { get; set; } // = null;
    }
}
