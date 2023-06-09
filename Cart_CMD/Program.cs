using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace Cart_CMD
{
    class Program
    {
        static void Main(string[] args) 
        {
            RunAsync().Wait();
            Console.ReadKey();
        }

        public static async Task RunAsync()
        {
            Console.WriteLine("\r\nCart \r\n");
            Console.WriteLine("Press \r\n");
            Console.WriteLine("1 - Add product");
            Console.WriteLine("2 - Show all products");
            Console.WriteLine("3 - Search by IDProduct");
            Console.WriteLine("4 - Update product");
            Console.WriteLine("5 - Delete Product");
            Console.WriteLine("6 - Leave \r\n");

            int input = 0;

            input = Convert.ToInt16(Console.ReadLine());

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:44311/Product");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                var NameVar = ""; var PriceVar = 0; var SaledVar = false;
                var AuxPost = new Post() { ProductName = NameVar, Price = PriceVar, Saled = SaledVar };

                switch (input)
                {
                    #region Case1
                    case 1:
                        var requestResultURL = new RestClient(client.BaseAddress + $"/AddProduct");

                        if (requestResultURL.BaseUrl.IsAbsoluteUri == true)
                        {
                            Console.WriteLine("\r\nProduct Name: ");
                            AuxPost.ProductName = Console.ReadLine();

                            Console.WriteLine("\r\nPrice: ");
                            AuxPost.Price = Convert.ToDouble(Console.ReadLine());

                            Console.WriteLine("\r\nStatus: ");
                            AuxPost.Saled = Convert.ToBoolean(Console.ReadLine());

                            var AddProduct = new Product() { ProductName = AuxPost.ProductName, Price = AuxPost.Price, Saled = AuxPost.Saled };

                            HttpResponseMessage response = await client.PostAsJsonAsync("Product/AddProduct", AddProduct);
                            response = await client.PostAsJsonAsync("Product", AddProduct);

                            Console.WriteLine("\r\nAdded product" +
                                "\r\nProduct Name: " + AuxPost.ProductName +
                                "\r\nPrice: " + AuxPost.Price +
                                "\r\nStatus: " + AuxPost.Saled
                                );
                        }
                        else
                        {
                            Console.WriteLine("Error");
                        }
                        RunAsync();
                        break;
                    #endregion

                    #region Case2
                    case 2:
                        var requestWebURL = WebRequest.CreateHttp("https://localhost:44311/Product/ShowAllProducts");
                        requestWebURL.Method = "GET";

                        if (requestWebURL.Address.IsAbsoluteUri == true)
                        {
                            using (var resposta = requestWebURL.GetResponse())
                            {
                                var streamDados = resposta.GetResponseStream();
                                StreamReader reader = new StreamReader(streamDados);
                                object objResponse = reader.ReadToEnd();
                                var json = objResponse;
                                var JsonResult = JsonConvert.DeserializeObject((string)json);
                                Console.WriteLine(JsonResult);
                            }
                        }
                        else
                        {
                            Console.WriteLine("Error");
                        }
                        RunAsync();
                        break;
                    #endregion

                    #region Case3
                    case 3:
                        Console.WriteLine("IDProduct");
                        var Id = Console.ReadLine();

                        requestWebURL = WebRequest.CreateHttp($"https://localhost:44311/Product/SearchProductById/" + Id);
                        requestWebURL.Method = "GET";

                        if (requestWebURL.Address.IsAbsoluteUri == true)
                        {
                            using (var resposta = requestWebURL.GetResponse())
                            {
                                var streamDados = resposta.GetResponseStream();
                                StreamReader reader = new StreamReader(streamDados);
                                object objResponse = reader.ReadToEnd();
                                var json = objResponse;
                                var JsonResult = JsonConvert.DeserializeObject((string)json);
                                Console.WriteLine(JsonResult);
                            }
                        }
                        else
                        {
                            Console.WriteLine("Error");
                        }
                        RunAsync();
                        break;
                    #endregion

                    #region Case4
                    case 4:
                        Console.WriteLine("IDProduct");
                        Id = Console.ReadLine();

                        requestResultURL = new RestClient(client.BaseAddress + $"Product/UpdateProduct/" + Id);

                        if (requestResultURL.BaseUrl.IsAbsoluteUri == true)
                        {
                            Console.WriteLine("\r\nProduct Name: ");
                            AuxPost.ProductName = Console.ReadLine();

                            Console.WriteLine("\r\nPrice: ");
                            AuxPost.Price = Convert.ToDouble(Console.ReadLine());

                            Console.WriteLine("\r\nStatus: ");
                            AuxPost.Saled = Convert.ToBoolean(Console.ReadLine());

                            var UpdateProduct = new Product() { ProductName = AuxPost.ProductName, Price = AuxPost.Price, Saled = AuxPost.Saled };

                            HttpResponseMessage response = await client.PostAsJsonAsync("Product/UpdateProduct/" + Id, UpdateProduct);
                            response = await client.PostAsJsonAsync("Product/UpdateProduct/" + Id, UpdateProduct);

                            Console.WriteLine("\r\nUpdate product" +
                                "\r\nProduct Name: " + AuxPost.ProductName +
                                "\r\nPrice: " + AuxPost.Price +
                                "\r\nStatus: " + AuxPost.Saled
                                );
                        }
                        else
                        {
                            Console.WriteLine("Error");
                            Console.ReadKey();
                        }
                        RunAsync();
                        break;
                    #endregion

                    #region Case5
                    case 5:
                        Console.WriteLine("IDProduct");
                        Id = Console.ReadLine();

                        requestResultURL = new RestClient(client.BaseAddress + $"Product/DeleteProduct/" + Id);
                        //request = new RestRequest(Method.GET);

                        HttpResponseMessage response2 = await client.DeleteAsync($"Product/UpdateProduct/" + Id);
                        response2 = await client.DeleteAsync("Product/DeleteProduct/" + Id);
                        Console.WriteLine("Deleted product");
                        RunAsync();
                        break;
                    #endregion

                    #region Case6
                    case 6:
                        Console.WriteLine("Sair");
                        Console.ReadKey();
                        break;
                    #endregion
                    default:
                        Console.WriteLine("Opção invalida");
                        RunAsync();
                        break;
                }
            }
        }
    }
}
