using System.Xml.Serialization;

namespace Config
{
    /// <remarks/>
    [XmlType(AnonymousType = true)]
    public class ConfigMetrichandler
    {
        /// <remarks/>
        [XmlAttribute]
        public bool Influxdb { get; set; }
    }
}