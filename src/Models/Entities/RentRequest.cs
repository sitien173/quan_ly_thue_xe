﻿namespace CarRentalManagement.Models.Entities;

public class RentRequest
{
    public int Id { get; set; }
    public int CarId { get; set; }
    public int CustomerId { get; set; }
    public DateTime RentalDate { get; set; }
    public DateTime ReturnedDate { get; set; }
    public Car Car { get; set; }
    public Customer Customer { get; set; }
    public RentRequestStatusEnum RentRequestStatusEnum { get; set; }
    public RentalMethodEnum RentalMethod { get; set; }
    public decimal TotalPrice { get; set; }
    public string? Note { get; set; }
    public bool IsDeleted { get; set; }
}