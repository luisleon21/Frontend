using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhysioLink.Components.Services
{
    public class test
    {
        private readonly HttpClient _httpClient;

        public test(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task RealizarPeticionGet()
        {
            try
            {
                var response = await _httpClient.GetAsync("TipoDocumento");
                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    // Procesa la respuesta según tus necesidades
                    Console.WriteLine(content);
                }
                else
                {
                    Console.WriteLine($"Error: {response.StatusCode}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
    }
}
