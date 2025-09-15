// ============================
// Student Model
// ============================
class Student {
  constructor(id, name, age, className, scores = []) {
    this.id = id;
    this.name = name;
    this.age = age;
    this.className = className;
    this.scores = scores;
  }

  // Tính điểm trung bình
  getAverageScore() {
    if (this.scores.length === 0) return 0;
    const total = this.scores.reduce((sum, score) => sum + score, 0);
    return (total / this.scores.length).toFixed(2);
  }

  // Xếp loại học lực
  getRank() {
    const avg = this.getAverageScore();
    if (avg >= 8) return "Giỏi";
    if (avg >= 6.5) return "Khá";
    if (avg >= 5) return "Trung Bình";
    return "Yếu";
  }
}

// ============================
// Student Manager
// ============================
class StudentManager {
  constructor() {
    this.students = [];
  }

  // Thêm học sinh
  addStudent(student) {
    if (this.findStudentById(student.id)) {
      console.log(`ID ${student.id} đã tồn tại!`);
      return;
    }
    this.students.push(student);
    console.log(`Thêm học sinh ${student.name} thành công!`);
  }

  // Xóa học sinh
  removeStudent(id) {
    this.students = this.students.filter(student => student.id !== id);
    console.log(` Đã xóa học sinh có ID ${id}`);
  }

  // Cập nhật thông tin học sinh
  updateStudent(id, newData) {
    const student = this.findStudentById(id);
    if (!student) {
      console.log(` Không tìm thấy học sinh với ID ${id}`);
      return;
    }

    Object.assign(student, newData);
    console.log(` Cập nhật học sinh ${id} thành công!`);
  }

  // Tìm học sinh theo ID
  findStudentById(id) {
    return this.students.find(student => student.id === id);
  }

  // Tìm học sinh theo tên (gần đúng)
  findStudentByName(name) {
    return this.students.filter(student =>
      student.name.toLowerCase().includes(name.toLowerCase())
    );
  }

  // Hiển thị toàn bộ danh sách
  displayStudents() {
    console.log(" Danh sách học sinh:");
    this.students.forEach(student => {
      console.log(
        `ID: ${student.id} | Tên: ${student.name} | Tuổi: ${student.age} | Lớp: ${student.className} | TB: ${student.getAverageScore()} | Xếp loại: ${student.getRank()}`
      );
    });
  }
}

// ============================
// Demo sử dụng
// ============================

const manager = new StudentManager();

const student1 = new Student(1, "Nguyễn Văn A", 16, "10A1", [8, 9, 7]);
const student2 = new Student(2, "Trần Thị B", 15, "9B", [6, 7, 5]);
const student3 = new Student(3, "Lê Văn C", 17, "11C", [9, 8, 10]);

manager.addStudent(student1);
manager.addStudent(student2);
manager.addStudent(student3);

manager.displayStudents();

console.log("\n Tìm học sinh tên 'Văn':");
console.log(manager.findStudentByName("Văn"));

manager.updateStudent(2, { age: 16, className: "10B", scores: [7, 8, 6] });
manager.displayStudents();

manager.removeStudent(1);
manager.displayStudents();
