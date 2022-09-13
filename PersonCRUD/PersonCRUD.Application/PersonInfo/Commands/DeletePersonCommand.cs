using MediatR;
using PersonCRUD.Application.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonCRUD.Application.PersonInfo.Commands
{
    public class DeletePersonCommand : IRequest<Person>
    {
        public int Id { get; set; }
    }
}
