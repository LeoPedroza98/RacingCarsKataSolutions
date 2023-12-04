using System;
using Xunit;

namespace TDDMicroExercises.TelemetrySystem
{
    /// <summary>
    /// Classe respons�vel por controlar o diagn�stico de telemetria.
    /// </summary>
    public class TelemetryDiagnosticControls
    {
        // Constante que representa a string de conex�o do canal de diagn�stico.
        private const string DiagnosticChannelConnectionString = "*111#";

        // Cliente de telemetria utilizado para enviar e receber mensagens.
        private readonly ITelemetryClient _telemetryClient;

        /// <summary>
        /// Inicializa uma nova inst�ncia de <see cref="TelemetryDiagnosticControls"/> utilizando uma implementa��o padr�o de <see cref="TelemetryClient"/>.
        /// </summary>
        public TelemetryDiagnosticControls()
        {
            _telemetryClient = new TelemetryClient();
        }

        /// <summary>
        /// Inicializa uma nova inst�ncia de <see cref="TelemetryDiagnosticControls"/> utilizando uma implementa��o espec�fica de <see cref="ITelemetryClient"/>.
        /// </summary>
        /// <param name="telemetryClient">Implementa��o de <see cref="ITelemetryClient"/>.</param>
        public TelemetryDiagnosticControls(ITelemetryClient telemetryClient)
        {
            _telemetryClient = telemetryClient;
        }

        /// <summary>
        /// Obt�m ou define as informa��es de diagn�stico.
        /// </summary>
        public string DiagnosticInfo { get; set; }

        /// <summary>
        /// Realiza a verifica��o da transmiss�o de telemetria.
        /// </summary>
        public void CheckTransmission()
        {
            DiagnosticInfo = string.Empty;
            OpenConnection();
            _telemetryClient.Send(TelemetryClient.DiagnosticMessage);
            DiagnosticInfo = _telemetryClient.Receive();
        }

        /// <summary>
        /// Abre a conex�o com o canal de diagn�stico.
        /// </summary>
        private void OpenConnection()
        {
            _telemetryClient.Disconnect();

            int retryLeft = 3;
            while (_telemetryClient.OnlineStatus == false && retryLeft > 0)
            {
                _telemetryClient.Connect(DiagnosticChannelConnectionString);
                retryLeft -= 1;
            }

            if (_telemetryClient.OnlineStatus == false)
            {
                throw new Exception("Unable to connect.");
            }
        }
    }
}
