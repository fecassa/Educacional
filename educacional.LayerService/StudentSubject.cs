using educacional.LayerDomain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace educacional.LayerService
{
    public class StudentSubjectService
    {
        private readonly educacional.LayerInfrastructure.AppContext _context;

        public StudentSubjectService(educacional.LayerInfrastructure.AppContext context)
        {
            _context = context;
        }

        public void CreateStudentSubject()
        {
            var _historic = _context.StudentSubjects.ToList().Count;

            if (_historic > 0)
                throw new System.Exception("There are already registered subjects. Please, reload database scripts.");

            var _students = _context.Students.ToList();
            var _subjects = _context.Subjects.ToList();

            foreach (Student _student in _students)
            {
                foreach (Subject _subject in _subjects)
                {
                    StudentSubject _studentSubject = new StudentSubject();
                    _studentSubject.StudentId = _student.Id;
                    _studentSubject.SubjectId = _subject.Id;
                    _studentSubject.Grade = GenerateRandomGrade();

                    _context.Add(_studentSubject);
                }
                _context.SaveChanges();
            }                        
        }

        private double GenerateRandomGrade()
        {            
            int _gradeInt = new Random().Next(0, 10);
            double _gradeDbl = 0;

            if(_gradeInt < 10)
            {
                _gradeDbl = new Random().NextDouble() + _gradeInt;
            }
            else
            {
                _gradeDbl = _gradeInt;
            }

            return Math.Round(_gradeDbl,2);
        }        
//      
    }
}
