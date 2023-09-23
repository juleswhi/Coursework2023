using System;
using System.Linq;
using Utils;

namespace ClaredonHighSchoolSkiTrip
{
    class Quiz : AddDetails
    {

        private string[] questions =
        {

            "How do you slow down on the slope?",
            "What is the height of the highest slope?",
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

        public void StartQuiz()
        {

            ShowStudents studentselecter = new ShowStudents();
            string studentname = studentselecter.SelectStudent();

            enteredAnswers = new int[questions.Length];

            ArrayUtils<string> arrayUtils = new ArrayUtils<string>();


            for (int i = 0; i < questions.Length; i++)
            {
                // RunMenu returns an index, which can then be compared to correct Answers
                DisplayMenu menu = new DisplayMenu($"{questions[i]}", arrayUtils.GetRow(possibleAnswers, i));
                int answer = menu.RunMenu();
                enteredAnswers[i] = answer;
            }

            Grade gradeMarker = new Grade(enteredAnswers, answers);
            char grade = gradeMarker.grade;



            AddStudentDetails addStudentDetails = new AddStudentDetails("Students.csv");

            addStudentDetails.addGrade(studentname, grade.ToString());

            Console.Clear();
            Console.WriteLine($"{studentname}'s score was a {grade}");
            System.Threading.Thread.Sleep(1000);
            Console.WriteLine("Press any key to return to main menu");
            Console.ReadKey();
            GoToMainMenu();

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

            for (int i = 0; i < answers.Length; i++)
            {
                if (enteredAnswers[i] == answers[i])
                {
                    score++;
                }
            }


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


    class ShowStudents : ReadData
    {
        public string SelectStudent()
        {
            string[,] data = readData("Students.csv", 7);

            DisplayMenu dm = new DisplayMenu("Select Student",
                Enumerable.Range(0, data.GetLength(0) - 1)
                .Select(x => $"{data[x + 1, 1]} {data[x + 1, 2]}")
                .ToArray()
                );
            int index = dm.RunMenu() + 1;
            return data[index, 0];
        }
    }

}

