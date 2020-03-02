using System;
using System.Net.Http;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Cw1
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            //Console.WriteLine("Hello World!");
            //int? tmp1 = 1; //zmienna może być null, przy skorzystaniu z pytajnika
            //double tmp2 = 2.0;

            //string tmp3 = "Ala ma kota";
            //string tmp6 = "i psa";
            //bool tmp4 = true;

            //// CTRL + k + c komentarz
            //// CTRL + k + u zdjęcie komentarza

            //var tmp5 = 1; // nie moze byc: var tmp5; lub var tmp5 = null;
            //var tmp7 = 2;

            //var path = @"Z:\APBD\Cw1"; // mozna laczy $ z @ $@

            //var newPerson = new Person { FirstName = "Daniel" };

            //Console.WriteLine($"{tmp3} {tmp6} {tmp5+tmp7}");

            var url = args.Length > 0 ? args[0] : "https://www.pja.edu.pl";

            var httpClient = new HttpClient();

            var response = await httpClient.GetAsync(url);

            if (response.IsSuccessStatusCode)
            {
                var htmlContent = await response.Content.ReadAsStringAsync();

                var regex = new Regex("[a-z]+[a-z0-9]*@[a-z0-9]+\\.[a-z]+", RegexOptions.IgnoreCase);

                var matches = regex.Matches(htmlContent);

                foreach (var match in matches)
                {
                    Console.WriteLine(match.ToString());
                }
            }
        }
    }
}
