using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;


namespace PLUMWEB.Data.Models;

public class ProduceVM
{
    public int Id { get; set; }
    [Display(Name = "Name of Produce")]
    [Required]
    public string NameOfProduce { get; set; }
    [Display(Name = "Type of Produce")]
    [Required]
    public string TypeOfProduce { get; set; }
    public string Quantity { get; set; }
    public decimal Price { get; set; }
    [Display(Name = "Date Added")]
    public DateTime DateAdded { get; set; }
}
