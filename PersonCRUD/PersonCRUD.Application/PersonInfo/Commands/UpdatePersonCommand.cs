using MediatR;
using PersonCRUD.Application.DataAccess;

namespace PersonCRUD.Application.PersonInfo.Commands
{
    public class UpdatePersonCommand : IRequest<Person>
    {
        public int Id { get; set; }
        public string FirstName { get; set; } = null!;
        public string MiddleName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public int Age { get; set; }
        public string Gender { get; set; } = null!;
        public string Email { get; set; } = null!;
    }
}
