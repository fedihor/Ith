using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ith.Domain.Entities
{
    public class Post
    {
        [Key]
        [Display(Name = "Номер")]
        public int Id { get; set; }
        [Display(Name = "Заглавие")]
        public string Title { get; set; }
        [Display(Name = "Статья")]
        public string Text { get; set; }
        [Display(Name = "Тема")]
        public int SubjectId { get; set; }
        [Display(Name = "Статус")]
        public byte StateId { get; set; }
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Дата создания")]
        public DateTime? DateAdd { get; set; }
        [Display(Name = "Дата редактирования")]
        public DateTime? DateEdit { get; set; }
        [Display(Name = "Пользователь")]
        public string UserId { get; set; }

        [ForeignKey("StateId")]
        public State State { get; set; }
        [ForeignKey("SubjectId")]
        public Subject Subject { get; set; }

        [NotMapped]
        public PostFeedback Feedback { get; set; }

        [NotMapped]
        public ModelParams PostParams = new ModelParams();

        //public static Post GetPost(int postId, string ip, PostContext db)
        //{
        //    Post Post = db.Posts.Include("Subject").FirstOrDefault(r => r.Id == postId);
        //    if (Post == null) return null;
        //    Post.Text = CodeUpdater.CodeTagReplace(CodeUpdater.DeleteEmptyLines(Post.Text));
        //    FeedbackManager Fbm = new FeedbackManager();
        //    Fbm.GetFeedback(Post.Id, ip);
        //    Post.Feedback = new PostFeedback(Post.Id)
        //    {
        //        CurrentValue = Fbm.Feedback != null ? Fbm.Feedback.Value : "",
        //        Likes = Fbm.CountLikes(Post.Id),
        //        Dislikes = Fbm.CountDisLikes(Post.Id)
        //    };
        //    Post.State = db.States.FirstOrDefault(r => r.Id == Post.StateId);
        //    return Post;
        //}
    }
}