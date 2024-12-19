using NetCoreMVC.DataAccess.Data;
using NetCoreMVC.DataAccess.Repository.IRepository;
using NetCoreMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetCoreMVC.DataAccess.Repository
{
    public class ProductRepository : Repository<Product>, IProductRepository
    {
        private readonly ApplicationDbContext _db;

        public ProductRepository(ApplicationDbContext db) : base(db) 
        {
            _db = db;
        }

        //public void Save()
        //{
        //    _db.SaveChanges();
        //}

        public void Update(Product obj)
        {
            // 先讀出原來的資料
            var objFromDb = _db.PRODUCTS.FirstOrDefault(u => u.ID == obj.ID);

            if (objFromDb != null)
            {
                objFromDb.NAME = obj.NAME;
                objFromDb.SIZE = obj.SIZE;
                objFromDb.PRICE = obj.PRICE;
                objFromDb.DESCRIPTION = obj.DESCRIPTION;
                objFromDb.CATEGORYID = obj.CATEGORYID;
                if (objFromDb.IMAGEURL.Trim() != "")
                {
                    objFromDb.IMAGEURL = obj.IMAGEURL;
                }
            }
        }
    }
}
