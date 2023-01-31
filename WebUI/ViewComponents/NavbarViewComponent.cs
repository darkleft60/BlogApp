﻿using Business.Dtos;
using Entities.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace WebUI.ViewComponents
{
    public class NavbarViewComponent : ViewComponent
    {
        private readonly UserManager<User> _userManager;

        public NavbarViewComponent(UserManager<User> userManager)
        {
            _userManager = userManager;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var user = await _userManager.GetUserAsync(HttpContext.User);
            if (user == null)
            {
                return Content("Kullanıcı Bulunamadı");
            }
            var roles = await _userManager.GetRolesAsync(user);
            if (roles == null)
            {
                return Content("Roller Bulunamadı");
            }
            return View(new AuthorWithRolesViewModel
            {
                User = user,
                Roles = roles
            });
        }
    }
}
