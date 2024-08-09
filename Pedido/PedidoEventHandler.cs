using System;
using System.Threading.Tasks;
using Core.Messages.IntegrationEvents;
using Rebus.Handlers;

namespace Pedido
{
    public class PedidoEventHandler :
        IHandleMessages<PedidoRealizadoEvent>
    {
        public Task Handle(PedidoRealizadoEvent message)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("PEGUEI EM OUTRO LUGAR");
            Console.ForegroundColor = ConsoleColor.Black;
            return Task.CompletedTask;
        }
    }
}