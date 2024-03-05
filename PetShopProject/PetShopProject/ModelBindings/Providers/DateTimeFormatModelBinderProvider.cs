using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace PetShopProject.ModelBindings.Providers
{
    public class DateTimeFormatModelBinderProvider : IModelBinderProvider
    {
        public IModelBinder? GetBinder(ModelBinderProviderContext context)
        {
            if (context == null)
            {
                throw new ArgumentNullException(nameof(context));
            }

            if (context.Metadata.ModelType == typeof(DateTime)
                || context.Metadata.ModelType == typeof(DateTime?))
            {
                return new DateTimeFormatModelBinding();
            }

            return null;
        }
    }
}
