﻿namespace PTCApp.Entities
{
    public class AppUserAuth: UserAuthBase
    {
        public AppUserAuth(): base()
        {
            CanAccessProducts = false;
            CanAccessCategories = false;
            CanAccessLogs = false;
            CanAccessSettings = false;
            CanAddProduct = false;
            CanDeleteProduct = false;
        }

        public bool CanAccessProducts { get; set; }
        public bool CanAccessCategories { get; set; }
        public bool CanAccessLogs { get; set; }
        public bool CanAccessSettings { get; set; }
        public bool CanAddProduct { get; set; }
        public bool CanDeleteProduct { get; set; }
    }
}
