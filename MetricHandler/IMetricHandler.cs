using System.Collections.Generic;
using System.Threading.Tasks;

namespace Tessup
{
    interface IMetricHandler
    {
        Task<string> WriteMetric(List<Metric> metricList);
    }
}
