using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            user _user = new user();

            using (matchiEntities db = new matchiEntities())
            {
                try
                {
                    _user.full_name = "Frank123123213 Humarang";
                    _user.email = "frank@gmail.com";

                    _user.password = "abcd1234";
                    _user.date_joined = DateTime.Now.ToString();
                    _user.user_handle = "frank32";
                    _user.user_avatar_url = "";

                    _user.is_active = true;
                    db.users.Add(_user);
                    db.SaveChanges();
                }catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    Console.ReadKey();
                }
            }
        }
    }
}
