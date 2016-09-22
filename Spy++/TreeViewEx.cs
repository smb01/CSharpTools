using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace Spypp
{
    public partial class TreeViewEx : TreeView
    {
        public TreeViewEx()
        {
            SetStyle(ControlStyles.DoubleBuffer |
                ControlStyles.OptimizedDoubleBuffer |
                ControlStyles.AllPaintingInWmPaint, true);
            UpdateStyles();
        }
    }

}
