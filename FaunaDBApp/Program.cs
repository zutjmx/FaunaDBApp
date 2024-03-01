using Fauna;
using FaunaDBApp.Modelos;
using System;
using System.Globalization;
using static Fauna.Query;

namespace FaunaDBApp
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            var secret = Environment.GetEnvironmentVariable("FAUNA_SECRET");
            if (string.IsNullOrEmpty(secret))
            {
                Console.WriteLine("Fauna secret is not valid");
                return;
            }
            var cfg = new Configuration(secret);
            var client = new Client(cfg);

            //var createCollection = FQL($@"Collection.create({{ ""name"": ""personas"" }})");


            //var addToCollection = FQL($@"personas.create({{""name"": ""Jesús Zúñiga Trejo""}})");
            //var addToCollection = FQL($@"personas.create(
            //    {{
            //        ""id"": ""1"",
            //        ""nombre"": ""Jesús"",
            //        ""paterno"": ""Zúñiga"",
            //        ""materno"": ""Trejo""
            //    }}
            //)");

            //var personaChuy = new Persona 
            //{
            //    Id = "1",
            //    Nombre = "Jesús",
            //    Paterno = "Zúñiga",
            //    Materno = "Trejo",
            //    Edad = 54
            //};
            //var creaPersonaChuy = FQL($@"personas.create({personaChuy})");

            //var personaAna = new Persona
            //{
            //    Id = "2",
            //    Nombre = "Ana María",
            //    Paterno = "Alejandre",
            //    Materno = "Arroyo",
            //    Edad = 51
            //};
            //var creaPersonaAna = FQL($@"personas.create({personaAna})");

            var productoQuery = FQL($@"products.all()");

            try
            {
                //var result = await client.QueryAsync(createCollection);
                //Console.WriteLine($"Collection created: {result.Data}");

                //var addDocument = await client.QueryAsync(addToCollection);
                //Console.WriteLine($"Document added: {addDocument.Data}");

                //var addDocument = await client.QueryAsync(creaPersonaChuy);
                //Console.WriteLine($"Document added: {addDocument.Data}");

                //var addDocument = await client.QueryAsync(creaPersonaAna);
                //Console.WriteLine($"Document added: {addDocument.Data}");

                var productos = client.PaginateAsync<Producto>(productoQuery).FlattenAsync();

                await foreach (var producto in productos)
                {
                    Console.WriteLine(@$"Producto: {producto.Name} , Precio: {producto.Price.ToString("00.00", CultureInfo.InvariantCulture)}");
                }

            }
            catch (Exception e)
            {
                Console.WriteLine($"Error creating collection: {e.Message}");
            }
        }
    }
}
