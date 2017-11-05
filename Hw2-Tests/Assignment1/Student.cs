namespace Hw2_Tests.Assignment1 {

    public class Student {
        public string Name { get; set; }
        public string Jmbag { get; set; }
        public Gender Gender { get; set; }

        public Student(string name, string jmbag) {
            Name = name;
            Jmbag = jmbag;
        }

        public override bool Equals(object obj) {
            var student = obj as Student;

            if (ReferenceEquals(student, null)) {
                return false;
            }

            return Jmbag.Equals(student.Jmbag);
        }

        public static bool operator== (Student student1, Student student2) {
            return student1.Jmbag == student2.Jmbag;
        }

        public static bool operator!= (Student student1, Student student2) {
            return student1.Jmbag != student2.Jmbag;
        }

        public override int GetHashCode() {
            return Jmbag.GetHashCode();
        }

    }

    public enum Gender {
        Male,
        Female
    }
}
   