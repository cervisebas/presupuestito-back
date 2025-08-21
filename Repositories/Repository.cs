using Microsoft.EntityFrameworkCore;
using PresupuestitoBack.DataAccess;
using PresupuestitoBack.Repositories.IRepositories;
using System.Linq.Expressions;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using System.Reflection;

namespace PresupuestitoBack.Repositories
{
    public class Repository<T> : IRepository<T> where T : class
    {
        protected readonly ApplicationDbContext _context;
        internal DbSet<T> dbSet;

        public Repository(ApplicationDbContext context)
        {
            _context = context;
            this.dbSet = _context.Set<T>();
        }

        public virtual async Task<List<T>> GetAll(Expression<Func<T, bool>>? filter = null)
        {
            
            IQueryable<T> query = dbSet;
            if (filter != null)
            {
                query = query.Where(filter);
            }

            return await query.ToListAsync();
        }

        
        public virtual async Task<bool> Insert(T entity)
        {
            try
            {
                // Obtener la propiedad clave
                var keyProperty = GetKeyProperty();

                // Obtener el valor de la clave primaria
                var entityId = keyProperty.GetValue(entity);

                // Verificar si la entidad ya existe
                if (await EntityExists(keyProperty, entityId))
                {
                    return false; // La entidad ya existe
                }

                // Agregar la entidad y guardar cambios
                await AddEntity(entity);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        private PropertyInfo GetKeyProperty()
        {
            var keyProperty = typeof(T).GetProperties()
                .FirstOrDefault(prop => prop.IsDefined(typeof(KeyAttribute), false));

            if (keyProperty == null)
            {
                throw new InvalidOperationException($"La entidad {typeof(T).Name} no tiene una propiedad marcada con [Key].");
            }

            return keyProperty;
        }

        private async Task<bool> EntityExists(PropertyInfo keyProperty, object entityId)
        {
            var existingEntity = await _context.Set<T>().FirstOrDefaultAsync(e => keyProperty.GetValue(e).Equals(entityId));
            return existingEntity != null;
        }

        private async Task AddEntity(T entity)
        {
            _context.Set<T>().Add(entity);
            await _context.SaveChangesAsync();
        }



        public async virtual Task<T?> GetById(int id)
        {
            return await dbSet.FindAsync(id);
        }

        public virtual async Task<bool> Update(T entity)
        {
            try
            {
                // Obtener la propiedad clave
                var keyProperty = GetKeyProperty();

                // Obtener el valor de la clave primaria
                var entityId = keyProperty.GetValue(entity);

                // Buscar la entidad existente en la base de datos
                var existingEntity = await _context.Set<T>().FindAsync(entityId);
                if (existingEntity == null)
                {
                    return false; // La entidad no existe
                }

                // Actualizar los valores de la entidad existente con los valores de la entidad actualizada
                _context.Entry(existingEntity).CurrentValues.SetValues(entity);

                // Guardar los cambios
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        /*
        public virtual async Task<bool> Delete(int id)
        {
            try
            {
                // Obtener la propiedad clave
                var keyProperty = GetKeyProperty();

                // Verificar si la entidad existe
                if (!await EntityExists(keyProperty, id))
                {
                    return false; // La entidad no existe
                }

                // Obtener la entidad por su ID
                var entity = await GetById(x => keyProperty.GetValue(x).Equals(id));
                if (entity == null) return false;

                // Eliminar la entidad
                dbSet.Remove(entity);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                
                // loguear la excepcion: _logger.LogError(ex, "Error al eliminar la entidad");

                return false; // Retornar false si ocurre un error
            }
        }
        */

    }
}
