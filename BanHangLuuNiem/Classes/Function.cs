using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace BanHangLuuNiem.Classes
{
    internal class Function
    {
        public void FillComBox(ComboBox cb, DataTable dt, string display, string value)
        {
            cb.DataSource = dt;
            cb.DisplayMember = display;
            cb.ValueMember = value;
        }
    }
}
