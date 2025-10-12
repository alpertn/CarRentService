using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Security.Policy;

namespace CarRentService.Services
{
    public class kullanicisozlesmesi
    {
        public static void kullanicisoz()
        {
            string url = "https://www.serbest.av.tr/?p=yararlibilgiler&id=205"; // Alakam yoktur internette gordum koydum.
            ProcessStartInfo info = new ProcessStartInfo()
            {
                FileName = url,
                UseShellExecute = false,
            };
            Process.Start(info);
        }
    }
}
