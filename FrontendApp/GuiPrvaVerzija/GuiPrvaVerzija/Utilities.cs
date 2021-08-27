using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
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
                
                 return  product;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return product;
            }
        }

        

        public static async Task<string> CreateKategorijaAsync(kategorija product)
        {
            var response = string.Empty;
            try
            {
                
                Uri u = new Uri("http://localhost:9000/kategorije");
                string strPayload = JsonConvert.SerializeObject(product);
                HttpContent c = new StringContent(strPayload, Encoding.UTF8, "application/json");
                HttpRequestMessage request = new HttpRequestMessage
                {
                    Method = HttpMethod.Post,
                    RequestUri = u,
                    Content = c
                };

                HttpResponseMessage result = await client.SendAsync(request);
                if (result.IsSuccessStatusCode)
                {
                    response = result.StatusCode.ToString();
                }
                
                return response;
                    

            }catch(Exception ex)
            {
                Console.WriteLine(ex.InnerException);
                return response;
            }
        }

        public static async Task<string> CreateRacunAsync(racun product)
        {
            var response = string.Empty;
            try
            {
                
                Uri u = new Uri("http://localhost:9000/racuni");
                string strPayload = JsonConvert.SerializeObject(product);
                HttpContent c = new StringContent(strPayload, Encoding.UTF8, "application/json");
                HttpRequestMessage request = new HttpRequestMessage
                {
                    Method = HttpMethod.Post,
                    RequestUri = u,
                    Content = c
                };

                HttpResponseMessage result = await client.SendAsync(request);
                if (result.IsSuccessStatusCode)
                {
                    response = result.StatusCode.ToString();
                }
                return response;

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.InnerException);
                return response;
            }
        }

        public static async Task<string> CreateArtikalAsync(artikal product)
        {
            var response = string.Empty;
            try
            {
                
                Uri u = new Uri("http://localhost:9000/artikli");
                string strPayload = JsonConvert.SerializeObject(product);
                HttpContent c = new StringContent(strPayload, Encoding.UTF8, "application/json");
                HttpRequestMessage request = new HttpRequestMessage
                {
                    Method = HttpMethod.Post,
                    RequestUri = u,
                    Content = c
                };

                HttpResponseMessage result = await client.SendAsync(request);
                if (result.IsSuccessStatusCode)
                {
                    response = result.StatusCode.ToString();
                }
                return response;

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.InnerException);
                return response;
            }
        }

        public static async Task<string> CreateAdministratorAsync(administrator product)
        {
            var response = string.Empty;
            try
            {
                
                Uri u = new Uri("http://localhost:9000/administratori");
                string strPayload = JsonConvert.SerializeObject(product);
                HttpContent c = new StringContent(strPayload, Encoding.UTF8, "application/json");
                HttpRequestMessage request = new HttpRequestMessage
                {
                    Method = HttpMethod.Post,
                    RequestUri = u,
                    Content = c
                };

                HttpResponseMessage result = await client.SendAsync(request);
                if (result.IsSuccessStatusCode)
                {
                    response = result.StatusCode.ToString();
                }
                return response;

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.InnerException);
                return response;
            }
        }

        public static async Task<string> CreateRadnikAsync(radnik product)
        {
            var response = string.Empty;
            try
            {
                
                Uri u = new Uri("http://localhost:9000/radnici");
                string strPayload = JsonConvert.SerializeObject(product);
                HttpContent c = new StringContent(strPayload, Encoding.UTF8, "application/json");
                HttpRequestMessage request = new HttpRequestMessage
                {
                    Method = HttpMethod.Post,
                    RequestUri = u,
                    Content = c
                };

                HttpResponseMessage result = await client.SendAsync(request);
                if (result.IsSuccessStatusCode)
                {
                    response = result.StatusCode.ToString();
                }
                return response;

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.InnerException);
                return response;
            }
        }

        public static async Task<string> CreateStavkaAsync(stavka product)
        {
            var response = string.Empty;
            try
            {
                
                Uri u = new Uri("http://localhost:9000/stavke");
                string strPayload = JsonConvert.SerializeObject(product);
                HttpContent c = new StringContent(strPayload, Encoding.UTF8, "application/json");
                HttpRequestMessage request = new HttpRequestMessage
                {
                    Method = HttpMethod.Post,
                    RequestUri = u,
                    Content = c
                };

                HttpResponseMessage result = await client.SendAsync(request);
                if (result.IsSuccessStatusCode)
                {
                    response = result.StatusCode.ToString();
                }
                
                return response;

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.InnerException);
                return response;
            }
        }

        public static async Task<string> UpdateArtikalAsync(artikal product)
        {
            var response = string.Empty;
            try
            {
                Uri u = new Uri("http://localhost:9000/artikli/"+product.sifra);
                string str = JsonConvert.SerializeObject(product);               
                HttpContent c = new StringContent(str, Encoding.UTF8, "application/json");              
                HttpRequestMessage request = new HttpRequestMessage
                {
                    Method = HttpMethod.Put,
                    RequestUri = u,
                    Content = c
                };

                HttpResponseMessage result = await client.SendAsync(request);
                if (result.IsSuccessStatusCode)
                {
                    response = result.StatusCode.ToString();
                }              
                return response;

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.InnerException);
                return response;
            }

        }

        public static async Task<string> UpdateRadnikAsync(radnik product)
        {
            var response = string.Empty;
            try
            {
                Uri u = new Uri("http://localhost:9000/radnici/" + product.jmb);
                string str = JsonConvert.SerializeObject(product);
                HttpContent c = new StringContent(str, Encoding.UTF8, "application/json");
                HttpRequestMessage request = new HttpRequestMessage
                {
                    Method = HttpMethod.Put,
                    RequestUri = u,
                    Content = c
                };

                HttpResponseMessage result = await client.SendAsync(request);
                if (result.IsSuccessStatusCode)
                {
                    response = result.StatusCode.ToString();
                }
               
                return response;
                
            }
            catch (Exception ex)
            {
                
                return response;
            }

        }

        public static async Task<string> UpdateRacunAsync(racun product)
        {
            var response = string.Empty;
            try
            {
                Uri u = new Uri("http://localhost:9000/racuni/" + product.idracuna);
                string str = JsonConvert.SerializeObject(product);
                HttpContent c = new StringContent(str, Encoding.UTF8, "application/json");
                HttpRequestMessage request = new HttpRequestMessage
                {
                    Method = HttpMethod.Put,
                    RequestUri = u,
                    Content = c
                };

                HttpResponseMessage result = await client.SendAsync(request);
                if (result.IsSuccessStatusCode)
                {
                    response = result.StatusCode.ToString();
                }
                
                return response;

            }
            catch (Exception ex)
            {
                
                return response;
            }

        }

        public static async Task<string> UpdateStavkaAsync(stavka product)
        {
            var response = string.Empty;
            try
            {
                Uri u = new Uri("http://localhost:9000/stavke/" + product.racunIdracuna+"/"+product.artikalSifra);
                string str = JsonConvert.SerializeObject(product);
                HttpContent c = new StringContent(str, Encoding.UTF8, "application/json");
                HttpRequestMessage request = new HttpRequestMessage
                {
                    Method = HttpMethod.Put,
                    RequestUri = u,
                    Content = c
                };

                HttpResponseMessage result = await client.SendAsync(request);
                if (result.IsSuccessStatusCode)
                {
                    response = result.StatusCode.ToString();
                }
                
                return response;

            }
            catch (Exception ex)
            {
                
                return response;
            }

        }

        
    }
}
