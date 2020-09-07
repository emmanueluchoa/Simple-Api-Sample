namespace SADomain.Interfaces.Repository.MongoDB
{
    public interface IMongoDbConfig
    {
        public string NomeDaColecao { get; set; }
        public string CaminhoDaConexao { get; set; }
        public string NomeDoBanco { get; set; }
    }
}
