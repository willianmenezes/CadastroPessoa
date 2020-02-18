using Repository.Contexts;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repository.Repositories
{
    public class BaseRepository : IDisposable
    {
        protected Context _context { get; set; }

        public BaseRepository(Context context)
        {
            _context = context;
        }

        public void Dispose()
        {
            if (_context != null)
            {
                _context.Dispose();
            }
        }
    }
}
