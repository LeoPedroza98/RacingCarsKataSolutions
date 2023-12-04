namespace TDDMicroExercises.TurnTicketDispenser;

/// <summary>
/// Interface para fornecer números de turno.
/// </summary>
public interface ITurnNumberSequence
{
    /// <summary>
    /// Obtém o próximo número de turno na sequência.
    /// </summary>
    /// <returns>Próximo número de turno.</returns>
    int GetNextTurnNumber();
}