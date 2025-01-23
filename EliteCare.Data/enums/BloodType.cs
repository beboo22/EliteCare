using System.Runtime.Serialization;

namespace EliteCare.Data.enums
{
    public enum BloodType
    {
        [EnumMember(Value = "A+")]
        APositive=0,
        [EnumMember(Value = "A-")]
        ANegative,
        [EnumMember(Value = "B+")]
        BPositive,
        [EnumMember(Value = "B-")]
        BNegative,
        [EnumMember(Value = "AB+")]
        ABPositive,
        [EnumMember(Value = "AB-")]
        ABNegative,
        [EnumMember(Value = "O+")]
        OPositive,
        [EnumMember(Value = "O-")]
        ONegative
    }
}