using System.ComponentModel;

namespace CarRentalManagement.Common.Enum;

public enum CheckInOutEnum : short
{
    [Description("Vào")]
    In = 0,
    [Description("Ra")]
    Out = 1
}