using Core.Models.Final;
using Core.Models.Original;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Xml;
using System.Xml.Serialization;

namespace Core.Controllers
{
    public static class FinalController
    {
        public static IndividualizationKiz GetIndividualization(Query query)
        {
            var inn = query?.UnifySelfSigns?.SenderGln;
            if (!string.IsNullOrWhiteSpace(inn) && inn.Length > 10)
            {
                inn = inn.Substring(0, 10);
            }

            var obj = new IndividualizationKiz()
            {
                Version = "1",
                ParticipantInn = inn,
                IndividualizationDate = query?.UnifySelfSigns?.UnifyDate?.ToString("yyyy-MM-dd"),
                ProductsList = new ProductsList()
                {
                    Product = new List<Product>()
                }
            };

            foreach (var item in query?.UnifySelfSigns?.Unifies?.ByGtin)
            {
                foreach (var union in item.Union)
                {
                    var produc = new Product()
                    {
                        CisCode = union?.SignNum,
                        Sgtin = union?.Gs1Sgtin,
                        Gtin = $"0{item?.SignGtin}"
                    };
                    obj.ProductsList.Product.Add(produc);
                }                
            }            

            return obj;
        }

        public static void GetXML(IndividualizationKiz obj, string path, Encoding encoding)
        {
            var str = SerializeObject(obj, encoding);
            File.WriteAllText(path, str);
        }

        public static string SerializeObject<T>(T obj, Encoding enc)
        {
            using (var ms = new MemoryStream())
            {
                var xmlWriterSettings = new XmlWriterSettings()
                {
                    CloseOutput = false,
                    Encoding = enc,
                    OmitXmlDeclaration = false,
                    Indent = true
                };

                using (var xw = XmlWriter.Create(ms, xmlWriterSettings))
                {
                    var emptyNamespaces = new XmlSerializerNamespaces();
                    emptyNamespaces.Add("", "any-non-empty-string");

                    XmlSerializer s = new XmlSerializer(typeof(T));
                    s.Serialize(xw, obj, emptyNamespaces);
                }

                return enc.GetString(ms.ToArray());
            }
        }
    }
}
