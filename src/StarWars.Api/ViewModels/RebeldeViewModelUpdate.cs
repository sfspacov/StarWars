using System.ComponentModel.DataAnnotations;

namespace StarWars.Api.ViewModels
{
    public class RebeldeViewModelUpdate : RebeldeViewModelCreate
    {
        #region Properties
        [Required]
        public new int Id { get; set; }
        #endregion
    }
}