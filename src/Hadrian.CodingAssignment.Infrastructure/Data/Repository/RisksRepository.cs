using Hadrian.CodingAssignment.Infrastructure.Model;
using Microsoft.EntityFrameworkCore;

namespace Hadrian.CodingAssignment.Infrastructure.Data.Repository;

public class RisksRepository
{
    private readonly DbSet<Risk> _dbSet;

    public RisksRepository(DbContext context)
    {
        _dbSet = context.Set<Risk>();
    }

    public IQueryable<Risk> BuildQuery()
    {
        return _dbSet;
    }

    public void Add(Risk item)
    {
        _dbSet.Add(item);
    }

    public void Remove(Risk item)
    {
        _dbSet.Remove(item);
    }
}
