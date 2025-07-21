using CSharpFunctionalExtensions;
using petFamily.Domain.Shared;

namespace petFamily.Domain.PetManagement.ValueObjects;

public record NickName
{
    private NickName(string name)
    {
        Name = name;
    }
   
    public string Name { get;}
    //

    public static Result<NickName, Error> Create(string nickName)
    {
        if(string.IsNullOrWhiteSpace(nickName))
            return Errors.General.ValueIsInvalid("NickName");
        return new NickName(nickName);
    }
}