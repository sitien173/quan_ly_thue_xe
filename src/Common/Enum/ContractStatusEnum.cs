using System.ComponentModel;

namespace CarRentalManagement.Common.Enum;

public enum ContractStatusEnum : short
{
    [Description("Chưa thanh lý")]
    NotFinished = 0,
    [Description("Đã thanh lý")]
    Finished = 1,
    [Description("Đã hủy")]
    Canceled = 2
}