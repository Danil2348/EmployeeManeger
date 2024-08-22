using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManeger.Application.Exeptions
{
    public class NotDataExeption: Exception
    {
        public NotDataExeption()
            :base("Неверные данные"){}
    }
}
