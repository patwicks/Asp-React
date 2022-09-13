using MediatR;
using PersonCRUD.Application.DataAccess;

namespace PersonCRUD.Application.PersonInfo.Queries
{
    public class GetAllPerson : IRequest<List<Person>>
    {
    }
}
