using System;
using System.Collections.Generic;
using System.Text;
using EntitiesProject.Models;


namespace BLInterfaces
{
    public interface ILogin
    {
        string Login(LoginEntity loginEntity);
    }

    public interface IRegister
    {
        string Register(RegisterEntity registerEntity);
    }
}
