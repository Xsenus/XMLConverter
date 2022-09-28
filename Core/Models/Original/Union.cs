using System.Xml.Serialization;

namespace Core.Models.Original
{
    [XmlRoot(ElementName = "union")]
    public class Union
    {
        [XmlElement(ElementName = "gs1_sgtin")]
        public string Gs1Sgtin { get; set; }
        [XmlElement(ElementName = "sign_num")]
        public string SignNum { get; set; }
    }
}