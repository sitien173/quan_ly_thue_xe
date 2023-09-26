using System.ComponentModel;

public enum TransmissionEnum : short
{
    [Description("Số tự động")]
    Automatic = 1,
    [Description("Số sàn")]
    Manual = 2
}