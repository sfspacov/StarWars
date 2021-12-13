namespace StarWars.Domain.Entities
{
    public class Localizacao
    {
        #region Properties
        public int Id { get; set; }
        public int IdRebelde { get; set; }
        public float Latitude { get; set; }
        public float Longitude { get; set; }
        public string NomeDaBase { get; set; } 
        #endregion
    }
}
