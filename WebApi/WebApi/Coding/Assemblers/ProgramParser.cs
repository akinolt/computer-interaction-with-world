using System;
using System.Collections.Generic;
using System.Linq;
using WebApi.Coding.Domain.Actions;
using WebApi.Coding.Domain.Conditionals;
using WebApi.Coding.Domain.Data;

namespace WebApi.Coding.Assemblers
{
    public interface IProgramParser
    {
        Domain.Program ParseProgram(string programName, string program, IEnumerable<IVariable> externalVariables);
    }

    public class ProgramParser : IProgramParser
    {
        private readonly Func<IData, SayPhraseAction> sayPhraseActionFactory;

        public ProgramParser(Func<IData, SayPhraseAction> sayPhraseActionFactory)
        {
            this.sayPhraseActionFactory = sayPhraseActionFactory;
        }

        public Domain.Program ParseProgram(string programName, string program, IEnumerable<IVariable> externalVariables)
        {
            // First, put spaces around any equals characters, to ensure they are recognised as separate tokens
            program = program.Replace("=", " = ");

            // Split by quote character, so that quoted bits are treated as single units, even if they contain spaces
            var quotedBits = program.Split(new[] { '\"' });

            var programTokens = new List<string>();
            var insideQuote = false;
            foreach (var quotedBit in quotedBits)
            {
                if (!insideQuote)
                {
                    // For non quoted, split the code into tokens, separated by spaces or newlines
                    programTokens.AddRange(program.Split(new[] { '\n', '\r', ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries));
                }
                else
                {
                    programTokens.Add("\"" + quotedBit + "\"");
                }

                insideQuote = !insideQuote;
            }

            
            var actions = ParseActionList(programTokens);

            return null;
            ////var root = new Domain.Program(programName);

            ////return root;
        }

        private ActionList ParseActionList(IEnumerable<string> tokens)
        {
            var tokensList = tokens.ToList();

            var actions = new List<IAction>();
            while (tokensList.Any())
            {
                if (string.Equals(tokensList.First(), "If", StringComparison.OrdinalIgnoreCase))
                {
                    var endIfLoc = tokensList.FindIndex(x => string.Equals(x, "EndIf", StringComparison.OrdinalIgnoreCase));
                    if (endIfLoc < 0)
                    {
                        throw new Exception("If without EndIf");
                    }

                    actions.Add(this.ParseIfStatement(tokensList.Take(endIfLoc)));
                    tokensList = tokensList.Skip(endIfLoc).ToList();
                    continue;
                }

                if (string.Equals(tokensList.First(), "Say", StringComparison.OrdinalIgnoreCase))
                {
                    var dataToken = tokensList.Skip(1).Take(1).Single();
                    var data = this.ParseData(dataToken);
                    actions.Add(this.sayPhraseActionFactory(data));
                    tokensList = tokensList.Skip(2).ToList();
                    continue;
                }
            }

            return null;
        }

        private IfThenAction ParseIfStatement(IEnumerable<string> tokens)
        {
            var tokensList = tokens.ToList();
            if (tokensList[2] != "=" || !string.Equals(tokensList[4], "Then", StringComparison.OrdinalIgnoreCase))
            {
                throw new Exception("Can currently only parse If statements of the form If x = y Then ... EndIf");
            }

            var operand1 = this.ParseData(tokensList[1]);
            var operand2 = this.ParseData(tokensList[3]);
            var actionList = this.ParseActionList(tokensList.Skip(5).Take(tokensList.Count - 6));

            return new IfThenAction(new Equals(operand1, operand2), actionList);
        }

        private IData ParseData(string token)
        {
            if (token.Contains("\""))
            {
                // Constant
                return new ConstantString(token.Skip(1).Take(token.Length - 2).ToString());
            }

            return new VariableString(token);
        }
    }
}