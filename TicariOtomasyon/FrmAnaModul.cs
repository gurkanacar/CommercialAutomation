using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TicariOtomasyon
{
    public partial class FrmAnaModul : Form
    {
        public FrmAnaModul()
        {
            InitializeComponent();
        }

        FrmUrunler fr;
        private void btnUrunler_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if(fr==null || fr.IsDisposed)
            {
                fr = new FrmUrunler();
                fr.MdiParent = this;
                fr.Show();
            }
            
        }
        FrmMusteriler fr2;
        private void btnMusteriler_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (fr2 == null || fr2.IsDisposed)
            {
                fr2 = new FrmMusteriler();
                fr2.MdiParent = this;
                fr2.Show();
            }
        }
    }
}
