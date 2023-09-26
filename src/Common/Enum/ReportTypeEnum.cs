using System.ComponentModel;

namespace CarRentalManagement.Common.Enum;

public enum ReportTypeEnum : short
{
    [Description("Theo tháng")]
    Month = 1,
    
    [Description("Theo năm")]
    Year = 2
}