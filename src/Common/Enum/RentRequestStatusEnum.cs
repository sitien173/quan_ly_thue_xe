using System.ComponentModel;

namespace CarRentalManagement.Common.Enum;

public enum RentRequestStatusEnum : short
{
    [Description("Chờ duyệt")]
    Pending = 0,
    [Description("Đã duyệt")]
    Approved = 1,
    [Description("Từ chối")]
    Rejected = 2,
    [Description("Đã hủy")]
    Cancelled = 3
}