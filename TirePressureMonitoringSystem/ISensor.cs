namespace TDDMicroExercises.TirePressureMonitoringSystem;

/// <summary>
/// Interface que define o contrato para um sensor de pressão de pneus.
/// </summary>
public interface ISensor
{
    /// <summary>
    /// Obtém o próximo valor simulado da pressão em PSI.
    /// </summary>
    /// <returns>O próximo valor simulado da pressão em PSI.</returns>
    double PopNextPressurePsiValue();
}