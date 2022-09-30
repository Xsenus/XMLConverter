using System.Collections.Generic;
using System.Xml.Serialization;

namespace Core.Models.Original
{
    [XmlRoot(ElementName = "by_gtin")]
    public class ByGtin
    {
        [XmlElement(ElementName = "sign_gtin")]
        public string SignGtin { get; set; }
        [XmlElement(ElementName = "union")]
        public List<Union> Union { get; set; }
    }
}