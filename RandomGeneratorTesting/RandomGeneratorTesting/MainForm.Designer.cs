using System;
using System.Drawing;
using System.Linq;
using System.Numerics;
using System.Threading;
using System.Windows.Forms;
using RandomGeneratorTesting.RandomGenerators;

namespace RandomGeneratorTesting
{
    partial class MainForm
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
            this.randomPanel = new System.Windows.Forms.Panel();
            this.generatorChooser = new System.Windows.Forms.ComboBox();
            this.drawButton = new System.Windows.Forms.Button();
            this.TestButton = new System.Windows.Forms.Button();
            this.TestSummary = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // randomPanel
            // 
            this.randomPanel.BackColor = System.Drawing.Color.GreenYellow;
            this.randomPanel.Location = new System.Drawing.Point(12, 12);
            this.randomPanel.Name = "randomPanel";
            this.randomPanel.Size = new System.Drawing.Size(879, 343);
            this.randomPanel.TabIndex = 0;
            this.randomPanel.Paint += new System.Windows.Forms.PaintEventHandler(this.RandomPanelPaint);
            // 
            // generatorChooser
            // 
            this.generatorChooser.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.generatorChooser.FormattingEnabled = true;
            this.generatorChooser.Location = new System.Drawing.Point(12, 361);
            this.generatorChooser.Name = "generatorChooser";
            this.generatorChooser.Size = new System.Drawing.Size(879, 24);
            this.generatorChooser.TabIndex = 1;
            this.generatorChooser.SelectedIndexChanged += new System.EventHandler(this.GeneratorChooserSelectedIndexChanged);
            // 
            // drawButton
            // 
            this.drawButton.Location = new System.Drawing.Point(12, 391);
            this.drawButton.Name = "drawButton";
            this.drawButton.Size = new System.Drawing.Size(879, 38);
            this.drawButton.TabIndex = 2;
            this.drawButton.Text = "Draw test cases";
            this.drawButton.UseVisualStyleBackColor = true;
            this.drawButton.Click += new System.EventHandler(this.DrawButtonClick);
            // 
            // TestButton
            // 
            this.TestButton.Location = new System.Drawing.Point(12, 435);
            this.TestButton.Name = "TestButton";
            this.TestButton.Size = new System.Drawing.Size(879, 35);
            this.TestButton.TabIndex = 3;
            this.TestButton.Text = "Test";
            this.TestButton.UseVisualStyleBackColor = true;
            this.TestButton.Click += new System.EventHandler(this.TestButtonClick);
            // 
            // TestSummary
            // 
            this.TestSummary.FormattingEnabled = true;
            this.TestSummary.ItemHeight = 16;
            this.TestSummary.Location = new System.Drawing.Point(12, 476);
            this.TestSummary.Name = "TestSummary";
            this.TestSummary.Size = new System.Drawing.Size(879, 116);
            this.TestSummary.TabIndex = 4;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(903, 617);
            this.Controls.Add(this.TestSummary);
            this.Controls.Add(this.TestButton);
            this.Controls.Add(this.drawButton);
            this.Controls.Add(this.generatorChooser);
            this.Controls.Add(this.randomPanel);
            this.Name = "MainForm";
            this.Text = "RandomNumberTesting";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel randomPanel;
        private ComboBox generatorChooser;
        private Button drawButton;
        private Button TestButton;
        private ListBox TestSummary;
    }
}