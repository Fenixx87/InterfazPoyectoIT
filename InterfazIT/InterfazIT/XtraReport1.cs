using DevExpress.XtraReports.UI;
using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;

namespace InterfazIT
{
    public partial class XtraReport1 : DevExpress.XtraReports.UI.XtraReport
    {
        public XtraReport1()
        {
            InitializeComponent();
        }

        public void InitData(string name, string lastName, string codeImg)
        {
            pName.Value = name;
            pLastName.Value = lastName;
            pCode.Value = codeImg;
        }

    }
}
