using JqueryCrud.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JqueryCrud.InterFace
{
    public interface HomeInterface
    {
        List<EmployeeModel> GetEmply();
        void SaveEmply(EmployeeModel a_emp);
    }
}