using System;
using System.Collections.Generic;
using System.Text;
using EntitiesProject.Models;
using BLInterfaces;
using DALImplementation;
using DALInterfaces;


namespace BLImplementation 
{
    public class LoginBLImp : BLInterfaces.ILogin
    {
        public string Login(LoginEntity loginEntity)
        {
            try
            {
                LoginDALImp inslogindal = new LoginDALImp();
                return inslogindal.LoginDal(loginEntity);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }

    public class RegisterBLImp : BLInterfaces.IRegister
    {
        public string Register(RegisterEntity registerEntity)
        {
            try
            {
                LoginDALImp inslogindal = new LoginDALImp();
                return inslogindal.RegisterDal(registerEntity);
            }

            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
