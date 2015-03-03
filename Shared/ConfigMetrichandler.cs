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
        public string InfluxdbUrl { get; set; }
        public int InfluxdbPort { get; set; }
        public string InfluxdbUser { get; set; }
        public string InfluxdbPass { get; set; }
        
        public bool Graphite { get; set; }
        public bool Plaintext { get; set; }
    }
}