using System;

namespace TDDMicroExercises.TelemetrySystem
{
    /// <summary>
    /// Representa um cliente de telemetria que se conecta a um servidor de telemetria para enviar e receber dados.
    /// </summary>
    public class TelemetryClient : ITelemetryClient
    {
        /// <summary>
        /// Mensagem de diagnóstico padrão.
        /// </summary>
        public const string DiagnosticMessage = "AT#UD";

        // Resultado da mensagem de diagnóstico simulada
        private string _diagnosticMessageResult = string.Empty;

        // Simulador de eventos para testes
        private readonly IEventsSimulator _eventsSimulator;

        /// <summary>
        /// Inicializa uma nova instância de <see cref="TelemetryClient"/> com um simulador de eventos padrão.
        /// </summary>
        public TelemetryClient()
        {
            _eventsSimulator = new EventSimulator();
        }

        /// <summary>
        /// Inicializa uma nova instância de <see cref="TelemetryClient"/> com um simulador de eventos personalizado.
        /// </summary>
        /// <param name="eventsSimulator">Simulador de eventos a ser utilizado.</param>
        public TelemetryClient(IEventsSimulator eventsSimulator)
        {
            _eventsSimulator = eventsSimulator;
        }

        /// <summary>
        /// Obtém ou define o status online do cliente.
        /// </summary>
        public bool OnlineStatus { get; private set; }

        /// <summary>
        /// Conecta o cliente ao servidor de telemetria.
        /// </summary>
        /// <param name="telemetryServerConnectionString">String de conexão com o servidor de telemetria.</param>
        public void Connect(string telemetryServerConnectionString)
        {
            if (string.IsNullOrEmpty(telemetryServerConnectionString))
            {
                throw new ArgumentNullException();
            }

            // Simula a operação em um modem real
            OnlineStatus = _eventsSimulator.CanConnect();
        }

        /// <summary>
        /// Desconecta o cliente do servidor de telemetria.
        /// </summary>
        public void Disconnect()
        {
            OnlineStatus = false;
        }

        /// <summary>
        /// Envia uma mensagem para o servidor de telemetria.
        /// </summary>
        /// <param name="message">Mensagem a ser enviada.</param>
        public void Send(string message)
        {
            if (string.IsNullOrEmpty(message))
            {
                throw new ArgumentNullException();
            }

            if (message == DiagnosticMessage)
            {
                // Simula um relatório de status
                _diagnosticMessageResult = "LAST TX rate................ 100 MBPS\r\n"
                  + "HIGHEST TX rate............. 100 MBPS\r\n"
                  + "LAST RX rate................ 100 MBPS\r\n"
                  + "HIGHEST RX rate............. 100 MBPS\r\n"
                  + "BIT RATE.................... 100000000\r\n"
                  + "WORD LEN.................... 16\r\n"
                  + "WORD/FRAME.................. 511\r\n"
                  + "BITS/FRAME.................. 8192\r\n"
                  + "MODULATION TYPE............. PCM/FM\r\n"
                  + "TX Digital Los.............. 0.75\r\n"
                  + "RX Digital Los.............. 0.10\r\n"
                  + "BEP Test.................... -5\r\n"
                  + "Local Rtrn Count............ 00\r\n"
                  + "Remote Rtrn Count........... 00"; ;

                return;
            }

            // Aqui deveria ir a operação real de envio
        }

        /// <summary>
        /// Recebe uma mensagem do servidor de telemetria.
        /// </summary>
        /// <returns>Mensagem recebida.</returns>
        public string Receive()
        {
            string message;

            if (!string.IsNullOrEmpty(_diagnosticMessageResult))
            {
                // Se houver uma mensagem de diagnóstico simulada, retorna-a
                message = _diagnosticMessageResult;
                _diagnosticMessageResult = string.Empty;
            }
            else
            {
                // Simula uma mensagem recebida
                message = _eventsSimulator.Message();
            }

            return message;
        }
    }
}
