﻿namespace Restaurant
{
  partial class TextboxMain
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
            this._cmPhoto = new System.Windows.Forms.ContextMenuStrip(this.components);
            this._btPhotoDelete = new System.Windows.Forms.ToolStripMenuItem();
            this._cmAlbum = new System.Windows.Forms.ContextMenuStrip(this.components);
            this._btDeleteAlbum = new System.Windows.Forms.ToolStripMenuItem();
            this.buttonNew = new System.Windows.Forms.Button();
            this.buttonEdit = new System.Windows.Forms.Button();
            this.buttonDelete = new System.Windows.Forms.Button();
            this.buttonCopy = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this._cmPhoto.SuspendLayout();
            this._cmAlbum.SuspendLayout();
            this.SuspendLayout();
            // 
            // _cmPhoto
            // 
            this._cmPhoto.ImageScalingSize = new System.Drawing.Size(20, 20);
            this._cmPhoto.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._btPhotoDelete});
            this._cmPhoto.Name = "m_cmPhoto";
            this._cmPhoto.Size = new System.Drawing.Size(108, 26);
            // 
            // _btPhotoDelete
            // 
            this._btPhotoDelete.Name = "_btPhotoDelete";
            this._btPhotoDelete.Size = new System.Drawing.Size(107, 22);
            this._btPhotoDelete.Text = "Delete";
            // 
            // _cmAlbum
            // 
            this._cmAlbum.ImageScalingSize = new System.Drawing.Size(20, 20);
            this._cmAlbum.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._btDeleteAlbum});
            this._cmAlbum.Name = "m_cmAlbum";
            this._cmAlbum.Size = new System.Drawing.Size(108, 26);
            // 
            // _btDeleteAlbum
            // 
            this._btDeleteAlbum.Name = "_btDeleteAlbum";
            this._btDeleteAlbum.Size = new System.Drawing.Size(107, 22);
            this._btDeleteAlbum.Text = "Delete";
            // 
            // buttonNew
            // 
            this.buttonNew.Location = new System.Drawing.Point(12, 254);
            this.buttonNew.Name = "buttonNew";
            this.buttonNew.Size = new System.Drawing.Size(75, 23);
            this.buttonNew.TabIndex = 6;
            this.buttonNew.Text = "New";
            this.buttonNew.UseVisualStyleBackColor = true;
            this.buttonNew.Click += new System.EventHandler(this.buttonNew_Click);
            // 
            // buttonEdit
            // 
            this.buttonEdit.Location = new System.Drawing.Point(12, 283);
            this.buttonEdit.Name = "buttonEdit";
            this.buttonEdit.Size = new System.Drawing.Size(75, 23);
            this.buttonEdit.TabIndex = 7;
            this.buttonEdit.Text = "Edit";
            this.buttonEdit.UseVisualStyleBackColor = true;
            this.buttonEdit.Click += new System.EventHandler(this.buttonEdit_Click);
            // 
            // buttonDelete
            // 
            this.buttonDelete.Location = new System.Drawing.Point(12, 311);
            this.buttonDelete.Name = "buttonDelete";
            this.buttonDelete.Size = new System.Drawing.Size(75, 23);
            this.buttonDelete.TabIndex = 8;
            this.buttonDelete.Text = "Delete";
            this.buttonDelete.UseVisualStyleBackColor = true;
            // 
            // buttonCopy
            // 
            this.buttonCopy.Location = new System.Drawing.Point(12, 340);
            this.buttonCopy.Name = "buttonCopy";
            this.buttonCopy.Size = new System.Drawing.Size(75, 23);
            this.buttonCopy.TabIndex = 9;
            this.buttonCopy.Text = "Copy";
            this.buttonCopy.UseVisualStyleBackColor = true;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(234, 147);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(370, 216);
            this.textBox1.TabIndex = 10;
            // 
            // TextboxMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1071, 396);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.buttonCopy);
            this.Controls.Add(this.buttonDelete);
            this.Controls.Add(this.buttonEdit);
            this.Controls.Add(this.buttonNew);
            this.Name = "TextboxMain";
            this._cmPhoto.ResumeLayout(false);
            this._cmAlbum.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

    }

    #endregion
    private System.Windows.Forms.ContextMenuStrip _cmPhoto;
    private System.Windows.Forms.ToolStripMenuItem _btPhotoDelete;
    private System.Windows.Forms.ContextMenuStrip _cmAlbum;
    private System.Windows.Forms.ToolStripMenuItem _btDeleteAlbum;
        private System.Windows.Forms.Button buttonNew;
        private System.Windows.Forms.Button buttonEdit;
        private System.Windows.Forms.Button buttonDelete;
        private System.Windows.Forms.Button buttonCopy;
        private System.Windows.Forms.TextBox textBox1;
    }
}

