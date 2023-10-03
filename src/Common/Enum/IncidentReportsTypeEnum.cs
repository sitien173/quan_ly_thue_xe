using System.ComponentModel;

namespace CarRentalManagement.Common.Enum;

public enum IncidentReportsTypeEnum : short
{
    [Description("Tai nạn")]
    Accident = 1,
    
    [Description("Mất cắp")]
    Theft = 2,
    
    [Description("Phá hoại")]
    Vandalism = 3,
    
    [Description("Khác")]
    Other = 4
}