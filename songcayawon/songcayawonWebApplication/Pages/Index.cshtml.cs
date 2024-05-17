#nullable disable
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.RazorPages;
using songcayawoncorelib.Model;
using songcayawoncorelib.Stores;

namespace songcayawonWebApplication.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly IStudentStore _store;
        private readonly IStudentModel _student;

        public string Title { get; set; }

        [BindProperty]
        public StudentModel Student { get; set; }
        public IEnumerable<IStudentModel> StudentList => _store.StudentList;

        public IndexModel(
            ILogger<IndexModel> logger,
            IStudentStore store,
            IStudentModel student
        )
        {
            _logger = logger;

            Title = "Welcome " + DateTime.Now.ToString();

            _store = store;
            _student = student;
        }

        public IActionResult OnGet()
        {
            Title = string.Empty;
            Student = new StudentModel();
            // Student = _student;

            return Page();
        }

        public IActionResult OnPost()
        {
            if (ModelState.IsValid)
            {
                Title = $"{Student.StudentId} - {Student.StudentName}";

                _store.CreateStudent(Student);
            }
            return Page();
        }

        public void OnPostTest()
        {

        }

        public IActionResult OnGetCreateStudent()
        {
            Title = string.Empty;
            Student = new StudentModel() { StudentName = "AJ The Great" };
            // Student = _student;

            return Page();
        }

        public IActionResult OnGetEditStudent(string id = null)
        {
            if (string.IsNullOrEmpty(id))
            {
                Title = string.Empty;
                Student = new StudentModel();
                // Student = _student;
            }
            else
            {
                var student = _store.FindStudentById(id);
                Student = (StudentModel)student;
            }

            return Page();
        }

        public IActionResult OnGetDeleteStudent(string id = null)
        {
            Student = new StudentModel();

            if (string.IsNullOrEmpty(id))
            {
            }
            else
            {
                _store.DeleteStudent(id);
            }

            return Page();
        }
    }
}