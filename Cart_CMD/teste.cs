using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cart_CMD
{
    //class Program
    {
        static void Main(string[] args)
        {
            RunAsync().Wait();
            Console.ReadKey();
        }

        static async Task RunAsync()
        {
            Console.WriteLine("Cart \r\n");
            Console.WriteLine("Press \r\n");
            Console.WriteLine("1 - Add product");
            Console.WriteLine("2 - Show all products");
            Console.WriteLine("3 - Search by IDProduct");
            Console.WriteLine("4 - Update product");
            Console.WriteLine("5 - Delete Product");
            Console.WriteLine("6 - Leave \r\n");

            var input = Console.ReadLine();

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:44311/Product");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                switch (input)
                {
                    case "1":
                        var requestResultURL = new RestClient(client.BaseAddress + $"/AddProduct");
                        var request = new RestRequest(Method.GET);

                        if (requestResultURL.BaseUrl.IsAbsoluteUri == true)
                        {
                            Console.WriteLine("\r\nProduct Name: ");
                            var productName = Console.ReadLine();

                            Console.WriteLine("\r\nPrice: ");
                            var price = Convert.ToInt32(Console.ReadLine());

                            Console.WriteLine("\r\nStock: ");
                            int stock = Convert.ToInt32(Console.ReadLine());

                            Console.WriteLine("\r\nStatus: ");
                            var status = Console.ReadLine();

                            var product = new Product() { ProductName = productName, Price = price, Stock = stock, Status = status };

                            HttpResponseMessage response = await client.PostAsJsonAsync("Product/AddProduct", product);
                            response = await client.PostAsJsonAsync("Product", product);

                            Console.WriteLine("\r\nAdded product" +
                                "\r\nProduct Name: " + productName +
                                "\r\nPrice: " + price +
                                "\r\nStock: " + stock +
                                "\r\nStatus: " + status
                                );
                            Console.ReadKey();
                        }
                        else
                        {
                            Console.WriteLine("Error");
                            Console.ReadKey();
                        }
                        break;

                    case "2":
                        var requestURL = WebRequest.CreateHttp("https://localhost:44311/Product/ShowAllProducts");
                        requestURL.Method = "GET";

                        if (requestURL.Address.IsAbsoluteUri == true)
                        {
                            using (var resposta = requestURL.GetResponse())
                            {
                                var streamDados = resposta.GetResponseStream();
                                StreamReader reader = new StreamReader(streamDados);
                                object objResponse = reader.ReadToEnd();
                                Console.WriteLine(objResponse.ToString());
                                Console.ReadLine();
                                streamDados.Close();
                                resposta.Close();
                            }
                        }
                        else
                        {
                            Console.WriteLine("Error");
                            Console.ReadKey();
                        }
                        break;

                    case "3":
                        Console.WriteLine("IDProduct");
                        var Id = Console.ReadLine();

                        requestURL = WebRequest.CreateHttp($"https://localhost:44311/Product/SearchProductById/" + Id);
                        requestURL.Method = "GET";

                        if (requestURL.Address.IsAbsoluteUri == true)
                        {
                            using (var resposta = requestURL.GetResponse())
                            {
                                var streamDados = resposta.GetResponseStream();
                                StreamReader reader = new StreamReader(streamDados);
                                object objResponse = reader.ReadToEnd();
                                Console.WriteLine(objResponse.ToString());
                                Console.ReadLine();
                                streamDados.Close();
                                resposta.Close();
                            }
                        }
                        else
                        {
                            Console.WriteLine("Error");
                            Console.ReadKey();
                        }
                        break;

                    case "4":
                        //Console.WriteLine("IDProduct");
                        //Id = Console.ReadLine();

                        //requestResultURL = new RestClient(client.BaseAddress + $"Product/UpdateProduct/5");
                        //request = new RestRequest(Method.PUT);

                        //if (requestResultURL.BaseUrl.IsAbsoluteUri == true)
                        //{
                        Console.WriteLine("\r\nProduct Name: ");
                        var Name = Console.ReadLine();

                        Console.WriteLine("\r\nPrice: ");
                        var price1 = Convert.ToInt32(Console.ReadLine());

                        Console.WriteLine("\r\nStock: ");
                        int stock1 = Convert.ToInt32(Console.ReadLine());

                        Console.WriteLine("\r\nStatus: ");
                        var status1 = Console.ReadLine();

                        //var product1 = new Product() { ProductName = Name, Price = price1, Stock = stock1, Status = status1 };


                        //requestURL = WebRequest.CreateHttp($"https://localhost:44311/Product/UpdateProduct/5");
                        //requestURL.Method = "GET";

                        HttpResponseMessage response1 = await client.PutAsync($"https://localhost:44311/Product/UpdateProduct/", 5);
                        //    response1 = await client.PutAsJsonAsync($"Product/UpdateProduct/5", product1);


                        Uri chaUrl = response1.Headers.Location;
                        var product1 = new Product() { ProductName = Name, Price = price1, Stock = stock1, Status = status1 }; // atualiza o preco do produto
                        response1 = await client.PutAsJsonAsync(chaUrl, product1);
                        Console.WriteLine("Produto preço do atualizado. Tecle algo para excluir o produto");
                        Console.ReadKey();


                        Console.WriteLine("\r\nAdded product" +
                            "\r\nProduct Name: " + Name +
                            "\r\nPrice: " + price1 +
                            "\r\nStock: " + stock1 +
                            "\r\nStatus: " + status1
                            );
                        Console.ReadKey();
                        //}


                        break;

                    //case "5":
                    //    Console.WriteLine("1 OK");
                    //    break;

                    //case "6":
                    //    Console.WriteLine("2 OK");
                    //    break;

                    default:
                        Console.WriteLine("Opção invalida");
                        break;
                }
            }

            //GET
            //Product product = await response.Content.ReadFromJsonAsync<Product>();
            //Console.WriteLine("{0}\tR${1}\t{2}", product.ProductName, product.Price, product.Stock);
            //Console.WriteLine("Produto acessado e exibido.  Tecle algo para incluir um novo produto.");
            //Console.ReadKey();

            //if (response.IsSuccessStatusCode)
            //{   //PUT
            //    Uri chaUrl = response.Headers.Location;
            //    cha.Preco = 2.55M;   // atualiza o preco do produto
            //    response = await client.PutAsJsonAsync(chaUrl, cha);
            //    Console.WriteLine("Produto preço do atualizado. Tecle algo para excluir o produto");
            //    Console.ReadKey();
            //    //DELETE
            //    response = await client.DeleteAsync(chaUrl);
            //    Console.WriteLine("Produto deletado");
            //    Console.ReadKey();
            //}
        }
    }
}
