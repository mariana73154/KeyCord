using Microsoft.AspNetCore.Identity;

namespace KeyCord3.Data
{
    public class SeedRoles
    {
        public static void Seed(RoleManager<IdentityRole> roleManager)
        {
            if (roleManager.Roles.Any() == false)
            {
                roleManager.CreateAsync(new IdentityRole("Admin")).Wait();
                roleManager.CreateAsync(new IdentityRole("Cliente")).Wait();
                roleManager.CreateAsync(new IdentityRole("Funcionario")).Wait();
            }
        }
    }

}
