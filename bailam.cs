import java.util.*;
class Student
{
    String id;
    String name;
    int age;
    double gpa;

    Student(String id, String name, int age, double gpa)
    {
        this.id = id;
        this.name = name;
        this.age = age;
        this.gpa = gpa;
    }

    @Override
    public String toString()
    {
        return "ID:" + id + " | Name:" + name + " | Age:" + age + " | GPA:" + gpa;
    }
}

class Teacher
{
    String id;
    String name;
    String major;

    Teacher(String id, String name, String major)
    {
        this.id = id;
        this.name = name;
        this.major = major;
    }

    @Override
    public String toString()
    {
        return "ID:" + id + " | Name:" + name + " | Major:" + major;
    }
}

class Course
{
    String id;
    String name;
    int credits;

    Course(String id, String name, int credits)
    {
        this.id = id;
        this.name = name;
        this.credits = credits;
    }

    @Override
    public String toString()
    {
        return "ID:" + id + " | Name:" + name + " | Credits:" + credits;
    }
}

class Enrollment
{
    String studentId;
    String courseId;

    Enrollment(String sid, String cid)
    {
        this.studentId = sid;
        this.courseId = cid;
    }

    @Override
    public String toString()
    {
        return "SV:" + studentId + " | MH:" + courseId;
    }
}

class Grade
{
    String studentId;
    String courseId;
    double score;

    Grade(String sid, String cid, double score)
    {
        this.studentId = sid;
        this.courseId = cid;
        this.score = score;
    }

    @Override
    public String toString()
    {
        return "SV:" + studentId + " | MH:" + courseId + " | Diem:" + score;
    }
}

public class SchoolProgram
{
    static Scanner sc = new Scanner(System.in);

    static ArrayList<Student> students = new ArrayList<>();
    static ArrayList<Teacher> teachers = new ArrayList<>();
    static ArrayList<Course> courses = new ArrayList<>();
    static ArrayList<Enrollment> enrollments = new ArrayList<>();
    static ArrayList<Grade> grades = new ArrayList<>();

    public static void main(String[] args)
    {
        int menu = 0;
        while (menu != 99)
        {
            System.out.println("============= MENU CHINH =============");
            System.out.println("1. Quan ly Sinh vien");
            System.out.println("2. Quan ly Giao vien");
            System.out.println("3. Quan ly Mon hoc");
            System.out.println("4. Quan ly Dang ky hoc");
            System.out.println("5. Quan ly Diem");
            System.out.println("6. Bao cao tong hop");
            System.out.println("99. Thoat");
            System.out.print("Nhap lua chon: ");
            menu = sc.nextInt(); sc.nextLine();

            switch (menu)
            {
                case 1->studentMenu();
                case 2->teacherMenu();
                case 3->courseMenu();
                case 4->enrollmentMenu();
                case 5->gradeMenu();
                case 6->report();
            }
        }
    }

