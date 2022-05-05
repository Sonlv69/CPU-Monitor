
namespace CPUMonitor
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.TreeNode treeNode7 = new System.Windows.Forms.TreeNode("Package");
            System.Windows.Forms.TreeNode treeNode8 = new System.Windows.Forms.TreeNode("Utilization               Current      |    Min      |     Max", new System.Windows.Forms.TreeNode[] {
            treeNode7});
            System.Windows.Forms.TreeNode treeNode9 = new System.Windows.Forms.TreeNode("Temperature");
            System.Windows.Forms.TreeNode treeNode10 = new System.Windows.Forms.TreeNode("CPU name", new System.Windows.Forms.TreeNode[] {
            treeNode8,
            treeNode9});
            System.Windows.Forms.TreeNode treeNode11 = new System.Windows.Forms.TreeNode("RAM                              Current      |    Min");
            System.Windows.Forms.TreeNode treeNode12 = new System.Windows.Forms.TreeNode("Machine", new System.Windows.Forms.TreeNode[] {
            treeNode10,
            treeNode11});
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.lblContent = new System.Windows.Forms.Label();
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.cpuProgressBarLb = new System.Windows.Forms.Label();
            this.progressBarCPU = new System.Windows.Forms.ProgressBar();
            this.cpuProgressBarCPUPLb = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.progressBarRAM = new System.Windows.Forms.ProgressBar();
            this.progressBarRAMPLb = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblContent
            // 
            this.lblContent.AutoSize = true;
            this.lblContent.Font = new System.Drawing.Font("Microsoft Tai Le", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblContent.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblContent.Location = new System.Drawing.Point(239, 4);
            this.lblContent.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblContent.Name = "lblContent";
            this.lblContent.Size = new System.Drawing.Size(55, 21);
            this.lblContent.TabIndex = 0;
            this.lblContent.Text = "isNull";
            // 
            // timer
            // 
            this.timer.Enabled = true;
            this.timer.Interval = 2000;
            this.timer.Tick += new System.EventHandler(this.timer_Tick);
            // 
            // treeView1
            // 
            this.treeView1.Font = new System.Drawing.Font("Microsoft New Tai Lue", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.treeView1.LineColor = System.Drawing.Color.Red;
            this.treeView1.Location = new System.Drawing.Point(12, 28);
            this.treeView1.Name = "treeView1";
            treeNode7.Name = "cpuUtilizationPackage";
            treeNode7.Text = "Package";
            treeNode8.ImageIndex = -2;
            treeNode8.Name = "cpuUtilization";
            treeNode8.NodeFont = new System.Drawing.Font("Microsoft Tai Le", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            treeNode8.Text = "Utilization               Current      |    Min      |     Max";
            treeNode9.Name = "Temperature";
            treeNode9.Text = "Temperature";
            treeNode10.ImageIndex = -2;
            treeNode10.Name = "cpuName";
            treeNode10.Text = "CPU name";
            treeNode11.Name = "RAM";
            treeNode11.NodeFont = new System.Drawing.Font("Microsoft Tai Le", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            treeNode11.Text = "RAM                              Current      |    Min";
            treeNode12.ImageIndex = -2;
            treeNode12.Name = "machineName";
            treeNode12.Text = "Machine";
            this.treeView1.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode12});
            this.treeView1.ShowRootLines = false;
            this.treeView1.Size = new System.Drawing.Size(576, 372);
            this.treeView1.TabIndex = 1;
            // 
            // cpuProgressBarLb
            // 
            this.cpuProgressBarLb.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.cpuProgressBarLb.AutoSize = true;
            this.cpuProgressBarLb.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cpuProgressBarLb.Location = new System.Drawing.Point(12, 414);
            this.cpuProgressBarLb.Name = "cpuProgressBarLb";
            this.cpuProgressBarLb.Size = new System.Drawing.Size(33, 15);
            this.cpuProgressBarLb.TabIndex = 2;
            this.cpuProgressBarLb.Text = "CPU";
            // 
            // progressBarCPU
            // 
            this.progressBarCPU.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.progressBarCPU.Location = new System.Drawing.Point(51, 406);
            this.progressBarCPU.Name = "progressBarCPU";
            this.progressBarCPU.Size = new System.Drawing.Size(509, 23);
            this.progressBarCPU.TabIndex = 3;
            // 
            // cpuProgressBarCPUPLb
            // 
            this.cpuProgressBarCPUPLb.AutoSize = true;
            this.cpuProgressBarCPUPLb.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cpuProgressBarCPUPLb.Location = new System.Drawing.Point(565, 414);
            this.cpuProgressBarCPUPLb.Name = "cpuProgressBarCPUPLb";
            this.cpuProgressBarCPUPLb.Size = new System.Drawing.Size(18, 15);
            this.cpuProgressBarCPUPLb.TabIndex = 4;
            this.cpuProgressBarCPUPLb.Text = "%";
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 10;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // progressBarRAM
            // 
            this.progressBarRAM.Location = new System.Drawing.Point(50, 437);
            this.progressBarRAM.Name = "progressBarRAM";
            this.progressBarRAM.Size = new System.Drawing.Size(509, 23);
            this.progressBarRAM.TabIndex = 5;
            // 
            // progressBarRAMPLb
            // 
            this.progressBarRAMPLb.AutoSize = true;
            this.progressBarRAMPLb.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.progressBarRAMPLb.Location = new System.Drawing.Point(565, 443);
            this.progressBarRAMPLb.Name = "progressBarRAMPLb";
            this.progressBarRAMPLb.Size = new System.Drawing.Size(18, 15);
            this.progressBarRAMPLb.TabIndex = 4;
            this.progressBarRAMPLb.Text = "%";
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(12, 443);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(32, 15);
            this.label2.TabIndex = 2;
            this.label2.Text = "RAM";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(600, 469);
            this.Controls.Add(this.progressBarRAM);
            this.Controls.Add(this.progressBarRAMPLb);
            this.Controls.Add(this.cpuProgressBarCPUPLb);
            this.Controls.Add(this.progressBarCPU);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cpuProgressBarLb);
            this.Controls.Add(this.treeView1);
            this.Controls.Add(this.lblContent);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "Form1";
            this.Text = "Monitor";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblContent;
        private System.Windows.Forms.Timer timer;
        private System.Windows.Forms.TreeView treeView1;
        private System.Windows.Forms.Label cpuProgressBarLb;
        private System.Windows.Forms.ProgressBar progressBarCPU;
        private System.Windows.Forms.Label cpuProgressBarCPUPLb;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.ProgressBar progressBarRAM;
        private System.Windows.Forms.Label progressBarRAMPLb;
        private System.Windows.Forms.Label label2;
    }
}

