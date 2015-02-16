using System;
using System.Collections.Generic;
using System.Text;

namespace Tessup.Shared
{

    /// <remarks/>
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "", IsNullable = false)]
    public partial class Config
    {

        private ConfigLogHandler logHandlerField;

        private ConfigMetrichandler metrichandlerField;

        /// <remarks/>
        public ConfigLogHandler LogHandler
        {
            get
            {
                return this.logHandlerField;
            }
            set
            {
                this.logHandlerField = value;
            }
        }

        /// <remarks/>
        public ConfigMetrichandler metrichandler
        {
            get
            {
                return this.metrichandlerField;
            }
            set
            {
                this.metrichandlerField = value;
            }
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class ConfigLogHandler
    {

        private bool nlogField;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public bool nlog
        {
            get
            {
                return this.nlogField;
            }
            set
            {
                this.nlogField = value;
            }
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class ConfigMetrichandler
    {

        private bool influxdbField;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public bool influxdb
        {
            get
            {
                return this.influxdbField;
            }
            set
            {
                this.influxdbField = value;
            }
        }
    }



}
