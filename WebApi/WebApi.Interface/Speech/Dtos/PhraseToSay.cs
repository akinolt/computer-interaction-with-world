using WebApi.Interface.Speech.Enums;

namespace WebApi.Interface.Speech.Dtos
{
    public class PhraseToSay
    {
        public string Phrase { get; set; }

        public string Language { get; set; }

        public Gender Gender { get; set; }
    }
}
