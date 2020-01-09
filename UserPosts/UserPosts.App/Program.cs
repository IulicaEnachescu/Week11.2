using System;
using UserPosts.Data;
using UserPosts.Domain;
using UserPosts.Services;


namespace UserPosts.App
{
    public class Program
    {
        static void Main(string[] args)
        {
            IPostRepository postRepository = new PostDataAccess();
            IUserRepository userRepository = new UserDataAccess();
            ICommentRepository commentRepository = new CommentDataAccess();

            var service = new UserService(userRepository, postRepository);

           // var response = service.GetUserActiveRespose(4);

            var commentService = new UserCommentsService(userRepository, postRepository, commentRepository);
            int user = 9;
            var userComments = commentService.GetUserComments(user);
            if (userComments.Comments.Count == 0) Console.WriteLine($"User {user} has no comments");
            foreach (var c in userComments.Comments)
            {
                Console.WriteLine($"Comment for User: {userComments.User.Id},PostId: {c.PostId}, Body: {c.Text}");
            }

            Console.ReadKey();

        }
       
    }
}