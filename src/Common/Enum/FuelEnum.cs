using System.ComponentModel;

namespace CarRentalManagement.Common.Enum;

public enum FuelEnum : short
{
    [Description("Xăng")]
    Gasoline = 1,
    [Description("Dầu")]
    Diesel = 2,
    [Description("Điện")]
    Electric = 3
}