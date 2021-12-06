using LecturerConsoleApp;


List<Lecturer> lecturersList = new List<Lecturer>();
List<string> StudentString = new List<string>();




void CrateTextFile(List<Lecturer> someList, string fileName)
{
    int id = 0;
    FileStream fs1 = new FileStream($@"c:\test\{fileName}.text", FileMode.Append);
    using (StreamWriter writer = new StreamWriter(fs1))
    {

        foreach (Lecturer lecturer in someList)
        {
            writer.Write($" id:0-{id} ||lecturer Name:{lecturer.lecturerName}|| student Name:{lecturer.studentName}|| student taz:{lecturer.taz} grades :");

            for (int i = 0; i < lecturer.grades.Count; i++)
            {
                writer.Write($" {lecturer.grades[i]},");
            }
            writer.WriteLine();
            id++;
        };

    }
}

void studentsApp()
{
    try
    {
        Console.WriteLine("enter number of students you want to enter");
        int numOfStudentsToAdd = int.Parse(Console.ReadLine());
        Console.WriteLine("enter your name");
        string LecturerName = Console.ReadLine();

        for (int i = 0; i < numOfStudentsToAdd; i++)
        {
            Lecturer newLecturer = new Lecturer();

            newLecturer.lecturerName = LecturerName;

            Console.WriteLine("enter stident name");
            newLecturer.studentName = Console.ReadLine();
            Console.WriteLine("enter stident taz");
            newLecturer.taz = Console.ReadLine();
            newLecturer.grades = new List<int>();
            for (int j = 0; j < 3; j++)
            {
                Console.WriteLine("enter a grade ");
                newLecturer.grades.Add(int.Parse(Console.ReadLine()));
            }
            lecturersList.Add(newLecturer);


            CrateTextFile(lecturersList, LecturerName);


        }


    }
    catch (FormatException)
    {
        Console.WriteLine("Enter the details correctly");
        studentsApp();
    }
    catch (Exception ex)
    {
        Console.WriteLine(ex.Message);
        studentsApp();
    }
}



void readFromFile(List<string> someList, string fileName)
{
    try
    {

        FileStream fs2 = new FileStream($@"c:\test\{fileName}.text", FileMode.Open);
        using (StreamReader reader = new StreamReader(fs2))
        {
            for (int i = 0; i < reader.Peek(); i++)
                someList.Add(reader.ReadLine());
        }

    }
    catch (ArgumentException)
    {
        Console.WriteLine("the name of the lecturer is not found");
    }
    catch (Exception ex)
    {
        Console.WriteLine(ex.Message);
    }
}


void getTheFirstStudent()
{
    try
    {
        Console.WriteLine("enter the lecturer name of the student");
        string lecturerName = Console.ReadLine();

        FileStream fs3 = new FileStream($@"c:\test\{lecturerName}.text", FileMode.Open);
        using (StreamReader reader = new StreamReader(fs3))
        {
            Console.Write(reader.ReadLine());

        }
    }catch (ArgumentException)
    {
        Console.WriteLine("the name of the lecturer is not found");
    }
    catch (Exception ex)
    {
        Console.WriteLine(ex.Message);
    }
};




void gradesApp()
{
    Console.WriteLine($"for add a student press 1\n for the avrege and the name of the first student press 2");
    int options = int.Parse(Console.ReadLine());

    switch (options)
    {
        case 1:
            studentsApp();

            break;

        case 2:
            getTheFirstStudent();

            break;
    }
}

gradesApp();