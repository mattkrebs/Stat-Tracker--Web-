using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Runtime.Serialization.Json;

namespace StatTrackr.WCF
{
    public static class ServicesHelper
    {
        public static string Serialize<T>(T obj)
        {
            string json;
            DataContractJsonSerializer ser = new DataContractJsonSerializer(typeof(T));
            using (var ms = new MemoryStream())
            {
                 ser.WriteObject(ms, obj);
                 json = Encoding.Default.GetString(ms.ToArray());
            }
            return json;
        } 

        public static T Deserialise<T>(string json)
        {
            var obj = Activator.CreateInstance<T>();
            using (var memoryStream = new MemoryStream(Encoding.Unicode.GetBytes(json)))
            {
                var serializer = new DataContractJsonSerializer(obj.GetType());
                obj = (T)serializer.ReadObject(memoryStream);
                return obj;
            }
        } 
    }
}
