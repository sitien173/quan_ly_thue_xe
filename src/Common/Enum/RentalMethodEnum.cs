using System.ComponentModel;

namespace CarRentalManagement.Common.Enum;

public enum RentalMethodEnum : short
{
    [Description("Thuê theo ngày")]
    Daily = 1,
    [Description("Thuê theo tuần")]
    Weekly = 2,
    [Description("Thuê theo tháng")]
    Monthly = 3,
    [Description("Thuê theo năm")]
    Yearly = 4
}