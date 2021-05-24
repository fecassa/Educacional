using educacional.LayerDomain.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace educacional.Domain.Model
{
    [Table("StudentAddress")]
    public class StudentAddress
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public int StudentId { get; set; }
        public virtual Student Student { get; set; }
    }
}
