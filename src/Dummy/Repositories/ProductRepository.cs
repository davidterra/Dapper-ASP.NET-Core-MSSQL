using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using Dummy.Data;
using Dummy.Models;

namespace Dummy.Repositories
{

    public class ProductRepository : IProductRepository
    {
        private readonly IDb _db;
        public ProductRepository(IDb db) => this._db = db;

        public async Task<IEnumerable<Product>> GetAll()
        {
            var sql = @"SELECT P.*, C.*, S.* 
                        FROM Products P INNER JOIN Categories C ON P.CategoryID = C.CategoryID
                        INNER JOIN Suppliers S ON P.SupplierID = S.SupplierID";

            var products = await _db.Connection.QueryAsync<Product, Category, Supplier, Product>(sql,
            (p, c, s) =>
            {
                p.Category = c;
                p.Supplier = s;
                return p;
            },
            splitOn: "CategoryID,SupplierID");

            return products;

        }

        public async Task<IEnumerable<Category>> GetGroupByCategory(int? categoryID)
        {
            var sql = new StringBuilder();

            sql.Append(@" SELECT C.*, P.*");
            sql.AppendLine(" FROM Categories C INNER JOIN Products P ON C.CategoryID = P.CategoryID");
            sql.AppendLine(" WHERE 1 = 1 ");

            if(categoryID.HasValue)
                sql.AppendLine(" AND C.CategoryId = @categoryID");                

            
             var dict = new Dictionary<int, Category>();

            var result  = await _db.Connection.QueryAsync<Category, Product, Category>(sql.ToString(), 
            (c, p) =>
            {
                Category categoryEntry;

                if(!dict.TryGetValue(c.CategoryID, out categoryEntry))
                {
                    categoryEntry = c;
                    dict.Add(categoryEntry.CategoryID, categoryEntry);
                }

                categoryEntry.AddProduct(p);
                return categoryEntry;
            }, new { categoryID }
            , splitOn: "ProductID");

            return result
                .Distinct()
                .ToList();

        }
    }
}