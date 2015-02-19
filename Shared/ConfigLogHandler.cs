using System.Xml.Serialization;

namespace Config
{
    /// <remarks/>
    [XmlType(AnonymousType = true)]
    public class ConfigLogHandler
    {
        /// <remarks/>
        [XmlAttribute]
        public bool Nlog { get; set; }
    }
}