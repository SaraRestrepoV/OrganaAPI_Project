using Microsoft.AspNetCore.Mvc;
using Organa.DAL.Entities;
using Newtonsoft.Json;
using System.Text.Json.Serialization;
using System.Security.Policy;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Net.Sockets;

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

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Dish dishes)
        {
            try
            {
                var url = "https://localhost:7187/api/Dish/CreateDish";
                await _httpClient.CreateClient().PostAsJsonAsync(url, dishes);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                return View("Error", ex);
            }
        }

        [HttpGet]
        public async Task<IActionResult> Edit(Guid? id)
        {
            try
            {
                var url = String.Format("https://localhost:7187/api/Dish/Get/{0}", id);
                var json = await _httpClient.CreateClient().GetStringAsync(url);
                Dish dishes = JsonConvert.DeserializeObject<Dish>(json);
                return View(dishes);
            }
            catch (Exception ex)
            {
                return View("Error", ex);
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid? id, Dish  dishes)
        {
            try
            {
                var url = String.Format("https://localhost:7187/api/Dish/Edit/{0}", id);
                await _httpClient.CreateClient().PutAsJsonAsync(url, dishes);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                return View("Error", ex);
            }
        }

        [HttpGet]
        public async Task<IActionResult> Delete(Guid? id)
        {
            try
            {
                var url = String.Format("https://localhost:7187/api/Dish/Get/{0}", id);
                var json = await _httpClient.CreateClient().GetStringAsync(url);
                Dish dishes = JsonConvert.DeserializeObject<Dish>(json);
                return View(dishes);
            }
            catch (Exception ex)
            {
                return View("Error", ex);
            }
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            try
            {
                var url = String.Format("https://localhost:7187/api/Dish/Delete/{0}", id);
                await _httpClient.CreateClient().DeleteAsync(url);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                return View("Error", ex);
            }
        }
    }
}
