using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam_OOP
{
    internal class PracticalExam : Exam
    {   
        public PracticalExam(int examTime, int numQuestions) : base(examTime, numQuestions)
        {
        }

      
        public override void ShowExam()
        {
            Console.WriteLine("\n--- practical Exam ---");
            
            

            foreach (var q in Questions)
            {
                q.ShowQuestion();


                int userChoice;
                do
                {
                    Console.Write("Your Answer (enter number): ");
                } while (!int.TryParse(Console.ReadLine(), out userChoice));

                if (q.RightAnswer != null && q.RightAnswer.AnswerId == userChoice)
                {
                    Console.WriteLine("Correct");
                   
                }
                else
                {
                    Console.WriteLine("Wrong");
                }
            }

            for (int i = 0; i < Questions.Count; i++)
            {
                var q = Questions[i];

                Console.WriteLine($"Question {i + 1}: {q.BodyOfQuestion}");
                Console.WriteLine($"Correct Answer: {q.RightAnswer?.AnswerText}\n");
            }
        }

        public override void CreateExamQuestions()
        {
            for (int i = 0; i < NumQuestions; i++)
            {
                Console.Clear();
                

               
                string body;
                float mark;
                int choiceCount;
                int correctId;

                Console.WriteLine("\n----- [MCQ Question] -----");


                do
                {
                    Console.WriteLine("Enter Question Body:");
                    body = Console.ReadLine();
                } while (string.IsNullOrWhiteSpace(body));

                do
                {
                    Console.WriteLine("Enter Question Mark (between 0 and 100):");
                } while (!float.TryParse(Console.ReadLine(), out mark) || mark < 0 || mark> 100 );


                MCQ mcq = new MCQ(body, mark);
                do
                {
                    Console.WriteLine("Enter number of choices (min 2):");
                } while (!int.TryParse(Console.ReadLine(), out choiceCount) || choiceCount < 2 || choiceCount>5);
                
                for (int j = 1; j <= choiceCount; j++)
                    {
                    string choiceText;
                    do
                    {
                        Console.WriteLine($"Enter Choice {j}:");
                        choiceText = Console.ReadLine();
                    } while (string.IsNullOrWhiteSpace(choiceText));

                    mcq.AnswerList.Add(new Answers(j, choiceText));
                }

                do
                {
                    Console.WriteLine("Enter the correct choice number:");
                } while (!int.TryParse(Console.ReadLine(), out correctId) ||
                         mcq.AnswerList.All(a => a.AnswerId != correctId));

                foreach (var ans in mcq.AnswerList)
                {
                    if (ans.AnswerId == correctId)
                    {
                        mcq.RightAnswer = ans;
                        break;
                    }
                }
                Questions.Add(mcq);
            }
        }


    }
}
