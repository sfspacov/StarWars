using System.ComponentModel.DataAnnotations.Schema;

namespace StarWars.Domain.Entities
{
    public class Item
    {
        #region Properties

        public int Id { get; set; }
        public int IdRebelde { get; set; }
        [ForeignKey("CustomerId")]
        public virtual Rebelde Rebelde { get; set; }
        public string Nome { get; set; }
        public int Ponto { get; set; }

        #endregion
    }
}