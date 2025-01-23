using System.Runtime.Serialization;

namespace EliteCare.Data.enums
{
    public enum Gender
    {
        [EnumMember(Value = "male")]
        male = 0,
        [EnumMember(Value = "female")]
        female,
    }
}