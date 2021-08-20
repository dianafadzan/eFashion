using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Text;
using Newtonsoft.Json;
using System.Net.Http;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Net;

namespace eFashion
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        private static HttpClient _client = new HttpClient();
        public MainWindow()
        {
            _client.BaseAddress = new Uri("http://localhost:9000/");
            InitializeComponent();
        }

        public static async Task<TResult> PostObjectToWebsiteAsync<TResult>(
    Uri site, object objToPost)
        {
            using (var req = new HttpRequestMessage(HttpMethod.Post, site))
            {
                req.Content = new StringContent(JsonConvert.SerializeObject(objToPost),
                    Encoding.UTF8, "application/json");
                using (var resp = await _client.SendAsync(req))
                {
                    resp.EnsureSuccessStatusCode();

                    using (var s = await resp.Content.ReadAsStreamAsync())
                    using (var sr = new StreamReader(s))
                    using (var jtr = new JsonTextReader(sr))
                    {
                        return new JsonSerializer().Deserialize<TResult>(jtr);
                    }
                }
            }
        }




        private void putMethod(string address,byte[] data)
        {
            using (var client = new System.Net.WebClient())
            {
                client.UploadData(address, "PUT", data);
            }
        }


        private async Task onBtnAsync()
        {

            var objToPost = new 
            {
                postanskibroj = 5421,
                naziv = "NY"
            };

            var postResonse = await PostObjectToWebsiteAsync<object>(
             new Uri("http://localhost:9000/mjesta"), objToPost);


            /*Mjesto mjesto = new Mjesto(4500, "Prnjavor");
            Console.WriteLine(mjesto.Naziv);

            var values = new Mjesto(8956, "NS");
            HttpClient client = new HttpClient();
            //client.BaseAddress = new Uri("http://localhost:9000/");
            string json = JsonConvert.SerializeObject(values);
            var httpContent = new StringContent(json, Encoding.UTF8, "application/json");
            var Httpresponse =await client.PostAsync("http://localhost:9000/mjesta", httpContent);
            /*HttpClient client = new HttpClient();*/

            /* int pb = 78000;
             HttpResponseMessage response = client.GetAsync("mjesta/").Result;
             if (response.IsSuccessStatusCode)
             {
                 string result = response.Content.ReadAsStringAsync().Result;
                 Console.WriteLine(result);


             }*/



        }

        private void getMethod(Uri site)
        {
            
            HttpResponseMessage response = _client.GetAsync("mjesta").Result;
            if (response.IsSuccessStatusCode)
            {
                string result = response.Content.ReadAsStringAsync().Result;
                Console.WriteLine(result);
                var model = JsonConvert.DeserializeObject<List<Mjesto>>(result);
                foreach(var m in model){
                    tb.Text +=m.Naziv+" " ;

                }


            }
            

        }

        public static byte[] ObjectToByteArray(Object obj)
        {
            BinaryFormatter bf = new BinaryFormatter();
            using (var ms = new MemoryStream())
            {
                bf.Serialize(ms, obj);
                return ms.ToArray();
            }
        }

        public void PutObject(string postUrl, object payload)
        {
            var values = new
            {
                postanskibroj = 1234,
                naziv = "PG"
            };
            string json = JsonConvert.SerializeObject(values);
            Console.WriteLine(json);
            var httpContent = new StringContent(json, Encoding.UTF8, "application/json");
            var response = _client.PutAsync(postUrl, httpContent).Result;
            if (response.IsSuccessStatusCode)
            {
                Console.Write("Success");
            }
            else
                Console.Write("Error");
        }

       
        private void onBtnButton(object sender, RoutedEventArgs e)
        {
            getMethod(new Uri("http://localhost:9000/"));
            var objToPost = new
            {
                postanskibroj = 1234,
                naziv = "BEO"
            };
           
            PutObject("mjesta/1234",objToPost);
            onBtnAsync();
            getMethod(new Uri("http://localhost:9000/"));
        }
    }
}
