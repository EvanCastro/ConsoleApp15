using System;
using ConsoleAppProject.Helpers;

namespace ConsoleAppProject.App04
{
    /// <summary>
    /// 
    /// </summary>
    public class NetworkApp
    {
       private NewsFeed news = new NewsFeed();



        public void DisplayMenu()
        {
            ConsoleHelper.OutputHeading("Evan's Daily");

            string[] choices = new string[]
            {
                "Post Message", "Post Image", "Display All Posts","Remove Post","Display by Author", "Display by Time",
                "Add comment", "Like Post", "Quit"
            };

            bool wantToQuit = false;
            do
            {
                int choice = ConsoleHelper.SelectChoice(choices);
                switch (choice)
                {
                    case 1: PostMessage(); break;
                    case 2: PostPhoto(); break;
                    case 3: DisplayAll(); break;
                    case 4: RemovePost(); break;
                    case 5: DisplayByAuthor(); break;
                    case 6: DisplayByTime(); break;
                    case 7: AddComment(); break;
                    case 8: LikePost(); break;
                    case 9 : wantToQuit = true; break;
                }

            } while (!wantToQuit);

        }



        private void DisplayAll()
        {
            news.Display();

        }

        private void PostPhoto()
        {
            ///Get user to type this information
            PhotoPost photoPost = new PhotoPost("Evan", "Photo.jpg", "Hello World");
            news.AddPhotoPost(photoPost);
            Console.WriteLine("Posting an Image...\n");

            Console.Write("Type your username: ");
            string author = Console.ReadLine();

            Console.Write("Please enter your image filename: ");
            string filename = Console.ReadLine();

            Console.Write("Please enter your image caption: ");
            string caption = Console.ReadLine();

            PhotoPost post = new PhotoPost(author, filename, caption);
            news.AddPhotoPost(photoPost);

            Console.WriteLine("You have succesfully posted a photo.\n");
            post.Display();


        }

        private void PostMessage()
        {
            ///User to enter information - placeholder for now
            Console.WriteLine("Posting a message...\n");

            Console.Write("Type your username: ");
            string author = Console.ReadLine();

            Console.Write("Please enter your message: ");
            string message = Console.ReadLine();

            MessagePost post = new MessagePost(author, message);
            news.AddMessagePost(post);

            Console.WriteLine("You have succesfully posted a message.\n");

            post.Display();
        }

        /// <summary>
        /// Removes post.
        /// </summary>
        private void RemovePost()
        {
            Console.WriteLine("Removing a post...\n");

            Console.Write("Please enter your post id: \n");

            string value = Console.ReadLine();

            int id = Convert.ToInt32(value);

            news.RemovePost(id);
        }

        /// <summary>
        /// Displays 1 author's posts
        /// </summary>
        private void DisplayByAuthor()
        {
            Console.WriteLine("Displaying authors posts...\n");

            Console.Write("Please enter authors username: \n");

            string username = Console.ReadLine();

            news.DisplayAuthor(username);
        }
        /// <summary>
        /// Displays all posts for particular time
        /// </summary>
        private void DisplayByTime()
        {
            Console.WriteLine("Displaying posts by time...\n");

            Console.Write("Please enter time elapsed (in seconds) for a post: \n");

            string value = Console.ReadLine();

            int time = Convert.ToInt32(value);

            news.DisplayByTime(time);
        }

        /// <summary>
        /// Adds a comment to post
        /// </summary>
        private void AddComment()
        {
            Console.WriteLine("Adding a comment...\n");

            Console.Write("Please enter post id: \n");

            string value = Console.ReadLine();

            int id = Convert.ToInt32(value);

            news.AddComment(id);
        }

        /// <summary>
        /// Adds a like to a post.
        /// </summary>
        private void LikePost()
        {
            Console.Write("Please enter post id: \n");

            string value = Console.ReadLine();

            int id = Convert.ToInt32(value);

            news.LikePost(id);
        }
    }
}