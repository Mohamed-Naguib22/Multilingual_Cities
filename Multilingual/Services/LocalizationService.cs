using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Multilingual.Data;
using Multilingual.Dtos;
using System.Reflection;

namespace Multilingual.Services
{
    public class LocalizationService : ILocalizationService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly ApplicationDbContext _context;
        public LocalizationService(IHttpContextAccessor httpContextAccessor, ApplicationDbContext context)
        {
            _httpContextAccessor = httpContextAccessor;
            _context = context;
        }

        public async Task TranslateToArabicIfArabicLanguageSelected<T>(IEnumerable<T> dtos)
                where T : BaseDto
        {
            if (IsArabicLanguageSelected())
            {
                await TranslateNamesToArabic(dtos, async (dto) =>
                {

                    string resourceValue = await GetStringResourceValueOfEntityById(dto.ID);
                    if (!resourceValue.IsNullOrEmpty())
                    {
                        // Assuming the DTO has a property named Name
                        PropertyInfo nameProperty = typeof(T).GetProperty("Name");
                        if (nameProperty != null)
                        {
                            nameProperty.SetValue(dto, resourceValue);
                        }
                    }
                });
            }

        }
        private bool IsArabicLanguageSelected()
        {
            if (_httpContextAccessor.HttpContext.Items.TryGetValue("Language", out var language))
            {
                return language.ToString() == "ar";
            }

            return false;
        }

        private async Task TranslateNamesToArabic<T>(IEnumerable<T> items, Func<T, Task> translateNameAsync)
        {
            foreach (var item in items)
            {
                await translateNameAsync(item);
            }
        }

        private async Task<string> GetStringResourceValueOfEntityById(Guid entityId)
        {
                return await GetArabicStringResourceValue(entityId);
        }

        private async Task<string> GetArabicStringResourceValue(Guid entityId)
        {
            var languageInArabic = await _context.Languages.FirstOrDefaultAsync(x => x.Culture == "ar");

            var stringResource = await _context.StringResources.FirstOrDefaultAsync(x => x.Key == entityId && x.LanguageId == languageInArabic.ID);

            if (stringResource == null) { return string.Empty; }

            return stringResource.Value;
        }
    }
}
