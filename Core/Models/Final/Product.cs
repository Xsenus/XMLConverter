using System.Xml.Serialization;

namespace Core.Models.Final
{
    [XmlRoot(ElementName = "product")]
    public class Product
    {
        [XmlElement(ElementName = "cis_code")]
        public string CisCode { get; set; }
        [XmlElement(ElementName = "sgtin")]
        public string Sgtin { get; set; }
        [XmlElement(ElementName = "gtin")]
        public string Gtin { get; set; }
    }

}

