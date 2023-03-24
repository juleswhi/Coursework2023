using System;
using System.Collections.Generic;
using System.Text;
using Utils;
using System.Linq;

namespace ClaredonHighSchoolSkiTrip
{
    class Quiz : AddDetails
    {

        private string[] questions =
        {

            "How do you slow down on the slope?",
            "What is the height of the slope?",
            "What do you use to get up the slope?",
            "At what inverals should you go down the slope?",
            "How Tight Should Your Boots Be?",

        };

        private string[,] possibleAnswers =
        {
            {"Spread your skis", "Line up your skis", "Fall over" },
            {"20m", "10m", "5m" },
            {"Ski Lift", "Telekinesis", "Run" },
            {"10m", "5m", "1m" },
            {"Loose", "Tight", "Very Tight" }
        };

        private int[] answers =
        {
            // Index of correct Answers

            0,
            0,
            0,
            2,
            1
            
        };

        private int[] enteredAnswers;

        // Grades are given out for grouping
        private char[] grades = { 'A', 'B', 'C', 'D', 'E', 'F' };


        /*  
         * 
         * Idea: Use menu system for quiz
         * 
         */
        string[] test = { "hello" };

        public void StartQuiz()
        {
            enteredAnswers = new int[questions.Length];

            ArrayUtils<string> arrayUtils = new ArrayUtils<string>();
            

           for(int i = 0; i < questions.Length; i++)
           {
                // RunMenu returns an index, which can then be compared to correct Answers
                DisplayMenu menu = new DisplayMenu($"{questions[i]}", arrayUtils.GetRow(possibleAnswers, i));
                int answer = menu.RunMenu();
                Console.WriteLine($"Your Answer Was {answer}");
                System.Threading.Thread.Sleep(2000);
                enteredAnswers[i] = answer;
           }

           Grade gradeMarker = new Grade(enteredAnswers, answers);
           char grade = gradeMarker.grade;


            5.Loop(() => { Console.WriteLine($"Your Grade is {grade}"); System.Threading.Thread.Sleep(2000); });

        }

    }


    class Grade
    {
        private int[] enteredAnswers { get; set; }
        private int[] answers { get; set; }
        public char grade { get; set; }

        public Grade(int[] enteredAnswers, int[] answers)
        {
            this.enteredAnswers = enteredAnswers;
            this.answers = answers;
            grade = checkScore(CompareAnswers());
        }

        private int CompareAnswers()
        {
            int score = 0;
            int index = 0;
            answers.Length.Loop(() => { 
                if(enteredAnswers[index] == answers[index])
                {
                    score++;
                }
                index++;
            });



            return score;
        }


        private char checkScore(int score)
        {
            if ((int)Grades.A <= score) return 'A';
            if ((int)Grades.B <= score) return 'B';
            if ((int)Grades.C <= score) return 'C';
            if ((int)Grades.D <= score) return 'D';
            if ((int)Grades.E <= score) return 'E';
            if ((int)Grades.F <= score) return 'F';

            return 'F';
        }

        private enum Grades
        {
            A = 5,
            B = 4,
            C = 3,
            D = 2,
            E = 1,
            F = 0
        }
    }

}

