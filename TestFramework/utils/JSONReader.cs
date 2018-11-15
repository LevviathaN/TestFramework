using System;
using System.IO;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Configuration;

namespace TestFramework.utils
{
    public class JSONReader
    {
        public class SchemaInfo
        {
            public string AuthenticateCmdlets { get; set; }
            public string GetPowerState { get; set; }
            public string PowerOff { get; set; }
            public string PowerOn { get; set; }
        }

        public static void LoadJson()
        {
            using (StreamReader r = new StreamReader("SchemaList.json"))
            {
                var json = r.ReadToEnd();
                var items = JsonConvert.DeserializeObject<List<SchemaInfo>>(json);
                foreach (var item in items)
                {
                    // Console.WriteLine("{0} {1}", item.temp, item.vcc);
                }
            }
        }
    }
}
