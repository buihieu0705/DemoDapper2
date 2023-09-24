using Dapper;
using DemoDapper.Context;
using DemoDapper.Models;
using System.Data;

namespace DemoDapper.Repository
{
    public class CategoryRepository : BaseRepository<Category>, ICategoryRepository
    {

        public CategoryRepository(DapperContext db) : base(db)
        {
        }

        public async Task<Category> Create(CategoryRequest cat)
        {
            var query = "insert into category(categoryname,status) values(@categoryname, @status)";
            var parameters = new DynamicParameters();
            parameters.Add("categoryname", cat.CategoryName, DbType.String);
            parameters.Add("status", cat.Status, DbType.Boolean);
            using (var connection = db.CreateConnection())
            {
                var id = await connection.QuerySingleOrDefaultAsync<int>(query, parameters);
                var category = new Category
                {
                    Id = id,
                    CategoryName = cat.CategoryName,
                    Status = cat.Status
                };
                return category;
            }
        }

        public async Task Delete(int id)
        {
            var query = "delete from category where id=@id";
            using ( var connection = db.CreateConnection())
            {
                await connection.ExecuteAsync(query, new { id });
            }
        }

        public async Task<IEnumerable<Category>> GetAll()
        {
            var query = "Select * from category";
            using ( var connection = db.CreateConnection() )
            {
                var categories = await connection.QueryAsync<Category>( query );
                return categories;
            }
        }

        public async Task<Category> GetById(int id)
        {
            var query = "Select * from category where Id= @Id ";
            using (var connection = db.CreateConnection())
            {
                var category = await connection.QuerySingleOrDefaultAsync<Category>(query, new {id });
                return category;
            }
        }

        public async Task<Category> GetCategoryWithProducts(int id)
        {
            var query = "Select * from category where id=@id;Select * from products where categoryid=@id";
            using ( var connection = db.CreateConnection())
                using ( var multiple = await connection.QueryMultipleAsync(query, new { id}))
            {
                var category=await multiple.ReadSingleOrDefaultAsync<Category>();
                if (category != null)
                    category.Products = (await multiple.ReadAsync<Product>()).ToList();
                return category;
            }
        }

        public async Task Update(int id, CategoryRequest cat)
        {
            var query = "update category set categoryname= @name, status = @status where id=@id";
            var parameters = new DynamicParameters();
            parameters.Add("id", id);
            parameters.Add("name", cat.CategoryName);
            parameters.Add("status", cat.Status);
            using (var connection = db.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }
        }
    }
}
