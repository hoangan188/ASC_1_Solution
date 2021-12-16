using ASC_1.Models;
using ASC_1.Web.Configuration;
using ElCamino.AspNetCore.Identity.AzureTable.Model;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASC_1.Data
{
    public interface IIdentitySeed
    {
        Task Seed(Microsoft.AspNetCore.Identity.UserManager<ApplicationUser> userManager, RoleManager<IdentityRole>
           roleManager, IOptions<ApplicationSettings> options);
    }
}
