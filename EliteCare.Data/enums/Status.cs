using System.Runtime.Serialization;

namespace EliteCare.Data.enums
{
    public enum Status
    {
        [EnumMember(Value = "scheduled")]
        Scheduled=0,
        [EnumMember(Value = "in-progress")]
        InProgress,
        [EnumMember(Value = "completed")]
        Completed,
        [EnumMember(Value = "cancelled")]
        Cancelled
    }
}