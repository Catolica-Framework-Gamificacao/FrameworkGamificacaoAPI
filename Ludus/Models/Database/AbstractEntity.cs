using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Ludus.Models.Database
{
    public class AbstractEntity
    {

        [Required]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }

        [JsonIgnore]
        public DateTime? UpdateDate { get; set; } = DateTime.Now;

        [JsonIgnore]
        public DateTime? InsertDate { get; set; } = DateTime.Now;

    }
}
