using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using OpenHardwareMonitor.Hardware;
using System.Collections;
using System.Diagnostics;
using System.Reflection;
using System.Security.Principal;


namespace CPUMonitor
{
    public partial class Form1 : Form
    {
        Computer thisComputer;
        int cpuCoresNum;
        Hashtable minMax;


        public Form1()
        {
            InitializeComponent();
            //Initialize open hardware monitor object
            thisComputer = new Computer() 
            { 
                CPUEnabled = true, 
                //GPUEnabled = true, 
                RAMEnabled = true
            };
            minMax = new Hashtable(); //create hash table to storage min, max values
            thisComputer.Open();

            lblContent.Anchor = (AnchorStyles.Top);
            cpuProgressBarLb.Anchor = (AnchorStyles.Left | AnchorStyles.Bottom);
            progressBarCPU.Anchor = (cpuProgressBarLb.Anchor);
            cpuProgressBarCPUPLb.Anchor = (AnchorStyles.Right| AnchorStyles.Bottom);
            progressBarCPU.ForeColor = Color.BlueViolet;
            progressBarRAM.Anchor = (AnchorStyles.Bottom | AnchorStyles.Left);
            progressBarRAMPLb.Anchor = (AnchorStyles.Bottom | AnchorStyles.Right);
           
        }

        
        private void Form1_Load(object sender, EventArgs e)
        {
            //lblContent.Text = String.Format("CPU =");
            lblContent.Text = "System Monitor";
            //lblContent.Text = thisComputer.Hardware[0].Sensors.Count().ToString();
            //lblContent.Text = Environment.ProcessorCount.ToString();
            cpuCoresNum = Environment.ProcessorCount;
            progressBarCPU.Maximum = 100;
            progressBarCPU.Minimum = 0;
            FillTreeView();
            int i = 0;
            foreach (var node in Collect(treeView1.Nodes))
            {
                // load every child node here
                if (i % 2 == 0)
                {
                    node.BackColor = Color.FromArgb(240, 240, 240);
                }
                i++;
            }

        }

