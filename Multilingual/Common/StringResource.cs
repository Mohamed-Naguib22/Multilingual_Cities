using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Multilingual.Common
{
    public partial class StringResource
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid ID { get; set; }
        public Guid Key { get; set; }
        public string Value { get; set; }

        [ForeignKey("LanguageID")]
        public Guid? LanguageId { get; set; }
        [JsonIgnore, ValidateNever]
        public virtual Language? Language { get; set; }
    }
}
