using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BookStoreApp
{
    public partial class Form1 : Form
    {
        Data.Connection con = new Data.Connection();
        public Form1()
        {
            InitializeComponent();
            Data.Connection.dataSource();
            con.connOpen();
        }
    }
}
