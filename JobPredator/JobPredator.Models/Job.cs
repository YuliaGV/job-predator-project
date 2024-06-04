

using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace JobPredator.Models
{

    [Table("jobs")]
    [Index(nameof(Url), nameof(Title), nameof(Location), IsUnique = true)]
    public class Job
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }

        [Required]
        [Column("title")]
        [MaxLength(100)]
        public string Title { get; set; }

        [Required]
        [Column("url")]
        public string Url { get; set; }

        [Required]
        [Column("location")]
        [MaxLength(100)]
        public string Location { get; set; }

        [Column("jobtype")]
        [MaxLength(50)]
        public string JobType { get; set; }

        [Column("salary")]
        [MaxLength(50)]
        public string Salary { get; set; }

        [Column("date_posted")]
        public DateTime DatePosted { get; set; }

        [Required]
        [Column("description")]
        public string Description { get; set; }

        [Required]
        public bool Status { get; set; }

        [Required]
        [ForeignKey("Company")]
        public int CompanyId { get; set; }

        [NotMapped]
        public string CompositeId => $"{Url}-{Title}-{Location}";
    }
}
