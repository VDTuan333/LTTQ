using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace De1_DataProcesses.Classes
{
    internal class Function
    {
        public void FillComBox(ComboBox cb, DataTable dt, string display, string values)
        {
            cb.DataSource = dt;
            cb.DisplayMember = display;
            cb.ValueMember = values;
        }
    }
}
