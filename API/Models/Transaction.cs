namespace RabbitMQ.API.Models;

public class Transaction
{
    public long? Id { get; set; }
    public required string Sender { get; set; }
    public required string To { get; set; }
    public required bool Confirmed { get; set; }
    public required double Value { get; set; }
    public required DateTime Date { get; set; }

};