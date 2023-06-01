﻿using Microsoft.AspNetCore.Mvc;
using Organa.DAL.Entities;
using Newtonsoft.Json;
using System.Text.Json.Serialization;
using System.Security.Policy;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Net.Sockets;
using WebPagesOrgana.Models;

namespace WebPagesOrgana.Controllers
{
    public class MenuController : Controller
    {
        private readonly IHttpClientFactory _httpClient;

        public MenuController(IHttpClientFactory httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<IActionResult> Index()
        {
            try
            {
                var url = "https://localhost:7187/api/Menu/Get";
                var json = await _httpClient.CreateClient().GetStringAsync(url);
                List<Menu> Menus = JsonConvert.DeserializeObject<List<Menu>>(json);
                return View(Menus);
            } catch (Exception ex)
            {
                return View("Error", ex);
            }          
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            var dishesTask = GetDishesAsync();
            MenuViewModel menuViewModel = new MenuViewModel();
            menuViewModel.Dishes = new List<DishViewModel>();
            var dishes = await dishesTask;

            foreach (var dish in dishes)
            {
                menuViewModel.Dishes.Add(dish);
            }

            //ViewBag.Dishes = dishes;
            return View(menuViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(MenuViewModel menuViewModel)
        {
            try
            {
                Menu menu = new()
                {
                    Name = menuViewModel.Name,
                    Description = menuViewModel.Description,
                    //Dishes = 
                
                };
                var url = "https://localhost:7187/api/Dish/CreateMenu";
                await _httpClient.CreateClient().PostAsJsonAsync(url, menu);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                return View("Error", ex);
            }
        }

        private async Task<ICollection<DishViewModel>> GetDishesAsync()
        {
            var url = "https://localhost:7187/api/Dish/Get";
            var json = await _httpClient.CreateClient().GetStringAsync(url);
            ICollection<DishViewModel> dishes = JsonConvert.DeserializeObject<List<DishViewModel>>(json);
            dishes.Select(d => new { d.Id, d.Name });
            return dishes;
        }

        [HttpGet]
        public async Task<IActionResult> Edit(Guid? id)
        {
            try
            {
                var url = String.Format("https://localhost:7187/api/Menu/Get/{0}", id);
                var json = await _httpClient.CreateClient().GetStringAsync(url);
                Menu menus = JsonConvert.DeserializeObject<Menu>(json);
                return View(menus);
            }
            catch (Exception ex)
            {
                return View("Error", ex);
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid? id, Menu  menus)
        {
            try
            {
                var url = String.Format("https://localhost:7187/api/Menu/Edit/{0}", id);
                await _httpClient.CreateClient().PutAsJsonAsync(url, menus);
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
                var url = String.Format("https://localhost:7187/api/Menu/Get/{0}", id);
                var json = await _httpClient.CreateClient().GetStringAsync(url);
                Menu menus = JsonConvert.DeserializeObject<Menu>(json);
                return View(menus);
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
                var url = String.Format("https://localhost:7187/api/Menu/Delete/{0}", id);
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
