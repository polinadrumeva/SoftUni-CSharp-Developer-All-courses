namespace MiniORM;

using System.Collections;

public class DbSet<TEntity> : ICollection<TEntity>
    where TEntity : class, new()
{
    internal DbSet(IEnumerable<TEntity> entities)
    {
        this.Entities = entities.ToList();
        this.ChangeTracker = new ChangeTracker<TEntity>(entities);
    }

    internal ChangeTracker<TEntity> ChangeTracker { get; set; }

    internal IList<TEntity> Entities { get; set; }

    public int Count
        => this.Entities.Count;

    public bool IsReadOnly
        => this.Entities.IsReadOnly;

    public void Add(TEntity entity)
    {
        if (entity == null)
        {
            throw new ArgumentNullException(nameof(entity), ExceptionMessages.EntityNullException);
        }

        this.Entities.Add(entity);
        this.ChangeTracker.Add(entity); 
    }

    public bool Remove(TEntity entity)
    {
        if (entity == null)
        {
            throw new ArgumentNullException(nameof(entity), ExceptionMessages.EntityNullException);
        }

        bool isRemoved = this.Entities.Remove(entity);
        if (isRemoved)
        {
            this.ChangeTracker.Remove(entity);
        }

        return isRemoved;
    }

    public void RemoveRange(IEnumerable<TEntity> entitiesToRemove)
    {
        foreach (TEntity entity in entitiesToRemove)
        {
            this.Remove(entity);
        }
    }

    public void Clear()
    {
        while (this.Entities.Any())
        {
            TEntity entityToRemove = this.Entities.First();
            this.Remove(entityToRemove);
        }
    }

    public bool Contains(TEntity item)
        => this.Entities.Contains(item);

    public void CopyTo(TEntity[] array, int arrayIndex)
        => this.Entities.CopyTo(array, arrayIndex);

    public IEnumerator<TEntity> GetEnumerator()
        => this.Entities.GetEnumerator();

    IEnumerator IEnumerable.GetEnumerator()
        => this.GetEnumerator();
}
