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
    public class CreatePersonHandler : IRequestHandler<CreatePersonCommand, Person>
    {
        private readonly PersonDbContext context;
        public CreatePersonHandler(PersonDbContext context) => this.context = context;
        public async Task<Person> Handle(CreatePersonCommand request, CancellationToken cancellationToken)
        {

            var newData = new Person
            {
                Id = request.Id,
                FirstName = request.FirstName,
                MiddleName = request.MiddleName,
                LastName = request.LastName,
                Age = request.Age,
                Gender = request.Gender,
                Email = request.Email
            };

            await context.AddAsync(newData);
            await context.SaveChangesAsync();

            return newData;
        }
    }
}
