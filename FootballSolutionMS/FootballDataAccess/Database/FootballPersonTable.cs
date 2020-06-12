using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FootballDataAccess.Database
{
    [Table("FOOTBALL_PERSON_SPORT")]
    public class FootballPersonTable
    {
        [Key]
        [Column("ID")]
        public int Id { get; set; }
        [Column("NAME")]
        [MaxLength(50)]
        public string Name { get; set; }
    }
}
