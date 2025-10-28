namespace lab11;

public class Payment
{
    public int Id { get; set; }
    public string Description { get; set; }
    public DateTime DateTime { get; set; }
    public int UserId { get; set; }
    public User User { get; set; }
    public int CategoryId { get; set; }
    public Category Category { get; set; }
}