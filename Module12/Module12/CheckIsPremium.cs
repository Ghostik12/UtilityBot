using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module12
{
    class CheckIsPremium
    {
        private bool _isPremium;

        public void Check(User user)
        {
            var show = new ShowAds();
            Console.WriteLine($"{user.Name}");
            if (user.IsPremium ==  true)
            {
                return;
            }
            else
            {
                show.IsShowAds();
            }
        }
    }
}
