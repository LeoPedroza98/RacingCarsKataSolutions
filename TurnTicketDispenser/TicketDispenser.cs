namespace TDDMicroExercises.TurnTicketDispenser
{
    /// <summary>
    /// Dispensador de tickets de atendimento.
    /// </summary>
    public class TicketDispenser
    {
        private int _newTurnNumber;
        private readonly ITurnNumberSequence _turnNumberSequence;

        /// <summary>
        /// Inicializa uma nova instância de <see cref="TicketDispenser"/> usando a implementação padrão de <see cref="TurnNumberSequence"/>.
        /// </summary>
        public TicketDispenser() : this(new TurnNumberSequence())
        {
        }

        /// <summary>
        /// Inicializa uma nova instância de <see cref="TicketDispenser"/> usando uma implementação específica de <see cref="ITurnNumberSequence"/>.
        /// </summary>
        /// <param name="turnNumberSequence">Implementação de <see cref="ITurnNumberSequence"/>.</param>
        public TicketDispenser(ITurnNumberSequence turnNumberSequence)
        {
            _turnNumberSequence = turnNumberSequence;
        }

        /// <summary>
        /// Obtém um novo ticket de atendimento.
        /// </summary>
        /// <returns>Novo ticket de atendimento.</returns>
        public TurnTicket GetTurnTicket()
        {
            GetNextTurnNumber();
            var newTurnTicket = new TurnTicket(_newTurnNumber);

            return newTurnTicket;
        }

        /// <summary>
        /// Obtém o próximo número de turno usando a implementação de <see cref="ITurnNumberSequence"/>.
        /// </summary>
        private void GetNextTurnNumber()
        {
            _newTurnNumber = _turnNumberSequence.GetNextTurnNumber();
        }
    }
}