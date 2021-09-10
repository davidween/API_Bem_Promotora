using System;
using System.Threading;
using System.Threading.Tasks;
using GreenPipes;
using MassTransit;

namespace MicroServices
{
    class Program
    {
        private static readonly AutoResetEvent _closing = new AutoResetEvent(false);
        static async Task Main(string[] args)
        {
            var busControl = Bus.Factory.CreateUsingRabbitMq(config =>
                        {
                            config.Host(new Uri($"rabbitmq://localhost"), host =>
                            {
                                host.Username("guest");  // padrão
                                host.Password("guest");
                            });

                            config.ReceiveEndpoint("fila-propostas", e =>
                            {
                                e.UseRetry(r => r.Interval(5, TimeSpan.FromSeconds(1)));
                                e.Consumer<ProcessarSituacaoProposta>();
                            });
                        });

            await busControl.StartAsync();

            Console.WriteLine("Servico Iniciado");

            _closing.WaitOne();

            /*
            try
            {
                await busControl.StartAsync();

                await Task.Run(() =>
                {
                    Console.WriteLine("Iniciado. Precione ENTER para sair.");
                    Console.ReadLine();
                });
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
            finally
            {
                await busControl.StopAsync();
            }*/
        }
    }
}