using System.ComponentModel.DataAnnotations;

namespace GoldKeeper.Models
{
    public class PostProductModel
    {
        [Required(AllowEmptyStrings = false)]
        public string Name { get; set; }
    }
}
