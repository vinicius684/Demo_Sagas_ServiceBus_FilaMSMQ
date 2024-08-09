using System;
using System.Threading.Tasks;
using Core.Messages.IntegrationEvents;
using Pagamento.Commands;
using Rebus.Bus;
using Rebus.Handlers;

namespace Pagamento
{
    public class PagamentoCommandHandler :
        IHandleMessages<RealizarPagamentoCommand>
    {
        private readonly IBus _bus;

        public PagamentoCommandHandler(IBus bus)
        {
            _bus = bus;
        }

        public Task Handle(RealizarPagamentoCommand message)
        {
            if (Caos.GerarResultado())
            {
                _bus.Publish(new PagamentoRealizadoEvent { AggregateRoot = message.AggregateRoot }).Wait();
                return Task.CompletedTask;
            }

            _bus.Publish(new PagamentoRecusadoEvent { AggregateRoot = message.AggregateRoot }).Wait();
            return Task.CompletedTask;
        }

        public class Caos
        {
            public static bool GerarResultado()
            {
                return new Random().NextDouble() >= 0.5;
            }
        }
    }
}