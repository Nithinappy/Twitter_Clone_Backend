using Twitter_Clone_Backend.Models;
using Dapper;
using Twitter_Clone_Backend.Utilities;
using Twitter_Clone_Backend.Repositories;

namespace Twitter_Clone_Backend.Repositories;

public interface IPostRepository
{
    Task<Post> Create(Post Item);
    Task Update(Post Item);
    Task Delete(int Id);
    Task<List<Post>> GetAll();
    Task<Post> GetById(int TodoId);
}

public class PostRepository : BaseRepository, IPostRepository
{
    public PostRepository(IConfiguration config) : base(config)
    {

    }

    public async Task<Post> Create(Post Item)
    {
        var query = $@"INSERT INTO {TableNames.posts} (title,user_id)
        VALUES (@Title, @UserId) RETURNING *";

        using (var con = NewConnection)
            return await con.QuerySingleOrDefaultAsync<Post>(query, Item);
    }

    public async Task Delete(int Id)
    {
        var query = $@"DELETE FROM {TableNames.posts} WHERE id = @Id";

        using (var con = NewConnection)
            await con.ExecuteAsync(query, new { Id });
    }

    public async Task<List<Post>> GetAll()
    {
        var query = $@"SELECT * FROM {TableNames.posts} ORDER BY created_at DESC";

        using (var con = NewConnection)
            return (await con.QueryAsync<Post>(query)).AsList();
    }

    public async Task<Post> GetById(int UserId)
    {
        var query = $@"SELECT * FROM {TableNames.posts} WHERE user_id = @UserId";

        using (var con = NewConnection)
            return await con.QuerySingleOrDefaultAsync<Post>(query, new { UserId });
    }

    public async Task Update(Post Item)
    {
        var query = $@"UPDATE {TableNames.posts} SET title = @Title,
        updated_at =now() WHERE id = @Id";

        using (var con = NewConnection)
            await con.ExecuteAsync(query, Item);
    }
}