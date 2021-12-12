namespace StarWars.Domain.Entities
{
    public class Rebelde
    {
        #region Properties

        public int Id { get; set; }

        public string Nome { get; set; }
        public int Idade { get; set; }
        public string Genero { get; set; }
        public Lozalizacao Lozalizacao { get; set; }

        public Inventario Inventario { get; set; }


        #endregion
    }
}