using System.Web.Mvc;
using Ith.Domain.Abstract;
using PagedList.Mvc;
using PagedList;
using Ith.Domain.Entities;
using System.Collections.Generic;
using System.Linq;
using System;

namespace Ith.WebUI.Controllers
{
    public class PostController : Controller
    {
        private IPostRepository PostRepo;

        public PostController(IPostRepository Repository)
        {
            PostRepo = Repository;
        }

        [Authorize(Roles = "User")]
        public ActionResult Index(int page = 1)
        {
            IQueryable<Post> PostList = PostRepo.Posts();

            for (int i = 0; i < 10; i++)
            {
                Post po = new Post();
                po.Title = i.ToString();
                po.Text = Guid.NewGuid().ToString("n").Substring(0, 8);
                po.DateAdd = DateTime.Now;
                PostRepo.Create(po);
                
            }

            PostRepo.Save();

            var PagedPostList = GetConsultRequestsPreview(PostList, page, 10, true);

            return View(PagedPostList);
        }

        public IPagedList<Post> GetConsultRequestsPreview(IQueryable<Post> Posts, int? currentPage, int itemPerPage = 10, bool toSetLastPageIfCurrPageEmpty = true)
        {
            if (currentPage == null || currentPage <= 0) currentPage = 1;
            if (itemPerPage <= 0) itemPerPage = 10;

            IPagedList<Post> PostList = Posts != null ? Posts.OrderBy(r => r.Id).ToPagedList((int)currentPage, itemPerPage) : null;

            if (toSetLastPageIfCurrPageEmpty && Posts.Any() && !PostList.Any())
            {
                PostList = Posts != null ? Posts.OrderBy(r => r.Id).ToPagedList(PostList.PageCount, itemPerPage) : null;
            }

            int previewPostLength = 15;

            foreach (Post Post in PostList)
            {
                if (!string.IsNullOrWhiteSpace(Post.Text) && Post.Text.Length > previewPostLength)
                {
                    Post.Text = Post.Text.Substring(0, previewPostLength);
                    int lastSpacePlace = Post.Text.LastIndexOf(' ');
                    Post.Text = Post.Text.Substring(0, lastSpacePlace) + " ...";
                }
            }

            return PostList;
        }

        protected override void Dispose(bool disposing)
        {
            PostRepo.Dispose();
            base.Dispose(disposing);
        }
    }
}