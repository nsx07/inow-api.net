using Microsoft.CodeAnalysis.VisualBasic.Syntax;
using MongoDB.Driver;
using System.Configuration;

namespace INOW.API.Core
{
    public class MongoClientResolver
    {
        private static MongoClientResolver instance;
        private static MongoClientSettings mongoSettings;
        public MongoClient client;

        private MongoClientResolver() { }

        public static MongoClientResolver Inialize(IConfiguration configuration) {
            mongoSettings = MongoClientSettings.FromConnectionString(configuration.GetConnectionString("mongodb"));
            mongoSettings.ServerApi = new ServerApi(ServerApiVersion.V1);
            
            instance = getInstance();
            instance.client = new MongoClient(mongoSettings);

            return instance;
        }

        public static MongoClientResolver getInstance()
        {
            if (instance == null)
            {
                instance = new MongoClientResolver();
            }

            return instance;
        }




    }
}
