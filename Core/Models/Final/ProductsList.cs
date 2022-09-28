using System.Collections.Generic;
using System.Xml.Serialization;

namespace Core.Models.Final
{
    [XmlRoot(ElementName = "products_list")]
    public class ProductsList
    {
        [XmlElement(ElementName = "product")]
        public List<Product> Product { get; set; }
    }
}