    // ====== QUẢN LÝ SINH VIÊN ======
    static void studentMenu()
    {
        int smenu = 0;
        while (smenu != 9)
        {
            System.out.println("--- QUAN LY SINH VIEN ---");
            System.out.println("1. Them SV");
            System.out.println("2. Xoa SV");
            System.out.println("3. Cap nhat SV");
            System.out.println("4. Hien thi tat ca SV");
            System.out.println("5. Tim SV theo ten");
            System.out.println("6. Tim SV GPA > 8");
            System.out.println("7. Sap xep theo ten");
            System.out.println("8. Sap xep theo GPA");
            System.out.println("9. Quay lai");
            smenu = sc.nextInt(); sc.nextLine();

            switch (smenu)
            {
                case 1-> {
                        System.out.print("Nhap id: "); String id = sc.nextLine();
                        System.out.print("Nhap ten: "); String name = sc.nextLine();
                        System.out.print("Nhap tuoi: "); int age = sc.nextInt(); sc.nextLine();
                        System.out.print("Nhap GPA: "); double gpa = sc.nextDouble(); sc.nextLine();
                        students.add(new Student(id, name, age, gpa));
                    }
                case 2-> {
                        System.out.print("Nhap id can xoa: ");
                        String id = sc.nextLine();
                        students.removeIf(s->s.id.equals(id));
                    }
                case 3-> {
                        System.out.print("Nhap id can cap nhat: ");
                        String id = sc.nextLine();
                        for (Student s : students)
                        {
                            if (s.id.equals(id))
                            {
                                System.out.print("Nhap ten moi: "); s.name = sc.nextLine();
                                System.out.print("Nhap tuoi moi: "); s.age = sc.nextInt(); sc.nextLine();
                                System.out.print("Nhap GPA moi: "); s.gpa = sc.nextDouble(); sc.nextLine();
                            }
                        }
                    }
                case 4->students.forEach(System.out::println);
                case 5-> {
                        System.out.print("Nhap ten: ");
                        String name = sc.nextLine();
                        students.stream().filter(s->s.name.equals(name)).forEach(System.out::println);
                    }
                case 6->students.stream().filter(s->s.gpa > 8).forEach(System.out::println);
                case 7-> {
                        students.sort(Comparator.comparing(s->s.name));
                        System.out.println("Da sap xep theo ten.");
                    }
                case 8-> {
                        students.sort((a, b)->Double.compare(b.gpa, a.gpa));
                        System.out.println("Da sap xep theo GPA.");
                    }
            }
        }
    }

    // ====== QUẢN LÝ GIÁO VIÊN ======
    static void teacherMenu()
    {
        int tmenu = 0;
        while (tmenu != 9)
        {
            System.out.println("--- QUAN LY GIAO VIEN ---");
            System.out.println("1. Them GV");
            System.out.println("2. Xoa GV");
            System.out.println("3. Cap nhat GV");
            System.out.println("4. Hien thi GV");
            System.out.println("9. Quay lai");
            tmenu = sc.nextInt(); sc.nextLine();

            switch (tmenu)
            {
                case 1-> {
                        System.out.print("Nhap id GV: "); String id = sc.nextLine();
                        System.out.print("Nhap ten GV: "); String name = sc.nextLine();
                        System.out.print("Nhap chuyen mon: "); String major = sc.nextLine();
                        teachers.add(new Teacher(id, name, major));
                    }
                case 2-> {
                        System.out.print("Nhap id GV can xoa: ");
                        String id = sc.nextLine();
                        teachers.removeIf(t->t.id.equals(id));
                    }
                case 3-> {
                        System.out.print("Nhap id GV cap nhat: ");
                        String id = sc.nextLine();
                        for (Teacher t : teachers)
                        {
                            if (t.id.equals(id))
                            {
                                System.out.print("Nhap ten moi: "); t.name = sc.nextLine();
                                System.out.print("Nhap chuyen mon moi: "); t.major = sc.nextLine();
                            }
                        }
                    }
                case 4->teachers.forEach(System.out::println);
            }
        }
    }

    // ====== QUẢN LÝ MÔN HỌC ======
    static void courseMenu()
    {
        int cmenu = 0;
        while (cmenu != 9)
        {
            System.out.println("--- QUAN LY MON HOC ---");
            System.out.println("1. Them MH");
            System.out.println("2. Xoa MH");
            System.out.println("3. Cap nhat MH");
            System.out.println("4. Hien thi MH");
            System.out.println("9. Quay lai");
            cmenu = sc.nextInt(); sc.nextLine();

            switch (cmenu)
            {
                case 1-> {
                        System.out.print("Nhap id MH: "); String id = sc.nextLine();
                        System.out.print("Nhap ten MH: "); String name = sc.nextLine();
                        System.out.print("Nhap so tin chi: "); int tc = sc.nextInt(); sc.nextLine();
                        courses.add(new Course(id, name, tc));
                    }
                case 2-> {
                        System.out.print("Nhap id MH can xoa: ");
                        String id = sc.nextLine();
                        courses.removeIf(c->c.id.equals(id));
                    }
                case 3-> {
                        System.out.print("Nhap id MH cap nhat: ");
                        String id = sc.nextLine();
                        for (Course c : courses)
                        {
                            if (c.id.equals(id))
                            {
                                System.out.print("Nhap ten moi: "); c.name = sc.nextLine();
                                System.out.print("Nhap tin chi moi: "); c.credits = sc.nextInt(); sc.nextLine();
                            }
                        }
                    }
                case 4->courses.forEach(System.out::println);
            }
        }
    }

