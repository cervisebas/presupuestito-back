using Microsoft.EntityFrameworkCore;
using PresupuestitoBack.DataAccess;
using PresupuestitoBack.Models;
using PresupuestitoBack.Repositories.IRepository;

namespace PresupuestitoBack.Repositories.Repository
{
    public class SettingRepository : Repository<Setting>, ISettingRepository
    {
        private readonly ApplicationDbContext _context;

        public SettingRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<Setting?> GetByLabelAsync(string label)
        {
                return await _context.Settings
                .Where(s => s.Label == label)
                .FirstOrDefaultAsync();
        }

        public async Task<Setting> UpdateOrCreateAsync(string label, string value)
        {
           var setting = await _context.Settings.FirstOrDefaultAsync(s => s.Label == label);

            if (setting == null)
            {
                setting = new Setting { Label = label, Value = value };
                await _context.Settings.AddAsync(setting);
            }
            else
            {
                setting.Value = value;
                _context.Settings.Update(setting);
            }

            await _context.SaveChangesAsync();
            return setting;
        }
        }
    }

