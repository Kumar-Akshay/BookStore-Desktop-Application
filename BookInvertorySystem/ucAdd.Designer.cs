namespace BookInvertorySystem
{
    partial class ucAdd
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.save = new System.Windows.Forms.Button();
            this.qtybox = new System.Windows.Forms.TextBox();
            this.authorbox = new System.Windows.Forms.TextBox();
            this.pbox = new System.Windows.Forms.TextBox();
            this.yearbox = new System.Windows.Forms.TextBox();
            this.pricebox = new System.Windows.Forms.TextBox();
            this.titlebox = new System.Windows.Forms.TextBox();
            this.isbnbox = new System.Windows.Forms.TextBox();
            this.qty = new System.Windows.Forms.Label();
            this.author = new System.Windows.Forms.Label();
            this.pname = new System.Windows.Forms.Label();
            this.year = new System.Windows.Forms.Label();
            this.price = new System.Windows.Forms.Label();
            this.title = new System.Windows.Forms.Label();
            this.isbn = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // save
            // 
            this.save.Location = new System.Drawing.Point(280, 355);
            this.save.Name = "save";
            this.save.Size = new System.Drawing.Size(170, 23);
            this.save.TabIndex = 99;
            this.save.Text = "Add Details";
            this.save.UseVisualStyleBackColor = true;
            this.save.Click += new System.EventHandler(this.save_Click);
            // 
            // qtybox
            // 
            this.qtybox.Location = new System.Drawing.Point(278, 295);
            this.qtybox.Name = "qtybox";
            this.qtybox.Size = new System.Drawing.Size(172, 20);
            this.qtybox.TabIndex = 98;
            // 
            // authorbox
            // 
            this.authorbox.Location = new System.Drawing.Point(278, 262);
            this.authorbox.Name = "authorbox";
            this.authorbox.Size = new System.Drawing.Size(172, 20);
            this.authorbox.TabIndex = 97;
            // 
            // pbox
            // 
            this.pbox.Location = new System.Drawing.Point(278, 228);
            this.pbox.Name = "pbox";
            this.pbox.Size = new System.Drawing.Size(172, 20);
            this.pbox.TabIndex = 96;
            // 
            // yearbox
            // 
            this.yearbox.Location = new System.Drawing.Point(278, 192);
            this.yearbox.Name = "yearbox";
            this.yearbox.Size = new System.Drawing.Size(172, 20);
            this.yearbox.TabIndex = 95;
            // 
            // pricebox
            // 
            this.pricebox.Location = new System.Drawing.Point(278, 158);
            this.pricebox.Name = "pricebox";
            this.pricebox.Size = new System.Drawing.Size(172, 20);
            this.pricebox.TabIndex = 94;
            // 
            // titlebox
            // 
            this.titlebox.Location = new System.Drawing.Point(278, 118);
            this.titlebox.Name = "titlebox";
            this.titlebox.Size = new System.Drawing.Size(172, 20);
            this.titlebox.TabIndex = 93;
            // 
            // isbnbox
            // 
            this.isbnbox.Location = new System.Drawing.Point(278, 76);
            this.isbnbox.Name = "isbnbox";
            this.isbnbox.Size = new System.Drawing.Size(172, 20);
            this.isbnbox.TabIndex = 92;
            // 
            // qty
            // 
            this.qty.AutoSize = true;
            this.qty.Location = new System.Drawing.Point(168, 302);
            this.qty.Name = "qty";
            this.qty.Size = new System.Drawing.Size(46, 13);
            this.qty.TabIndex = 91;
            this.qty.Text = "Quantity";
            // 
            // author
            // 
            this.author.AutoSize = true;
            this.author.Location = new System.Drawing.Point(178, 265);
            this.author.Name = "author";
            this.author.Size = new System.Drawing.Size(38, 13);
            this.author.TabIndex = 90;
            this.author.Text = "Author";
            // 
            // pname
            // 
            this.pname.AutoSize = true;
            this.pname.Location = new System.Drawing.Point(115, 231);
            this.pname.Name = "pname";
            this.pname.Size = new System.Drawing.Size(99, 13);
            this.pname.TabIndex = 89;
            this.pname.Text = "PUBLISHERNAME";
            // 
            // year
            // 
            this.year.AutoSize = true;
            this.year.Location = new System.Drawing.Point(178, 192);
            this.year.Name = "year";
            this.year.Size = new System.Drawing.Size(36, 13);
            this.year.TabIndex = 88;
            this.year.Text = "YEAR";
            // 
            // price
            // 
            this.price.AutoSize = true;
            this.price.Location = new System.Drawing.Point(178, 158);
            this.price.Name = "price";
            this.price.Size = new System.Drawing.Size(39, 13);
            this.price.TabIndex = 87;
            this.price.Text = "PRICE";
            // 
            // title
            // 
            this.title.AutoSize = true;
            this.title.Location = new System.Drawing.Point(178, 118);
            this.title.Name = "title";
            this.title.Size = new System.Drawing.Size(37, 13);
            this.title.TabIndex = 86;
            this.title.Text = "TITLE";
            // 
            // isbn
            // 
            this.isbn.AutoSize = true;
            this.isbn.Location = new System.Drawing.Point(184, 84);
            this.isbn.Name = "isbn";
            this.isbn.Size = new System.Drawing.Size(32, 13);
            this.isbn.TabIndex = 85;
            this.isbn.Text = "ISBN";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(275, 31);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(143, 17);
            this.label4.TabIndex = 84;
            this.label4.Text = "Enter Book Details";
            // 
            // ucAdd
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.save);
            this.Controls.Add(this.qtybox);
            this.Controls.Add(this.authorbox);
            this.Controls.Add(this.pbox);
            this.Controls.Add(this.yearbox);
            this.Controls.Add(this.pricebox);
            this.Controls.Add(this.titlebox);
            this.Controls.Add(this.isbnbox);
            this.Controls.Add(this.qty);
            this.Controls.Add(this.author);
            this.Controls.Add(this.pname);
            this.Controls.Add(this.year);
            this.Controls.Add(this.price);
            this.Controls.Add(this.title);
            this.Controls.Add(this.isbn);
            this.Controls.Add(this.label4);
            this.Name = "ucAdd";
            this.Size = new System.Drawing.Size(820, 423);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button save;
        private System.Windows.Forms.TextBox qtybox;
        private System.Windows.Forms.TextBox authorbox;
        private System.Windows.Forms.TextBox pbox;
        private System.Windows.Forms.TextBox yearbox;
        private System.Windows.Forms.TextBox pricebox;
        private System.Windows.Forms.TextBox titlebox;
        private System.Windows.Forms.TextBox isbnbox;
        private System.Windows.Forms.Label qty;
        private System.Windows.Forms.Label author;
        private System.Windows.Forms.Label pname;
        private System.Windows.Forms.Label year;
        private System.Windows.Forms.Label price;
        private System.Windows.Forms.Label title;
        private System.Windows.Forms.Label isbn;
        private System.Windows.Forms.Label label4;
    }
}
