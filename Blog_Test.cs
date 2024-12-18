using System.ComponentModel.DataAnnotations;

public class Blog_Test
{
    [Key]
    public Guid Id { get; set; }

    public Guid? Ids { get; set; }

    public string Name { get; set; }

    public bool Sex { get; set; }

    public bool? Sexy { get; set; }

    public int Age { get; set; }

    public int? Ager { get; set; }

    public DateTime Birth { get; set; }

    public DateTime? Birthy { get; set; }

    public float Money { get; set; }

    public float? Moneies { get; set; }

    public double Pi { get; set; }

    public double? Pis { get; set; }

    public State State { get; set; }

    public State? States { get; set; }

    [Timestamp]
    public byte[] RowVersion { get; set; }
}