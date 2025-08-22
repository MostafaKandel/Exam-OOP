using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam_OOP
{
    internal class TrueFalse: Question
    {
        //public TrueFalseOption CorrectOption { get; set; }

        public TrueFalse( string body, float mark)
            : base("True & False",body, mark)
        {
             
            AnswerList.Add(new Answers((int)TrueFalseOption.True, "True"));
            AnswerList.Add(new Answers((int)TrueFalseOption.False, "False"));
        }

        public override void ShowQuestion()
        {
            Console.WriteLine($"{HeaderOfQuestion} - {BodyOfQuestion} (Mark: {Mark})");
            foreach (var answer in AnswerList)
            {
                Console.WriteLine(answer);
            }
        }
    }
}
