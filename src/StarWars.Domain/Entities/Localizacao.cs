namespace StarWars.Domain.Entities
{
    public class Lozalizacao
    {
        #region Properties
        public int Id { get; set; }
        public float Latitude { get; set; }
        public float Longitude { get; set; }
        public string NomeDaBase { get; set; } 
        #endregion
    }
}
