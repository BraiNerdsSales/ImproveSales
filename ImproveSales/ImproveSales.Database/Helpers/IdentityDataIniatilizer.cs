namespace ImproveSales.Database.Helpers
{
    using ImproveSales.Database.Models;
    using Microsoft.AspNetCore.Identity;

    public static class IdentityDataIniatilizer
    {
        public static void SeedData(UserManager<User> userManager,
                                    RoleManager<Role> roleManager)
        {
            SeedUsers(userManager);
            SeedRoles(roleManager);
        }

        private static void SeedUsers(UserManager<User> userManager)
        {
            userManager.CreateAsync(new User()
            { 
                UserName = "FidoDidoo100",
                Email = "iavor.orlyov1@gmail.com",
                EmailConfirmed = true
            }, "A123123123a");

        }

        private static void SeedRoles(RoleManager<Role> roleManager)
        {
            // Adding new role into Roles is enough to be created.
            foreach (var currentProperty in typeof(Roles).GetProperties())
            {
                if (!roleManager
                    .RoleExistsAsync(currentProperty.Name).Result)
                {
                    Role role = new Role
                    {
                        Name = currentProperty.Name
                    };
                    roleManager.CreateAsync(role);
                }
            }
        }
    }
}
