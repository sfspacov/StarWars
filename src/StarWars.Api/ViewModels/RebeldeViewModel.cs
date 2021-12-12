using System.ComponentModel.DataAnnotations;

namespace StarWars.Api.ViewModels
{
    public class RebeldeViewModel
    {
        #region Properties

        public int Id { get; set; }
        [Required(ErrorMessage = "Campo Nome é obrigatório")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Campo Idade é obrigatório")]
        public int Idade { get; set; }
        [Required(ErrorMessage = "Campo Gênero é obrigatório")]
        [Display(Name = "Gênero")]
        public string Genero { get; set; }
        [Required(ErrorMessage = "Campo Localização é obrigatório")]
        [Display(Name = "Localização")]
        public LozalizacaoViewModel Lozalizacao { get; set; }
        public InventarioViewModel Inventario { get; set; }
        #endregion
    }
}