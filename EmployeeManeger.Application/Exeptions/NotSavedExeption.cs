using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManeger.Application.Exeptions
{
    class NotSavedExeption: Exception
    {
        public NotSavedExeption()
            :base ("Что то пошло не так при изменении бд"){}
    }
}
