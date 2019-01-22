using System;
using System.Collections.Generic;
using Ith.Domain.Abstract;
using Ith.Domain.Entities;

namespace Ith.Domain.Concrete
{
    public class PostRepository : IPostRepository, IDisposable
    {
        private PostDbContext Context = new PostDbContext();
        
        public Post Post(int id)
        {
            return Context.Posts.Find(id);
        }

        public IEnumerable<Post> Posts()
        {
            return Context.Posts;
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
