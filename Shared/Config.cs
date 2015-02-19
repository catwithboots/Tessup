using System.Xml.Serialization;

namespace Config
{

    /// <remarks/>
    [XmlType(AnonymousType = true)]
    [XmlRoot(Namespace = "", IsNullable = false)]
    public class Config
    {
        /// <remarks/>
        public ConfigLogHandler LogHandler { get; set; }

        /// <remarks/>
        public ConfigMetrichandler Metrichandler { get; set; }
    }

    /// <remarks/>
    [XmlType(AnonymousType = true)]
    public class ConfigLogHandler
    {
        /// <remarks/>
        [XmlAttribute]
        public bool Nlog { get; set; }
    }

    /// <remarks/>
    [XmlType(AnonymousType = true)]
    public class ConfigMetrichandler
    {
        /// <remarks/>
        [XmlAttribute]
        public bool Influxdb { get; set; }
    }



}
