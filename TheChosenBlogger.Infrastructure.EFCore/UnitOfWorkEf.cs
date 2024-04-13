using Common.Infrastructure;

namespace TheChosenBlogger.Infrastructure.EFCore;

public class UnitOfWorkEf(TheChosenBloggerContext context) : IUnitOfWork
{
    public void BeginTran() => context.Database.BeginTransaction();
    public void CommitTran()
    {
        context.Database.CommitTransaction();
        context.SaveChanges();
    }

    public void Rollback() => context.Database.RollbackTransaction();
}
