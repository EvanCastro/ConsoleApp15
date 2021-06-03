using System;
using System.Collections.Generic;


namespace ConsoleAppProject.App04
{
    ///<summary>
    /// The NewsFeed class stores news posts for the news feed in a social network 
    /// application.
    /// 
    /// Display of the posts is currently simulated by printing the details to the
    /// terminal. (Later, this should display in a browser.)
    /// 
    /// This version does not save the data to disk, and it does not provide any
    /// search or ordering functions.
    ///</summary>
    ///<author>
    ///  Evan Castro 27/05/2021
    ///  version 0.1
    ///</author> 
    public class NewsFeed
    {
        public const string AUTHOR = "Evan";
        private readonly List<Post> posts;


        ///<summary>
        /// Construct an empty news feed.
        ///</summary>
        public NewsFeed()
        {
            posts = new List<Post>();
            MessagePost post = new MessagePost(AUTHOR, "Hello world");
            AddMessagePost(post);

            PhotoPost photoPost = new PhotoPost(AUTHOR, "Photo.jpg", "this is a photo");
            AddPhotoPost(photoPost);
        }




        ///<summary>
        /// Add a text post to the news feed.
        /// 
        /// @param text  The text post to be added.
        ///</summary>
        public void AddMessagePost(Post message)
        {
            posts.Add(message);
        }

        ///<summary>
        /// Add a photo post to the news feed.
        /// 
        /// @param photo  The photo post to be added.
        ///</summary>
        public void AddPhotoPost(PhotoPost photo)
        {
            posts.Add(photo);
        }

        ///<summary>
        /// Show the news feed. Currently: print the news feed details to the
        /// terminal. (To do: replace this later with display in web browser.)
        ///</summary>
        public void Display()
        {
            // display all text posts
            foreach (Post post in posts)
            {
                post.Display();
                Console.WriteLine();   // empty line between posts
            }




        }

        /// <summary>
        /// Finds and removes post from list of posts.
        /// </summary>
        /// <param name="id"></param>
        public void RemovePost(int id)
        {
            Post post = FindPost(id);

            if (post == null)
            {
                Console.WriteLine("Post with id: ", id, " does not exist");
            }
            else
            {
                Console.WriteLine("This post has been removed: ");

                if (post is MessagePost mp)
                {
                    mp.Display();
                }
                else if (post is PhotoPost pp)
                {
                    pp.Display();
                }

                posts.Remove(post);
            }
        }

        /// <summary>
        /// Finds post by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Post FindPost(int id)
        {
            foreach (Post post in posts)
            {
                if (post.Postid == id)
                {
                    return post;
                }
            }

            return null;
        }

        /// <summary>
        /// Displays posts for particular author
        /// </summary>
        /// <param name="username"></param>
        public void DisplayAuthor(string username)
        {
            Post post = FindAuthor(username);

            if (post == null)
            {
                Console.WriteLine("No posts from", username, " exist.");
            }
            else
            {
                Console.WriteLine("Displaying all posts from ", username);
                post.Display();
            }
        }

        /// <summary>
        /// Searches for a posts from particular author
        /// </summary>
        /// <param name="username"></param>
        /// <returns></returns>
        public Post FindAuthor(string username)
        {
            foreach (Post post in posts)
            {
                if (post.Username == username)
                {
                    return post;
                }
            }

            return null;
        }

        /// <summary>
        /// Likes post with particular id
        /// </summary>
        /// <param name="id"></param>
        public void LikePost(int id)
        {
            Post post = FindPost(id);

            if (post == null)
            {
                Console.WriteLine("Post with id ", id, " does not exist.");
            }
            else
            {
                Console.WriteLine("Post has been liked.");
                post.Like();
                post.Display();
            }
        }

        /// <summary>
        /// Adds a comment to a post with particular id
        /// </summary>
        /// <param name="id"></param>
        public void AddComment(int id)
        {
            Post post = FindPost(id);

            if (post == null)
            {
                Console.WriteLine("Post with id ", id, " does not exist.");
            }
            else
            {
                Console.WriteLine("Adding a comment...");
                Console.Write("Please enter your comment: ");
                string text = Console.ReadLine();
                post.AddComment(text);
            }
        }

        /// <summary>
        /// Displays all posts for particular time.
        /// </summary>
        /// <param name="time"></param>
        public void DisplayByTime(int time)
        {
            Post post = FindTime(time);

            if (post == null)
            {
                Console.WriteLine("No posts in this period", time, "seconds; exist.");
            }
            else
            {
                Console.WriteLine("Displaying all posts for this period ", time, "seconds");
                post.Display();
            }
        }

        /// <summary>
        /// Searches for posts made in particular time.
        /// </summary>
        /// <param name="time"></param>
        /// <returns></returns>
        public Post FindTime(int time)
        {
            foreach (Post post in posts)
            {
                DateTime current = DateTime.Now;
                TimeSpan timePast = current - post.Timestamp;
                int seconds = (Int32)timePast.TotalSeconds;

                if (seconds <= time)
                {
                    return post;
                }
            }

            return null;
        }

        ///<summary>
        /// Add a text post to the news feed.
        /// 
        /// @param text  The text post to be added.
        ///</summary>
        public void AddMessagePost(MessagePost message)
        {
            posts.Add(message);
        }
    }
}
