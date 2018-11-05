using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace GoldKeeper.Models
{
    public class PostCompanyModel
    {
        [Required(AllowEmptyStrings = false)]
        public string Name { get; set; }
    }
}
