using System;
using System.IO;
using Utils;

namespace ClaredonHighSchoolSkiTrip
{
    class AddDetails : ReadData
    {
        protected string path { get; set; }
        protected void AddToFile(string[] data)
        {
            using (StreamWriter sw = new StreamWriter(path, true))
            {
                for (int i = 0; i < data.GetLength(0); i++) sw.Write($"{data[i]},");
                sw.WriteLine();
            }
        }


        private Random rand = new Random();
        private int getRandom() => rand.Next(100, 999);
        protected string createUsername(string fname, string sname) => $"{fname[0]}{sname}{getRandom()}";

        protected string input(string str)
        {
            Console.Clear();
            Console.WriteLine($"Please Enter Student's {str}:");
            string ret = Console.ReadLine();
            ret.IsMaxStringLength(() =>
            {
                Console.WriteLine("You have entered an incorrect value");
                Console.WriteLine("Press any key to try again");
                Console.ReadKey();
                ret = null;
            });
            return ret;
        }


    }






    class AddStudentDetails : AddDetails
    {
        public AddStudentDetails(string path) => this.path = path;



        public void addStudent()
        {
            string fname, sname, dob, year, averagetime, SkillGroup;

            // Input Data and validation
            do
            {
                fname = input("First Name"); fname.ValidateString(() =>
                {
                    Console.WriteLine("You Have Entered an incorrect first name");
                    Console.WriteLine("Press any key to try again");
                    Console.ReadKey();
                    Console.Clear();
                    fname = null;
                });
            } while (fname == null);
            do
            {
                sname = input("Second Name"); sname.ValidateString(() =>
            {
                Console.WriteLine("You have entered an incorrect second name");
                Console.WriteLine("Press any key to try again");
                Console.ReadKey();
                Console.Clear();
                sname = null;
            });
            } while (sname == null);
            do
            {
                dob = input("Date Of Birth XX/XX/XX").ValidateDate(() =>
                {
                    Console.WriteLine("You have entered an invalid date");
                    Console.WriteLine("Press any key to try again");
                    Console.ReadKey();
                    Console.Clear();
                    dob = null;
                });
            } while (dob == null);
            do
            {
                year = input("School Year"); year.ValidateInt<string>(() =>
                {
                    Console.WriteLine("You have entered an incorrect year");
                    Console.WriteLine("Press any key to try again");
                    Console.ReadKey();
                    year = null;
                });
            } while (year == null);

            averagetime = "?";
            SkillGroup = "?";

            // Create A Username using data and automatically set average ski slope time to 0
            string username = createUsername(fname, sname);
            string[] data = { username, fname, sname, dob, year, averagetime, SkillGroup };
            Console.Clear();
            AddToFile(data);
            Console.WriteLine($"Added Student, {username}");
            System.Threading.Thread.Sleep(750);
            Console.WriteLine("Press any key to return to main Menu");
            Console.ReadKey();

            GoToMainMenu();

        }


        public void addGrade(string username, string grade)
        {
            string[,] data = readData(path, 7);

            for (int i = 0; i < data.GetLength(0); i++)
            {
                if (data[i, 0] == username)
                {
                    data[i, 6] = grade; break;
                }
            }

            ReWriteFile(data);

        }

        private void ReWriteFile(string[,] data)
        {
            using (StreamWriter sw = new StreamWriter("Students.csv", false))
            {
                for (int i = 0; i < data.GetLength(0); i++)
                {
                    for (int j = 0; j < data.GetLength(1); j++)
                    {
                        sw.Write($"{data[i, j]},");
                    }
                    sw.WriteLine();
                }
            }
        }
    }











    class SkiTimeInput : AddDetails
    {
        public void addSlopeTime()
        {

            string[,] data = readData("students.csv", 7);


            ShowStudents studentselecter = new ShowStudents();
            string studentname = studentselecter.SelectStudent();


            double[] time = new double[5];

            // Input times
            for (int j = 0; j < 5; j++)
            {

                bool isDouble;

                // time[j] = Convert.ToDouble(input($"Time {j + 1} (s)"));
                do
                {
                    isDouble = true;
                    time[j] = input($"Time {j + 1} (s)").ValidateDouble<string>(() =>
                    {
                        Console.WriteLine("You have entered an incorrect time");
                        Console.WriteLine("Press any key to try again");
                        Console.ReadKey();
                        isDouble = false;
                    });

                } while (!isDouble);
            }
            double averageTime = 0;

            // Average time of student
            for (int a = 0; a < 5; a++) averageTime += time[a];
            averageTime = averageTime / 5;

            // Write
            string[] finalArr = { studentname, $"{time[0]}", $"{time[1]}", $"{time[2]}", $"{time[3]}", $"{time[4]}", $"{averageTime}" };

            path = "slopeTimes.csv";

            AddToFile(finalArr);
            addSkiTimesToFile(data, studentname, Math.Round(averageTime).ToString());

            GoToMainMenu();
        }

        private void addSkiTimesToFile(string[,] data, string username, string time)
        {
            for (int i = 0; i < data.GetLength(0); i++)
            {
                if (username == data[i, 0])
                {
                    data[i, 5] = time;
                }
            }

            using (StreamWriter sw = new StreamWriter("Students.csv", false))
            {
                for (int i = 0; i < data.GetLength(0); i++)
                {
                    for (int j = 0; j < data.GetLength(1); j++)
                    {
                        sw.Write($"{data[i, j]},");
                    }
                    sw.WriteLine();
                }
            }


        }
    }
}