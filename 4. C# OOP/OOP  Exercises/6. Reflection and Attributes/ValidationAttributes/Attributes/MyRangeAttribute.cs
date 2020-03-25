using System;
using ValidationAttributes.Models;

namespace ValidationAttributes.Attributes
{
    public class MyRangeAttribute : MyValidationAttribute
    {
        private int minValue;
        private int maxValue;
        public MyRangeAttribute(int minValue, int maxValue)
        {
            this.ValidateValue();

            this.minValue = minValue;
            this.maxValue = maxValue;

        }
        public override bool IsValid(object obj)
        {
            if (obj is Int32)
            {
                var value = (int)obj;
                if (value < minValue || value > maxValue)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
            else
            {
                throw new ArgumentException("Can't validate current data");
            }
        }


        private void ValidateValue()
        {
            if (minValue > maxValue)
            {
                throw new ArgumentException("Invalid range!");
            }

        }
    }
}
