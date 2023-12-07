
namespace pokemon
{
    partial class Battle
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Battle));
            this.listView1 = new System.Windows.Forms.ListView();
            this.button1 = new System.Windows.Forms.Button();
            this.btnPokemon = new System.Windows.Forms.Button();
            this.btnBag = new System.Windows.Forms.Button();
            this.btnFight = new System.Windows.Forms.Button();
            this.listView2 = new System.Windows.Forms.ListView();
            this.listView3 = new System.Windows.Forms.ListView();
            this.lblText = new System.Windows.Forms.Label();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.lblEnemyPokemon = new System.Windows.Forms.Label();
            this.lblBackground = new System.Windows.Forms.Label();
            this.lblPlayerPokemonName = new System.Windows.Forms.Label();
            this.lblHP = new System.Windows.Forms.Label();
            this.lblPlayerPokemonHealth = new System.Windows.Forms.Label();
            this.playerPokemonHealthBar = new System.Windows.Forms.ProgressBar();
            this.btnDamage = new System.Windows.Forms.Button();
            this.btnHeal = new System.Windows.Forms.Button();
            this.lblHP2 = new System.Windows.Forms.Label();
            this.enemyPokemonHealthBar = new System.Windows.Forms.ProgressBar();
            this.lblEnemyPokemonHealth = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // listView1
            // 
            this.listView1.BackColor = System.Drawing.Color.Gray;
            this.listView1.HideSelection = false;
            this.listView1.Location = new System.Drawing.Point(12, 429);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(540, 151);
            this.listView1.TabIndex = 0;
            this.listView1.UseCompatibleStateImageBehavior = false;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(124)))), ((int)(((byte)(212)))));
            this.button1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button1.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(72)))), ((int)(((byte)(212)))));
            this.button1.FlatAppearance.BorderSize = 6;
            this.button1.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(169)))), ((int)(((byte)(212)))));
            this.button1.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(169)))), ((int)(((byte)(212)))));
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Unispace", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(719, 508);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(155, 72);
            this.button1.TabIndex = 1;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = false;
            // 
            // btnPokemon
            // 
            this.btnPokemon.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.btnPokemon.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnPokemon.FlatAppearance.BorderColor = System.Drawing.Color.Green;
            this.btnPokemon.FlatAppearance.BorderSize = 6;
            this.btnPokemon.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.btnPokemon.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.btnPokemon.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPokemon.Font = new System.Drawing.Font("Unispace", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPokemon.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnPokemon.Location = new System.Drawing.Point(558, 508);
            this.btnPokemon.Name = "btnPokemon";
            this.btnPokemon.Size = new System.Drawing.Size(155, 72);
            this.btnPokemon.TabIndex = 2;
            this.btnPokemon.Text = "Pokémon";
            this.btnPokemon.UseVisualStyleBackColor = false;
            // 
            // btnBag
            // 
            this.btnBag.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.btnBag.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnBag.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btnBag.FlatAppearance.BorderSize = 6;
            this.btnBag.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.btnBag.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.btnBag.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBag.Font = new System.Drawing.Font("Unispace", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBag.Location = new System.Drawing.Point(719, 430);
            this.btnBag.Name = "btnBag";
            this.btnBag.Size = new System.Drawing.Size(155, 72);
            this.btnBag.TabIndex = 3;
            this.btnBag.Text = "Bag";
            this.btnBag.UseVisualStyleBackColor = false;
            // 
            // btnFight
            // 
            this.btnFight.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.btnFight.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnFight.FlatAppearance.BorderColor = System.Drawing.Color.Red;
            this.btnFight.FlatAppearance.BorderSize = 6;
            this.btnFight.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btnFight.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btnFight.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFight.Font = new System.Drawing.Font("Unispace", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFight.Location = new System.Drawing.Point(558, 430);
            this.btnFight.Name = "btnFight";
            this.btnFight.Size = new System.Drawing.Size(155, 72);
            this.btnFight.TabIndex = 4;
            this.btnFight.Text = "Fight";
            this.btnFight.UseVisualStyleBackColor = false;
            // 
            // listView2
            // 
            this.listView2.BackColor = System.Drawing.Color.Gray;
            this.listView2.HideSelection = false;
            this.listView2.Location = new System.Drawing.Point(483, 315);
            this.listView2.Name = "listView2";
            this.listView2.Size = new System.Drawing.Size(391, 108);
            this.listView2.TabIndex = 7;
            this.listView2.UseCompatibleStateImageBehavior = false;
            // 
            // listView3
            // 
            this.listView3.BackColor = System.Drawing.Color.Gray;
            this.listView3.HideSelection = false;
            this.listView3.Location = new System.Drawing.Point(12, 12);
            this.listView3.Name = "listView3";
            this.listView3.Size = new System.Drawing.Size(390, 108);
            this.listView3.TabIndex = 8;
            this.listView3.UseCompatibleStateImageBehavior = false;
            // 
            // lblText
            // 
            this.lblText.BackColor = System.Drawing.Color.White;
            this.lblText.Font = new System.Drawing.Font("Unispace", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblText.Location = new System.Drawing.Point(23, 440);
            this.lblText.Name = "lblText";
            this.lblText.Size = new System.Drawing.Size(517, 128);
            this.lblText.TabIndex = 9;
            this.lblText.Text = "label1";
            this.lblText.Click += new System.EventHandler(this.label1_Click);
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox2.Location = new System.Drawing.Point(501, 12);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(358, 288);
            this.pictureBox2.TabIndex = 6;
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.Location = new System.Drawing.Point(12, 135);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(390, 288);
            this.pictureBox1.TabIndex = 5;
            this.pictureBox1.TabStop = false;
            // 
            // lblEnemyPokemon
            // 
            this.lblEnemyPokemon.BackColor = System.Drawing.Color.White;
            this.lblEnemyPokemon.Font = new System.Drawing.Font("Unispace", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEnemyPokemon.Location = new System.Drawing.Point(23, 24);
            this.lblEnemyPokemon.Name = "lblEnemyPokemon";
            this.lblEnemyPokemon.Size = new System.Drawing.Size(364, 84);
            this.lblEnemyPokemon.TabIndex = 11;
            this.lblEnemyPokemon.Text = "pokemonName";
            // 
            // lblBackground
            // 
            this.lblBackground.BackColor = System.Drawing.Color.White;
            this.lblBackground.Location = new System.Drawing.Point(494, 330);
            this.lblBackground.Name = "lblBackground";
            this.lblBackground.Size = new System.Drawing.Size(365, 77);
            this.lblBackground.TabIndex = 12;
            // 
            // lblPlayerPokemonName
            // 
            this.lblPlayerPokemonName.BackColor = System.Drawing.Color.White;
            this.lblPlayerPokemonName.Font = new System.Drawing.Font("Unispace", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPlayerPokemonName.Location = new System.Drawing.Point(495, 330);
            this.lblPlayerPokemonName.Name = "lblPlayerPokemonName";
            this.lblPlayerPokemonName.Size = new System.Drawing.Size(326, 44);
            this.lblPlayerPokemonName.TabIndex = 13;
            this.lblPlayerPokemonName.Text = "PokemonName";
            // 
            // lblHP
            // 
            this.lblHP.BackColor = System.Drawing.Color.White;
            this.lblHP.Font = new System.Drawing.Font("Unispace", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHP.Location = new System.Drawing.Point(564, 365);
            this.lblHP.Name = "lblHP";
            this.lblHP.Size = new System.Drawing.Size(58, 42);
            this.lblHP.TabIndex = 14;
            this.lblHP.Text = "HP";
            // 
            // lblPlayerPokemonHealth
            // 
            this.lblPlayerPokemonHealth.BackColor = System.Drawing.Color.White;
            this.lblPlayerPokemonHealth.Font = new System.Drawing.Font("Unispace", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPlayerPokemonHealth.Location = new System.Drawing.Point(604, 386);
            this.lblPlayerPokemonHealth.Name = "lblPlayerPokemonHealth";
            this.lblPlayerPokemonHealth.Size = new System.Drawing.Size(145, 21);
            this.lblPlayerPokemonHealth.TabIndex = 15;
            this.lblPlayerPokemonHealth.Text = "PokemonHP";
            // 
            // playerPokemonHealthBar
            // 
            this.playerPokemonHealthBar.BackColor = System.Drawing.Color.Lime;
            this.playerPokemonHealthBar.ForeColor = System.Drawing.Color.Lime;
            this.playerPokemonHealthBar.Location = new System.Drawing.Point(608, 365);
            this.playerPokemonHealthBar.Name = "playerPokemonHealthBar";
            this.playerPokemonHealthBar.Size = new System.Drawing.Size(242, 18);
            this.playerPokemonHealthBar.TabIndex = 16;
            // 
            // btnDamage
            // 
            this.btnDamage.Location = new System.Drawing.Point(408, 94);
            this.btnDamage.Name = "btnDamage";
            this.btnDamage.Size = new System.Drawing.Size(75, 76);
            this.btnDamage.TabIndex = 17;
            this.btnDamage.Text = "damage";
            this.btnDamage.UseVisualStyleBackColor = true;
            this.btnDamage.Click += new System.EventHandler(this.btnDamage_Click);
            // 
            // btnHeal
            // 
            this.btnHeal.Location = new System.Drawing.Point(408, 12);
            this.btnHeal.Name = "btnHeal";
            this.btnHeal.Size = new System.Drawing.Size(75, 76);
            this.btnHeal.TabIndex = 18;
            this.btnHeal.Text = "heal";
            this.btnHeal.UseVisualStyleBackColor = true;
            this.btnHeal.Click += new System.EventHandler(this.btnHeal_Click);
            // 
            // lblHP2
            // 
            this.lblHP2.BackColor = System.Drawing.Color.White;
            this.lblHP2.Font = new System.Drawing.Font("Unispace", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHP2.Location = new System.Drawing.Point(91, 66);
            this.lblHP2.Name = "lblHP2";
            this.lblHP2.Size = new System.Drawing.Size(58, 42);
            this.lblHP2.TabIndex = 19;
            this.lblHP2.Text = "HP";
            // 
            // enemyPokemonHealthBar
            // 
            this.enemyPokemonHealthBar.BackColor = System.Drawing.Color.Lime;
            this.enemyPokemonHealthBar.ForeColor = System.Drawing.Color.Lime;
            this.enemyPokemonHealthBar.Location = new System.Drawing.Point(133, 66);
            this.enemyPokemonHealthBar.Name = "enemyPokemonHealthBar";
            this.enemyPokemonHealthBar.Size = new System.Drawing.Size(239, 18);
            this.enemyPokemonHealthBar.TabIndex = 20;
            // 
            // lblEnemyPokemonHealth
            // 
            this.lblEnemyPokemonHealth.BackColor = System.Drawing.Color.White;
            this.lblEnemyPokemonHealth.Font = new System.Drawing.Font("Unispace", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEnemyPokemonHealth.Location = new System.Drawing.Point(129, 87);
            this.lblEnemyPokemonHealth.Name = "lblEnemyPokemonHealth";
            this.lblEnemyPokemonHealth.Size = new System.Drawing.Size(145, 21);
            this.lblEnemyPokemonHealth.TabIndex = 21;
            this.lblEnemyPokemonHealth.Text = "PokemonHP";
            // 
            // Battle
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::pokemon.Properties.Resources.background;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(886, 592);
            this.Controls.Add(this.lblEnemyPokemonHealth);
            this.Controls.Add(this.enemyPokemonHealthBar);
            this.Controls.Add(this.lblHP2);
            this.Controls.Add(this.btnHeal);
            this.Controls.Add(this.btnDamage);
            this.Controls.Add(this.playerPokemonHealthBar);
            this.Controls.Add(this.lblPlayerPokemonHealth);
            this.Controls.Add(this.lblHP);
            this.Controls.Add(this.lblPlayerPokemonName);
            this.Controls.Add(this.lblBackground);
            this.Controls.Add(this.lblEnemyPokemon);
            this.Controls.Add(this.lblText);
            this.Controls.Add(this.listView3);
            this.Controls.Add(this.listView2);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.btnFight);
            this.Controls.Add(this.btnBag);
            this.Controls.Add(this.btnPokemon);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.listView1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Battle";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Battle";
            this.Load += new System.EventHandler(this.Form2_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btnPokemon;
        private System.Windows.Forms.Button btnBag;
        private System.Windows.Forms.Button btnFight;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.ListView listView2;
        private System.Windows.Forms.ListView listView3;
        private System.Windows.Forms.Label lblText;
        private System.Windows.Forms.Label lblEnemyPokemon;
        private System.Windows.Forms.Label lblBackground;
        private System.Windows.Forms.Label lblPlayerPokemonName;
        private System.Windows.Forms.Label lblHP;
        private System.Windows.Forms.Label lblPlayerPokemonHealth;
        private System.Windows.Forms.ProgressBar playerPokemonHealthBar;
        private System.Windows.Forms.Button btnDamage;
        private System.Windows.Forms.Button btnHeal;
        private System.Windows.Forms.Label lblHP2;
        private System.Windows.Forms.ProgressBar enemyPokemonHealthBar;
        private System.Windows.Forms.Label lblEnemyPokemonHealth;
    }
}