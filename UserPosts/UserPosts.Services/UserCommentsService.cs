using System.Collections.Generic;
using System.Linq;
using UserPosts.Domain;

namespace UserPosts.Services
{
    public class UserCommentsService
    {
        private readonly IUserRepository userRepository;
        private readonly ICommentRepository commentRepository;
        private readonly IPostRepository postRepository;


        public UserCommentsService(IUserRepository userRepository, IPostRepository postRepository, ICommentRepository commentRepository )
        {
            this.userRepository = userRepository;
            this.postRepository = postRepository;
            this.commentRepository = commentRepository;

        }
        public UserComments GetUserComments(int id)
        {
            User user = this.userRepository.GetById(id);
            var posts = this.postRepository.GetPostsByUserId(user.Id);

           
            IList<Comment> comments = this.commentRepository.GetAll();
            
         IEnumerable<int> postsB = from post in posts
                              select post.Id;

            // IList<int> postsB = posts.Select(u => u.Id).ToList();
             

           var comm = from comment in comments
                      where postsB.Contains(comment.PostId)
                      select comment;
            UserComments result = new UserComments
            {
                User = user,
                Comments = comm.ToList(),
            };
            
                  
            return result;

        }
    }
     
public class UserComments
{
    public User User { get; set; }
    public IList<Comment> Comments { get; set; }
}
}
/* foreach (var item in posts)
            {
                //System.Console.WriteLine($"Item { item.Id}");
                var commentsPerPost = comments.Where(c => c.PostId == item.Id).ToList();
                foreach (Comment item1 in commentsPerPost)
                {
                   // System.Console.WriteLine($"commentsPerUser {item1.PostId}, {item1.Id}");
                    commentsPerUser.Add(item1);
                }
                

            }*/

