using System.ComponentModel.DataAnnotations;

namespace Argosy.Web.FrontEnd.Models
{
    public class ConsumerCompanyModel
    {
        [Required]
        [MaxLength(50)]
        public string CompanyName { get; set; }
    }
}