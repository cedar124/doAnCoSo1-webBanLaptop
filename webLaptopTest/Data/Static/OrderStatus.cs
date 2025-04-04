using System.Collections.Generic;

namespace webLaptopTest.Data.Static
{
    public class OrderStatus
    {
        public const string Processing = "Processing";
        public const string Accepted = "Accepted";
        public const string Refused = "Refused";
        public static List<string> AllStatuses => new() { Processing, Accepted, Refused };
    }
    
}
