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
            if (NewPost != null)
            {
                NewPost.Invoke(this, EventArgs.Empty);
            }
        }

    }

    public class Reader
    {
        private Blog _blog;

        public Reader(Blog blog)
        {
            _blog = blog;

            blog.NewPost += Blog_NewPost;

        }

        private void Blog_NewPost(object sender, EventArgs e)
        {
            // Go and read the new post
            Console.WriteLine("New post read!");
        }
    }
}
