using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace barmaster
{
    internal class NavigationService : INavigation
    {
        public void Navigate(Form currentForm , Form destinationForm)
        {
            if (currentForm == null)
                throw new ArgumentNullException(nameof(currentForm));
            if (destinationForm == null)
                throw new ArgumentNullException(nameof(destinationForm));

            destinationForm.Show();
            currentForm.Close();
        }
    }
}
