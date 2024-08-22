using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManeger.Application.Exeptions
{
    public class NotFoundExeption: Exception
    {
        public NotFoundExeption()
            :base("Не удалось найти таких данных"){}
    }
}
