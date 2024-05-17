#nullable disable
using songcayawoncorelib.Model;

namespace songcayawoncorelib.Stores
{
    public interface IStudentStore
    {
        IEnumerable<IStudentModel> StudentList { get; set; }

        void CreateStudent(IStudentModel student);
        IStudentModel FindStudentByName(string name);
        IStudentModel FindStudentById(string id);
        void UpdateStudent(IStudentModel student);
        void DeleteStudent(string id);
    }

    public class StudentStore : IStudentStore
    {
        private IEnumerable<IStudentModel> _studentList;
        public StudentStore()
        {
            _studentList = new List<IStudentModel>();
            {
                new StudentModel() { StudentName = "s1" };
                new StudentModel() { StudentName = "s2" };
                new StudentModel() { StudentName = "s3" };
                new StudentModel() { StudentName = "s4" };
                new StudentModel() { StudentName = "s5" };
            };
        }
        public IEnumerable<IStudentModel> StudentList { get => _studentList; set => _studentList = value; }

        public void CreateStudent(IStudentModel student)
        {
            _studentList = _studentList.Append(student).ToList();
        }
        public void DeleteStudent(string id)
        {
            _studentList = _studentList.Where(x => x.StudentId != id).ToList();
        }
        public IStudentModel FindStudentByName(string name)
        {
            return _studentList.Where(x => x.StudentName == name).FirstOrDefault();
        }
        public IStudentModel FindStudentById(string id)
        {
            return _studentList.Where(x => x.StudentId == id).FirstOrDefault();
        }
        public void UpdateStudent(IStudentModel student)
        {
            var item = _studentList.Where(s => s.StudentId == student.StudentId).FirstOrDefault();
            DeleteStudent(item.StudentId);
            CreateStudent(student);
        }
    }
}
