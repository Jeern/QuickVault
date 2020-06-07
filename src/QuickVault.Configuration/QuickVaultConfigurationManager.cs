namespace QuickVault.Configuration
{
    public static class QuickVaultConfigurationManager
    {
        private static string _rootFolder;
        public static void SetRootFolder(string rootfolder)
        {
            _rootFolder = rootfolder;
        }

        private static AppSettings _appSettings;
        public static AppSettings AppSettings => _appSettings ?? (_appSettings = new AppSettings(_rootFolder));

        private static ConnectionStrings _connectionStrings;
        public static ConnectionStrings ConnectionStrings => _connectionStrings ?? (_connectionStrings = new ConnectionStrings(_rootFolder));
    }
}
