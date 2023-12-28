using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GESTCAT.APPLICATION.Features.Livree.Commands.Create
{
    internal class CreateLivreCommandHandler : IRequestHandler<CreateLivreCommand, int>
    {
        public CreateLivreCommandHandler()
        {
            
        }
        public Task<int> Handle(CreateLivreCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
