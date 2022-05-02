using Microsoft.Extensions.Localization;
using System.Reflection;

namespace NutritionistPreview.Api.Core.Resources
{
    public class Resource
    {
        private readonly IStringLocalizer localizer;
        private readonly Assembly assembly;

        public Resource(IStringLocalizerFactory factory)
        {
            var type = typeof(Resource);
            var assemblyName = new AssemblyName(type.GetTypeInfo().Assembly.FullName);
            localizer = factory.Create("Resource", assemblyName.Name);
            assembly = type.GetTypeInfo().Assembly;
        }

        public string GetMessage(string resource, params string[] parameters)
        {
            if ((parameters?.Length ?? 0) > 0)
            {
                return string.Format(localizer[resource].Value, parameters);
            }

            return localizer[resource].Value;
        }

        public const string CLIENT_INVALID = "ClientInvalid";
        public const string FIELD_NOT_FOUND = "FieldNotFound";
    }
}
