using Moq;
using NUnit.Framework;
using WebApi.Coding.Assemblers;
using WebApi.Coding.Domain.Actions;
using WebApi.Coding.Domain.Data;
using WebApi.Speech;

namespace WebApi.Tests.Coding.Assemblers
{
    [TestFixture]
    public class ProgramParserTests
    {
        [Test]
        public void DoStuff()
        {
            var phraseQueueMock = new Mock<IPhraseQueue>();

            var programParser = new ProgramParser(data => new SayPhraseAction(data, phraseQueueMock.Object));

            var program = "If buttonColour = \"Green\"" + "\r\n" +
                "Then" + "\r\n" +
                    "Say \"Fish pie\"" + "\r\n" +
                "EndIf" + "\r\n" +
                "If buttonColour = \"Yellow\"" + "\r\n" +
                "Then" + "\r\n" +
                    "Say \"Fish Cakes\"" + "\r\n" +
                "EndIf";

            var variables = new[] { new VariableString("buttonColour", "Green") };

            programParser.ParseProgram("Test", program, variables);
        }
    }
}
