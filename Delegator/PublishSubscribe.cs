using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Delegator
{
    public class Blog
    {
        // title => content
        private Dictionary<string, string> _posts = new Dictionary<string, string>();

        public event EventHandler NewPost;

        public string this[string title]
        {
            get
            {
                if (_posts.ContainsKey(title))
                {
                    return _posts[title];
                }

                return null;
                //_posts.TryGetValue(title, out var _content);
                //return _content;
            }
            set { _posts[title] = value; }
        }


        public void Post(string title, string content)
        {
            //save the post
            _posts[title] = content;

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
