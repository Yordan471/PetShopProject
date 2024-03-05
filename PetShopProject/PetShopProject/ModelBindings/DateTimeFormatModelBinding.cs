using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.Globalization;
using System.Reflection.Metadata.Ecma335;

namespace PetShopProject.ModelBindings
{
    public class DateTimeFormatModelBinding : IModelBinder
    {
        public Task BindModelAsync(ModelBindingContext bindingContext)
        {
            if (bindingContext == null)
            {
                throw new ArgumentNullException(nameof(bindingContext));
            }

            ValueProviderResult valueResult = bindingContext.ValueProvider
               .GetValue(bindingContext.ModelName);

            if (valueResult != ValueProviderResult.None && !string.IsNullOrEmpty(valueResult.FirstValue))
            {
                // Define the expected DateTime format
                string expectedFormat = "yyyy-MM-dd HH:mm:ss";
                bool success = false;
                DateTime parsedValue = DateTime.UtcNow;

                try
                {
                    // Get the raw value from the value provider
                    string rawValue = valueResult.FirstValue.Trim();
                    
                    // Parse the raw value to DateTime using the specified format
                    if (DateTime.TryParseExact(rawValue,
                        expectedFormat,
                        CultureInfo.InvariantCulture,
                        DateTimeStyles.None,
                        out parsedValue))
                    {
                        success = true;
                    }
                }
                catch (FormatException fe)
                {
                    bindingContext.ModelState.AddModelError(bindingContext.ModelName, fe, bindingContext.ModelMetadata);
                }

                if (success)
                {
                    bindingContext.Result = ModelBindingResult.Success(parsedValue);
                }
            }

            // If parsing fails, use the default model binder behavior
            return Task.CompletedTask;
        }
    }
}
