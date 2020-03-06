using System;
using System.Collections.Generic;
using System.Text;

namespace Person
{
    public class People
    {
        private string name;
        private int age;
        public People(string name, int age)
        {
            this.Name = name;
            this.Age = age;
        }

        public string Name {
            get
            {
                return name;
            }
            private set 
            {
                name = value;
            }
        }
        public int Age {
            get
            {
                return this.age;
            }
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Invalid input");
                }
                age = value;
            }
        }

        public override string ToString()
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append(String.Format("Name: {0}, Age: {1}",
                                 this.Name,
                                 this.Age));

            return stringBuilder.ToString();

        }

    }
}
