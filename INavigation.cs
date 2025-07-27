using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static barmaster.INavigation;
using System.Windows.Forms;

namespace barmaster
{
    public interface INavigation
    {
        void Navigate(Form currentForm, Form destinationForm);
    }
}
