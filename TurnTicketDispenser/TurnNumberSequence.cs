namespace TDDMicroExercises.TurnTicketDispenser
{
    /// <summary>
    /// Implementação da interface <see cref="ITurnNumberSequence"/> que fornece números de turno sequenciais.
    /// </summary>
    public class TurnNumberSequence : ITurnNumberSequence
    {
        private int _turnNumber = 0;

        /// <summary>
        /// Obtém o próximo número de turno na sequência.
        /// </summary>
        /// <returns>Próximo número de turno.</returns>
        public int GetNextTurnNumber()
        {
            return _turnNumber++;
        }
    }
}
