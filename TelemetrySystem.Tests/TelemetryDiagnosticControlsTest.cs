using System;
using Moq;
using Shouldly;
using Xunit;

namespace TDDMicroExercises.TelemetrySystem.Tests
{
    public class TelemetryDiagnosticControlsTest
    {
        private readonly TelemetryDiagnosticControls _sut;
        private readonly Mock<ITelemetryClient> _client;

        public TelemetryDiagnosticControlsTest()
        {
            _client = new Mock<ITelemetryClient>();
            _sut = new TelemetryDiagnosticControls(_client.Object);

        }

        [Fact]
        public void CheckTransmission_dever�_enviar_uma_mensagem_diagn�stica_e_receber_uma_resposta_de_mensagem_de_status()
        {
            // Arrange
            var telemetryControl = new TelemetryDiagnosticControls();

            // Act
            telemetryControl.CheckTransmission();

            // Assert
            telemetryControl.DiagnosticInfo.ShouldNotBeNullOrEmpty();
            telemetryControl.DiagnosticInfo.ShouldContain( "WORD LEN");
        }

        [Fact]
        public void CheckTransmission_ComComandoDiagn�stico_DeveRetornarInforma��esDiagn�sticas()
        {
            // Arrange
            var expected = "expected return";
            _client.SetupSequence(x => x.OnlineStatus)
                .Returns(false)
                .Returns(true)
                .Returns(true);
            _client.Setup(x => x.Receive())
                .Returns(expected);

            // Act
            _sut.CheckTransmission();


            // Assert
            _sut.DiagnosticInfo.ShouldContain(expected);
        }

        [Fact]
        public void CheckTransmission_ComFalhaDeConex�o_DeveLan�arExce��o()
        {
            // Arrange
            var expectedMessage = "Unable to connect.";
            _client.SetupSequence(x => x.OnlineStatus)
                .Returns(false)
                .Returns(false)
                .Returns(false)
                .Returns(false);
            
            // Act
            // Assert
            Should.Throw<Exception>(() => _sut.CheckTransmission(), expectedMessage);
        }
    }
}
