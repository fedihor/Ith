using System;

namespace Ith.Domain.Entities
{
    public class Feedback
    {
        public int Id { get; set; }
        public int PostId { get; set; }
        public string Value { get; set; }
        public string Ip { get; set; }
        public DateTime? DateAdd { get; set; }
    }

    public class PostFeedback
    {
        public PostFeedback(int postId)
        {
            PostId = postId;
        }
        public int PostId { get; set; }
        public string CurrentValue { get; set; }
        public int Likes { get; set; }
        public int Dislikes { get; set; }
    }

    //public class FeedbackManager
    //{
    //    private string connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

    //    public Feedback Feedback;

    //    public int CountLikes(int postId)
    //    {
    //        return CountValues(postId, "+");
    //    }

    //    public int CountDisLikes(int postId)
    //    {
    //        return CountValues(postId, "-");
    //    }

    //    private int CountValues(int postId, string value)
    //    {
    //        if (postId <= 0 || string.IsNullOrWhiteSpace(value)) return 0;

    //        int countValues = 0;

    //        using (MySqlConnection connection = new MySqlConnection(connectionString))
    //        {
    //            connection.Open();
    //            MySqlCommand command = new MySqlCommand("SELECT COUNT(*) FROM FEEDBACKS WHERE POSTID = @POSTID AND VALUE = @VALUE", connection);
    //            command.Parameters.AddWithValue("POSTID", postId);
    //            command.Parameters.AddWithValue("VALUE", value);
    //            object countObj = command.ExecuteScalar();
    //            if (countObj != null)
    //            {
    //                int.TryParse(countObj.ToString(), out countValues);
    //            }
    //        }

    //        return countValues;
    //    }

    //    public Feedback GetFeedback(int postId, string ip)
    //    {
    //        if (postId <= 0 || string.IsNullOrWhiteSpace(ip)) return null;

    //        using (MySqlConnection connection = new MySqlConnection(connectionString))
    //        {
    //            connection.Open();

    //            MySqlCommand command = new MySqlCommand(@"
    //                SELECT ID, POSTID, IP, VALUE, DATEADD FROM FEEDBACKS WHERE POSTID = @POSTID AND IP = @IP LIMIT 1", connection);
    //            command.Parameters.AddWithValue("POSTID", postId);
    //            command.Parameters.AddWithValue("IP", ip);

    //            MySqlDataReader Reader = command.ExecuteReader();

    //            if (Reader.Read())
    //            {
    //                Feedback = new Feedback();
    //                Feedback.Id = Reader.GetInt32("ID");
    //                Feedback.PostId = Reader.GetInt32("POSTID");
    //                Feedback.Ip = Reader.GetString("IP");
    //                Feedback.Value = Reader.GetString("VALUE");
    //                Feedback.DateAdd = Reader.GetDateTime("DATEADD");
    //            }
    //            else
    //            {
    //                Feedback = null;
    //            }

    //            Reader.Close();

    //            return Feedback;
    //        }
    //    }

    //    private int Edit(int id, string value)
    //    {
    //        if (id <= 0 || string.IsNullOrWhiteSpace(value)) return 0;
    //        using (MySqlConnection connection = new MySqlConnection(connectionString))
    //        {
    //            connection.Open();
    //            MySqlCommand command = new MySqlCommand("UPDATE FEEDBACKS SET VALUE = '" + value + "', DATEADD = NOW() WHERE ID = " + id, connection);
    //            return command.ExecuteNonQuery();
    //        }
    //    }

    //    private int Add(int postId, string ip, string value)
    //    {
    //        if (string.IsNullOrWhiteSpace(value) || postId <= 0 || string.IsNullOrWhiteSpace(ip)) return 0;
    //        using (MySqlConnection connection = new MySqlConnection(connectionString))
    //        {
    //            connection.Open();
    //            MySqlCommand command = new MySqlCommand("INSERT INTO FEEDBACKS (POSTID, IP, VALUE, DATEADD) VALUES (@POSTID, @IP, @VALUE, NOW())", connection);
    //            command.Parameters.AddWithValue("POSTID", postId);
    //            command.Parameters.AddWithValue("IP", ip);
    //            command.Parameters.AddWithValue("VALUE", value);
    //            return command.ExecuteNonQuery();
    //        }
    //    }

    //    private int Delete(int id)
    //    {
    //        using (MySqlConnection connection = new MySqlConnection(connectionString))
    //        {
    //            connection.Open();
    //            MySqlCommand command = new MySqlCommand("DELETE FROM FEEDBACKS WHERE ID = " + id, connection);
    //            return command.ExecuteNonQuery();
    //        }
    //    }

    //    public int Set(int postId, string ip, string value)
    //    {
    //        GetFeedback(postId, ip);

    //        if (Feedback != null && Feedback.Id > 0)
    //        {
    //            if (Feedback.Value == value)
    //            {
    //                return Delete(Feedback.Id);
    //            }
    //            else
    //            {
    //                return Edit(Feedback.Id, value);
    //            }
    //        }
    //        else
    //        {
    //            return Add(postId, ip, value);
    //        }
    //    }
    //}
}