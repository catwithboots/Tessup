using System.Xml.Serialization;

namespace Config
{

    /// <remarks/>
    [XmlType(AnonymousType = true)]
    [XmlRoot(Namespace = "", IsNullable = false)]
    public class Configure
    {
        /// <remarks/>
        public ConfigLogHandler LogHandler { get; set; }

        /// <remarks/>
        public ConfigMetrichandler Metrichandler { get; set; }
    }
}
