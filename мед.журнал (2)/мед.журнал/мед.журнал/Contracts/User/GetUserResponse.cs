namespace мед.журнал.Contracts.User
{
    public class GetUserResponse
    {
        
            public int Id { get; set; }
       
            public string Surname { get; set; } = null!;
            public DateTime DateOfBirth { get; set; }
            public string Name { get; set; } = null!;
            public string Email { get; set; } = null!;
            public string PasswordHash { get; set; } = null!;
        
    }
}
