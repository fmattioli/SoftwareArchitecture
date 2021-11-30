using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArch.Application.ViewModels
{
    public class ProductViewModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "O nome é obrigátorio")]
        [MinLength(3)]
        [MaxLength(100)]
        [DisplayName("Name")]
        public string Name { get; set; }
        [Required(ErrorMessage = "O Description é obrigátorio")]
        [MinLength(3)]
        [MaxLength(200)]
        [DisplayName("Description")]
        public string Description { get; set; }
        [Required(ErrorMessage = "O preço é obrigátorio")]
        [Range(1, 999999.99)]
        [DisplayName("Price")]
        [DisplayFormat(DataFormatString = "{0:C2}")]
        public decimal Price { get; set; }
    }
}
