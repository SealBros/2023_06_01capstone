using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EUV.Utility
{
    class Json
    {
        string path;
        public Json(string path)
        {
            try
            {

                if (!File.Exists(path))
                {
                    using (File.Create(path))
                    {
                        Console.WriteLine("파일 생성 성공");
                        this.path = path;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        public void WriteJson(string fullName)
        {
            if (File.Exists(path))
                InputJson(fullName);
        }

        private void InputJson(string fullName)
        {
            JObject dbSpec = new JObject(
                new JProperty("PATH", fullName)
                );

            //Jarray 로 추가 (리스트)
            //dbSpec.Add("USERS", JArray.FromObject(users));

            File.WriteAllText(path, dbSpec.ToString());
        }

        public List<string> ReadJson()
        {
            List<string> fileName = new List<string>();

            //// Json 파일 읽기
            using (StreamReader file = File.OpenText(path))
            using (JsonTextReader reader = new JsonTextReader(file))
            {
                JObject json = (JObject)JToken.ReadFrom(reader);

                fileName.Add(json["PATH"].ToString());
            }
            return fileName;
        }
    }
}
