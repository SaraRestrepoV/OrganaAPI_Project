using Microsoft.AspNetCore.Mvc;
using Organa.DAL.Entities;
using Newtonsoft.Json;
using System.Text.Json.Serialization;

namespace WebPagesOrgana.Controllers
{
    public class DishesController : Controller
    {
        private readonly IHttpClientFactory _httpClient;

        public DishesController(IHttpClientFactory httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<IActionResult> Index()
        {
            try
            {
                var url = "https://localhost:7187/api/Dish/Get";
                var json = await _httpClient.CreateClient().GetStringAsync(url);
                List<Dish> Dishes = JsonConvert.DeserializeObject<List<Dish>>(json);
                return View(Dishes);
            } catch (Exception ex)
            {
                return View("Error", ex);
            }          
        }
    }
}
