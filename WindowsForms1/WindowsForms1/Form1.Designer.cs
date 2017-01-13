namespace WindowsForms1
{
    partial class Form1
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.RankDic = new System.Windows.Forms.Button();
            this.Token = new System.Windows.Forms.Button();
            this.Train = new System.Windows.Forms.Button();
            this.Caculation = new System.Windows.Forms.Button();
            this.OutSourceTest = new System.Windows.Forms.Button();
            this.stateLable = new System.Windows.Forms.Label();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.dataProcess = new System.Windows.Forms.TabPage();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.addFeatures = new System.Windows.Forms.Button();
            this.addCoreTerm = new System.Windows.Forms.Button();
            this.TestToken = new System.Windows.Forms.Button();
            this.logText = new System.Windows.Forms.TextBox();
            this.machineLearn = new System.Windows.Forms.TabPage();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.Test = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.resultState = new System.Windows.Forms.Label();
            this.resultAnalysis = new System.Windows.Forms.TabPage();
            this.splitContainer3 = new System.Windows.Forms.SplitContainer();
            this.newTerms = new System.Windows.Forms.Button();
            this.openTest = new System.Windows.Forms.TabPage();
            this.splitContainer4 = new System.Windows.Forms.SplitContainer();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.testResults = new System.Windows.Forms.TextBox();
            this.outTest0 = new System.Windows.Forms.TextBox();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.rePath = new System.Windows.Forms.Button();
            this.pathInput = new System.Windows.Forms.Button();
            this.pathState = new System.Windows.Forms.Label();
            this.pathHeader = new System.Windows.Forms.TextBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.tabControl1.SuspendLayout();
            this.dataProcess.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.machineLearn.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.resultAnalysis.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).BeginInit();
            this.splitContainer3.Panel1.SuspendLayout();
            this.splitContainer3.Panel2.SuspendLayout();
            this.splitContainer3.SuspendLayout();
            this.openTest.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer4)).BeginInit();
            this.splitContainer4.Panel1.SuspendLayout();
            this.splitContainer4.Panel2.SuspendLayout();
            this.splitContainer4.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.SuspendLayout();
            // 
            // RankDic
            // 
            this.RankDic.BackColor = System.Drawing.Color.White;
            this.RankDic.Location = new System.Drawing.Point(12, 31);
            this.RankDic.Name = "RankDic";
            this.RankDic.Size = new System.Drawing.Size(115, 40);
            this.RankDic.TabIndex = 0;
            this.RankDic.Text = "核心词汇排序";
            this.RankDic.UseVisualStyleBackColor = false;
            this.RankDic.Click += new System.EventHandler(this.RankDic_Click);
            // 
            // Token
            // 
            this.Token.BackColor = System.Drawing.Color.White;
            this.Token.Location = new System.Drawing.Point(12, 108);
            this.Token.Name = "Token";
            this.Token.Size = new System.Drawing.Size(115, 40);
            this.Token.TabIndex = 1;
            this.Token.Text = "训练语料标注";
            this.Token.UseVisualStyleBackColor = false;
            this.Token.Click += new System.EventHandler(this.Token_Click);
            // 
            // Train
            // 
            this.Train.BackColor = System.Drawing.Color.White;
            this.Train.Location = new System.Drawing.Point(13, 80);
            this.Train.Name = "Train";
            this.Train.Size = new System.Drawing.Size(75, 40);
            this.Train.TabIndex = 2;
            this.Train.Text = "训练";
            this.Train.UseVisualStyleBackColor = false;
            this.Train.Click += new System.EventHandler(this.Train_Click);
            // 
            // Caculation
            // 
            this.Caculation.BackColor = System.Drawing.Color.White;
            this.Caculation.Location = new System.Drawing.Point(16, 68);
            this.Caculation.Name = "Caculation";
            this.Caculation.Size = new System.Drawing.Size(91, 40);
            this.Caculation.TabIndex = 3;
            this.Caculation.Text = "性能分析";
            this.Caculation.UseVisualStyleBackColor = false;
            this.Caculation.Click += new System.EventHandler(this.Caculation_Click);
            // 
            // OutSourceTest
            // 
            this.OutSourceTest.BackColor = System.Drawing.Color.White;
            this.OutSourceTest.Location = new System.Drawing.Point(12, 218);
            this.OutSourceTest.Name = "OutSourceTest";
            this.OutSourceTest.Padding = new System.Windows.Forms.Padding(2);
            this.OutSourceTest.Size = new System.Drawing.Size(72, 40);
            this.OutSourceTest.TabIndex = 4;
            this.OutSourceTest.Text = "测试";
            this.OutSourceTest.UseVisualStyleBackColor = false;
            this.OutSourceTest.Click += new System.EventHandler(this.OutSourceTest_Click);
            // 
            // stateLable
            // 
            this.stateLable.AutoSize = true;
            this.stateLable.Location = new System.Drawing.Point(23, 44);
            this.stateLable.Name = "stateLable";
            this.stateLable.Size = new System.Drawing.Size(52, 15);
            this.stateLable.TabIndex = 7;
            this.stateLable.Text = "结果：";
            // 
            // tabControl1
            // 
            this.tabControl1.AccessibleRole = System.Windows.Forms.AccessibleRole.MenuBar;
            this.tabControl1.Controls.Add(this.dataProcess);
            this.tabControl1.Controls.Add(this.machineLearn);
            this.tabControl1.Controls.Add(this.resultAnalysis);
            this.tabControl1.Controls.Add(this.openTest);
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Location = new System.Drawing.Point(2, 2);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.Padding = new System.Drawing.Point(20, 12);
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(691, 482);
            this.tabControl1.TabIndex = 10;
            // 
            // dataProcess
            // 
            this.dataProcess.AllowDrop = true;
            this.dataProcess.Controls.Add(this.splitContainer1);
            this.dataProcess.Location = new System.Drawing.Point(4, 43);
            this.dataProcess.Name = "dataProcess";
            this.dataProcess.Padding = new System.Windows.Forms.Padding(3);
            this.dataProcess.Size = new System.Drawing.Size(683, 435);
            this.dataProcess.TabIndex = 0;
            this.dataProcess.Text = "数据预处理";
            this.dataProcess.UseVisualStyleBackColor = true;
            // 
            // splitContainer1
            // 
            this.splitContainer1.BackColor = System.Drawing.Color.Transparent;
            this.splitContainer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.splitContainer1.Location = new System.Drawing.Point(6, 3);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.addFeatures);
            this.splitContainer1.Panel1.Controls.Add(this.addCoreTerm);
            this.splitContainer1.Panel1.Controls.Add(this.TestToken);
            this.splitContainer1.Panel1.Controls.Add(this.RankDic);
            this.splitContainer1.Panel1.Controls.Add(this.Token);
            this.splitContainer1.Panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.splitContainer1_Panel1_Paint);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.AllowDrop = true;
            this.splitContainer1.Panel2.Controls.Add(this.logText);
            this.splitContainer1.Panel2.Margin = new System.Windows.Forms.Padding(5);
            this.splitContainer1.Size = new System.Drawing.Size(674, 426);
            this.splitContainer1.SplitterDistance = 146;
            this.splitContainer1.TabIndex = 2;
            // 
            // addFeatures
            // 
            this.addFeatures.BackColor = System.Drawing.Color.White;
            this.addFeatures.Location = new System.Drawing.Point(12, 341);
            this.addFeatures.Name = "addFeatures";
            this.addFeatures.Size = new System.Drawing.Size(115, 40);
            this.addFeatures.TabIndex = 4;
            this.addFeatures.Text = "添加新特征";
            this.addFeatures.UseVisualStyleBackColor = false;
            this.addFeatures.Click += new System.EventHandler(this.addFeatures_Click);
            // 
            // addCoreTerm
            // 
            this.addCoreTerm.BackColor = System.Drawing.Color.White;
            this.addCoreTerm.Location = new System.Drawing.Point(12, 266);
            this.addCoreTerm.Name = "addCoreTerm";
            this.addCoreTerm.Size = new System.Drawing.Size(115, 40);
            this.addCoreTerm.TabIndex = 3;
            this.addCoreTerm.Text = "添加核心词汇";
            this.addCoreTerm.UseVisualStyleBackColor = false;
            this.addCoreTerm.Click += new System.EventHandler(this.addCoreTerm_Click);
            // 
            // TestToken
            // 
            this.TestToken.BackColor = System.Drawing.Color.White;
            this.TestToken.Location = new System.Drawing.Point(12, 187);
            this.TestToken.Name = "TestToken";
            this.TestToken.Size = new System.Drawing.Size(115, 40);
            this.TestToken.TabIndex = 2;
            this.TestToken.Text = "测试语料标注";
            this.TestToken.UseVisualStyleBackColor = false;
            this.TestToken.Click += new System.EventHandler(this.TestToken_Click);
            // 
            // logText
            // 
            this.logText.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.logText.Location = new System.Drawing.Point(11, 2);
            this.logText.Multiline = true;
            this.logText.Name = "logText";
            this.logText.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.logText.Size = new System.Drawing.Size(508, 419);
            this.logText.TabIndex = 0;
            // 
            // machineLearn
            // 
            this.machineLearn.Controls.Add(this.splitContainer2);
            this.machineLearn.Location = new System.Drawing.Point(4, 43);
            this.machineLearn.Name = "machineLearn";
            this.machineLearn.Padding = new System.Windows.Forms.Padding(3);
            this.machineLearn.Size = new System.Drawing.Size(683, 435);
            this.machineLearn.TabIndex = 1;
            this.machineLearn.Text = "机器学习";
            this.machineLearn.UseVisualStyleBackColor = true;
            // 
            // splitContainer2
            // 
            this.splitContainer2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.splitContainer2.Location = new System.Drawing.Point(6, 3);
            this.splitContainer2.Name = "splitContainer2";
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.Test);
            this.splitContainer2.Panel1.Controls.Add(this.Train);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.label3);
            this.splitContainer2.Panel2.Controls.Add(this.resultState);
            this.splitContainer2.Size = new System.Drawing.Size(671, 426);
            this.splitContainer2.SplitterDistance = 112;
            this.splitContainer2.TabIndex = 4;
            // 
            // Test
            // 
            this.Test.BackColor = System.Drawing.Color.White;
            this.Test.Location = new System.Drawing.Point(13, 235);
            this.Test.Name = "Test";
            this.Test.Size = new System.Drawing.Size(75, 40);
            this.Test.TabIndex = 3;
            this.Test.Text = "测试";
            this.Test.UseVisualStyleBackColor = false;
            this.Test.Click += new System.EventHandler(this.Test_Click_1);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(21, 56);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(75, 15);
            this.label3.TabIndex = 9;
            this.label3.Text = "结果状态:";
            // 
            // resultState
            // 
            this.resultState.AutoSize = true;
            this.resultState.Location = new System.Drawing.Point(95, 80);
            this.resultState.Name = "resultState";
            this.resultState.Size = new System.Drawing.Size(97, 15);
            this.resultState.TabIndex = 8;
            this.resultState.Text = "等待中。。。";
            // 
            // resultAnalysis
            // 
            this.resultAnalysis.Controls.Add(this.splitContainer3);
            this.resultAnalysis.Location = new System.Drawing.Point(4, 43);
            this.resultAnalysis.Name = "resultAnalysis";
            this.resultAnalysis.Size = new System.Drawing.Size(683, 435);
            this.resultAnalysis.TabIndex = 2;
            this.resultAnalysis.Text = "结果分析";
            this.resultAnalysis.UseVisualStyleBackColor = true;
            // 
            // splitContainer3
            // 
            this.splitContainer3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.splitContainer3.Location = new System.Drawing.Point(0, 3);
            this.splitContainer3.Name = "splitContainer3";
            // 
            // splitContainer3.Panel1
            // 
            this.splitContainer3.Panel1.Controls.Add(this.newTerms);
            this.splitContainer3.Panel1.Controls.Add(this.Caculation);
            // 
            // splitContainer3.Panel2
            // 
            this.splitContainer3.Panel2.Controls.Add(this.stateLable);
            this.splitContainer3.Size = new System.Drawing.Size(683, 432);
            this.splitContainer3.SplitterDistance = 123;
            this.splitContainer3.TabIndex = 8;
            // 
            // newTerms
            // 
            this.newTerms.BackColor = System.Drawing.Color.White;
            this.newTerms.Location = new System.Drawing.Point(16, 253);
            this.newTerms.Name = "newTerms";
            this.newTerms.Size = new System.Drawing.Size(91, 40);
            this.newTerms.TabIndex = 6;
            this.newTerms.Text = "候选术语";
            this.newTerms.UseVisualStyleBackColor = false;
            this.newTerms.Click += new System.EventHandler(this.newTerms_Click);
            // 
            // openTest
            // 
            this.openTest.Controls.Add(this.splitContainer4);
            this.openTest.Location = new System.Drawing.Point(4, 43);
            this.openTest.Name = "openTest";
            this.openTest.Padding = new System.Windows.Forms.Padding(3);
            this.openTest.Size = new System.Drawing.Size(683, 435);
            this.openTest.TabIndex = 3;
            this.openTest.Text = "开放测试";
            this.openTest.UseVisualStyleBackColor = true;
            // 
            // splitContainer4
            // 
            this.splitContainer4.Location = new System.Drawing.Point(6, 6);
            this.splitContainer4.Name = "splitContainer4";
            // 
            // splitContainer4.Panel1
            // 
            this.splitContainer4.Panel1.Controls.Add(this.OutSourceTest);
            // 
            // splitContainer4.Panel2
            // 
            this.splitContainer4.Panel2.Controls.Add(this.label2);
            this.splitContainer4.Panel2.Controls.Add(this.label1);
            this.splitContainer4.Panel2.Controls.Add(this.testResults);
            this.splitContainer4.Panel2.Controls.Add(this.outTest0);
            this.splitContainer4.Size = new System.Drawing.Size(677, 429);
            this.splitContainer4.SplitterDistance = 105;
            this.splitContainer4.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(18, 243);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(75, 15);
            this.label2.TabIndex = 3;
            this.label2.Text = "测试结果:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(18, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(75, 15);
            this.label1.TabIndex = 2;
            this.label1.Text = "测试数据:";
            // 
            // testResults
            // 
            this.testResults.Location = new System.Drawing.Point(21, 261);
            this.testResults.Multiline = true;
            this.testResults.Name = "testResults";
            this.testResults.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.testResults.Size = new System.Drawing.Size(503, 153);
            this.testResults.TabIndex = 1;
            // 
            // outTest0
            // 
            this.outTest0.Location = new System.Drawing.Point(21, 28);
            this.outTest0.Multiline = true;
            this.outTest0.Name = "outTest0";
            this.outTest0.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.outTest0.Size = new System.Drawing.Size(503, 184);
            this.outTest0.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.rePath);
            this.tabPage1.Controls.Add(this.pathInput);
            this.tabPage1.Controls.Add(this.pathState);
            this.tabPage1.Controls.Add(this.pathHeader);
            this.tabPage1.Controls.Add(this.textBox1);
            this.tabPage1.Location = new System.Drawing.Point(4, 43);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(683, 435);
            this.tabPage1.TabIndex = 4;
            this.tabPage1.Text = "使用说明";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // rePath
            // 
            this.rePath.Location = new System.Drawing.Point(582, 326);
            this.rePath.Name = "rePath";
            this.rePath.Size = new System.Drawing.Size(75, 23);
            this.rePath.TabIndex = 9;
            this.rePath.Text = "重置路径";
            this.rePath.UseVisualStyleBackColor = true;
            this.rePath.Click += new System.EventHandler(this.rePath_Click);
            // 
            // pathInput
            // 
            this.pathInput.Location = new System.Drawing.Point(20, 326);
            this.pathInput.Name = "pathInput";
            this.pathInput.Size = new System.Drawing.Size(75, 23);
            this.pathInput.TabIndex = 8;
            this.pathInput.Text = "确定";
            this.pathInput.UseVisualStyleBackColor = true;
            this.pathInput.Click += new System.EventHandler(this.pathInput_Click);
            // 
            // pathState
            // 
            this.pathState.AutoSize = true;
            this.pathState.Location = new System.Drawing.Point(17, 277);
            this.pathState.Name = "pathState";
            this.pathState.Size = new System.Drawing.Size(137, 15);
            this.pathState.TabIndex = 7;
            this.pathState.Text = "CRFs文件路径输入:";
            // 
            // pathHeader
            // 
            this.pathHeader.Location = new System.Drawing.Point(20, 295);
            this.pathHeader.Name = "pathHeader";
            this.pathHeader.Size = new System.Drawing.Size(637, 25);
            this.pathHeader.TabIndex = 6;
            this.pathHeader.Text = "C:\\Users\\AMY\\Desktop\\thesis\\crfs";
            // 
            // textBox1
            // 
            this.textBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox1.Location = new System.Drawing.Point(20, 19);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(637, 207);
            this.textBox1.TabIndex = 0;
            this.textBox1.Text = resources.GetString("textBox1.Text");
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(692, 486);
            this.Controls.Add(this.tabControl1);
            this.Name = "Form1";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "专利术语抽取系统";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.tabControl1.ResumeLayout(false);
            this.dataProcess.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.machineLearn.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            this.splitContainer2.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.resultAnalysis.ResumeLayout(false);
            this.splitContainer3.Panel1.ResumeLayout(false);
            this.splitContainer3.Panel2.ResumeLayout(false);
            this.splitContainer3.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).EndInit();
            this.splitContainer3.ResumeLayout(false);
            this.openTest.ResumeLayout(false);
            this.splitContainer4.Panel1.ResumeLayout(false);
            this.splitContainer4.Panel2.ResumeLayout(false);
            this.splitContainer4.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer4)).EndInit();
            this.splitContainer4.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button RankDic;
        private System.Windows.Forms.Button Token;
        private System.Windows.Forms.Button Train;
        private System.Windows.Forms.Button Caculation;
        private System.Windows.Forms.Button OutSourceTest;
        private System.Windows.Forms.Label stateLable;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage dataProcess;
        private System.Windows.Forms.TabPage machineLearn;
        private System.Windows.Forms.TabPage resultAnalysis;
        private System.Windows.Forms.TabPage openTest;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.TextBox logText;
        private System.Windows.Forms.Button addCoreTerm;
        private System.Windows.Forms.Button TestToken;
        private System.Windows.Forms.Button addFeatures;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.Label resultState;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.Label pathState;
        private System.Windows.Forms.TextBox pathHeader;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button pathInput;
        private System.Windows.Forms.Button rePath;
        private System.Windows.Forms.Button Test;
        private System.Windows.Forms.SplitContainer splitContainer3;
        private System.Windows.Forms.Button newTerms;
        private System.Windows.Forms.SplitContainer splitContainer4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox testResults;
        private System.Windows.Forms.TextBox outTest0;
    }
}

