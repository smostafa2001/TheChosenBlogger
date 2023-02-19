using _01.Framework.Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace MasterBlogger.Infrastructure.EFCore
{
    public class UnitOfWorkEf : IUnitOfWork
    {
        private readonly MasterBloggerContext _context;
        public UnitOfWorkEf(MasterBloggerContext context) => _context = context;
        public void BeginTran() => _context.Database.BeginTransaction();
        public void CommitTran()
        {
            _context.Database.CommitTransaction();
            _context.SaveChanges();
        }

        public void Rollback() => _context.Database.RollbackTransaction();
    }
}
