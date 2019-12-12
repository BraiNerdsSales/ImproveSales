namespace ImproveSales.Database.Helpers
{
    using ImproveSales.Database.Models;
    using ImproveSales.Resources;
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

        }

        private static void SeedRoles(RoleManager<Role> roleManager)
        {
            // Adding new role into Roles is enough to be created.
            foreach (var currentProperty in typeof(Translator.Roles).GetProperties())
            {
                if (!roleManager
                    .RoleExistsAsync(currentProperty.Name).Result)
                {
                    Role role = new Role();
                    role.Name = currentProperty.Name;
                    roleManager.CreateAsync(role);
                }
            }
        }
    }
}
