// Feature branch commit
// Truong branch commit

using System;
using System.Collections.Generic;
using System.Linq;

namespace StudentManagement
{
    // Lớp Student đại diện cho 1 sinh viên
    public class Student
    {
        public string Id { get; private set; }
        public string Name { get; private set; }
        public int Age { get; private set; }

        public Student(string id, string name, int age)
        {
            if (string.IsNullOrWhiteSpace(id))
                throw new ArgumentException("ID không được để trống.");

            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException("Tên không được để trống.");

            if (age <= 0)
                throw new ArgumentException("Tuổi phải lớn hơn 0.");

            Id = id;
            Name = name;
            Age = age;
        }

        public override string ToString()
        {
            return $"[ID: {Id}] {Name}, {Age} tuổi";
        }
    }

    // Lớp StudentManager quản lý danh sách sinh viên
    public class StudentManager
    {
        private readonly List<Student> _students = new List<Student>();

        // Thêm sinh viên mới
        public void AddStudent(Student student)
        {
            if (_students.Any(s => s.Id == student.Id))
                throw new InvalidOperationException("Sinh viên với ID này đã tồn tại.");

            _students.Add(student);
        }

        // Hiển thị tất cả sinh viên
        public void DisplayAllStudents()
        {
            if (_students.Count == 0)
            {
                Console.WriteLine("Danh sách sinh viên trống.");
                return;
            }

            Console.WriteLine("\n--- Danh sách sinh viên ---");
            foreach (var student in _students)
            {
                Console.WriteLine(student);
            }
        }

        // Tìm sinh viên theo ID
        public Student FindStudentById(string id)
        {
            return _students.FirstOrDefault(s => s.Id == id);
        }

        // Xóa sinh viên theo ID
        public bool RemoveStudent(string id)
        {
            var student = FindStudentById(id);
            if (student == null)
                return false;

            _students.Remove(student);
            return true;
        }
    }

    // Chương trình chính
    public class Program
    {
        private static readonly StudentManager manager = new StudentManager();

        public static void Main(string[] args)
        {
            while (true)
            {
                ShowMenu();

                Console.Write("Chọn chức năng: ");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        AddStudentUI();
                        break;
                    case "2":
                        manager.DisplayAllStudents();
                        break;
                    case "3":
                        FindStudentUI();
                        break;
                    case "4":
                        RemoveStudentUI();
                        break;
                    case "0":
                        Console.WriteLine("Thoát chương trình.");
                        return;
                    default:
                        Console.WriteLine("Lựa chọn không hợp lệ.");
                        break;
                }
            }
        }

        private static void ShowMenu()
        {
            Console.WriteLine("\n===== Quản Lý Sinh Viên =====");
            Console.WriteLine("1. Thêm sinh viên");
            Console.WriteLine("2. Hiển thị danh sách sinh viên");
            Console.WriteLine("3. Tìm sinh viên theo ID");
            Console.WriteLine("4. Xóa sinh viên theo ID");
            Console.WriteLine("0. Thoát");
        }

        private static void AddStudentUI()
        {
            try
            {
                Console.Write("Nhập ID: ");
                string id = Console.ReadLine();

                Console.Write("Nhập tên: ");
                string name = Console.ReadLine();

                Console.Write("Nhập tuổi: ");
                int age = int.Parse(Console.ReadLine());

                var student = new Student(id, name, age);
                manager.AddStudent(student);

                Console.WriteLine("Thêm sinh viên thành công!");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi: {ex.Message}");
            }
        }

        private static void FindStudentUI()
        {
            Console.Write("Nhập ID cần tìm: ");
            string id = Console.ReadLine();

            var student = manager.FindStudentById(id);
            if (student != null)
                Console.WriteLine($"Tìm thấy: {student}");
            else
                Console.WriteLine("Không tìm thấy sinh viên.");
        }

        private static void RemoveStudentUI()
        {
            Console.Write("Nhập ID cần xóa: ");
            string id = Console.ReadLine();

            bool result = manager.RemoveStudent(id);
            Console.WriteLine(result ? "Đã xóa sinh viên." : "Không tìm thấy sinh viên.");
        }
    }
}
