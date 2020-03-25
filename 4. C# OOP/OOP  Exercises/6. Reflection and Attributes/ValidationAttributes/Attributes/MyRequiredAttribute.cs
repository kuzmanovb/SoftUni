using ValidationAttributes.Models;

namespace ValidationAttributes.Attributes
{
    public class MyRequiredAttribute : MyValidationAttribute
    {
        public override bool IsValid(object obj)
        {
            if (obj == null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}
