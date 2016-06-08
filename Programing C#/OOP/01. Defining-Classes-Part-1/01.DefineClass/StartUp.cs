namespace MobileDevice
{
    using System;

    public class StartUp
    {
        public static void Main()
        {
            var tests = new GsmTests();
            tests.DisplayGsmInformation();

            var call = new Call(new DateTime(2015, 09, 15, 12, 54, 6), "0456-345-33", 390);
            Console.WriteLine(call.ToString());

            var callTest = new GsmCallHistoryTest();
            callTest.Functionality();
        }
    }
}
