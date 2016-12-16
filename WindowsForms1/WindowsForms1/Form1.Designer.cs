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
            this.RankDic = new System.Windows.Forms.Button();
            this.Token = new System.Windows.Forms.Button();
            this.Train = new System.Windows.Forms.Button();
            this.Caculation = new System.Windows.Forms.Button();
            this.OutSourceTest = new System.Windows.Forms.Button();
            this.TermRelationship = new System.Windows.Forms.Button();
            this.button7 = new System.Windows.Forms.Button();
            this.stateLable = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // RankDic
            // 
            this.RankDic.Location = new System.Drawing.Point(27, 25);
            this.RankDic.Name = "RankDic";
            this.RankDic.Size = new System.Drawing.Size(75, 23);
            this.RankDic.TabIndex = 0;
            this.RankDic.Text = "order";
            this.RankDic.UseVisualStyleBackColor = true;
            this.RankDic.Click += new System.EventHandler(this.RankDic_Click);
            // 
            // Token
            // 
            this.Token.Location = new System.Drawing.Point(27, 89);
            this.Token.Name = "Token";
            this.Token.Size = new System.Drawing.Size(75, 23);
            this.Token.TabIndex = 1;
            this.Token.Text = "token";
            this.Token.UseVisualStyleBackColor = true;
            this.Token.Click += new System.EventHandler(this.Token_Click);
            // 
            // Train
            // 
            this.Train.Location = new System.Drawing.Point(27, 143);
            this.Train.Name = "Train";
            this.Train.Size = new System.Drawing.Size(75, 23);
            this.Train.TabIndex = 2;
            this.Train.Text = "train";
            this.Train.UseVisualStyleBackColor = true;
            this.Train.Click += new System.EventHandler(this.Train_Click);
            // 
            // Caculation
            // 
            this.Caculation.Location = new System.Drawing.Point(27, 208);
            this.Caculation.Name = "Caculation";
            this.Caculation.Size = new System.Drawing.Size(91, 23);
            this.Caculation.TabIndex = 3;
            this.Caculation.Text = "Caculation";
            this.Caculation.UseVisualStyleBackColor = true;
            this.Caculation.Click += new System.EventHandler(this.Caculation_Click);
            // 
            // OutSourceTest
            // 
            this.OutSourceTest.Location = new System.Drawing.Point(27, 263);
            this.OutSourceTest.Name = "OutSourceTest";
            this.OutSourceTest.Size = new System.Drawing.Size(114, 23);
            this.OutSourceTest.TabIndex = 4;
            this.OutSourceTest.Text = "outSourceTest";
            this.OutSourceTest.UseVisualStyleBackColor = true;
            this.OutSourceTest.Click += new System.EventHandler(this.OutSourceTest_Click);
            // 
            // TermRelationship
            // 
            this.TermRelationship.Location = new System.Drawing.Point(27, 325);
            this.TermRelationship.Name = "TermRelationship";
            this.TermRelationship.Size = new System.Drawing.Size(137, 23);
            this.TermRelationship.TabIndex = 5;
            this.TermRelationship.Text = "termRelationship";
            this.TermRelationship.UseVisualStyleBackColor = true;
            // 
            // button7
            // 
            this.button7.Location = new System.Drawing.Point(27, 388);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(75, 23);
            this.button7.TabIndex = 6;
            this.button7.Text = "button7";
            this.button7.UseVisualStyleBackColor = true;
            // 
            // stateLable
            // 
            this.stateLable.AutoSize = true;
            this.stateLable.Location = new System.Drawing.Point(337, 25);
            this.stateLable.Name = "stateLable";
            this.stateLable.Size = new System.Drawing.Size(74, 17);
            this.stateLable.TabIndex = 7;
            this.stateLable.Text = "stateLable";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(702, 481);
            this.Controls.Add(this.stateLable);
            this.Controls.Add(this.button7);
            this.Controls.Add(this.TermRelationship);
            this.Controls.Add(this.OutSourceTest);
            this.Controls.Add(this.Caculation);
            this.Controls.Add(this.Train);
            this.Controls.Add(this.Token);
            this.Controls.Add(this.RankDic);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button RankDic;
        private System.Windows.Forms.Button Token;
        private System.Windows.Forms.Button Train;
        private System.Windows.Forms.Button Caculation;
        private System.Windows.Forms.Button OutSourceTest;
        private System.Windows.Forms.Button TermRelationship;
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.Label stateLable;
    }
}

