using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Szakdolgozat.Model;

namespace Szakdolgozat.Main_Code
{
    public partial class OfficeClerkFormCheckBalance : Form
    {
        StyleForms stilus = new StyleForms();

        public OfficeClerkFormCheckBalance()
        {
            InitializeComponent();
            showBalance();

            stilus.styleChildForm(this);
        }

        private void showBalance()
        {
            int jelenlegiegyenleg = Balance.getInstance().getCurrentBalance();

            TB_egyenleg.Text =  jelenlegiegyenleg + " Ft";
        }


    }
}
