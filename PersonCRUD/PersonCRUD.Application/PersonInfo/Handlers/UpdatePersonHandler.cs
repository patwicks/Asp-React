using MediatR;
using PersonCRUD.Application.DataAccess;
using PersonCRUD.Application.PersonInfo.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonCRUD.Application.PersonInfo.Handlers
{
    public class UpdatePersonHandler : IRequestHandler<UpdatePersonCommand, Person>
    {
        private readonly PersonDbContext context;
        public UpdatePersonHandler(PersonDbContext context) => this.context = context;
        public async Task<Person> Handle(UpdatePersonCommand request, CancellationToken cancellationToken)
        {
            var person = await context.Persons.FindAsync(request.Id);

            if (person == null) return null;

            person.FirstName = request.FirstName;
            person.MiddleName = request.MiddleName;
            person.LastName = request.LastName;
            person.Age = request.Age;
            person.Gender = request.Gender;
            person.Email = request.Email;

            await context.SaveChangesAsync();

            return person;
        }
    }
}
