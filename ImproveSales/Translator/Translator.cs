﻿namespace ImproveSales.Resources
{
    public static class Translator
    {
        public static string ConnectionStringName = "ImproveSalesDbContextConnection";

        // Contains all the roles. If more are needed just add some here. That's enough.
        public static class Roles
        {
            public static string MasterUser = "MasterUser";
            public static string Administrator = "Administrator";
            public static string Moderator = "Moderator";
            public static string DefaultUser = "DefaultUser";
        }
    }
}
