using Microsoft.Bot.Builder.AI.Luis;

namespace Clinic.Bot.Infrastructure.Luis
{
    public interface ILuisService
    {
        LuisRecognizer _recognizer { get; }
    }
}
