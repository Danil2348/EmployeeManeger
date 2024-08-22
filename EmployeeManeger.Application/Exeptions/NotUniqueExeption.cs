using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManeger.Application.Exeptions
{
    public class NotUniqueExeption: Exception
    {
        public NotUniqueExeption()
            :base("Данные уже существуют"){}
    }
}
