using SADomain.Interfaces.Repository.MongoDB;

namespace SAData.MongoDb
{
    public class MongoDbConfig : IMongoDbConfig
    {
        public string NomeDaColecao { get; set; }
        public string CaminhoDaConexao { get; set; }
        public string NomeDoBanco { get; set; }
    }
}
