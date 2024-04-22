using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace It_Expert.DataBase.Entities;

public class Data
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [Key]
    public int Id { get; set; }
    public int Code { get; set; }
    public string Value { get; set; } = string.Empty;
}
