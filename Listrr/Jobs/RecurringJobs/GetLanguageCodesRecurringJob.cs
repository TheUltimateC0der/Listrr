﻿using Hangfire;
using Hangfire.Server;

using Listrr.Data;
using Listrr.Repositories;

using System.Globalization;
using System.Threading.Tasks;

namespace Listrr.Jobs.RecurringJobs
{

    [Queue("system")]
    public class GetLanguageCodesRecurringJob : IRecurringJob
    {
        private readonly ITraktCodeRepository _traktCodeRepository;

        public GetLanguageCodesRecurringJob(ITraktCodeRepository traktCodeRepository)
        {
            _traktCodeRepository = traktCodeRepository;
        }


        public async Task Execute(PerformContext context)
        {
            foreach (CultureInfo culture in CultureInfo.GetCultures(CultureTypes.NeutralCultures))
            {
                var languageCode = _traktCodeRepository.GetLanguageCode(culture.NativeName);

                if (languageCode == null)
                {
                    await _traktCodeRepository.CreateLanguageCode(
                        new LanguageCode()
                        {
                            Code = culture.TwoLetterISOLanguageName,
                            Name = culture.NativeName
                        }
                    );
                }
            }
        }
    }
}