using Core.Security.Entities;
using SMS.Domain.Enums;

namespace SMS.Domain.Entities;

public class UserEntity : User
{
    public string TRIN { get; set; }
    public Sex Gender { get; set; }
}