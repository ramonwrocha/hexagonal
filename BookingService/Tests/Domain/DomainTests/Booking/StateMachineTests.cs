using Domain.Entities;
using Domain.Enums;

namespace DomainTests.Booking;

public class StateMachineTests
{
    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public void BookingStatus_ShouldBePendingInitially()
    {
        var booking = BuildBookingEntity();  // Pending
        Assert.AreEqual(expected: BookingStatus.Pending, actual: booking.GetStatus);
    }

    [Test]
    public void ChangeBookingStatus_ShouldSetStatusFromPendingToConfirmed_WhenPayActionIsPerformed()
    {
        var booking = BuildBookingEntity();
        booking.ChangeBookingStatus(BookingAction.Pay); // Confirmed

        Assert.AreEqual(expected: BookingStatus.Confirmed, actual: booking.GetStatus);
    }

    [Test]
    public void ChangeBookingStatus_ShouldSetStatusFromPendingToCancelled_WhenCancelActionIsPerformed()
    {
        var booking = BuildBookingEntity();
        booking.ChangeBookingStatus(BookingAction.Cancel); // Cancelled

        Assert.AreEqual(expected: BookingStatus.Cancelled, actual: booking.GetStatus);
    }

    [Test]
    public void ChangeBookingStatus_ShouldSetStatusFromCancelledToPending_WhenReopenActionIsPerformed()
    {
        var booking = BuildBookingEntity();
        booking.ChangeBookingStatus(BookingAction.Cancel); // Cancelled  
        booking.ChangeBookingStatus(BookingAction.Reopen); // Pending

        Assert.AreEqual(expected: BookingStatus.Pending, actual: booking.GetStatus);
    }

    [Test]
    public void ChangeBookingStatus_ShouldSetStatusFromConfirmedToCancelled_WhenRefundActionIsPerformed()
    {
        var booking = BuildBookingEntity();
        booking.ChangeBookingStatus(BookingAction.Pay); // Confirmed
        booking.ChangeBookingStatus(BookingAction.Refund); // Cancelled

        Assert.AreEqual(expected: BookingStatus.Cancelled, actual: booking.GetStatus);
    }

    [Test]
    [TestCase(BookingAction.Reopen)]
    [TestCase(BookingAction.Refund)]
    public void ChangeBookingStatus_ShouldThrowInvalidOperationException_WhenInvalidActionIsPerformedInPendingState(BookingAction action)
    {
        var booking = BuildBookingEntity(); // Pending

        Assert.Throws<InvalidOperationException>(() => booking.ChangeBookingStatus(action));
    }

    [Test]
    [TestCase(BookingAction.Pay)]
    [TestCase(BookingAction.Cancel)]
    [TestCase(BookingAction.Reopen)]
    public void ChangeBookingStatus_ShouldThrowInvalidOperationException_WhenInvalidActionIsPerformedInConfirmedState(BookingAction action)
    {
        var booking = BuildBookingEntity();

        booking.ChangeBookingStatus(BookingAction.Pay); // Confirmed

        Assert.Throws<InvalidOperationException>(() => booking.ChangeBookingStatus(action));
    }

    [Test]
    [TestCase(BookingAction.Refund)]
    [TestCase(BookingAction.Reopen)]
    public void ChangeBookingStatus_ShouldThrowInvalidOperationException_WhenInvalidActionIsPerformedInPendingStateAfterReopen(BookingAction action)
    {
        var booking = BuildBookingEntity();

        booking.ChangeBookingStatus(BookingAction.Cancel); // Cancelled
         
        booking.ChangeBookingStatus(BookingAction.Reopen); // Pending

        Assert.Throws<InvalidOperationException>(() => booking.ChangeBookingStatus(action));
    }

    private BookingEntity BuildBookingEntity()
    {
        return new BookingEntity
        {
            Room = new RoomEntity(),
            Guests = [],
        };
    }
}
