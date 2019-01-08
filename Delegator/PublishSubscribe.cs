using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Delegator
{
    public class Blog
    {
        public event EventHandler NewPost;

        public void Post(string title, string content)
        {
            //save the post

            //notify the NewPost event subscribers
            //if (NewPost != null)
            //{
            //    NewPost.Invoke(this, EventArgs.Empty);
            //}
            NewPost?.Invoke(this, EventArgs.Empty);
        }

    }

    public class Reader : IDisposable
    {
        private Blog _blog;

        public Reader(Blog blog)
        {
            _blog = blog;

            blog.NewPost += Blog_NewPost;

        }

        public void Dispose()
        {
            _blog.NewPost -= Blog_NewPost;
            _blog = null;
        }

        private void Blog_NewPost(object sender, EventArgs e)
        {
            // Go and read the new post
            Console.WriteLine("New post read!");
        }
    }
}
