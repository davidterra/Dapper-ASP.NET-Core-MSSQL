using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using Dummy.Data;
using Dummy.ViewModel;

namespace Dummy.Repositories
{

    public class SalesRepository : ISalesRepository
    {
        private readonly IDb _db;
        public SalesRepository(IDb db) => _db = db;

        public async Task<List<TopSellerViewModel>> GetTopSeller(int top)
        {
            var sql = $@"SELECT TOP({top}) CONCAT(E.FirstName, ' ', E.LastName ) AS Fullname	
                        , COUNT(*) AS OrderTotal
                        , E.EmployeeID
                        , SUM(Sub.Subtotal) AS Subtotal
                    FROM Orders O INNER JOIN Employees E ON O.EmployeeID = E.EmployeeID
                        INNER JOIN (SELECT SUM(CONVERT(money,(OD.UnitPrice*OD.Quantity*(1-Discount)/100))*100) AS Subtotal			
                            , O.OrderID
                            FROM Orders O INNER JOIN [Order Details] OD ON  O.OrderID = OD.OrderID
                            GROUP BY O.OrderID) Sub ON Sub.OrderId = O.OrderId
                    GROUP BY CONCAT(E.FirstName, ' ', E.LastName ),  E.EmployeeID
                    ORDER BY SUM(Sub.Subtotal) DESC";

            var result = await _db.Connection.QueryAsync<TopSellerViewModel>(sql);

            return result.ToList();
        }

        public async Task<IEnumerable<OrdersTotalByYearViewModel>> GetOrdersTotalByYear()
        {
            var sql = @"SELECT YEAR(ShippedDate) AS year, COUNT(*) AS count 
                        FROM Orders
                        GROUP BY YEAR(ShippedDate)";

            var result = await _db.Connection.QueryAsync<OrdersTotalByYearViewModel>(sql);

            return result;

        }

    }
}