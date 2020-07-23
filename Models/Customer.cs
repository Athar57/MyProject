using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AdminLTE.Models
{
    public class Customer
    {
        [Key]
        public int Id { get; set; }
        [Display(Name ="Customer Name")]
        [Required(ErrorMessage ="Plaese fill this field")]
        public string Name { get; set; }
        [Display(Name = "Customer Adress")]
        [Required(ErrorMessage = "Plaese fill this field")]
        public string Adress { get; set; }
        [Display(Name = "Customer Notes")]
        [Required(ErrorMessage = "Plaese fill this field")]
        public string Notes { get; set; }
        [Display(Name = "Date")]
        [Required(ErrorMessage = "Plaese fill this field")]
        [DataType(DataType.DateTime)]
        public DateTime CreatedDate { get; set; }
        public int CityId { get; set; }




        public City City { get; set; }
       
       
    }
    
}
