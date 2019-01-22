using System.Collections.Generic;
using Ith.Domain.Entities;

namespace Ith.Domain.Abstract
{
    public interface IPostRepository
    {
        IEnumerable<Post> Posts();
        Post Post(int id);
    }
}
