using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Newtonsoft.Json;

namespace ii_dinahyi_
{
    class FileSave
    {
        public static void Serialize<T> ( string path, T obj)
        {
            File.WriteAllText(path, JsonConvert.SerializeObject(obj));
        }
        public static T Deserialize<T> (string path)
        {
            return JsonConvert.DeserializeObject<T>(File.ReadAllText(path));
        }
    }
}
