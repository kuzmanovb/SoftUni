using System.Linq;
using System.Reflection;

using ValidationAttributes.Models;

namespace ValidationAttributes.Utilities
{
    public static class Validator
    {

        public static bool IsValid(object obj)
        {

            if (obj == null)
            {
                return false;
            }

            var properties = obj.GetType().GetProperties();

            foreach (var property in properties)
            {
                var attributes = property.GetCustomAttributes()
                    .Where(at => at is MyValidationAttribute)
                    .Cast<MyValidationAttribute>()
                    .ToArray();

                foreach (var attribute in attributes)
                {

                    if (!attribute.IsValid(property.GetValue(obj)))
                    {
                        return false;
                    }

                }

            }
            return true;
        }
    }
}
