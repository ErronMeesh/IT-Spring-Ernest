using System;
using ClassLibrary6ITT;

namespace ClassLibrary6ITT{
    public class CustomStudent1 : Student
    {
        public string AdditionalProperty { get; set; }

        public override void AttendClass()
        {
            Console.WriteLine("Attending custom classes for CustomStudent1.");
        }

        public override void Study()
        {
            Console.WriteLine("Studying custom course for CustomStudent1.");
        }

        public void CustomMethod1(string parameter)
        {
            Console.WriteLine("Executing custom method CustomMethod1 with parameter: " + parameter);
        }

        public void CustomMethod2()
        {
            Console.WriteLine("Executing custom method CustomMethod2");
        }
    }

    public class CustomStudent2 : Student
    {
        public string AnotherAdditionalProperty { get; set; }

        public override void AttendClass()
        {
            Console.WriteLine("Attending custom classes for CustomStudent2.");
        }

        public override void Study()
        {
            Console.WriteLine("Studying custom course for CustomStudent2.");
        }

        public void CustomMethod3(int parameter)
        {
            Console.WriteLine("Executing custom method CustomMethod3 with parameter: " + parameter);
        }

        public void CustomMethod4(bool flag)
        {
            Console.WriteLine("Executing custom method CustomMethod4 with flag: " + flag);
        }
    }
}
