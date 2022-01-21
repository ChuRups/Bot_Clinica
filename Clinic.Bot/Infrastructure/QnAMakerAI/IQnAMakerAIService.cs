using Microsoft.Bot.Builder.AI.QnA;

namespace Clinic.Bot.Infrastructure.QnAMakerAI
{
    public interface IQnAMakerAIService
    {
        QnAMaker _qnaMakerResult { get; set; }
    }
}
