using System;
using System.Text;

namespace TDDMicroExercises.TelemetrySystem
{
    /// <summary>
    /// Simulador de eventos para o sistema de telemetria.
    /// </summary>
    public class EventSimulator : IEventsSimulator
    {
        private readonly Random _connectionEventsSimulator = new Random(42);

        /// <summary>
        /// Verifica se é possível estabelecer uma conexão.
        /// </summary>
        /// <returns>True se a conexão for possível, False caso contrário.</returns>
        public bool CanConnect() => _connectionEventsSimulator.Next(1, 10) <= 8;

        /// <summary>
        /// Gera uma mensagem simulada para telemetria.
        /// </summary>
        /// <returns>Mensagem simulada.</returns>
        public string Message()
        {
            var message = new StringBuilder();
            var length = _connectionEventsSimulator.Next(50, 110);
            for (var i = length; i >= 0; --i)
            {
                message.Append((char)_connectionEventsSimulator.Next(40, 126));
            }

            return message.ToString();
        }
    }
}