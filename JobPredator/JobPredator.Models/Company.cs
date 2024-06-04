

using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace JobPredator.Models
{
    public enum CompanyType
    {
        CareersSource,
        Placement,
        JobBoard,
       
    }

    [Table("companies")]
    public class Company
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }

        [Required]
        [Column("name")]
        [MaxLength(100)]
        public string Name { get; set; }

        [Column("logo_url")]
        public string LogoUrl { get; set; }

        [Column("company_type")]
        public CompanyType CompanyType { get; set; }

        [JsonIgnore]
        public ICollection<Job> Jobs { get; } = new List<Job>();
    }
}
