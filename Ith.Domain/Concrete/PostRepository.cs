using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using Ith.Domain.Abstract;
using Ith.Domain.Entities;

namespace Ith.Domain.Concrete
{
    public class PostRepository : IPostRepository
    {
        private PostDbContext db = new PostDbContext();
        
        public Post Post(int id)
        {
            return db.Posts.Find(id);
        }

        public IQueryable<Post> Posts()
        {
            return db.Posts;
        }

        private bool disposed = false;

        public virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    db.Dispose();
                }
            }

            disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public Post Create(Post item)
        {
            return db.Posts.Add(item);
        }

        public void Update(Post item)
        {
            db.Entry(item).State = EntityState.Modified;
        }

        public Post DeletePost(int id)
        {
            Post item = db.Posts.Find(id);

            if (item != null)
            {
                return db.Posts.Remove(item);
            }

            return null;
        }

        public int Save()
        {
            return db.SaveChanges();
        }
    }
}
