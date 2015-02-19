namespace Tessup
{
    public class Metric
    {
        public string TargetName { get; set; }
        public string ObjectName { get; set; }
        public string ValueName { get; set; }
        public object Values { get; set; }
        public Metric(string targetName, string objectName, string pointNames, object values)
        {
            TargetName = targetName;
            ObjectName = objectName.ToLower();
            ValueName = pointNames.ToLower();
            Values = values.ToString().ToLower();
        }
    }
}