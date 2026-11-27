using lb9.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Text;
using System.Xml;
using System.Xml.Linq;

namespace lb9.Services
{
    public class StudentService
    {
        private readonly string filePath;
        public StudentService()
        {
            string directory = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Data");
            Directory.CreateDirectory(directory);
            filePath = Path.Combine(directory, "Students.xml");

            if (!File.Exists(filePath))
            {
                SaveStudents(new List<Student>
                {
                    new Student
                    {
                        Surname = "Шевченко",
                        Name = "Олена",
                        Age = 19,
                        Gender = "Жіноча"
                    },
                    new Student
                    {
                        Surname = "Коваленко",
                        Name = "Андрій",
                        Age = 20,
                        Gender = "Чоловіча"
                    },
                    new Student
                    {
                        Surname = "Бондаренко",
                        Name = "Марія",
                        Age = 18,
                        Gender = "Жіноча"
                    },
                    new Student
                    {
                        Surname = "Мельник",
                        Name = "Іван",
                        Age = 21,
                        Gender = "Чоловіча"
                    }
                });
            }
        }
        public List<Student> LoadStudents(out string warning)
        {
            warning = "";
            XDocument document = XDocument.Load(filePath);
            List<Student> students = new List<Student>();
            foreach (XElement element in document.Root?.Elements("Student") ?? Enumerable.Empty<XElement>())
            {
                string ageText = (string?)element.Element("Age") ?? "";
                int age;

                if (!int.TryParse(ageText, NumberStyles.Integer, CultureInfo.InvariantCulture, out age))
                {
                    age = 0;
                    warning += $"Не вдалося прочитати вік студента " + $"{(string?)element.Element("Surname")} " +
                        $"{(string?)element.Element("Name")}. " + "Вік встановлено в 0.\n";
                }

                students.Add(new Student
                {
                    Surname = (string?)element.Element("Surname") ?? "",
                    Name = (string?)element.Element("Name") ?? "",
                    Age = age,
                    Gender = (string?)element.Element("Gender") ?? ""
                });
            }

            return students;
        }

        public void SaveStudents(List<Student> students)
        {
            XDocument document = new XDocument(new XElement("Students", students.Select(student => new XElement("Student",
                            new XElement("Surname", student.Surname),
                            new XElement("Name", student.Name),
                            new XElement("Age",student.Age.ToString(CultureInfo.InvariantCulture)),
                            new XElement("Gender", student.Gender)
                        )
                    )
                )
            );
            document.Save(filePath);
        }
    }
}
