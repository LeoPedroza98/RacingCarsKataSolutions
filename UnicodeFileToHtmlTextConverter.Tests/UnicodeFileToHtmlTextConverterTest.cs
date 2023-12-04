using System;
using System.IO;
using System.Security.Cryptography;
using Moq;
using Shouldly;
using Xunit;

namespace TDDMicroExercises.UnicodeFileToHtmlTextConverter
{
    public class HikerTest
    {
        //ERRO

        ///// <summary>
        ///// Testa a conversão de um arquivo existente para HTML.
        ///// </summary>
        //[Fact(Skip = "Internal Step of TDD")]
        //public void Initial_ConvertToHtml_WithExistingFile_ShouldReturnValidHtml()
        //{
        //    // Arrange
        //    var fileName = "foobar.txt";
        //    var fullpath = $"C:\\Users\\leona\\Documents\\Desenvolvimento\\Infnet\\RacingCarKatas\\CSharp\\{fileName}";
        //    var part1 = "\"Mercedes\"&\"Hamilton\"";
        //    var part2 = "<TirePressure>12<TirePressure>";
        //    var httpUtility = new HttpUtility();
        //    var expectedResult = httpUtility.HtmlEncode(part1) +
        //                         "<br />" +
        //                         httpUtility.HtmlEncode(part2) +
        //                         "<br />";
        //    var converter = new UnicodeFileToHtmlTextConverter(fullpath);

        //    // Act
        //    var result = converter.ConvertToHtml();

        //    // Assert
        //    result.ShouldNotBeNullOrEmpty();
        //    result.ShouldBe(expectedResult);
        //}


        /// <summary>
        /// Testa a conversão de duas linhas para HTML.
        /// </summary>
        [Fact]
        public void ConverterParaHtml_2Linhas_DeveRetornar2LinhasEmHtml()
        {
            // Arrange
            var httpUtility = new Mock<IHttpUtility>();
            httpUtility.SetupSequence(x => x.HtmlEncode(It.IsAny<string>()))
                .Returns("1")
                .Returns("2");

            var textReader = new Mock<ITextReader>();
            var reader = new Mock<TextReader>();

            textReader.Setup(x => x.GetTextReader()).Returns(reader.Object);
            reader.SetupSequence(x => x.ReadLine())
                .Returns("1")
                .Returns("2")
                .Returns((string)null);

            var expectedResult = $"1<br />2<br />";
            var converter = new UnicodeFileToHtmlTextConverter(httpUtility.Object, textReader.Object);

            // Act
            var result = converter.ConverteHtml();

            // Assert
            result.ShouldNotBeNullOrEmpty();
            result.ShouldBe(expectedResult);
        }

        /// <summary>
        /// Testa a conversão de uma linha para HTML.
        /// </summary>
        [Fact]
        public void ConverterParaHtml_1Linha_DeveRetornar1LinhaEmHtml()
        {
            // Arrange
            var httpUtility = new Mock<IHttpUtility>();
            var textReader = new Mock<ITextReader>();
            var reader = new Mock<TextReader>();

            httpUtility.SetupSequence(x => x.HtmlEncode(It.IsAny<string>()))
                .Returns("1");
            textReader.Setup(x => x.GetTextReader())
                .Returns(reader.Object);
            reader.SetupSequence(x => x.ReadLine())
                .Returns("1")
                .Returns((string)null);

            var expectedResult = $"1<br />";
            var converter = new UnicodeFileToHtmlTextConverter(httpUtility.Object, textReader.Object);

            // Act
            var result = converter.ConverteHtml();

            // Assert
            result.ShouldNotBeNullOrEmpty();
            result.ShouldBe(expectedResult);
        }
    }
}
