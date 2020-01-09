using System.Collections.Generic;
using System.Linq;
using UserPosts.Domain;
using UserPosts.Services;

namespace UserPosts.Data
{
    public class CommentDataAccess : BaseDataAccess<Comment>, ICommentRepository
    {
        public IList<Comment> GetCommentsByPostId(int id)
        {
            var list = this.GetAll();
            return list.Where(x => x.PostId == id).ToList();
        }

        protected override string GetFile()
        {
            return @"..\..\..\UserPosts.Data\Files\coments.json";
        }
    }

}
