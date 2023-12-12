using System;

namespace Module12
{
    class Program
    {
        static void Main(string[] args)
        {
            var check = new CheckIsPremium();
            var user1 = new User();
            var user2 = new User();
            var user3 = new User();

            user1.Name = "Test1";
            user1.Login = "Log1";
            user1.IsPremium = true;

            user2.Name = "Test2";
            user2.Login = "Log2";
            user2.IsPremium = false;

            user3.Name = "Test3";
            user3.Login = "Log3";
            user3.IsPremium = true;

            check.Check(user1);
            check.Check(user2);
            check.Check(user3);
        }
    }
}