using Newtonsoft.Json;
using System.Net.Http;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace vatACARS
{
    internal class Updater
    {
        private HttpClient hc;

        public async Task CheckForUpdatesAsync()
        {
            using(hc = new HttpClient())
            {
                object releaseData;

                var resp = await hc.GetAsync("https://api.github.com/repos/PlutonusDev/VatACARS/releases/latest");
                if (resp != null)
                {
                    releaseData = JsonConvert.DeserializeObject(await resp.Content.ReadAsStringAsync());
                } else
                {
                    releaseData = JsonConvert.DeserializeObject("{failed:true}");
                }

                MessageBox.Show(releaseData.ToString());
            }
        }
    }
}
