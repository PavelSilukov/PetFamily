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

    private static Result<NickName> Create(string nickName)
    {
        if(string.IsNullOrWhiteSpace(nickName))
            return "NickName cannot be null or empty";
        return new NickName(nickName);
    }
}