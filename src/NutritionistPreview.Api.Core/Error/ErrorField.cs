using System.Diagnostics.CodeAnalysis;

namespace NutritionistPreview.Api.Core.Error
{
    [ExcludeFromCodeCoverage]
    public class ErrorField
    {
        public ErrorField() : this(string.Empty, new List<string>())
        {
        }

        public ErrorField(string field, ICollection<string> erros)
        {
            FieldName = field;
            FieldErros = erros;
        }

        public string FieldName { get; set; }

        public ICollection<string> FieldErros { get; set; }
    }
}
