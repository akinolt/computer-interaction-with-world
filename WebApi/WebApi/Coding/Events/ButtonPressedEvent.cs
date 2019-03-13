using WebApi.Coding.Domain.Data;

namespace WebApi.Coding.Events
{
    public interface IButtonPressedEvent
    {
        void Trigger(string buttonColour);
    }

    public class ButtonPressedEvent : IButtonPressedEvent
    {
        private readonly IProgramQueue programQueue;

        public ButtonPressedEvent(IProgramQueue programQueue)
        {
            this.programQueue = programQueue;
        }

        public void Trigger(string buttonColour)
        {
            var variableString = new VariableString("buttonColour");
            variableString.SetValue(buttonColour);
            this.programQueue.CurrentProgram.RunWithStringParameter(variableString);
        }
    }
}
