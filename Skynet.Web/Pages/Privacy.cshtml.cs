using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Skynet.Data;
using Skynet.Domain;
using Microsoft.EntityFrameworkCore;

namespace Skynet.Web.Pages
{
    public class PrivacyModel : PageModel
    {
        private readonly ILogger<PrivacyModel> _logger;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly SkynetContext _db;

        public PrivacyModel(ILogger<PrivacyModel> logger, RoleManager<IdentityRole> roleManager
            , SkynetContext db)
        {
            _logger = logger;
            _roleManager = roleManager;
            _db = db;
        }

        public async Task OnGetAsync()
        {
            await CreateRoles();

            //await FillDatabase();
        }

        private async Task CreateRoles()
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

        private async Task FillDatabase()
        {
            var airlines = _db.Set<Airline>().ToList();

            foreach (var a in airlines)
            {
                var  array = a.Name.Split(' ');
                string abrv = string.Empty;

                foreach (var x in array)
                {
                    abrv += x.First();
                }

                a.Abbreviation = abrv;

            }

            _db.UpdateRange(airlines);
            await _db.SaveChangesAsync();

        }
    }
}
