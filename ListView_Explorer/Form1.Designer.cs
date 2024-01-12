namespace ListView_Explorer
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.ToolStripMenuItem ViewMenu;
            this.MenuLargeIcon = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuDetails = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuSmallIcon = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuList = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuTile = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.MenuTextBox = new System.Windows.Forms.ToolStripTextBox();
            this.listView = new System.Windows.Forms.ListView();
            this.NameFile = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.DateFile = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.TypeFile = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.BackButton = new System.Windows.Forms.Button();
            ViewMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // ViewMenu
            // 
            ViewMenu.AutoSize = false;
            ViewMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MenuLargeIcon,
            this.MenuDetails,
            this.MenuSmallIcon,
            this.MenuList,
            this.MenuTile});
            ViewMenu.Name = "ViewMenu";
            ViewMenu.Size = new System.Drawing.Size(80, 23);
            ViewMenu.Text = "Вид";
            // 
            // MenuLargeIcon
            // 
            this.MenuLargeIcon.Name = "MenuLargeIcon";
            this.MenuLargeIcon.Size = new System.Drawing.Size(164, 22);
            this.MenuLargeIcon.Text = "Крупные значки";
            this.MenuLargeIcon.Click += new System.EventHandler(this.MenuLargeIcon_Click);
            // 
            // MenuDetails
            // 
            this.MenuDetails.Name = "MenuDetails";
            this.MenuDetails.Size = new System.Drawing.Size(164, 22);
            this.MenuDetails.Text = "Таблица";
            this.MenuDetails.Click += new System.EventHandler(this.MenuDetails_Click);
            // 
            // MenuSmallIcon
            // 
            this.MenuSmallIcon.Name = "MenuSmallIcon";
            this.MenuSmallIcon.Size = new System.Drawing.Size(164, 22);
            this.MenuSmallIcon.Text = "Мелкие значки";
            this.MenuSmallIcon.Click += new System.EventHandler(this.MenuSmallIcon_Click);
            // 
            // MenuList
            // 
            this.MenuList.Name = "MenuList";
            this.MenuList.Size = new System.Drawing.Size(164, 22);
            this.MenuList.Text = "Список";
            this.MenuList.Click += new System.EventHandler(this.MenuList_Click);
            // 
            // MenuTile
            // 
            this.MenuTile.Name = "MenuTile";
            this.MenuTile.Size = new System.Drawing.Size(164, 22);
            this.MenuTile.Text = "Плитка";
            this.MenuTile.Click += new System.EventHandler(this.MenuTile_Click);
            // 
            // menuStrip
            // 
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            ViewMenu,
            this.MenuTextBox});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(484, 27);
            this.menuStrip.TabIndex = 0;
            // 
            // MenuTextBox
            // 
            this.MenuTextBox.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.MenuTextBox.Name = "MenuTextBox";
            this.MenuTextBox.ReadOnly = true;
            this.MenuTextBox.Size = new System.Drawing.Size(300, 23);
            // 
            // listView
            // 
            this.listView.AccessibleRole = System.Windows.Forms.AccessibleRole.TitleBar;
            this.listView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.NameFile,
            this.DateFile,
            this.TypeFile});
            this.listView.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.listView.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.listView.HideSelection = false;
            this.listView.Location = new System.Drawing.Point(0, 31);
            this.listView.Name = "listView";
            this.listView.Size = new System.Drawing.Size(478, 414);
            this.listView.TabIndex = 1;
            this.listView.UseCompatibleStateImageBehavior = false;
            this.listView.View = System.Windows.Forms.View.Details;
            this.listView.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.listView_MouseDoubleClick);
            // 
            // NameFile
            // 
            this.NameFile.Text = "Имя";
            this.NameFile.Width = 287;
            // 
            // DateFile
            // 
            this.DateFile.Text = "Дата изменения";
            this.DateFile.Width = 121;
            // 
            // TypeFile
            // 
            this.TypeFile.Text = "Тип";
            this.TypeFile.Width = 66;
            // 
            // BackButton
            // 
            this.BackButton.Location = new System.Drawing.Point(391, 2);
            this.BackButton.Name = "BackButton";
            this.BackButton.Size = new System.Drawing.Size(87, 23);
            this.BackButton.TabIndex = 2;
            this.BackButton.Text = "Назад";
            this.BackButton.UseVisualStyleBackColor = true;
            this.BackButton.Click += new System.EventHandler(this.BackButton_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(484, 450);
            this.Controls.Add(this.BackButton);
            this.Controls.Add(this.listView);
            this.Controls.Add(this.menuStrip);
            this.MainMenuStrip = this.menuStrip;
            this.Name = "Form1";
            this.Text = "Form1";
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ToolStripMenuItem MenuLargeIcon;
        private System.Windows.Forms.ToolStripMenuItem MenuDetails;
        private System.Windows.Forms.ToolStripMenuItem MenuSmallIcon;
        private System.Windows.Forms.ToolStripMenuItem MenuList;
        private System.Windows.Forms.ToolStripMenuItem MenuTile;
        private System.Windows.Forms.ToolStripTextBox MenuTextBox;
        private System.Windows.Forms.ListView listView;
        private System.Windows.Forms.ColumnHeader NameFile;
        private System.Windows.Forms.ColumnHeader DateFile;
        private System.Windows.Forms.ColumnHeader TypeFile;
        private System.Windows.Forms.Button BackButton;
    }
}

