using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace Skynet.Web.Pages
{
    public class PrivacyModel : PageModel
    {
        private readonly ILogger<PrivacyModel> _logger;
        private readonly RoleManager<IdentityRole> _roleManager;

        public PrivacyModel(ILogger<PrivacyModel> logger, RoleManager<IdentityRole> roleManager)
        {
            _logger = logger;
            _roleManager = roleManager;
        }

        public async Task OnGetAsync()
        {

            // Script to check if role X exists and add it
            var roleCheck = await _roleManager.RoleExistsAsync("Admin");
            if (!roleCheck)
            {
                _ = await _roleManager.CreateAsync(new IdentityRole("Admin"));
            }

            roleCheck = await _roleManager.RoleExistsAsync("Airline");
            if (!roleCheck)
            {
                _ = await _roleManager.CreateAsync(new IdentityRole("Airline"));
            }

            roleCheck = await _roleManager.RoleExistsAsync("Customer");
            if (!roleCheck)
            {   
                _ = await _roleManager.CreateAsync(new IdentityRole("Customer"));
            }
        }

    }
}
