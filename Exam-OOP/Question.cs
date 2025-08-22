using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam_OOP
{
    internal abstract class Question
    {
        #region Attributes
        
        private string bodyOfQuestion;
        private float mark;
        private List<Answers> answerList;
        private Answers? rightAnswer;


 

        #endregion
        #region properties
     
        public string BodyOfQuestion { get {return bodyOfQuestion; } set {
                ArgumentNullException.ThrowIfNullOrWhiteSpace(value);
                bodyOfQuestion = value; } }
        public float Mark { get { return mark; } set {
                if (value < 0 || value > 100)
                    throw new ArgumentOutOfRangeException(nameof(Mark), "Mark must be between 0 and 100.");
                mark = value; } }

        public List<Answers> AnswerList { get { return answerList; } set {
                ArgumentNullException.ThrowIfNull(value);
                answerList = value; } }
        public Answers? RightAnswer { get { return rightAnswer; } set {
                // list.contains: true if item is found in the List<T>; otherwise, false.
                if (value != null && !AnswerList.Contains(value))
                    throw new ArgumentException("Right answer must exist in the Answer List.");
                rightAnswer = value; } }

        public string HeaderOfQuestion { get; protected set; }
        #endregion

        #region constructor
        protected Question(string header, string bodyOfQuestion, float mark)
        {
      
            BodyOfQuestion = bodyOfQuestion;
            Mark = mark;
            /*
             * - to gutrantee that when i create instance for question a list of answers will be created and this gurantee that will be not null
             * - without this i can't add directly to the list because it will be null and it will throw Null exception error
             * or i should to create list of answers and after this add to the list (q1.AnswerList = new List<Answers>())
              */

            AnswerList = new List<Answers>(); 
        }
        #endregion
        #region Method
        public abstract void ShowQuestion();
        #endregion
    }
}
