using System.ComponentModel.DataAnnotations;

namespace GoldKeeper.Models
{
    public class PostPaymentMethodModel
    {
        [Required(AllowEmptyStrings = false)]
        public string Name { get; set; }
    }
}
