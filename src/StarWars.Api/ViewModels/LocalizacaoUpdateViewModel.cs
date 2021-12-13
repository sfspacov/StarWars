using System.ComponentModel.DataAnnotations;

namespace StarWars.Api.ViewModels
{
    public class LocalizacaoUpdateViewModel
    {
        #region Properties
        [Required]
        public int IdRebelde { get; set; }
        [Required]
        public float Latitude { get; set; }
        [Required]
        public float Longitude { get; set; }
        [Required]
        public string NomeDaBase { get; set; }
        #endregion
    }
}