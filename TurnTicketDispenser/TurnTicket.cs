namespace TDDMicroExercises.TurnTicketDispenser
{
    /// <summary>
    /// Representa um ticket de atendimento com um número de turno.
    /// </summary>
    public class TurnTicket
    {
        /// <summary>
        /// Inicializa uma nova instância de <see cref="TurnTicket"/> com o número de turno especificado.
        /// </summary>
        /// <param name="turnNumber">Número de turno associado ao ticket.</param>
        public TurnTicket(int turnNumber)
        {
            TurnNumber = turnNumber;
        }

        /// <summary>
        /// Obtém o número de turno associado ao ticket (somente leitura).
        /// </summary>
        public int TurnNumber { get; }
    }
}