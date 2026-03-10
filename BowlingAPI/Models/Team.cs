using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BowlingAPI.Models;

[Table("Teams")]
public class Team
{
    [Key]
    public int TeamID { get; set; }
    public string TeamName { get; set; } = string.Empty;
    public int? CaptainID { get; set; }
}
