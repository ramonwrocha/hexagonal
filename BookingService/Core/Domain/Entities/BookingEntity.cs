﻿using Domain.Entities.Base;
using Domain.Enums;

namespace Domain.Entities;

public class BookingEntity : EntityBase
{
    public DateTime CheckIn { get; set; }

    public DateTime CheckOut { get; set; }
    
    public decimal TotalPrice { get; set; }

    public RoomEntity Room { get; set; }

    public GuestEntity Guest { get; set; }

    private BookingStatus Status { get; set; }

    public BookingStatus GetStatus => Status;

    public void ChangeBookingStatus(BookingAction action)
    {
        var newStatus = (Status, action) switch
        {
            (Status: BookingStatus.Pending, action: BookingAction.Pay) => BookingStatus.Confirmed,
            (Status: BookingStatus.Pending, action: BookingAction.Cancel) => BookingStatus.Cancelled,
            (Status: BookingStatus.Confirmed, action: BookingAction.Refund) => BookingStatus.Cancelled,
            (Status: BookingStatus.Cancelled, action: BookingAction.Reopen) => BookingStatus.Pending,
            _ => throw new InvalidOperationException("Invalid action")
        };

        Status = newStatus;
    }
}
