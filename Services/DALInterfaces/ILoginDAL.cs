using System;
using System.Collections.Generic;
using System.Text;
using EntitiesProject.Models;

namespace DALInterfaces
{
    public interface ILoginDAL
    {
        string LoginDal(LoginEntity loginEntity);
        string RegisterDal(RegisterEntity registerEntity);
    }
}