        private void timer_Tick(object sender, EventArgs e)
        {
            try //reduce flicker??
            {
                treeView1.BeginUpdate();

                // Update tree view

                //get hardwares info
                foreach (IHardware hw in thisComputer.Hardware)
                {
                    hw.Update();
                    //CPU
                    if (hw.HardwareType == HardwareType.CPU)
                    {                       
                        foreach (IHardware subHardware in hw.SubHardware)
                            subHardware.Update();
                        foreach (var sensor in hw.Sensors)
                        {
                            //update cpu package value
                            if (sensor.SensorType == SensorType.Load)
                            {
                                //update min, max values
                                if (float.Parse((string)minMax["CPUTotalMin"]) > sensor.Value.GetValueOrDefault())
                                {
                                    minMax["CPUTotalMin"] = sensor.Value.GetValueOrDefault().ToString();
                                }
                                else if (float.Parse((string)minMax["CPUTotalMax"]) < sensor.Value.GetValueOrDefault())
                                {
                                    minMax["CPUTotalMax"] = sensor.Value.GetValueOrDefault().ToString();
                                }
                                //update node text
                                treeView1.Nodes[0].Nodes[0].Nodes[0].Nodes[0].Text = String.Format("{0:-10}:{1,14:0}%{2,15:0}%{3,15:0}%"
                                        , sensor.Name
                                        , sensor.Value.GetValueOrDefault()
                                        , float.Parse((string)minMax["CPUTotalMin"])
                                        , float.Parse((string)minMax["CPUTotalMax"])
                                        );
                                cpuProgressBarCPUPLb.Text = String.Format("{0:0}%", sensor.Value.GetValueOrDefault());
                                progressBarCPU.Value = (int)sensor.Value.GetValueOrDefault();
                            }

                            //update cpu cores value
                            for (int i = 1; i <= cpuCoresNum; i++)
                            {
                                if (sensor.SensorType == SensorType.Load && sensor.Name.Contains("CPU Core #" + i))
                                {
                                    //update min, max values
                                    if (float.Parse((string)minMax["CPUMin" + i]) > sensor.Value.GetValueOrDefault())
                                    {
                                        minMax["CPUMin" + i] = sensor.Value.GetValueOrDefault().ToString();
                                    }
                                    else if (float.Parse((string)minMax["CPUMax" + i]) < sensor.Value.GetValueOrDefault())
                                    {
                                        minMax["CPUMax" + i] = sensor.Value.GetValueOrDefault().ToString();
                                    }
                                    //update node text
                                    treeView1.Nodes[0].Nodes[0].Nodes[0].Nodes[i].Text = String.Format("{0:-10}:{1,9:0}%{2,15:0}%{3,15:0}%"
                                        , sensor.Name
                                        , sensor.Value.GetValueOrDefault()
                                        , float.Parse((string)minMax["CPUMin" + i])
                                        , float.Parse((string)minMax["CPUMax" + i]));
                                }
                            }

                            //update cpu temperature
                            if (sensor.SensorType == SensorType.Temperature)
                            {
                                //update min, max values
                                if (float.Parse((string)minMax["CPUTemperatureMin"]) > sensor.Value.GetValueOrDefault())
                                {
                                    minMax["CPUTemperatureMin"] = sensor.Value.GetValueOrDefault().ToString();
                                }
                                else if (float.Parse((string)minMax["CPUTemperatureMax"]) < sensor.Value.GetValueOrDefault())
                                {
                                    minMax["CPUTemperatureMax"] = sensor.Value.GetValueOrDefault().ToString();
                                }
                                //update node text
                                treeView1.Nodes[0].Nodes[0].Nodes[1].Nodes[0].Text = String.Format("{0:-10}:{1,9:0}°C{2,13:0}°C{3,12:0}°C"
                                    , sensor.Name
                                    , sensor.Value.GetValueOrDefault()
                                    , float.Parse((string)minMax["CPUTemperatureMin"])
                                    , float.Parse((string)minMax["CPUTemperatureMax"]));
                            }
                        }
                    }

                    //RAM
                    if (hw.HardwareType == HardwareType.RAM)
                    {
                        foreach (IHardware subHardware in hw.SubHardware)
                            subHardware.Update();
                        foreach (var sensor in hw.Sensors)
                        {
                            //update RAM value
                            if (sensor.SensorType == SensorType.Load)
                            {
                                //Update ram's minimum value
                                if (float.Parse((string)minMax["RAMMin"]) > sensor.Value.GetValueOrDefault())
                                {
                                    minMax["RAMMin"] = sensor.Value.GetValueOrDefault().ToString();
                                }
                                //update node text
                                treeView1.Nodes[0].Nodes[1].Nodes[0].Text = String.Format("{0:-2}:{1,23:0}%{2,15:0}%"
                                        , sensor.Name
                                        , sensor.Value.GetValueOrDefault()
                                        , float.Parse((string)minMax["RAMMin"])
                                        );
                                progressBarRAM.Value = (int)sensor.Value.GetValueOrDefault();
                                progressBarRAMPLb.Text = String.Format("{0:0}%", sensor.Value.GetValueOrDefault());
                            }
                            //update Used Memory
                            if (sensor.SensorType == SensorType.Data && sensor.Name.Contains("Used Memory"))
                            {                               
                                //update node text
                                treeView1.Nodes[0].Nodes[1].Nodes[1].Text = String.Format("{0}:  {1:0.0} GB"
                                        , sensor.Name
                                        , sensor.Value.GetValueOrDefault()
                                        );
                            }
                        }
                    }
                }              
            }
            finally
            {
                treeView1.EndUpdate();
            }
        }

