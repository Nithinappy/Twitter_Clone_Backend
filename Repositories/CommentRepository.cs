using Twitter_Clone_Backend.Models;
using Dapper;
using Twitter_Clone_Backend.Utilities;
using Twitter_Clone_Backend.Repositories;

namespace Twitter_Clone_Backend.Repositories;

public interface ICommentRepository
{
    Task<Comment> Create(Comment Item);
    Task Delete(int Id);
    Task<List<Comment>> GetAllComments(int PostId);
    Task<Comment> GetById(int Id);
}

public class CommentRepository : BaseRepository, ICommentRepository
{
    public CommentRepository(IConfiguration config) : base(config)
    {

    }

    public async Task<Comment> Create(Comment Item)
    {
        var query = $@"INSERT INTO {TableNames.comments} (comment_text,post_id,user_id)
        VALUES (@CommentText,@PostId, @UserId) RETURNING *";

        using (var con = NewConnection)
            return await con.QuerySingleOrDefaultAsync<Comment>(query, Item);
    }

    public async Task Delete(int Id)
    {
        var query = $@"DELETE FROM {TableNames.comments} WHERE id = @Id";

        using (var con = NewConnection)
            await con.ExecuteAsync(query, new { Id });
    }

    public async Task<List<Comment>> GetAllComments(int PostId)
    {
        var query = $@"SELECT * FROM {TableNames.comments} WHERE post_id = @PostId";


        using (var con = NewConnection)
            return (await con.QueryAsync<Comment>(query, new { PostId })).AsList();
    }

    public async Task<Comment> GetById(int Id)
    {
        var query = $@"SELECT * FROM {TableNames.comments} WHERE id = @Id";

        using (var con = NewConnection)
            return await con.QuerySingleOrDefaultAsync<Comment>(query, new { Id });
    }


}