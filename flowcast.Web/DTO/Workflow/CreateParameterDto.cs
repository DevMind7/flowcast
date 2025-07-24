namespace flowcast.ApiService.DTO.Workflow
{
    public class CreateParameterDto
    {
        public string Name { get; set; } = default!;
        public string DisplayName { get; set; } = default!;
        public ParameterType Type { get; set; }
    }

    public enum ParameterType
    {
        String,
        Int,
        Date,
        Bool,
        Enum
    }
}
