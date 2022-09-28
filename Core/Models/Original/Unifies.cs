using System.Collections.Generic;
using System.Xml.Serialization;

namespace Core.Models.Original
{
    [XmlRoot(ElementName = "unifies")]
    public class Unifies
    {
        [XmlElement(ElementName = "by_gtin")]
        public List<ByGtin> ByGtin { get; set; }
    }
}