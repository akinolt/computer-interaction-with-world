using WebApi.Interface.Enums;

namespace WebApi.Interface.Dtos
{
    public class PhraseToSay
    {
        public string Phrase { get; set; }

        public string Language { get; set; }

        public Gender Gender { get; set; }
    }
}
