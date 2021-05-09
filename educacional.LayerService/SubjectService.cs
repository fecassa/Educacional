using educacional.LayerDomain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace educacional.LayerService
{
    public class SubjectService
    {
        private readonly educacional.LayerInfrastructure.AppContext _context;

        public SubjectService(educacional.LayerInfrastructure.AppContext context)
        {
            _context = context;
        }

        public void CreateSubject()
        {
            var _historic = _context.Subjects.ToList().Count;

            if (_historic > 0)
                throw new System.Exception("There are already registered students. Please, reload database scripts.");

            string[] _subject = { "Maths", "Portuguese", "History", "Geography", "English", "Biology", "Philosophy", "Physics", "Chemistry" };
                        
            foreach (string _subjectName in _subject)
            {               
                 _context.Add(new Subject() { Name = _subjectName });                
                
            }
            _context.SaveChanges();
        }
    }
}
