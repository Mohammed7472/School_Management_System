using Microsoft.EntityFrameworkCore;
using School_Management_System.Data;

namespace School_Management_System.Repos.Abstraction;

public interface IGenericRepo<TEntity> where TEntity : class
{
    public List<TEntity> GetAll();
    public TEntity GetById(int id);
    public void Create(TEntity entity);
    public void Update(TEntity entity);
    public void Delete(int id);
    public void Save();

}
