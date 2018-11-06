using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace GoldKeeper.Models
{
    public class CompanyPostModel
    {
        [Required(AllowEmptyStrings = false)]
        public string Name { get; set; }
    }
}
