using EUV.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace EUV.Controls
{
    class MessageParser
    {
        #region 인스턴스 선언 및 반환
        private static MessageParser _instance;

        public static MessageParser _getInstance()
        {
            if (_instance == null)
                _instance = new MessageParser();

            return _instance;
        }
        #endregion

        internal bool parsing(byte[] b, string address)
        {
            string jsonStr = Encoding.Default.GetString(b);

            //Console.WriteLine(jsonStr);

            JsonDocumentOptions jsonDocumentOptions = new JsonDocumentOptions
            {
                AllowTrailingCommas = true
            };

            JsonDocument jsonDocument = JsonDocument.Parse(jsonStr.Remove(jsonStr.Length-1, 1), jsonDocumentOptions);

            // Json Data 전체 출력
            //Console.WriteLine(jsonDocument.RootElement);

            // JSON 데이터 중 'Radiation resistance' 데이터까지 접근하는 방법
            //Console.WriteLine(jsonDocument.RootElement.GetProperty("id"));
            /*
            // JSON 데이터 하위 객체인 members 객체의 name 값을 반복적으로 접근하는 방법
            JsonElement jsonElement = jsonDocument.RootElement.GetProperty("members");
            foreach (JsonElement members in jsonElement.EnumerateArray())
            {
                Console.WriteLine(members.GetProperty("name"));
            }
            */

            //역직렬화
            JsonSerializerOptions jsonSerializerOptions = new JsonSerializerOptions
            {
                AllowTrailingCommas = true, // 데이터 후행의 쉼표 허용 여부
                IgnoreNullValues = true
                //DefaultIgnoreCondition = System.Text.Json.Serialization.JsonIgnoreCondition.WhenWritingNull
            };
            
            int _id = -1;
            try
            {
                VehicleMessage vehicleMessage = JsonSerializer.Deserialize<VehicleMessage>(jsonStr.Remove(jsonStr.Length - 1, 1), jsonSerializerOptions);
                _id = vehicleMessage.id;

                //AllAboutMessages._getInstance().VehicleMessages
                var index = AllAboutMessages._getInstance().VehicleMessages.FindIndex(c => c.id == _id);
                if (index != -1)
                {
                    if (AllAboutMessages._getInstance().VehicleMessages[index].selected == true)
                    {
                        vehicleMessage.selected = true;

                    }
                    else
                    { 
                        vehicleMessage.selected = false;
                    }
                        
                    AllAboutMessages._getInstance().VehicleMessages[index] = vehicleMessage;
                    
                }
                else
                {
                    AllAboutMessages._getInstance().VehicleMessages.Add(vehicleMessage);
                }
                

            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }

            
            Sockets.TcpSocket._getInstance()._setSocketID(_id, address);

            return true;
        }
    }
}
