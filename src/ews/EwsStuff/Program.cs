using Microsoft.Exchange.WebServices.Data;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EwsStuff
{
    class Program
    {
        static void Main(string[] args)
        {

            var manifest = File.ReadAllBytes("manifest.xml");

            var stream = new FileStream("manifest.xml", FileMode.Open);

            var mBase64 = Convert.ToBase64String(manifest);


            AddApp(stream);

        }

        static void AddApp(Stream mBase64)
        {
            var ews = new ExchangeService();

            

            ews.Credentials = new WebCredentials("nobody@foo.com", "whatchalookinat");
            //ews.AutodiscoverUrl("scicoria@microsoft.com", RedirectionCallback);

            ews.Url = new Uri (@"https://outlook.office365.com/EWS/Exchange.asmx");

            ews.InstallApp(mBase64);

            //using (var ms = new MemoryStream(Encoding.Default.GetBytes(mBase64)))
            //{
            //    ews.InstallApp(ms);
           // }
         



            //throw new NotImplementedException();
        }

        static bool RedirectionCallback(string url)
        {
            Console.WriteLine(url);
            // Return true if the URL is an HTTPS URL.
            return url.ToLower().StartsWith("https://");
        }
    }
}
