using System;

namespace GridViewer
{
    public partial class FormMain
    {
        private string[] timerEnabledSign = { "-", "/", "|", "\\", };
        private int timerEnableSignIndex = 0;

        private void timer1_Tick(object sender, EventArgs e)
        {
            timerEnableSignIndex++;
            if (timerEnableSignIndex >= timerEnabledSign.Length)
            { timerEnableSignIndex = 0; }
            this.lblTimerEnabled.Text = timerEnabledSign[timerEnableSignIndex];
        }
    }
}