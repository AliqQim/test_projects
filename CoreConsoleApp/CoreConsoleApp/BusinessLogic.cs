using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace CoreConsoleApp
{
    public class BusinessLogic
    {
        private readonly IMyContext _context;

        public BusinessLogic(IMyContext context)
        {
            _context = context;
        }

        public async Task<List<JoinedOutput>> GetJoinedDataAsync()
        {
            return await _context.Persons.SelectMany(p=>p.Zamorochkas.Select(
                z=>new JoinedOutput(p.Name, z.Name))).ToListAsync();
        }

        public record JoinedOutput(string PersonName, string ZamorochkaName);
    }
}
