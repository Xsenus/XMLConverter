using System.Xml.Serialization;

namespace Core.Models.Final
{
    [XmlRoot(ElementName = "individualizationKiz")]
    public class IndividualizationKiz
    {
        [XmlElement(ElementName = "participant_inn")]
        public string ParticipantInn { get; set; }

        [XmlElement(ElementName = "individualization_date")]
        public string IndividualizationDate { get; set; }

        [XmlElement(ElementName = "products_list")]
        public ProductsList ProductsList { get; set; }

        [XmlAttribute(AttributeName = "version")]
        public string Version { get; set; }
    }
}