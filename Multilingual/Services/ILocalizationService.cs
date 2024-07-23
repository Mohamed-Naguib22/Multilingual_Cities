using Multilingual.Dtos;

namespace Multilingual.Services
{
    public interface ILocalizationService
    {
        Task TranslateToArabicIfArabicLanguageSelected<T>(IEnumerable<T> dtos) where T : BaseDto;
    }
}