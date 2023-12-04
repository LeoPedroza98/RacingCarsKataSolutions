using System;

namespace TDDMicroExercises.TirePressureMonitoringSystem
{
    /// <summary>
    /// Implementação concreta da interface ISensor que simula um sensor de pressão de pneus.
    /// </summary>
    public class Sensor : ISensor
    {
        private const double Offset = 16;

        /// <summary>
        /// Obtém o próximo valor simulado da pressão em PSI.
        /// </summary>
        /// <returns>O próximo valor simulado da pressão em PSI.</returns>
        public double PopNextPressurePsiValue()
        {
            double pressureTelemetryValue;
            SamplePressure(out pressureTelemetryValue);

            return Offset + pressureTelemetryValue;
        }

        private static void SamplePressure(out double pressureTelemetryValue)
        {
            // Implementação de espaço reservado que simula um sensor real em um pneu real
            Random basicRandomNumbersGenerator = new Random();
            pressureTelemetryValue = 6 * basicRandomNumbersGenerator.NextDouble() * basicRandomNumbersGenerator.NextDouble();
        }
    }
}
