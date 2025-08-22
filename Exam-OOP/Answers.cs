using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam_OOP
{
    internal class Answers
    {
        #region Attributes
        private int answerId;
        private string answerText;
        #endregion

        #region Properties
        public int AnswerId { get { return answerId; } set {
                ArgumentOutOfRangeException.ThrowIfNegative(value, nameof(AnswerId));
                answerId = value;
            
            } }
        public string AnswerText { get { return answerText; } set {
                ArgumentNullException.ThrowIfNullOrWhiteSpace(value, nameof(AnswerText));
                answerText = value; 
            
            } }
        #endregion

        #region constractor
        public Answers(int answerId, string answerText)
        {
            AnswerId = answerId;
            AnswerText = answerText;
        }
        #endregion

        #region methods
        public override string ToString() { 
            return $"{AnswerId} .{AnswerText}";
        }
        #endregion
    }
}
