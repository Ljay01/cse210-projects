using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        // Video 1
        Video video1 = new Video();
        video1._title = "Programming with C#";
        video1._author = "Simplilearn";
        video1._length = 1620;

        Comment comment1_1 = new Comment();
        comment1_1._authorName = "Jorge Escobar";
        comment1_1._commentText = "I'm rewatching this today and it's a wonderful overview of C#.";

        Comment comment1_2 = new Comment();
        comment1_2._authorName = "Remy Bryan";
        comment1_2._commentText = "Hello Simplilearn, just completed this session, it's great.";

        Comment comment1_3 = new Comment();
        comment1_3._authorName = "John Chibini";
        comment1_3._commentText = "I see a lot of similarities with Java, like A LOT!";

        video1._comments.Add(comment1_1);
        video1._comments.Add(comment1_2);
        video1._comments.Add(comment1_3);

        // Video 2
        Video video2 = new Video();
        video2._title = "Intro to Data Structures";
        video2._author = "CS Academy";
        video2._length = 900;

        Comment comment2_1 = new Comment();
        comment2_1._authorName = "Amina Patel";
        comment2_1._commentText = "Very clear explanations!";

        Comment comment2_2 = new Comment();
        comment2_2._authorName = "Luis Gomez";
        comment2_2._commentText = "Could you add more examples on trees?";

        Comment comment2_3 = new Comment();
        comment2_3._authorName = "Sofia N.";
        comment2_3._commentText = "Nice pace and content.";

        video2._comments.Add(comment2_1);
        video2._comments.Add(comment2_2);
        video2._comments.Add(comment2_3);

        // Video 3
        Video video3 = new Video();
        video3._title = "REST APIs in .NET";
        video3._author = "Dev Tutorials";
        video3._length = 1250;

        Comment comment3_1 = new Comment();
        comment3_1._authorName = "Kevin M.";
        comment3_1._commentText = "Helped me build my first API. Thanks!";

        Comment comment3_2 = new Comment();
        comment3_2._authorName = "Priya R.";
        comment3_2._commentText = "Can you explain authentication next?";

        Comment comment3_3 = new Comment();
        comment3_3._authorName = "Omar S.";
        comment3_3._commentText = "Great walkthrough of controllers and routing.";

        video3._comments.Add(comment3_1);
        video3._comments.Add(comment3_2);
        video3._comments.Add(comment3_3);

        // Put videos in a list
        List<Video> videos = new List<Video> { video1, video2, video3 };

        // Display each video and its comments
        foreach (Video v in videos)
        {
            Console.WriteLine("Title: " + v._title);
            Console.WriteLine("Author: " + v._author);
            Console.WriteLine("Length (seconds): " + v._length);
            Console.WriteLine("Number of comments: " + v.GetCommentCount());
            Console.WriteLine("Comments:");
            foreach (Comment c in v._comments)
            {
                Console.WriteLine(" - " + c._authorName + ": " + c._commentText);
            }
            Console.WriteLine();
        }
    }
}
