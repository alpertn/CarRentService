using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using System.Net.Http;

namespace CarRentService.Api
{
    public class akaryakit
    {
        
        // apiyi https://www.opet.com.tr/akaryakit-fiyatlari üzerinden buldum. sayfaya gelip  incele -> network  yerine geldim. preserve log'u actım.
        // il yerinden izmiri seçtim. isteği gönderdim ve Fetch / XHR secenegini secip gönderdigim requestlere baktım. Payload yerine geldigimdee
        // "ProvinceCode: 35" diye bir payload gönderdigimi gördüm. sağ tıklayıp "open in new tab" secenegini sectim.
        // linke tıkladıgımda veriyi JSON formatında aldıgımı fark ettim. 2-3 kaynaktan yararlanarak da json veriden istediklerimi cektim.
        public static void opetyakit()
        {
            string url = "https://api.opet.com.tr/api/fuelprices/prices?ProvinceCode=35&IncludeAllProducts=true"; // ProvinceCode il kodunu gösteriyor. 
            using (var client = new HttpClient())
            {
                try
                {
                    HttpResponseMessage response = client.GetAsync(url).Result; 

                    string newresponse = response.Content.ReadAsStringAsync().Result; 

                    JObject responsejson = JObject.Parse(newresponse); 

                    string districtName = "BAYRAKLI";

                    var fuelprices = responsejson[districtName];
                }
                catch (Exception ex) { 
                    Console.WriteLine(ex.Message);
                }
            }
        }
    }
}
