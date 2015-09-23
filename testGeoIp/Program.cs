using System;
using System.IO;

namespace testGeoIp
{
    class Program
    {
        static void Main(string[] args)
        {
            var path = Directory.GetCurrentDirectory();
            string GeoipDb = path + @"\db\GeoIP.dat";
            //open the database
            LookupService ls = new LookupService(GeoipDb, LookupService.GEOIP_MEMORY_CACHE);
            //get country of the ip address
            Country c = ls.getCountry("24.24.24.24");
            Console.Write(" code: " + c.getCode() + "\n");
            Console.Write(" name: " + c.getName() + "\n");

            GeoipDb = path + @"\db\GeoLiteCity.dat";
            ls = new LookupService(GeoipDb, LookupService.GEOIP_STANDARD);
            Location l = ls.getLocation("24.24.24.24");
            if (l != null)
            {
                Console.Write("country code " + l.countryCode + "\n");
                Console.Write("country name " + l.countryName + "\n");
                Console.Write("region " + l.region + "\n");
                Console.Write("city " + l.city + "\n");
                Console.Write("postal code " + l.postalCode + "\n");
                Console.Write("latitude " + l.latitude + "\n");
                Console.Write("longitude " + l.longitude + "\n");
                Console.Write("metro code " + l.metro_code + "\n");
                Console.Write("area code " + l.area_code + "\n");
                Console.Write("region name " + l.regionName + "\n");
            }
            else
            {
                Console.Write("IP Address Not Found\n");
            }

            Console.WriteLine();
        }
    }
}
