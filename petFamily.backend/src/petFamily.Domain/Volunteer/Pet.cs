namespace petFamily.Domain.Volunteer;

public class Pet
{
    public Pet(string nickname)
    {
        Nickname = nickname;
    }
    //ef core
       
    public Guid Id { get; private set; } 
    public string Nickname { get; private set; } 
    // public string Description { get; private set; } = default!;
    // public string Beed { get; private set; } = default!;
    // public Color color { get; private set; } = default!;
    // public Health helth { get; private set; } = default!;
    // public string AdressLocation {get; private set;} = default!;
    // public int Weight {get; private set;} = default!;
    // public int Height {get; private set;} = default!;
    // public DateTime BirthDate { get; private set; } = default!;
    // public string PhoneNumberOwner { get; private set; } = default!;
    // public bool IsNeutered { get; private set; } = default!;
    // public bool isVaccinated { get; private set; } = default!;
    // public Status status { get; private set; } = default!;
    // public Requisite requisite { get; private set; } = default!;
    // public DateTime DateOfCreate { get; private set; } = default!;
}