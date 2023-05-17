namespace vatACARS
{
    partial class PDCWindow
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
            this.btn_time = new vatsys.GenericButton();
            this.lbl_callsign = new vatsys.TextLabel();
            this.lbl_clearto = new vatsys.TextLabel();
            this.lbl_route = new vatsys.TextLabel();
            this.lbl_pdc = new vatsys.TextLabel();
            this.btn_etd = new vatsys.GenericButton();
            this.btn_adep = new vatsys.GenericButton();
            this.btn_atype = new vatsys.GenericButton();
            this.btn_callsign = new vatsys.GenericButton();
            this.btn_ades = new vatsys.GenericButton();
            this.lbl_via = new vatsys.TextLabel();
            this.btn_sid = new vatsys.GenericButton();
            this.lbl_dep = new vatsys.TextLabel();
            this.btn_text = new vatsys.GenericButton();
            this.btn_route = new vatsys.GenericButton();
            this.btn_alt = new vatsys.GenericButton();
            this.lbl_climb = new vatsys.TextLabel();
            this.lbl_freq = new vatsys.TextLabel();
            this.btn_freq = new vatsys.GenericButton();
            this.lbl_rb = new vatsys.TextLabel();
            this.btn_rbfreq = new vatsys.GenericButton();
            this.btn_send = new vatsys.GenericButton();
            this.SuspendLayout();
            // 
            // btn_time
            // 
            this.btn_time.Font = new System.Drawing.Font("Terminus (TTF)", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.btn_time.Location = new System.Drawing.Point(53, 49);
            this.btn_time.Name = "btn_time";
            this.btn_time.Size = new System.Drawing.Size(71, 25);
            this.btn_time.SubFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_time.SubText = "";
            this.btn_time.TabIndex = 14;
            this.btn_time.Text = "time";
            this.btn_time.UseVisualStyleBackColor = true;
            // 
            // lbl_callsign
            // 
            this.lbl_callsign.BackColor = System.Drawing.SystemColors.ControlDark;
            this.lbl_callsign.Font = new System.Drawing.Font("Terminus (TTF)", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.lbl_callsign.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.lbl_callsign.HasBorder = false;
            this.lbl_callsign.InteractiveText = false;
            this.lbl_callsign.Location = new System.Drawing.Point(9, 9);
            this.lbl_callsign.Name = "lbl_callsign";
            this.lbl_callsign.Size = new System.Drawing.Size(131, 25);
            this.lbl_callsign.TabIndex = 0;
            this.lbl_callsign.Text = "Callsign";
            this.lbl_callsign.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lbl_clearto
            // 
            this.lbl_clearto.BackColor = System.Drawing.SystemColors.ControlDark;
            this.lbl_clearto.Font = new System.Drawing.Font("Terminus (TTF)", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.lbl_clearto.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.lbl_clearto.HasBorder = false;
            this.lbl_clearto.InteractiveText = false;
            this.lbl_clearto.Location = new System.Drawing.Point(9, 114);
            this.lbl_clearto.Name = "lbl_clearto";
            this.lbl_clearto.Size = new System.Drawing.Size(108, 25);
            this.lbl_clearto.TabIndex = 25;
            this.lbl_clearto.Text = "CLEARED TO";
            this.lbl_clearto.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lbl_route
            // 
            this.lbl_route.BackColor = System.Drawing.SystemColors.ControlDark;
            this.lbl_route.Font = new System.Drawing.Font("Terminus (TTF)", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.lbl_route.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.lbl_route.HasBorder = false;
            this.lbl_route.InteractiveText = false;
            this.lbl_route.Location = new System.Drawing.Point(9, 145);
            this.lbl_route.Name = "lbl_route";
            this.lbl_route.Size = new System.Drawing.Size(58, 25);
            this.lbl_route.TabIndex = 26;
            this.lbl_route.Text = "ROUTE";
            this.lbl_route.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lbl_pdc
            // 
            this.lbl_pdc.BackColor = System.Drawing.SystemColors.ControlDark;
            this.lbl_pdc.Font = new System.Drawing.Font("Terminus (TTF)", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.lbl_pdc.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.lbl_pdc.HasBorder = false;
            this.lbl_pdc.InteractiveText = false;
            this.lbl_pdc.Location = new System.Drawing.Point(9, 49);
            this.lbl_pdc.Name = "lbl_pdc";
            this.lbl_pdc.Size = new System.Drawing.Size(38, 25);
            this.lbl_pdc.TabIndex = 27;
            this.lbl_pdc.Text = "PDC";
            this.lbl_pdc.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btn_etd
            // 
            this.btn_etd.Font = new System.Drawing.Font("Terminus (TTF)", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.btn_etd.Location = new System.Drawing.Point(243, 80);
            this.btn_etd.Name = "btn_etd";
            this.btn_etd.Size = new System.Drawing.Size(71, 25);
            this.btn_etd.SubFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_etd.SubText = "";
            this.btn_etd.TabIndex = 28;
            this.btn_etd.Text = "BLK/CND";
            this.btn_etd.UseVisualStyleBackColor = true;
            // 
            // btn_adep
            // 
            this.btn_adep.Font = new System.Drawing.Font("Terminus (TTF)", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.btn_adep.Location = new System.Drawing.Point(166, 80);
            this.btn_adep.Name = "btn_adep";
            this.btn_adep.Size = new System.Drawing.Size(71, 25);
            this.btn_adep.SubFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_adep.SubText = "";
            this.btn_adep.TabIndex = 29;
            this.btn_adep.Text = "BLK/CND";
            this.btn_adep.UseVisualStyleBackColor = true;
            // 
            // btn_atype
            // 
            this.btn_atype.Font = new System.Drawing.Font("Terminus (TTF)", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.btn_atype.Location = new System.Drawing.Point(89, 80);
            this.btn_atype.Name = "btn_atype";
            this.btn_atype.Size = new System.Drawing.Size(71, 25);
            this.btn_atype.SubFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_atype.SubText = "";
            this.btn_atype.TabIndex = 30;
            this.btn_atype.Text = "BLK/CND";
            this.btn_atype.UseVisualStyleBackColor = true;
            // 
            // btn_callsign
            // 
            this.btn_callsign.Font = new System.Drawing.Font("Terminus (TTF)", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.btn_callsign.Location = new System.Drawing.Point(12, 80);
            this.btn_callsign.Name = "btn_callsign";
            this.btn_callsign.Size = new System.Drawing.Size(71, 25);
            this.btn_callsign.SubFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_callsign.SubText = "";
            this.btn_callsign.TabIndex = 31;
            this.btn_callsign.Text = "BLK/CND";
            this.btn_callsign.UseVisualStyleBackColor = true;
            // 
            // btn_ades
            // 
            this.btn_ades.Font = new System.Drawing.Font("Terminus (TTF)", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.btn_ades.Location = new System.Drawing.Point(123, 114);
            this.btn_ades.Name = "btn_ades";
            this.btn_ades.Size = new System.Drawing.Size(71, 25);
            this.btn_ades.SubFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_ades.SubText = "";
            this.btn_ades.TabIndex = 32;
            this.btn_ades.Text = "des";
            this.btn_ades.UseVisualStyleBackColor = true;
            // 
            // lbl_via
            // 
            this.lbl_via.BackColor = System.Drawing.SystemColors.ControlDark;
            this.lbl_via.Font = new System.Drawing.Font("Terminus (TTF)", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.lbl_via.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.lbl_via.HasBorder = false;
            this.lbl_via.InteractiveText = false;
            this.lbl_via.Location = new System.Drawing.Point(200, 114);
            this.lbl_via.Name = "lbl_via";
            this.lbl_via.Size = new System.Drawing.Size(38, 25);
            this.lbl_via.TabIndex = 39;
            this.lbl_via.Text = "VIA";
            this.lbl_via.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btn_sid
            // 
            this.btn_sid.Font = new System.Drawing.Font("Terminus (TTF)", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.btn_sid.Location = new System.Drawing.Point(244, 114);
            this.btn_sid.Name = "btn_sid";
            this.btn_sid.Size = new System.Drawing.Size(71, 25);
            this.btn_sid.SubFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_sid.SubText = "";
            this.btn_sid.TabIndex = 40;
            this.btn_sid.Text = "SID";
            this.btn_sid.UseVisualStyleBackColor = true;
            // 
            // lbl_dep
            // 
            this.lbl_dep.BackColor = System.Drawing.SystemColors.ControlDark;
            this.lbl_dep.Font = new System.Drawing.Font("Terminus (TTF)", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.lbl_dep.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.lbl_dep.HasBorder = false;
            this.lbl_dep.InteractiveText = false;
            this.lbl_dep.Location = new System.Drawing.Point(321, 114);
            this.lbl_dep.Name = "lbl_dep";
            this.lbl_dep.Size = new System.Drawing.Size(38, 25);
            this.lbl_dep.TabIndex = 41;
            this.lbl_dep.Text = "DEP";
            this.lbl_dep.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btn_text
            // 
            this.btn_text.Font = new System.Drawing.Font("Terminus (TTF)", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.btn_text.Location = new System.Drawing.Point(365, 114);
            this.btn_text.Name = "btn_text";
            this.btn_text.Size = new System.Drawing.Size(71, 25);
            this.btn_text.SubFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_text.SubText = "";
            this.btn_text.TabIndex = 42;
            this.btn_text.UseVisualStyleBackColor = true;
            // 
            // btn_route
            // 
            this.btn_route.Font = new System.Drawing.Font("Terminus (TTF)", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.btn_route.Location = new System.Drawing.Point(73, 145);
            this.btn_route.Name = "btn_route";
            this.btn_route.Size = new System.Drawing.Size(71, 25);
            this.btn_route.SubFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_route.SubText = "";
            this.btn_route.TabIndex = 43;
            this.btn_route.Text = "ROUTE";
            this.btn_route.UseVisualStyleBackColor = true;
            // 
            // btn_alt
            // 
            this.btn_alt.Font = new System.Drawing.Font("Terminus (TTF)", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.btn_alt.Location = new System.Drawing.Point(183, 176);
            this.btn_alt.Name = "btn_alt";
            this.btn_alt.Size = new System.Drawing.Size(71, 25);
            this.btn_alt.SubFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_alt.SubText = "";
            this.btn_alt.TabIndex = 44;
            this.btn_alt.Text = "ALT";
            this.btn_alt.UseVisualStyleBackColor = true;
            // 
            // lbl_climb
            // 
            this.lbl_climb.BackColor = System.Drawing.SystemColors.ControlDark;
            this.lbl_climb.Font = new System.Drawing.Font("Terminus (TTF)", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.lbl_climb.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.lbl_climb.HasBorder = false;
            this.lbl_climb.InteractiveText = false;
            this.lbl_climb.Location = new System.Drawing.Point(9, 176);
            this.lbl_climb.Name = "lbl_climb";
            this.lbl_climb.Size = new System.Drawing.Size(168, 25);
            this.lbl_climb.TabIndex = 45;
            this.lbl_climb.Text = "CLIMB VIA SID TO";
            this.lbl_climb.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lbl_freq
            // 
            this.lbl_freq.BackColor = System.Drawing.SystemColors.ControlDark;
            this.lbl_freq.Font = new System.Drawing.Font("Terminus (TTF)", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.lbl_freq.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.lbl_freq.HasBorder = false;
            this.lbl_freq.InteractiveText = false;
            this.lbl_freq.Location = new System.Drawing.Point(9, 207);
            this.lbl_freq.Name = "lbl_freq";
            this.lbl_freq.Size = new System.Drawing.Size(88, 25);
            this.lbl_freq.TabIndex = 46;
            this.lbl_freq.Text = "DEP FREQ";
            this.lbl_freq.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btn_freq
            // 
            this.btn_freq.Font = new System.Drawing.Font("Terminus (TTF)", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.btn_freq.Location = new System.Drawing.Point(103, 207);
            this.btn_freq.Name = "btn_freq";
            this.btn_freq.Size = new System.Drawing.Size(71, 25);
            this.btn_freq.SubFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_freq.SubText = "";
            this.btn_freq.TabIndex = 48;
            this.btn_freq.Text = "FREQ";
            this.btn_freq.UseVisualStyleBackColor = true;
            // 
            // lbl_rb
            // 
            this.lbl_rb.BackColor = System.Drawing.SystemColors.ControlDark;
            this.lbl_rb.Font = new System.Drawing.Font("Terminus (TTF)", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.lbl_rb.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.lbl_rb.HasBorder = false;
            this.lbl_rb.InteractiveText = false;
            this.lbl_rb.Location = new System.Drawing.Point(9, 238);
            this.lbl_rb.Name = "lbl_rb";
            this.lbl_rb.Size = new System.Drawing.Size(468, 25);
            this.lbl_rb.TabIndex = 49;
            this.lbl_rb.Text = "ONLY READBACK SID, SQUAWK CODE, AND BAY NO. ON";
            this.lbl_rb.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btn_rbfreq
            // 
            this.btn_rbfreq.Font = new System.Drawing.Font("Terminus (TTF)", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.btn_rbfreq.Location = new System.Drawing.Point(483, 238);
            this.btn_rbfreq.Name = "btn_rbfreq";
            this.btn_rbfreq.Size = new System.Drawing.Size(71, 25);
            this.btn_rbfreq.SubFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_rbfreq.SubText = "";
            this.btn_rbfreq.TabIndex = 55;
            this.btn_rbfreq.Text = "READBACK FREQ";
            this.btn_rbfreq.UseVisualStyleBackColor = true;
            // 
            // btn_send
            // 
            this.btn_send.Font = new System.Drawing.Font("Terminus (TTF)", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.btn_send.Location = new System.Drawing.Point(236, 288);
            this.btn_send.Name = "btn_send";
            this.btn_send.Size = new System.Drawing.Size(94, 33);
            this.btn_send.SubFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_send.SubText = "";
            this.btn_send.TabIndex = 56;
            this.btn_send.Text = "Send";
            this.btn_send.UseVisualStyleBackColor = true;
            // 
            // PDCWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(566, 333);
            this.ControlBox = false;
            this.Controls.Add(this.btn_send);
            this.Controls.Add(this.btn_rbfreq);
            this.Controls.Add(this.lbl_rb);
            this.Controls.Add(this.btn_freq);
            this.Controls.Add(this.lbl_freq);
            this.Controls.Add(this.lbl_climb);
            this.Controls.Add(this.btn_alt);
            this.Controls.Add(this.btn_route);
            this.Controls.Add(this.btn_text);
            this.Controls.Add(this.lbl_dep);
            this.Controls.Add(this.btn_sid);
            this.Controls.Add(this.lbl_via);
            this.Controls.Add(this.btn_ades);
            this.Controls.Add(this.btn_callsign);
            this.Controls.Add(this.btn_atype);
            this.Controls.Add(this.btn_adep);
            this.Controls.Add(this.btn_etd);
            this.Controls.Add(this.lbl_pdc);
            this.Controls.Add(this.lbl_route);
            this.Controls.Add(this.lbl_clearto);
            this.Controls.Add(this.btn_time);
            this.Controls.Add(this.lbl_callsign);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.HasSendBackButton = false;
            this.HideOnClose = true;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MiddleClickClose = false;
            this.Name = "PDCWindow";
            this.Resizeable = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.Text = "ACARS Editor";
            this.TopMost = true;
            this.ResumeLayout(false);

        }

        #endregion
        private vatsys.GenericButton btn_time;
        private vatsys.TextLabel lbl_callsign;
        private vatsys.TextLabel lbl_clearto;
        private vatsys.TextLabel lbl_route;
        private vatsys.TextLabel lbl_pdc;
        private vatsys.GenericButton btn_etd;
        private vatsys.GenericButton btn_adep;
        private vatsys.GenericButton btn_atype;
        private vatsys.GenericButton btn_callsign;
        private vatsys.GenericButton btn_ades;
        private vatsys.TextLabel lbl_via;
        private vatsys.GenericButton btn_sid;
        private vatsys.TextLabel lbl_dep;
        private vatsys.GenericButton btn_text;
        private vatsys.GenericButton btn_route;
        private vatsys.GenericButton btn_alt;
        private vatsys.TextLabel lbl_climb;
        private vatsys.TextLabel lbl_freq;
        private vatsys.GenericButton btn_freq;
        private vatsys.TextLabel lbl_rb;
        private vatsys.GenericButton btn_rbfreq;
        private vatsys.GenericButton btn_send;
    }
}