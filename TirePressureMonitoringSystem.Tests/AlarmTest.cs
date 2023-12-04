using Moq;
using Shouldly;
using Xunit;

namespace TDDMicroExercises.TirePressureMonitoringSystem
{
    /// <summary>
    /// Conjunto de testes para a classe Alarm.
    /// </summary>
    public class AlarmTest
    {
        private readonly Mock<ISensor> _sensor;

        /// <summary>
        /// Inicializa uma nova instância da classe de testes.
        /// </summary>
        public AlarmTest()
        {
            _sensor = new Mock<ISensor>();
        }

        /// <summary>
        /// Verifica se o alarme está desativado após o início.
        /// </summary>
        [Fact]
        public void Alarm_AposIniciar_DeveRetornarFalso()
        {
            _sensor.Setup(x => x.PopNextPressurePsiValue()).Returns(Alarm.LowPressureThreshold + 1);
            var alarm = new Alarm(_sensor.Object);
            alarm.Check();
            alarm.AlarmOn.ShouldBeFalse();
        }

        /// <summary>
        /// Verifica se o alarme é ativado quando a pressão está fora dos limites permitidos.
        /// </summary>
        /// <param name="pressure">Valor de pressão fora dos limites.</param>
        [Theory]
        [InlineData(Alarm.LowPressureThreshold - 1)]
        [InlineData(Alarm.HighPressureThreshold + 1)]
        public void Alarm_ValoresExternos_DeveRetornarVerdadeiro(double pressure)
        {
            // Arrange
            _sensor.Setup(x => x.PopNextPressurePsiValue()).Returns(pressure);
            var alarm = new Alarm(_sensor.Object);
            
            // Act
            alarm.Check();
            
            // Assert
            alarm.AlarmOn.ShouldBeTrue();
        }

        /// <summary>
        /// Verifica se o alarme permanece ativado após ser acionado uma vez.
        /// </summary>
        [Fact]
        public void Alarm_AposDispararAlarmeUmaVez_DeveContinuarRetornandoVerdadeiro()
        {
            // Arrange
            _sensor.SetupSequence(x => x.PopNextPressurePsiValue())
                .Returns(Alarm.LowPressureThreshold - 1)
                .Returns(Alarm.HighPressureThreshold - 1)
                .Returns(Alarm.LowPressureThreshold + 1);
                
            var alarm = new Alarm(_sensor.Object);
            
            // Act
            alarm.Check();
            alarm.Check();
            alarm.Check();

            // Assert
            alarm.AlarmOn.ShouldBeTrue();
        }
    }
}
