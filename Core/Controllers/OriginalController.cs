using Core.Models.Original;
using System.IO;
using System.Xml.Serialization;

namespace Core.Controllers
{
    public static class OriginalController
    {
        public static Query GetQueryFromXML(string path)
        {
            var xmlSerializer = new XmlSerializer(typeof(Query));
            using (var fs = new FileStream(path, FileMode.OpenOrCreate))
            {
                return xmlSerializer.Deserialize(fs) as Query;
            }
        }
    }
}
