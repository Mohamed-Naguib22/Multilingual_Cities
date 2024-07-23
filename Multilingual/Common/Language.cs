using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace Multilingual.Common
{
    public partial class Language
    {
        public Language()
        {
            StringResources = new HashSet<StringResource>();
        }
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid ID { get; set; }
        public string Name { get; set; }
        public string Culture { get; set; }
        [JsonIgnore, ValidateNever]
        public virtual ICollection<StringResource>? StringResources { get; set; }
    }
}
