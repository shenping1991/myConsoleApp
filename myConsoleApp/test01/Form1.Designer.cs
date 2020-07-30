namespace test01
{
    partial class FrmMain
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
            this.GVBook = new System.Windows.Forms.DataGridView();
            this.BookId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BarCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BookName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Author = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PublisherId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PublishDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btn_showList = new System.Windows.Forms.Button();
            this.btn_addItem = new System.Windows.Forms.Button();
            this.btn_insertItem = new System.Windows.Forms.Button();
            this.btn_delItem = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.GVBook)).BeginInit();
            this.SuspendLayout();
            // 
            // GVBook
            // 
            this.GVBook.AllowUserToAddRows = false;
            this.GVBook.AllowUserToDeleteRows = false;
            this.GVBook.BackgroundColor = System.Drawing.SystemColors.Control;
            this.GVBook.ColumnHeadersHeight = 30;
            this.GVBook.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.BookId,
            this.BarCode,
            this.BookName,
            this.Author,
            this.PublisherId,
            this.PublishDate});
            this.GVBook.Location = new System.Drawing.Point(20, 20);
            this.GVBook.Name = "GVBook";
            this.GVBook.ReadOnly = true;
            this.GVBook.RowTemplate.Height = 23;
            this.GVBook.Size = new System.Drawing.Size(560, 260);
            this.GVBook.TabIndex = 0;
            // 
            // BookId
            // 
            this.BookId.DataPropertyName = "BookId";
            this.BookId.HeaderText = "序号";
            this.BookId.Name = "BookId";
            this.BookId.ReadOnly = true;
            this.BookId.Width = 60;
            // 
            // BarCode
            // 
            this.BarCode.DataPropertyName = "BarCode";
            this.BarCode.HeaderText = "图书编号";
            this.BarCode.Name = "BarCode";
            this.BarCode.ReadOnly = true;
            // 
            // BookName
            // 
            this.BookName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.BookName.DataPropertyName = "BookName";
            this.BookName.HeaderText = "图书名称";
            this.BookName.Name = "BookName";
            this.BookName.ReadOnly = true;
            // 
            // Author
            // 
            this.Author.DataPropertyName = "Author";
            this.Author.HeaderText = "作者";
            this.Author.Name = "Author";
            this.Author.ReadOnly = true;
            // 
            // PublisherId
            // 
            this.PublisherId.DataPropertyName = "PublisherId";
            this.PublisherId.HeaderText = "出版编号";
            this.PublisherId.Name = "PublisherId";
            this.PublisherId.ReadOnly = true;
            this.PublisherId.Width = 80;
            // 
            // PublishDate
            // 
            this.PublishDate.DataPropertyName = "PublishDate";
            this.PublishDate.HeaderText = "出版时间";
            this.PublishDate.Name = "PublishDate";
            this.PublishDate.ReadOnly = true;
            // 
            // btn_showList
            // 
            this.btn_showList.Location = new System.Drawing.Point(20, 300);
            this.btn_showList.Name = "btn_showList";
            this.btn_showList.Size = new System.Drawing.Size(90, 40);
            this.btn_showList.TabIndex = 1;
            this.btn_showList.Text = "显示图书列表";
            this.btn_showList.UseVisualStyleBackColor = true;
            this.btn_showList.Click += new System.EventHandler(this.btn_showList_Click);
            // 
            // btn_addItem
            // 
            this.btn_addItem.Location = new System.Drawing.Point(200, 300);
            this.btn_addItem.Name = "btn_addItem";
            this.btn_addItem.Size = new System.Drawing.Size(90, 40);
            this.btn_addItem.TabIndex = 2;
            this.btn_addItem.Text = "添加集合元素";
            this.btn_addItem.UseVisualStyleBackColor = true;
            this.btn_addItem.Click += new System.EventHandler(this.btn_addItem_Click);
            // 
            // btn_insertItem
            // 
            this.btn_insertItem.Location = new System.Drawing.Point(300, 300);
            this.btn_insertItem.Name = "btn_insertItem";
            this.btn_insertItem.Size = new System.Drawing.Size(90, 40);
            this.btn_insertItem.TabIndex = 3;
            this.btn_insertItem.Text = "插入集合元素";
            this.btn_insertItem.UseVisualStyleBackColor = true;
            this.btn_insertItem.Click += new System.EventHandler(this.btn_insertItem_Click);
            // 
            // btn_delItem
            // 
            this.btn_delItem.Location = new System.Drawing.Point(490, 300);
            this.btn_delItem.Name = "btn_delItem";
            this.btn_delItem.Size = new System.Drawing.Size(90, 40);
            this.btn_delItem.TabIndex = 4;
            this.btn_delItem.Text = "删除集合元素";
            this.btn_delItem.UseVisualStyleBackColor = true;
            this.btn_delItem.Click += new System.EventHandler(this.btn_delItem_Click);
            // 
            // FrmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(604, 362);
            this.Controls.Add(this.btn_delItem);
            this.Controls.Add(this.btn_insertItem);
            this.Controls.Add(this.btn_addItem);
            this.Controls.Add(this.btn_showList);
            this.Controls.Add(this.GVBook);
            this.Name = "FrmMain";
            this.Text = "集合应用";
            ((System.ComponentModel.ISupportInitialize)(this.GVBook)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView GVBook;
        private System.Windows.Forms.Button btn_showList;
        private System.Windows.Forms.Button btn_addItem;
        private System.Windows.Forms.Button btn_insertItem;
        private System.Windows.Forms.Button btn_delItem;
        private System.Windows.Forms.DataGridViewTextBoxColumn BookId;
        private System.Windows.Forms.DataGridViewTextBoxColumn BarCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn BookName;
        private System.Windows.Forms.DataGridViewTextBoxColumn Author;
        private System.Windows.Forms.DataGridViewTextBoxColumn PublisherId;
        private System.Windows.Forms.DataGridViewTextBoxColumn PublishDate;
    }
}

