using System;
using Moq;
using Shouldly;
using Xunit;

namespace TDDMicroExercises.TelemetrySystem.Tests
{
    public class TelemetryClientTests
    {
        private readonly TelemetryClient _sut;
        private readonly Mock<IEventsSimulator> _eventsSimulator;

        public TelemetryClientTests()
        {
            _eventsSimulator = new Mock<IEventsSimulator>();
            _sut = new TelemetryClient(_eventsSimulator.Object);
        }

        /// <summary>
        /// Testa a conexão bem-sucedida com uma string de conexão válida.
        /// </summary>
        [Fact]
        public void Conectar_ComCadeiaDeConexãoVálida_DeveConectarComSucesso()
        {
            // Act
            _eventsSimulator.Setup(x => x.CanConnect()).Returns(true);
            _sut.Connect("anyConnection");

            // Assert
            _sut.OnlineStatus.ShouldBeTrue();
        }

        /// <summary>
        /// Testa a tentativa de conexão com uma string de conexão inválida, esperando uma exceção.
        /// </summary>
        [Fact]
        public void Conectar_ComCadeiaDeConexãoInválida_DeveLançarExceção()
        {
            // Act & Assert
            Should.Throw<ArgumentNullException>(() => _sut.Connect(string.Empty));
        }

        /// <summary>
        /// Testa a desconexão bem-sucedida após uma conexão válida.
        /// </summary>
        [Fact]
        public void Desconectar_DeveDesconectarComSucesso()
        {
            // Arrange
            _eventsSimulator.Setup(x => x.CanConnect()).Returns(true);
            _sut.Connect("anyConnection");
            _sut.OnlineStatus.ShouldBeTrue();

            // Act
            _sut.Disconnect();

            // Assert
            _sut.OnlineStatus.ShouldBeFalse();
        }

        /// <summary>
        /// Testa o envio bem-sucedido de uma mensagem após uma conexão válida.
        /// </summary>
        [Fact]
        public void Enviar_ComComentárioVálido_DeveCriarUmaMensagemComSucesso()
        {
            // Arrange
            _eventsSimulator.Setup(x => x.CanConnect()).Returns(true);
            _sut.Connect("anyConnection");
            _sut.OnlineStatus.ShouldBeTrue();
            var expectedMessage = MensagemDiagnósticaEsperada();

            // Act
            _sut.Send(TelemetryClient.DiagnosticMessage);
            var result = _sut.Receive();

            // Assert
            result.ShouldNotBeNullOrEmpty();
            result.ShouldBe(expectedMessage);
        }

        /// <summary>
        /// Testa a tentativa de envio de uma mensagem com uma string de conexão inválida, esperando uma exceção.
        /// </summary>
        [Fact]
        public void Enviar_ComCadeiaDeConexãoInválida_DeveLançarExceção()
        {
            // Act & Assert
            Should.Throw<ArgumentNullException>(() => _sut.Send(string.Empty));
        }

        /// <summary>
        /// Testa se o método Receive retorna uma mensagem diferente daquela enviada.
        /// </summary>
        [Fact]
        public void Receber_EnviarComMensagemDiferente_DeveRetornarMensagemAleatória()
        {
            // Arrange
            var expectedMessage = "Believe_And_Work_Hard";
            _eventsSimulator.Setup(x => x.Message()).Returns(expectedMessage);

            // Act
            _sut.Send("random");
            var result = _sut.Receive();

            // Assert
            result.ShouldNotBeNullOrEmpty();
            result.ShouldBe(expectedMessage);
        }

        /// <summary>
        /// Método utilitário para obter uma mensagem de diagnóstico esperada.
        /// </summary>
        /// <returns>Mensagem de diagnóstico esperada.</returns>
        private static string MensagemDiagnósticaEsperada()
        {
            var expectedMessage =
                    "LAST TX rate................ 100 MBPS\r\n"
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
            return expectedMessage;
        }
    }
}