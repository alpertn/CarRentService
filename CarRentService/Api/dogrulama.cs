using System;
using System.Net.Http;
using System.Text;

namespace CarRentService.Api
{
    public class dogrulama
    {
        public static string TcDogrulama(string tckimlik, string name, string surname, string dogumyili)
        {

            // csharpda nvi api'yi hazır almadım. githubda csharp dilinde nvi api tek bende var. nvi kendi sitesinde gönderecegimiz xml istegini gosterıyor.
            
            string ad = name.ToUpper(); // ToUpper yazmazsam api sonucu hata veriyor.
            string soyad = surname.ToUpper();

            
            string soapRequest = $@"<?xml version=""1.0"" encoding=""utf-8""?>
    <soap:Envelope xmlns:xsi=""http://www.w3.org/2001/XMLSchema-instance"" xmlns:xsd=""http://www.w3.org/2001/XMLSchema"" xmlns:soap=""http://schemas.xmlsoap.org/soap/envelope/"">
      <soap:Body>
        <TCKimlikNoDogrula xmlns=""http://tckimlik.nvi.gov.tr/WS"">
          <TCKimlikNo>{tckimlik}</TCKimlikNo>
          <Ad>{ad}</Ad>
          <Soyad>{soyad}</Soyad>
          <DogumYili>{dogumyili}</DogumYili>
        </TCKimlikNoDogrula>
      </soap:Body>
    </soap:Envelope>";

            var httpclient = new HttpClient();
            var requestcontent = new StringContent(soapRequest, Encoding.UTF8, "text/xml"); // xml olarak gonderdıgımız ıcın text/xml yazıyoruz.

            try
            {
                
                var request = httpclient.PostAsync("https://tckimlik.nvi.gov.tr/service/kpspublic.asmx", requestcontent).Result; // nvi nufus mudurlugunun apisi. tc ad soyad ve dogumyıl gönderip dogrumu degılmı kontrol edıyoruz
                if (request.IsSuccessStatusCode) // eger istek basarili olursa calisiyor.
                {
                    string response = request.Content.ReadAsStringAsync().Result; // aldıgımız veride eger <TCKimlikNoDogrulaResult>true</TCKimlikNoDogrulaResult> varsa dogru kabul edıyoruz ve return true ile dogru donduruyoz
                    if (response.Contains("<TCKimlikNoDogrulaResult>true</TCKimlikNoDogrulaResult>")) 
                    {
                        return "true"; 
                    }
                    else
                    {
                        return "false"; 
                    }
                }
                else
                {
                    return "false";
                }
            }
            catch
            {
                
                return "false";
            }
        }
    }
}
