using MediatR;
using PersonCRUD.Application.DataAccess;
using PersonCRUD.Application.PersonInfo.Commands;


namespace PersonCRUD.Application.PersonInfo.Handlers
{
 
    public class DeletePersonHandler : IRequestHandler<DeletePersonCommand, Person>
    {
        private readonly PersonDbContext context;
        public DeletePersonHandler(PersonDbContext context) => this.context = context;
        public async Task<Person> Handle(DeletePersonCommand request, CancellationToken cancellationToken)
        {
            var person = await context.Persons.FindAsync(request.Id);

            if (person == null) return default;

           context.Persons.Remove(person);
            await context.SaveChangesAsync();

            return person;

        }
    }
}
