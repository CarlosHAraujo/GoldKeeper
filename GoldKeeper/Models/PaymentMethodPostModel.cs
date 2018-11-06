using System.ComponentModel.DataAnnotations;

namespace GoldKeeper.Models
{
    public class PaymentMethodPostModel
    {
        [Required(AllowEmptyStrings = false)]
        public string Name { get; set; }
    }
}
