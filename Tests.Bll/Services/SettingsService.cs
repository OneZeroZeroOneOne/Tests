using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Tests.Dal.Contexts;

namespace Tests.Bll.Services
{
    public class SettingsService
    {
        private readonly MainContext _context;
        public SettingsService(MainContext context)
        {
            _context = context;
        }

        public async Task<string> GetLoginUrl()
        {
            return (await _context.GlobalSetting.FirstOrDefaultAsync(x => x.Key == "LoginUrl")).StringValue;
        }

        public async Task<string> GetMailjetApiKey()
        {
            return (await _context.GlobalSetting.FirstOrDefaultAsync(x => x.Key == "MailjetApiKey")).StringValue;
        }

        public async Task<string> GetMailjetApiSecret()
        {
            return (await _context.GlobalSetting.FirstOrDefaultAsync(x => x.Key == "MailjetApiSecret")).StringValue;
        }

    }
}
