using educacional.LayerDomain.Model;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace educacional.LayerService
{
    public class StudentService
    {
        private readonly educacional.LayerInfrastructure.AppContext _context;

        public StudentService(educacional.LayerInfrastructure.AppContext context)
        {
            _context = context;
        }

        public void CreateStudents()
        {
            var _historic = _context.Students.ToList().Count;

            if (_historic > 0)
                throw new System.Exception("There already registered students. Please, reload database scripts.");

            string[] _name = { "Amanda", "Betina", "Bruna", "Carla", "Carlos", "Fabio", "Fabricio", "Fernanda", "Fernando", "Felipe", "Feliciano", "Denise", "Douglas", "Dario", "Gustavo", "Guilherme", "Juliana", "Juliano", "Thiago", "Marcelo" };
            string[] _middle = { "Cassiano", "Toledo", "Tavares", "Gomes", "Queiroz", "Pereira", "Isis", "Oliveira", "Viana", "Lima" };
            string[] _lastName = { "dos Santos", "Dias", "da Silva", "Silveira", "da Nobrega" };
            StringBuilder _studentName;

            foreach (string _fname in _name)
            {
                foreach (string _mname in _middle)
                {
                    foreach (string _lname in _lastName)
                    {
                        _studentName = new StringBuilder();
                        _studentName.Append(_fname).Append(" ").Append(_mname).Append(" ").Append(_lname);

                        _context.Add(new Student() { Name = _studentName.ToString() });
                    }
                }
            }            
            _context.SaveChanges();
        }

        public void GetAddress()
        {
            var _address = _context.Addresses.Include( b => b.Student).ToList();
        }

    }
}
