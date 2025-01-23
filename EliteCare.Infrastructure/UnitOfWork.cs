using EliteCare.Data.Entities;
using EliteCare.Infrastructure.Data;
using EliteCare.Infrastructure.Repository;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EliteCare.Infrastructure
{
    internal class UnitOfWork : IUnitOfWork ,IDisposable
    {
        private Hashtable DictRepo;
        public UnitOfWork (ApplicationDbContext db)
        {
            _db = db;
            DictRepo = new Hashtable();
        }

        public ApplicationDbContext _db { get; }

        public async Task<int> Commit()
        {
            try
            {

                return await _db.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return 0;
            }
        }

        public void Dispose()
        {
            _db.Dispose();
        }

        public IGenericRepository<T> Repo<T>() where T : BaseEntity, new()
        {
            var Key = typeof(T).Name;
            if (!DictRepo.ContainsKey(Key))
            {
                var repo = new GenericRepository<T>(_db);

                DictRepo.Add(Key, repo);
            }

            return (IGenericRepository<T>)DictRepo[Key];

        }
    }
