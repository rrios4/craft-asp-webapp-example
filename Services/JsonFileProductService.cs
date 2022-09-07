using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using crafts_webapp.Models;
using Microsoft.AspNetCore.Hosting;

namespace crafts_webapp.Services
{
    public class JsonFileProductService
    {
        // Constructor to define the webhost environmet where ASP.NET is running
        public JsonFileProductService(IWebHostEnvironment webHostEnvironment)
        {
            WebHostEnvironment = webHostEnvironment;
        }
        // We then store that information into a public class named WebHostEnvironment which then can be used to get any information regarding the web environment
        public IWebHostEnvironment WebHostEnvironment { get; }

        private string JsonFileName => Path.Combine(WebHostEnvironment.WebRootPath, "data", "products.json");
        
        public IEnumerable<Product> GetProducts()
        {
            using var jsonFileReader = File.OpenText(JsonFileName);
            return JsonSerializer.Deserialize<Product[]>(jsonFileReader.ReadToEnd(),
                new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                });
        }
    }
}
