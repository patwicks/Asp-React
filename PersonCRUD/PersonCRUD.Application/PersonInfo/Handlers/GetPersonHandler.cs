using MediatR;
using Microsoft.EntityFrameworkCore;
using PersonCRUD.Application.DataAccess;
using PersonCRUD.Application.PersonInfo.Queries;

namespace PersonCRUD.Application.PersonInfo.Handlers
{
    public class GetPersonHandler : IRequestHandler<GetAllPerson, List<Person>>, IRequestHandler<GetPersonById, Person>
    {
        private readonly PersonDbContext context;
        public GetPersonHandler(PersonDbContext context) => this.context = context;
   
        public async Task<List<Person>> Handle(GetAllPerson request, CancellationToken cancellationToken)
        {
            var result = await context.Persons.ToListAsync();

            return result;
        }

        public async Task<Person> Handle(GetPersonById request, CancellationToken cancellationToken)
        {
            var result = await context.Persons.FindAsync(request.Id);

            return result;
        }
    }
}
