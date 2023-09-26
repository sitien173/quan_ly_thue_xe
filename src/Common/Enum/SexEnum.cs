using System.ComponentModel;

namespace CarRentalManagement.Common.Enum;

public enum SexEnum : short
{
    [Description("Nam")]
    Male = 0,
    [Description("Nữ")]
    FeMale = 1
}