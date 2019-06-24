using System;
using SQLite;
using CubeXNative.Services;
using Autofac;


namespace CubeXNative
{
    public class App
    {
        public static bool UseMockDataStore = true;
        //public static string BackendUrl = "http://localhost:5000";
        public static string BackendUrl = "https://investhr.biz/investhr";
        public static SqliteDataStore database;   // for internal class use
        public static IContainer Container { get; set; }
        public static ContainerBuilder builder;
        public static void Initialize()
        {
            if (UseMockDataStore)
                ServiceLocator.Instance.Register<IDataStore<Item>, MockDataStore>();
            else
                ServiceLocator.Instance.Register<IDataStore<Item>, CloudDataStore>();

            builder = new ContainerBuilder();

            builder.RegisterInstance(new CloudDataStore()).As<IDataStore<Item>>();

            builder.RegisterInstance(new ApiStore()).As<IApiStore>();


        }

        //public static SqliteDataStore Database
        //{
        //    get
        //    {
        //        if (database == null)
        //        {
        //            //database = new SqliteDataStore(DependencyService.Get<IFileHelper>().GetLocalFilePath("InvestHR.db3"));
        //            database = new SqliteDataStore(DependencyService.Get<IFileHelper>().GetLocalFilePath("InvestHR.db3"));

        //        }
        //        return database;
        //    }
        //}

        public static SqliteDataStore Database
        {
            get
            {
                using (var scope = Container.BeginLifetimeScope())
                {
                    if (database == null)
                    {
                        IFileHelper fileHelper = Container.Resolve<IFileHelper>();

                        String localFilePath = fileHelper.GetLocalFilePath("CubeXNative.db3");

                        database = new SqliteDataStore(localFilePath);
                        
                    }

                    return database;

                }
            }
           
        }

    }
}
