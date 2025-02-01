namespace RabbitMQ.API.Models;

public class Transaction
{
    public long? Id { get; set; }
    public required string Sender { get; set; }
    public required string To { get; set; }
    public bool Confirmed { get; set; } = false;
    public required double Value { get; set; }
    public DateTime Date { get; set; } = DateTime.Now;


    public override string ToString()
    {
        return @$"
        Id: {Id}
        Sender: {Sender}
        To: {To}
        Confirmed: {Confirmed}        
        Value: {Value}
        Date: {Date}
        ";
    }
};