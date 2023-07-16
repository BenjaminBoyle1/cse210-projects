using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        List<Video> videos = new List<Video>();

        Video video1 = new Video("Video 1", "Author 1", 120);
        video1.AddComment("User1", "Great video!");
        video1.AddComment("User2", "I learned a lot from this.");
        video1.AddComment("User3", "Could you please make a follow-up video?");
        videos.Add(video1);

        Video video2 = new Video("Video 2", "Author 2", 180);
        video2.AddComment("User1", "This video is amazing!");
        video2.AddComment("User2", "I have a question.");
        video2.AddComment("User3", "Thanks for sharing!");
        videos.Add(video2);

        Video video3 = new Video("Video 3", "Author 3", 150);
        video3.AddComment("User1", "I didn't understand the last part.");
        video3.AddComment("User2", "Can you provide more examples?");
        video3.AddComment("User3", "You're doing a great job!");
        videos.Add(video3);

        foreach (Video video in videos)
        {
            Console.WriteLine("Title: " + video.Title);
            Console.WriteLine("Author: " + video.Author);
            Console.WriteLine("Length: " + video.Length + " seconds");
            Console.WriteLine("Number of Comments: " + video.GetCommentCount());
            Console.WriteLine("Comments:");
            foreach (Comment comment in video.Comments)
            {
                Console.WriteLine("  Commenter: " + comment.CommenterName);
                Console.WriteLine("  Text: " + comment.Text);
            }
            Console.WriteLine();
        }
    }
}
