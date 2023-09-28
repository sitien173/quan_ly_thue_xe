
using System.ComponentModel;

namespace CarRentalManagement.Common.Enum;

public enum ReceiptTypeEnum : short
{
    [Description("Phiếu thu")]
    In = 0,
    [Description("Phiếu chi")]
    Out = 1
}