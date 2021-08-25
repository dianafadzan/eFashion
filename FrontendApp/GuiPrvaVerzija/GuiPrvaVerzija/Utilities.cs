using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using Newtonsoft.Json;


namespace GuiPrvaVerzija
{
    class Utilities
    {
        public static HttpClient client = new HttpClient();

        public static async Task RunAsync()
        {
            // Update port # in the following line.
            //client.BaseAddress = new Uri("localhost:9000/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));
            
            
        }

        

        public static async Task<radnik> GetRadnikAsync(string path)
        {
            radnik product = null;
            try
            {  
                HttpResponseMessage response = await client.GetAsync(path);
                if (response.IsSuccessStatusCode)
                {     
                    product = JsonConvert.DeserializeObject<radnik>(await response.Content.ReadAsStringAsync());
                }             
                return product;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return product;
            }  
        }

        public static async Task<List<radnik>> GetRadniciAsync(string path)
        {
            List<radnik> product = null;
            try
            {
                HttpResponseMessage response = await client.GetAsync(path);
                if (response.IsSuccessStatusCode)
                {
                    product = JsonConvert.DeserializeObject<List<radnik>>(await response.Content.ReadAsStringAsync());
                }
                return product;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return product;
            }
        }


        public static async Task<racun> GetRacunAsync(string path)
        {
            racun product = null;
            try
            {
                HttpResponseMessage response = await client.GetAsync(path);
                if (response.IsSuccessStatusCode)
                {
                    product = JsonConvert.DeserializeObject<racun>(await response.Content.ReadAsStringAsync());
                }
                return product;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return product;
            }
        }

        public static async Task<List<racun>> GetRacuniAsync(string path)
        {
            List<racun> product = null;
            try
            {
                HttpResponseMessage response = await client.GetAsync(path);
                if (response.IsSuccessStatusCode)
                {
                    product = JsonConvert.DeserializeObject<List<racun>>(await response.Content.ReadAsStringAsync());
                }
                Console.WriteLine(product[0]);
                return product;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return product;
            }
        }

        public static async Task<stavka> GetStavkaAsync(string path)
        {
            stavka product = null;
            try
            {
                HttpResponseMessage response = await client.GetAsync(path);
                if (response.IsSuccessStatusCode)
                {
                    product = JsonConvert.DeserializeObject<stavka>(await response.Content.ReadAsStringAsync());
                }
                return product;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return product;
            }
        }

        public static async Task<List<stavka>> GetStavkeAsync(string path)
        {
            List<stavka> product = null;
            try
            {
                
                HttpResponseMessage response = await client.GetAsync(path);
                if (response.IsSuccessStatusCode)
                {
                    product = JsonConvert.DeserializeObject<List<stavka>>(await response.Content.ReadAsStringAsync());
                }
                
                return product;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return product;
            }
        }


        public static async Task<artikal> GetArtikalAsync(string path)
        {
            artikal product = null;
            try
            {
                HttpResponseMessage response = await client.GetAsync(path);
                if (response.IsSuccessStatusCode)
                {
                    product = JsonConvert.DeserializeObject<artikal>(await response.Content.ReadAsStringAsync());
                }
                
                return product;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return product;
            }
        }

        public static async Task<List<artikal>> GetArtikliAsync(string path)
        {
            List<artikal> product = null;
            try
            {
                HttpResponseMessage response = await client.GetAsync(path);
                if (response.IsSuccessStatusCode)
                {
                    product = JsonConvert.DeserializeObject<List<artikal>>(await response.Content.ReadAsStringAsync());
                }
                
                return product;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return product;
            }
        }

        public static async Task<List<administrator>> GetAdministratoriAsync(string path)
        {
            List<administrator> product = null;
            try
            {
                HttpResponseMessage response = await client.GetAsync(path);
                if (response.IsSuccessStatusCode)
                {
                    product = JsonConvert.DeserializeObject<List<administrator>>(await response.Content.ReadAsStringAsync());
                }
                
                return product;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return product;
            }
        }

        public static async Task<List<kategorija>> GetKategorijeAsync(string path)
        {
            List<kategorija> product = null;
            try
            {
                
                HttpResponseMessage response = await client.GetAsync(path);
                if (response.IsSuccessStatusCode)
                {
                    product = JsonConvert.DeserializeObject<List<kategorija>>(await response.Content.ReadAsStringAsync());
                }
                
                return product;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return product;
            }
        }

        /*

        public static async void CreateRacuntAsync(kategorija product)
        {
            /*StringContent content = new StringContent(json, Encoding.UTF8, "application/json");
            HttpResponseMessage response = await client.PostAsync(
                "api/products", product);
            response.EnsureSuccessStatusCode();

            // return URI of the created resource.
            return response.Headers.Location; 
            
            try
            {
                Console.WriteLine("create");
                var stringPayload = JsonConvert.SerializeObject(product);
                HttpContent httpContent = new StringContent(stringPayload, Encoding.UTF8, "application/json");
                var httpResponse =  client.PostAsync("http://localhost:9000/kategorije", httpContent).Result.Content.ReadAsStringAsync(); 
               
                
            }catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                
            }
        }


        public static async Task<racun> UpdateProductAsync(racun product)
        {
            HttpResponseMessage response = await client.PutAsJsonAsync(
                $"api/products/{product.Id}", product);
            response.EnsureSuccessStatusCode();

            // Deserialize the updated product from the response body.
            product = await response.Content.ReadAsAsync<racun>();
            return product;
        }

        public static async Task<HttpStatusCode> DeleteProductAsync(string id)
        {
            HttpResponseMessage response = await client.DeleteAsync(
                $"api/products/{id}");
            return response.StatusCode;
        }

        */
    }
}