    // ====== QUẢN LÝ ĐĂNG KÝ ======
    static void enrollmentMenu()
    {
        int emenu = 0;
        while (emenu != 9)
        {
            System.out.println("--- QUAN LY DANG KY HOC ---");
            System.out.println("1. Dang ky mon hoc");
            System.out.println("2. Huy dang ky");
            System.out.println("3. Xem tat ca dang ky");
            System.out.println("9. Quay lai");
            emenu = sc.nextInt(); sc.nextLine();

            switch (emenu)
            {
                case 1-> {
                        System.out.print("Nhap id SV: "); String sid = sc.nextLine();
                        System.out.print("Nhap id MH: "); String cid = sc.nextLine();
                        enrollments.add(new Enrollment(sid, cid));
                    }
                case 2-> {
                        System.out.print("Nhap id SV: "); String sid = sc.nextLine();
                        System.out.print("Nhap id MH: "); String cid = sc.nextLine();
                        enrollments.removeIf(e->e.studentId.equals(sid) && e.courseId.equals(cid));
                    }
                case 3->enrollments.forEach(System.out::println);
            }
        }
    }

    // ====== QUẢN LÝ ĐIỂM ======
    static void gradeMenu()
    {
        int gmenu = 0;
        while (gmenu != 9)
        {
            System.out.println("--- QUAN LY DIEM ---");
            System.out.println("1. Nhap diem");
            System.out.println("2. Cap nhat diem");
            System.out.println("3. Hien thi diem");
            System.out.println("9. Quay lai");
            gmenu = sc.nextInt(); sc.nextLine();

            switch (gmenu)
            {
                case 1-> {
                        System.out.print("Nhap id SV: "); String sid = sc.nextLine();
                        System.out.print("Nhap id MH: "); String cid = sc.nextLine();
                        System.out.print("Nhap diem: "); double d = sc.nextDouble(); sc.nextLine();
                        grades.add(new Grade(sid, cid, d));
                    }
                case 2-> {
                        System.out.print("Nhap id SV: "); String sid = sc.nextLine();
                        System.out.print("Nhap id MH: "); String cid = sc.nextLine();
                        for (Grade g : grades)
                        {
                            if (g.studentId.equals(sid) && g.courseId.equals(cid))
                            {
                                System.out.print("Nhap diem moi: "); g.score = sc.nextDouble(); sc.nextLine();
                            }
                        }
                    }
                case 3->grades.forEach(System.out::println);
            }
        }
    }

    // ====== BÁO CÁO ======
    static void report()
    {
        System.out.println("=== BAO CAO ===");
        for (Student s : students)
        {
            System.out.println("Sinh vien: " + s.name);
            for (Enrollment e : enrollments)
            {
                if (e.studentId.equals(s.id))
                {
                    for (Course c : courses)
                    {
                        if (c.id.equals(e.courseId))
                        {
                            System.out.print(" - Mon hoc: " + c.name);
                            for (Grade g : grades)
                            {
                                if (g.studentId.equals(s.id) && g.courseId.equals(c.id))
                                {
                                    System.out.print(" | Diem: " + g.score);
                                }
                            }
                            System.out.println();
                        }
                    }
                }
            }
        }
    }
}
