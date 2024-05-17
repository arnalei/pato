#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace songcayawoncorelib.Model
{
    public interface IStudentModel
    {
        string StudentId { get; set; }
        string StudentName { get; set; }
    }

    public class StudentModel : IStudentModel
    {
        private string studentId;
        private string studentName;

        public StudentModel()
        {
            studentId = Guid.NewGuid().ToString();
        }

        public string StudentId { get => studentId; set => studentId = value; }
        public string StudentName { get => studentName; set => studentName = value; }
    }
}
