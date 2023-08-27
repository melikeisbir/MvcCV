using MvcCV.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcCV.Repositories
{
    public class GenericRepository<T> where T: class, new()  //iskelet oluşturma . <T> sınıf 
    {
        DbCVEntities db= new DbCVEntities();
        public List<T> List()  //Listeleme
        {
            return db.Set<T>().ToList();
        }
        public void TAdd(T p) //Ekleme
        {
            db.Set<T>().Add(p);
            db.SaveChanges();
        }
        public void TDelete(T p) //Silme
        {
            db.Set<T>().Remove(p);
            db.SaveChanges();
        }
        public T TGet(int id) //ID'ye göre getirme
        {
            return db.Set<T>().Find(id);

        }
        public void TUpdate(T p)
        {
            db.SaveChanges();
        }
    }
}