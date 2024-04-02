using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuildingBlocks.CQRS
{
    
    public interface ICommand : ICommand<Unit>
    {
    }
    //custom ICommand inherit from IRequest<TResponse> this is reason why in endpoints class class i useing this interface 
    public interface ICommand<out /*-> key word is response type*/ TResponse> : IRequest<TResponse>
    {
    }
}
