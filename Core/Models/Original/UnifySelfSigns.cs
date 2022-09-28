using System;
using System.Xml.Serialization;

namespace Core.Models.Original
{
    [XmlRoot(ElementName = "unify_self_signs")]
    public class UnifySelfSigns
    {
        [XmlElement(ElementName = "sender_gln")]
        public string SenderGln { get; set; }

        [XmlElement(ElementName = "unify_date")]
        public string UnifyDateString { get; set; }

        [XmlElement(ElementName = "unifies")]
        public Unifies Unifies { get; set; }

        [XmlAttribute(AttributeName = "action_id")]
        public string ActionId { get; set; }

        public DateTime? UnifyDate
        {
            get
            {
                if (DateTime.TryParse(UnifyDateString, out DateTime result))
                {
                    return result;
                }

                return default;
            }
        }
    }
}