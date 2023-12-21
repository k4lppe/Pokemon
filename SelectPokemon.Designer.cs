
namespace pokemon
{
    partial class SelectPokemon
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SelectPokemon));
            this.label1 = new System.Windows.Forms.Label();
            this.btnStartGame = new System.Windows.Forms.Button();
            this.btnMachamp = new System.Windows.Forms.Button();
            this.btnGengar = new System.Windows.Forms.Button();
            this.btnSnorlax = new System.Windows.Forms.Button();
            this.btnZapdos = new System.Windows.Forms.Button();
            this.btnCharizard = new System.Windows.Forms.Button();
            this.btnGyarados = new System.Windows.Forms.Button();
            this.lblHover = new System.Windows.Forms.Label();
            this.lblStats = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Comic Sans MS", 30F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(220, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(404, 63);
            this.label1.TabIndex = 6;
            this.label1.Text = "Choose 3 Pokémon";
            this.label1.MouseHover += new System.EventHandler(this.Label1_MouseHover);
            // 
            // btnStartGame
            // 
            this.btnStartGame.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.btnStartGame.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnStartGame.FlatAppearance.BorderColor = System.Drawing.Color.Red;
            this.btnStartGame.FlatAppearance.BorderSize = 6;
            this.btnStartGame.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btnStartGame.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btnStartGame.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnStartGame.Font = new System.Drawing.Font("Comic Sans MS", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnStartGame.Location = new System.Drawing.Point(679, 593);
            this.btnStartGame.Name = "btnStartGame";
            this.btnStartGame.Size = new System.Drawing.Size(142, 55);
            this.btnStartGame.TabIndex = 7;
            this.btnStartGame.Text = "Start";
            this.btnStartGame.UseVisualStyleBackColor = false;
            this.btnStartGame.Click += new System.EventHandler(this.BtnStartGame_Click);
            this.btnStartGame.MouseHover += new System.EventHandler(this.BtnStartGame_MouseHover);
            // 
            // btnMachamp
            // 
            this.btnMachamp.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnMachamp.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnMachamp.FlatAppearance.BorderSize = 4;
            this.btnMachamp.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMachamp.Image = global::pokemon.Properties.Resources.machamp;
            this.btnMachamp.Location = new System.Drawing.Point(563, 336);
            this.btnMachamp.Name = "btnMachamp";
            this.btnMachamp.Size = new System.Drawing.Size(258, 240);
            this.btnMachamp.TabIndex = 5;
            this.btnMachamp.UseVisualStyleBackColor = true;
            this.btnMachamp.Click += new System.EventHandler(this.BtnMachamp_Click);
            this.btnMachamp.MouseHover += new System.EventHandler(this.BtnMachamp_MouseHover);
            // 
            // btnGengar
            // 
            this.btnGengar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnGengar.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnGengar.FlatAppearance.BorderSize = 4;
            this.btnGengar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGengar.Image = global::pokemon.Properties.Resources.gengar;
            this.btnGengar.Location = new System.Drawing.Point(286, 336);
            this.btnGengar.Name = "btnGengar";
            this.btnGengar.Size = new System.Drawing.Size(258, 240);
            this.btnGengar.TabIndex = 4;
            this.btnGengar.UseVisualStyleBackColor = true;
            this.btnGengar.Click += new System.EventHandler(this.BtnGengar_Click);
            this.btnGengar.MouseHover += new System.EventHandler(this.BtnGengar_MouseHover);
            // 
            // btnSnorlax
            // 
            this.btnSnorlax.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSnorlax.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnSnorlax.FlatAppearance.BorderSize = 4;
            this.btnSnorlax.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSnorlax.Image = global::pokemon.Properties.Resources.snorlax;
            this.btnSnorlax.Location = new System.Drawing.Point(12, 336);
            this.btnSnorlax.Name = "btnSnorlax";
            this.btnSnorlax.Size = new System.Drawing.Size(258, 240);
            this.btnSnorlax.TabIndex = 3;
            this.btnSnorlax.UseVisualStyleBackColor = true;
            this.btnSnorlax.Click += new System.EventHandler(this.BtnSnorlax_Click);
            this.btnSnorlax.MouseHover += new System.EventHandler(this.BtnSnorlax_MouseHover);
            // 
            // btnZapdos
            // 
            this.btnZapdos.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnZapdos.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnZapdos.FlatAppearance.BorderSize = 4;
            this.btnZapdos.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnZapdos.Image = global::pokemon.Properties.Resources.zapdos;
            this.btnZapdos.Location = new System.Drawing.Point(563, 75);
            this.btnZapdos.Name = "btnZapdos";
            this.btnZapdos.Size = new System.Drawing.Size(258, 240);
            this.btnZapdos.TabIndex = 2;
            this.btnZapdos.UseVisualStyleBackColor = true;
            this.btnZapdos.Click += new System.EventHandler(this.BtnZapdos_Click);
            this.btnZapdos.MouseHover += new System.EventHandler(this.BtnZapdos_MouseHover);
            // 
            // btnCharizard
            // 
            this.btnCharizard.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCharizard.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnCharizard.FlatAppearance.BorderSize = 4;
            this.btnCharizard.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCharizard.Image = global::pokemon.Properties.Resources.charizard;
            this.btnCharizard.Location = new System.Drawing.Point(286, 75);
            this.btnCharizard.Name = "btnCharizard";
            this.btnCharizard.Size = new System.Drawing.Size(258, 240);
            this.btnCharizard.TabIndex = 1;
            this.btnCharizard.UseVisualStyleBackColor = true;
            this.btnCharizard.Click += new System.EventHandler(this.btnCharizard_Click);
            this.btnCharizard.MouseHover += new System.EventHandler(this.btnCharizard_MouseHover);
            // 
            // btnGyarados
            // 
            this.btnGyarados.BackColor = System.Drawing.Color.White;
            this.btnGyarados.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnGyarados.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnGyarados.FlatAppearance.BorderSize = 4;
            this.btnGyarados.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnGyarados.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnGyarados.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGyarados.Image = global::pokemon.Properties.Resources.gyarados;
            this.btnGyarados.Location = new System.Drawing.Point(12, 75);
            this.btnGyarados.Name = "btnGyarados";
            this.btnGyarados.Size = new System.Drawing.Size(258, 240);
            this.btnGyarados.TabIndex = 0;
            this.btnGyarados.UseVisualStyleBackColor = false;
            this.btnGyarados.Click += new System.EventHandler(this.BtnGyarados_Click);
            this.btnGyarados.MouseHover += new System.EventHandler(this.BtnGyarados_MouseHover);
            // 
            // lblHover
            // 
            this.lblHover.Font = new System.Drawing.Font("Comic Sans MS", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHover.Location = new System.Drawing.Point(12, 579);
            this.lblHover.Name = "lblHover";
            this.lblHover.Size = new System.Drawing.Size(466, 37);
            this.lblHover.TabIndex = 8;
            this.lblHover.MouseHover += new System.EventHandler(this.LblHover_MouseHover);
            // 
            // lblStats
            // 
            this.lblStats.Font = new System.Drawing.Font("Comic Sans MS", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStats.Location = new System.Drawing.Point(12, 616);
            this.lblStats.Name = "lblStats";
            this.lblStats.Size = new System.Drawing.Size(661, 54);
            this.lblStats.TabIndex = 9;
            this.lblStats.MouseHover += new System.EventHandler(this.LblStats_MouseHover);
            // 
            // SelectPokemon
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(837, 679);
            this.Controls.Add(this.lblStats);
            this.Controls.Add(this.lblHover);
            this.Controls.Add(this.btnStartGame);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnMachamp);
            this.Controls.Add(this.btnGengar);
            this.Controls.Add(this.btnSnorlax);
            this.Controls.Add(this.btnZapdos);
            this.Controls.Add(this.btnCharizard);
            this.Controls.Add(this.btnGyarados);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "SelectPokemon";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Select Pokémon";
            this.Load += new System.EventHandler(this.SelectPokemon_Load_1);
            this.MouseHover += new System.EventHandler(this.SelectPokemon_MouseHover);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnGyarados;
        private System.Windows.Forms.Button btnCharizard;
        private System.Windows.Forms.Button btnZapdos;
        private System.Windows.Forms.Button btnSnorlax;
        private System.Windows.Forms.Button btnGengar;
        private System.Windows.Forms.Button btnMachamp;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnStartGame;
        private System.Windows.Forms.Label lblHover;
        private System.Windows.Forms.Label lblStats;
    }
}

