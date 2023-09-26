using System.ComponentModel;

namespace CarRentalManagement.Common.Enum;

public enum PayMethodEnum : short
{
    [Description("Tiền mặt")]
    Cash = 0,
    [Description("Chuyển khoản")]
    Bank = 1,
}