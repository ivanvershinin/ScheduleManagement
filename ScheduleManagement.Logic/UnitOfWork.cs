using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ScheduleManagement.Logic.Repository;

namespace ScheduleManagement.Logic
{
    public class UnitOfWork : IDisposable
    {
        Context _context = new Context();

        public CabinetRepository CRs { get; }
        public TutorRepository TRs { get; }
        public SchoolRepostory SRs { get; }
        public TutorCabinetRepository TCRs { get; }

        public UnitOfWork()
        {
            CRs = new CabinetRepository(_context);
            TRs = new TutorRepository(_context);
            SRs = new SchoolRepostory(_context);
            TCRs = new TutorCabinetRepository(_context);
        }

        public void Complete()
        {
            _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
