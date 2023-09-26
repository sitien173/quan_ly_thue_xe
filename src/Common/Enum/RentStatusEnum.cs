using System.ComponentModel;

namespace CarRentalManagement.Common.Enum;

public enum RentStatusEnum : short
{
    [Description("Đang thuê")]
    Renting = 0,
    [Description("Đã trả")]
    Returned = 1
}