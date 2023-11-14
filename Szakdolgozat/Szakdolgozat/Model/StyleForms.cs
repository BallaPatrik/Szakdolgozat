using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Szakdolgozat.Main_Code;

namespace Szakdolgozat.Model
{
    class StyleForms
    {
        public void styleChildForm(Form form)
        {
            form.BackColor = Color.FromArgb(153, 180, 209);
            Size formsize = new Size(963, 636);
            form.Size = formsize;
        }

        public void styleParentForm(Form form)
        {

        }
    }
}
