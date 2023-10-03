using Ardalis.SmartEnum;

namespace CarRentalManagement.Common.Enum;

public class PolicyEnum : SmartEnum<PolicyEnum, string>
{

    public PolicyEnum(string name, string value) : base(name, value)
    {
    }
    
    public static readonly PolicyEnum Admin = new(nameof(Admin), nameof(RoleEnum.ADM));
    public static readonly PolicyEnum Accountant = new(nameof(Accountant), string.Join(',', nameof(RoleEnum.ACC), nameof(RoleEnum.ADM)));
    public static readonly PolicyEnum ParkingAttendant = new(nameof(ParkingAttendant), string.Join(',', nameof(RoleEnum.PA), nameof(RoleEnum.ADM)));
    public static readonly PolicyEnum SalesRepresentative = new(nameof(SalesRepresentative), string.Join(',', nameof(RoleEnum.SP), nameof(RoleEnum.ADM)));
    public static readonly PolicyEnum All = new(nameof(SalesRepresentative), string.Join(',', nameof(RoleEnum.ACC), nameof(RoleEnum.PA), nameof(RoleEnum.SP), nameof(RoleEnum.ADM)));
}


