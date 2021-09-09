using System;
using System.Threading;
using GreenPipes;
using MassTransit;

namespace MicroServices
{
    class Program
    {
        private static readonly AutoResetEvent _closing = new AutoResetEvent(false);

        static void Main(string[] args)
        {
            var bus = Bus.Factory.CreateUsingRabbitMq(config =>
                        {
                            config.Host(new Uri($"rabbitmq://queue"), host =>
                            {
                                host.Username("guest");
                                host.Password("guest");
                            });

                            config.UseCircuitBreaker(cb =>
                            {
                                cb.TrackingPeriod = TimeSpan.FromMinutes(1);
                                cb.TripThreshold = 15;
                                cb.ActiveThreshold = 10;
                                cb.ResetInterval = TimeSpan.FromMinutes(5);
                            });

                            config.ReceiveEndpoint("recomendacao.imagem", e =>
                            {
                                e.UseRetry(r => r.Interval(5, TimeSpan.FromSeconds(1)));
                                e.Consumer<ProcessarSituacaoProposta>();
                            });
                        });

            bus.Start();

            Console.WriteLine("servico iniciado");

            _closing.WaitOne();
        }
    }
}