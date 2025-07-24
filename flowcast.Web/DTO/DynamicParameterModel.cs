namespace flowcast.Web.DTO
{
    public class DynamicParameterModel
    {
        private Dictionary<string, string> _values = new();

        public string this[string key]
        {
            get => _values.TryGetValue(key, out var val) ? val : "";
            set => _values[key] = value;
        }

        public Dictionary<string, string> ToDictionary() => new(_values);
    }
}
