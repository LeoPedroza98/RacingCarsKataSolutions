namespace TDDMicroExercises.TelemetrySystem;

/// <summary>
/// Interface para o cliente de telemetria.
/// </summary>
public interface ITelemetryClient
{
    /// <summary>
    /// Obtém o status online do cliente de telemetria.
    /// </summary>
    bool OnlineStatus { get; }

    /// <summary>
    /// Conecta o cliente de telemetria ao servidor usando a conexão fornecida.
    /// </summary>
    /// <param name="telemetryServerConnectionString">String de conexão para o servidor de telemetria.</param>
    void Connect(string telemetryServerConnectionString);

    /// <summary>
    /// Desconecta o cliente de telemetria do servidor.
    /// </summary>
    void Disconnect();

    /// <summary>
    /// Envia uma mensagem para o servidor de telemetria.
    /// </summary>
    /// <param name="message">Mensagem a ser enviada.</param>
    void Send(string message);

    /// <summary>
    /// Recebe uma mensagem do servidor de telemetria.
    /// </summary>
    /// <returns>Mensagem recebida.</returns>
    string Receive();
}