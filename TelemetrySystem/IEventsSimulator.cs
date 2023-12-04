namespace TDDMicroExercises.TelemetrySystem;

/// <summary>
/// Interface para um simulador de eventos.
/// </summary>
public interface IEventsSimulator
{
    /// <summary>
    /// Verifica se é possível conectar ao simulador de eventos.
    /// </summary>
    /// <returns>True se a conexão for possível, caso contrário, false.</returns>
    bool CanConnect();

    /// <summary>
    /// Obtém uma mensagem do simulador de eventos.
    /// </summary>
    /// <returns>Mensagem do simulador de eventos.</returns>
    string Message();
}