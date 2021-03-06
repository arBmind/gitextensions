﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace GitUI
{
    public partial class FormCommitCount : Form
    {
        public FormCommitCount()
        {
            InitializeComponent();
        }

        ~FormCommitCount()
        {
            cmd.Kill();
        }

        private GitCommands.GitCommands cmd = new GitCommands.GitCommands();
        private void FormCommitCount_Load(object sender, EventArgs e)
        {
            Loading.Visible = true;
            cmd.Exited += new EventHandler(cmd_Exited);
            //cmd.CmdStartProcess(GitCommands.Settings.GitDir + "git.cmd", "shortlog -s -n");
            cmd.CmdStartProcess(GitCommands.Settings.GitDir + "C:\\Windows\\System32\\cmd.exe", "/c \"git.cmd log --pretty=short | git.cmd shortlog -s -n\"");
            
           
        }

        void SetCount()
        {
            CommitCount.Text = cmd.Output.ToString();
            Loading.Visible = false;
        }

        void cmd_Exited(object sender, EventArgs e)
        {
            if (CommitCount.InvokeRequired)
            {
                DoneCallback d = new DoneCallback(SetCount);
                this.Invoke(d, new object[] { });
            }
        }
    }
}
