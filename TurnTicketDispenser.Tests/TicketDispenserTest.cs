using Moq;
using Shouldly;
using Xunit;

namespace TDDMicroExercises.TurnTicketDispenser.Tests
{
    public class TicketDispenserTest
    {
        /// <summary>
        /// Testa se, a cada chamada, um novo ticket de atendimento é retornado com números de turno incrementais.
        /// </summary>
        [Fact]
        public void TicketDispenser_CadaChamada_DeveRetornarUmNovoTicket()
        {
            // Arrange
            var ticketDispenser = new TicketDispenser();

            // Act
            var firstTicket = ticketDispenser.GetTurnTicket();
            var secondTicket = ticketDispenser.GetTurnTicket();
            var thirdTicket = ticketDispenser.GetTurnTicket();

            // Assert
            firstTicket.TurnNumber.ShouldBe(0);
            secondTicket.TurnNumber.ShouldBe(1);
            thirdTicket.TurnNumber.ShouldBe(2);
        }

        /// <summary>
        /// Testa se, ao usar várias instâncias de TicketDispenser, não há duplicação de números de turno.
        /// </summary>
        [Fact]
        public void TicketDispenser_ComMultiplasInstancias_NaoDeveDuplicarNumeros()
        {
            // Arrange
            var turnNumberSequence = new TurnNumberSequence();
            var ticketDispenser1 = new TicketDispenser(turnNumberSequence);
            var ticketDispenser2 = new TicketDispenser(turnNumberSequence);

            // Act
            var firstTicketFromDispenser1 = ticketDispenser1.GetTurnTicket();
            var firstTicketFromDispenser2 = ticketDispenser2.GetTurnTicket();
            var secondTicketFromDispenser1 = ticketDispenser1.GetTurnTicket();

            // Assert
            firstTicketFromDispenser1.TurnNumber.ShouldBe(0);
            firstTicketFromDispenser2.TurnNumber.ShouldBe(1);
            secondTicketFromDispenser1.TurnNumber.ShouldBe(2);
        }

        /// <summary>
        /// Testa se o TicketDispenser, quando usando uma sequência de números de turno mockada,
        /// retorna corretamente o próximo número de turno conforme definido no mock.
        /// </summary>
        [Fact]
        public void TicketDispenser_UltimoTicketFoi26_DeveRetornar27()
        {
            // Arrange
            var turnNumberMock = new Mock<ITurnNumberSequence>();
            turnNumberMock.Setup(x => x.GetNextTurnNumber()).Returns(27);

            var ticketDispenser = new TicketDispenser(turnNumberMock.Object);

            // Act
            var nextTicket = ticketDispenser.GetTurnTicket();

            // Assert
            nextTicket.TurnNumber.ShouldBe(27);
        }
    }
}