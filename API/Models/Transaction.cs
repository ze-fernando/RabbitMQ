using System;

namespace API.Models;

public record Transaction(
    long? Id,
    string Sender,
    string To,
    Status Confirmed,
    double value,
    DateTime Date
);