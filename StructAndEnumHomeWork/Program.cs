using System;
using System.Collections.Generic;
using System.Linq;

namespace StructAndEnumHomeWork
{
    class Program
    {
        static void Main(string[] args)
        {
            // 1.	Создать массив сотрудников. 
            // Длина массива задается пользователем, заполнение массива производится им же.
            Console.Write("Count of employies: ");
            int countofEmployee = Int32.Parse(Console.ReadLine());

            Console.WriteLine();
            Employee[] employies = new Employee[countofEmployee];

            for (int i = 0; i < countofEmployee; i++)
            {
                Console.Write("Name of employee: ");
                employies[i].Name = Console.ReadLine();

                Console.Write("Vacancie of employee (0 - Manager, 1 - Boss, 2 - Clerk, 3 - Salesman): ");
                int vacance = Int32.Parse(Console.ReadLine());
                employies[i].vacancies = (Vacancies)vacance;

                Console.Write("Salary of employee $: ");
                employies[i].Salary = Int32.Parse(Console.ReadLine());

                Console.WriteLine();
                Console.Write("Year of EmploymentDate: ");
                int year = Int32.Parse(Console.ReadLine());
                Console.Write("Month of EmploymentDate: ");
                int month = Int32.Parse(Console.ReadLine());
                Console.Write("Day of EmploymentDate: ");
                int day = Int32.Parse(Console.ReadLine());
                employies[i].EmploymentDate = new DateTime(year, month, day);
                Console.WriteLine();
            }

            // a. вывести полную информацию обо всех сотрудниках;
            foreach (var el in employies)
            {
                Console.WriteLine(el.Name);
                Console.WriteLine(el.Salary);
                Console.WriteLine(el.EmploymentDate);
            }

            // b. найти в массиве всех менеджеров, зарплата которых больше средней зарплаты всех клерков, 
            // вывести на экран полную информацию о таких менеджерах отсортированной по их фамилии.
            int avgClerkSalary;
            int sumOfSalaryOfClerk = 0;
            int countOfClerk = 0;
            for (int i = 0; i < countofEmployee; i++)
            {
                if (employies[i].vacancies == Vacancies.Clerk)
                {
                    sumOfSalaryOfClerk += employies[i].Salary;
                    countOfClerk++;
                }
            }

            avgClerkSalary = sumOfSalaryOfClerk / countOfClerk;

            IEnumerable<Employee> query = employies.OrderBy(employee => employee.Name);

            foreach (var el in query)
            {
                if (el.vacancies == Vacancies.Manager)
                {
                    if (el.Salary > avgClerkSalary)
                    {
                        Console.WriteLine(el.Name);
                        Console.WriteLine(el.Salary);
                        Console.WriteLine(el.EmploymentDate);
                    }
                }
            }

            // c. распечатать информацию обо всех сотрудниках, принятых на работу позже босса, 
            // отсортированную в алфавитном порядке по фамилии сотрудника.
            Employee boss = new Employee();
            for (int i = 0; i < countofEmployee; i++)
            {
               if (employies[i].vacancies == Vacancies.Boss)
                {
                    boss = employies[i];
                }
            }
            
            foreach (var el in query)
            {
                if ((el.vacancies != Vacancies.Boss) || el.EmploymentDate > boss.EmploymentDate)
                {
                    Console.WriteLine(el);
                }
            }

            // 2. Для получения места в общежитии формируется список студентов, 
            // который включает Ф.И.О. студента, группу, средний балл, доход на члена семьи, пол (перечисление), 
            // форма обучения(перечисление). Общежитие в первую очередь предоставляется тем, 
            // у кого доход на члена семьи меньше двух минимальных зарплат, затем остальным в порядке уменьшения среднего балла. 
            // Вывести список очередности предоставления мест в общежитии.

            Student[] students = new Student[3];

            for (int i = 0; i< 3; i++)
            {
                students[i].Surname = Console.ReadLine();
                students[i].Name = Console.ReadLine();
                students[i].Group = Console.ReadLine();
                students[i].AvgMark = Double.Parse(Console.ReadLine());
                students[i].AvgIncome = Double.Parse(Console.ReadLine()); 
                Console.Write("Sex of student (0 - Male, 1 - Female: ");
                int sex = Int32.Parse(Console.ReadLine());
                students[i].Sex = (Sexies)sex;
                Console.Write("Study form of student (0 - Fulltime, 1 - Extramural, 2 - Distance: ");
                int StudyForm = Int32.Parse(Console.ReadLine());
                students[i].FormStudy = (FormOfStudy)StudyForm;
            }

            IEnumerable<Student> list = from student in students
                                        orderby student.AvgMark, student.AvgIncome descending
                                        select student;
        }
    }
}
