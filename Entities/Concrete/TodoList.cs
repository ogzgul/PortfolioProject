using Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class TodoList:IEntity
    {
        [Key]
        public int TodoID { get; set; }
        public string Content { get; set; }
        public bool Status { get; set; }
    }
}
