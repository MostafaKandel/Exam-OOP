using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam_OOP
{
    internal class FinalExam : Exam
    {
       

      
        public FinalExam(int examTime, int numQuestions) : base(examTime, numQuestions)
        {

        }

        public override void ShowExam()
        {
            Console.WriteLine("\n--- Final Exam ---");
            float totalMarks = 0;
            var userAnswers = new List<Answers?>();

            foreach (var q in Questions)
            {
                q.ShowQuestion();

                int userChoice;
                Answers? selectedAnswer;
                do
                {
                    Console.Write("Your Answer (enter number): ");
                } while (!int.TryParse(Console.ReadLine(), out userChoice) ||
                         (selectedAnswer = q.AnswerList.FirstOrDefault(a => a.AnswerId == userChoice)) == null);

                userAnswers.Add(selectedAnswer);

                if (q.RightAnswer != null && q.RightAnswer.AnswerId == selectedAnswer.AnswerId)
                {
                    Console.WriteLine("Correct");
                    totalMarks += q.Mark;
                }
                else
                {
                    Console.WriteLine("Wrong");
                }

                Console.WriteLine();
            }

            Console.Clear();

            for (int i = 0; i < Questions.Count; i++)
            {
                var q = Questions[i];
                var userAns = userAnswers[i];

                Console.WriteLine($"Question {i + 1}: Your Answer = {userAns?.AnswerText} | Correct Answer = {q.RightAnswer?.AnswerText}");
            }

            Console.WriteLine($"\nYour Total Grade: {totalMarks}/{Questions.Sum(q => q.Mark)}");
        }
        

        public override void CreateExamQuestions()

        {
           
            for (int i = 0; i < NumQuestions; i++)
            {
                Console.Clear();
                int type;
                do
                {
                    Console.WriteLine($"Enter type of Question {i + 1} (1 for MCQ | 2 for True/False):");
                } while (!int.TryParse(Console.ReadLine(), out type) || (type != 1 && type != 2));

                Console.Clear();
                
                if (type == 1)
                    Console.WriteLine("\n----- [MCQ Question] -----");
                else
                    Console.WriteLine("\n----- [True/False Question] -----");

                string body;
                do
                {
                    Console.WriteLine("Enter Question Body:");
                    body = Console.ReadLine();
                } while (string.IsNullOrWhiteSpace(body));

                float mark;
                do
                {
                    Console.WriteLine("Enter Question Mark (0–100):");
                } while (!float.TryParse(Console.ReadLine(), out mark) || mark < 0 || mark > 100);



                if (type == 1) // MCQ
                {
                  
                    
                    MCQ mcq = new MCQ(body, mark);
                    int choiceCount;
                    do
                    {
                        Console.WriteLine("Enter number of choices (at least 2):");
                    } while (!int.TryParse(Console.ReadLine(), out choiceCount) || choiceCount < 2);

                    for (int j = 1; j <= choiceCount; j++)
                    {
                        string choiceText;
                        do
                        {
                            Console.WriteLine($"please Enter Choice {j}");
                            choiceText = Console.ReadLine();
                        } while (string.IsNullOrWhiteSpace(choiceText));

                        mcq.AnswerList.Add(new Answers(j, choiceText));
                    }

                    int correctId;
                    do
                    {
                        Console.WriteLine("Enter the correct choice number:");
                    } while (!int.TryParse(Console.ReadLine(), out correctId) ||
                             !mcq.AnswerList.Any(a => a.AnswerId == correctId)); // Any: to check if the answerId in the AnswerList

                   Answers? correctAnswer = null;
                    foreach (var ans in mcq.AnswerList)
                    {
                        if (ans.AnswerId == correctId)
                        {
                            correctAnswer = ans;
                            break;
                        }
                    }
                    mcq.RightAnswer = correctAnswer;

                    Questions.Add(mcq);
                }
                else if (type == 2) // True/False

                {
                    
                    TrueFalse tf = new TrueFalse( body, mark);

                    int correct;
                    do
                    {
                        Console.WriteLine("Enter correct answer (1 for True, 2 for False):");
                    } while (!int.TryParse(Console.ReadLine(), out correct) || (correct != 1 && correct != 2));

                    Answers? correctAnswer = null;
                    foreach (var ans in tf.AnswerList)
                    {
                        if (ans.AnswerId == correct)
                        {
                            correctAnswer = ans;
                            break;
                        }
                    }
                   tf.RightAnswer = correctAnswer;

                    Questions.Add(tf);
                }
            }
        }
    }
}
