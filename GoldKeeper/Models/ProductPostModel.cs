using System.ComponentModel.DataAnnotations;

namespace GoldKeeper.Models
{
    public class ProductPostModel
    {
        [Required(AllowEmptyStrings = false)]
        public string Name { get; set; }
    }
}
