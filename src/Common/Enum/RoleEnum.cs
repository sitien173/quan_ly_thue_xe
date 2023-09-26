using System.ComponentModel;

namespace CarRentalManagement.Common.Enum;

public enum RoleEnum : short
{
    [Description("Kế toán")]
    ACC,
    [Description("Bãi xe")]
    PA,
    [Description("Admin")]
    ADM,
    [Description("Kinh doanh")]
    SP
}