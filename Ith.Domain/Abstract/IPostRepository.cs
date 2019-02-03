using System;
using System.Collections.Generic;
using System.Linq;
using Ith.Domain.Entities;

namespace Ith.Domain.Abstract
{
    public interface IPostRepository : IDisposable
    {
        IQueryable<Post> Posts();
        Post Post(int id);
        Post Create(Post item);
        void Update(Post item);
        Post DeletePost(int id);
        int Save();
    }
}
