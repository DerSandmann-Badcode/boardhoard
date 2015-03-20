using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoardHoard
{
    // Create DataGridView that allows us to set DoubleBuffered
    public class BufferedDataGridView: System.Windows.Forms.DataGridView
    {
        public BufferedDataGridView()
        {
            // Doublebuffering is slow on remote sessions, check for this. If not remote, set double buffering to true
            if (!System.Windows.Forms.SystemInformation.TerminalServerSession)
                DoubleBuffered = true;
        } 
    }
}