        // set treeview
        private void FillTreeView()
        {
            treeView1.Anchor = (progressBarCPU.Anchor | AnchorStyles.Right | AnchorStyles.Left | lblContent.Anchor);
            // Load the images in an ImageList.
            ImageList myImageList = new ImageList();
            myImageList.Images.Add(Properties.Resources.item);
            myImageList.Images.Add(Properties.Resources.computer_monitor);
            myImageList.Images.Add(Properties.Resources.computer_cpu);
            myImageList.Images.Add(Properties.Resources.graph);
            myImageList.Images.Add(Properties.Resources.temperature);
            myImageList.Images.Add(Properties.Resources.ram);

           
            // Assign the ImageList to the TreeView.
            treeView1.ImageList = myImageList;

            // Set the TreeView control's default image and selected image indexes.
            treeView1.ImageIndex = 0;
            treeView1.SelectedImageIndex = 0;

            //create default nodes
            //device name
            treeView1.Nodes[0].Text = Environment.MachineName.ToString();
            treeView1.Nodes[0].ImageIndex = 1;
            treeView1.Nodes[0].SelectedImageIndex = 1;
            //cpu name
            treeView1.Nodes[0].Nodes[0].Text = thisComputer.Hardware[0].Name.ToString();
            treeView1.Nodes[0].Nodes[0].ImageIndex = 2;
            treeView1.Nodes[0].Nodes[0].SelectedImageIndex = 2;
            //cpu Usage
            treeView1.Nodes[0].Nodes[0].Nodes[0].ImageIndex = 3;
            treeView1.Nodes[0].Nodes[0].Nodes[0].SelectedImageIndex = 3;
            //cpu temp
            treeView1.Nodes[0].Nodes[0].Nodes[1].ImageIndex = 4;
            treeView1.Nodes[0].Nodes[0].Nodes[1].SelectedImageIndex = 4;

            String currentVal;
            float usedMem = 0;
            //add items to tree view
            foreach (IHardware hw in thisComputer.Hardware)
            {
                hw.Update();
                //create CPU nodes, min, max values
                if (hw.HardwareType == HardwareType.CPU)
                {
                    foreach (var sensor in hw.Sensors)
                    {
                        //cpu total
                        if (sensor.SensorType == SensorType.Load && sensor.Name.Contains("CPU Total"))
                        {
                            currentVal = sensor.Value.GetValueOrDefault().ToString();
                            minMax.Add("CPUTotalMin", currentVal);
                            minMax.Add("CPUTotalMax", currentVal);

                        }
                        //add all cpu cores
                        for (int i = 1; i <= cpuCoresNum; i++)
                        {
                            if (sensor.SensorType == SensorType.Load && sensor.Name.Contains("CPU Core #" + i))
                            {
                                currentVal = sensor.Value.GetValueOrDefault().ToString();
                                treeView1.Nodes[0].Nodes[0].Nodes[0].Nodes.Add("initializing");
                                minMax.Add("CPUMin" + i, currentVal);
                                minMax.Add("CPUMax" + i, currentVal);
                            }
                        }
                        //cpu temperature
                        if (sensor.SensorType == SensorType.Temperature && sensor.Name.Contains("CPU Package"))
                        {
                            currentVal = sensor.Value.GetValueOrDefault().ToString();
                            treeView1.Nodes[0].Nodes[0].Nodes[1].Nodes.Add("initializing");
                            minMax.Add("CPUTemperatureMin", currentVal);
                            minMax.Add("CPUTemperatureMax", currentVal);
                        }
                    }
                }

                //create RAM nodes, min, max values
                if (hw.HardwareType == HardwareType.RAM)
                {
                    foreach (var sensor in hw.Sensors)
                    {
                        //Ram percent
                        if (sensor.SensorType == SensorType.Load)
                        {
                            treeView1.Nodes[0].Nodes[1].Nodes.Add("initializing");
                            currentVal = sensor.Value.GetValueOrDefault().ToString();
                            minMax.Add("RAMMin", currentVal);
                        }
                        //ram values
                        if (sensor.SensorType == SensorType.Data)
                        {
                            if (sensor.Name.Contains("Used Memory"))
                            {
                                usedMem = sensor.Value.GetValueOrDefault();
                                treeView1.Nodes[0].Nodes[1].Nodes.Add("initializing");
                                
                            }
                            if (sensor.Name.Contains("Available Memory"))
                            {
                                // caculate total memory
                                float totalMem = usedMem + sensor.Value.GetValueOrDefault(); 
                                treeView1.Nodes[0].Nodes[1].Nodes.Add(String.Format("Total memory:  {0:0.0} GB",totalMem));
                            }
                        }

                    }
                }
            }


            treeView1.ExpandAll();

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            progressBarCPU.Width = this.Width - 110;
            progressBarRAM.Width = this.Width - 110;
        }

        IEnumerable<TreeNode> Collect(TreeNodeCollection nodes)
        {
            foreach (TreeNode node in nodes)
            {
                yield return node;

                foreach (var child in Collect(node.Nodes))
                    yield return child;
            }
        }
    }

    
}
