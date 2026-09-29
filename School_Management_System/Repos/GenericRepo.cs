using Microsoft.EntityFrameworkCore;
using School_Management_System.Data;
using School_Management_System.Models;
using School_Management_System.Repos.Abstraction;

namespace School_Management_System.Repos;

public class GenericRepo<TEntity> : IGenericRepo<TEntity> where TEntity : class
{
    private readonly AppDbContext context;

    public GenericRepo(AppDbContext context)
    {
        this.context = context;
    }

    public List<TEntity> GetAll()
    {
        return context.Set<TEntity>().ToList();
    }
    public TEntity GetById(int id)
    {
        return context.Set<TEntity>().Find(id);
    }
    public void Create(TEntity entity)
    {
        context.Set<TEntity>().Add(entity);
    }

    public void Update(TEntity entity)
    {
        context.Set<TEntity>().Update(entity);
        //context.Entry(entity).State = EntityState.Modified;
    }
    public void Delete(int id)
    {
        var dbEntity = context.Set<TEntity>().Find(id);

        if (dbEntity != null)
        {
            context.Set<TEntity>().Remove(dbEntity);
        }
    }
    public void Save()
    {
        context.SaveChanges();
    }

}
