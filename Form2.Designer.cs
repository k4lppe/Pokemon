
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
            this.btnBag = new System.Windows.Forms.Button();
            this.btnFight = new System.Windows.Forms.Button();
            this.listView2 = new System.Windows.Forms.ListView();
            this.listView3 = new System.Windows.Forms.ListView();
            this.lblText = new System.Windows.Forms.Label();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.lblBackground2 = new System.Windows.Forms.Label();
            this.lblBackground = new System.Windows.Forms.Label();
            this.lblHP = new System.Windows.Forms.Label();
            this.lblPlayerPokemonHealth = new System.Windows.Forms.Label();
            this.playerPokemonHealthBar = new System.Windows.Forms.ProgressBar();
            this.btnDamage = new System.Windows.Forms.Button();
            this.btnHeal = new System.Windows.Forms.Button();
            this.lblHP2 = new System.Windows.Forms.Label();
            this.enemyPokemonHealthBar = new System.Windows.Forms.ProgressBar();
            this.lblEnemyPokemonHealth = new System.Windows.Forms.Label();
            this.lblPlayerPokemonName = new System.Windows.Forms.Label();
            this.customObject1 = new System.Windows.Forms.Label();
            this.customObject2 = new System.Windows.Forms.Label();
            this.lblEnemyPokemonName = new System.Windows.Forms.Label();
            this.btnHeal2 = new System.Windows.Forms.Button();
            this.btnDamage2 = new System.Windows.Forms.Button();
            this.btnMove1 = new System.Windows.Forms.Button();
            this.btnMove2 = new System.Windows.Forms.Button();
            this.btnMove3 = new System.Windows.Forms.Button();
            this.btnMove4 = new System.Windows.Forms.Button();
            this.btnPotion = new System.Windows.Forms.Button();
            this.btnSPotion = new System.Windows.Forms.Button();
            this.btnHPotion = new System.Windows.Forms.Button();
            this.lblInfo = new System.Windows.Forms.Label();
            this.lblParalyzed = new System.Windows.Forms.Label();
            this.lblSleeping = new System.Windows.Forms.Label();
            this.lblConfused = new System.Windows.Forms.Label();
            this.lblBurning = new System.Windows.Forms.Label();
            this.lblParalyzed2 = new System.Windows.Forms.Label();
            this.lblSleeping2 = new System.Windows.Forms.Label();
            this.lblConfused2 = new System.Windows.Forms.Label();
            this.lblBurning2 = new System.Windows.Forms.Label();
            this.btnLumberry = new System.Windows.Forms.Button();
            this.lblTime = new System.Windows.Forms.Label();
            this.lblDamageText = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // listView1
            // 
            this.listView1.BackColor = System.Drawing.Color.Gray;
            this.listView1.HideSelection = false;
            this.listView1.Location = new System.Drawing.Point(1, 496);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(629, 151);
            this.listView1.TabIndex = 0;
            this.listView1.UseCompatibleStateImageBehavior = false;
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
            this.btnBag.Font = new System.Drawing.Font("Comic Sans MS", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBag.Location = new System.Drawing.Point(637, 575);
            this.btnBag.Name = "btnBag";
            this.btnBag.Size = new System.Drawing.Size(315, 72);
            this.btnBag.TabIndex = 3;
            this.btnBag.Text = "Bag";
            this.btnBag.UseVisualStyleBackColor = false;
            this.btnBag.Click += new System.EventHandler(this.btnBag_Click);
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
            this.btnFight.Font = new System.Drawing.Font("Comic Sans MS", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFight.Location = new System.Drawing.Point(636, 497);
            this.btnFight.Name = "btnFight";
            this.btnFight.Size = new System.Drawing.Size(316, 72);
            this.btnFight.TabIndex = 4;
            this.btnFight.Text = "Fight";
            this.btnFight.UseVisualStyleBackColor = false;
            this.btnFight.Click += new System.EventHandler(this.BtnFight_Click);
            // 
            // listView2
            // 
            this.listView2.BackColor = System.Drawing.Color.Gray;
            this.listView2.HideSelection = false;
            this.listView2.Location = new System.Drawing.Point(561, 373);
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
            this.lblText.Font = new System.Drawing.Font("Comic Sans MS", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblText.Location = new System.Drawing.Point(12, 507);
            this.lblText.Name = "lblText";
            this.lblText.Size = new System.Drawing.Size(606, 128);
            this.lblText.TabIndex = 9;
            this.lblText.Text = "label1";
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox2.Location = new System.Drawing.Point(582, 59);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(347, 302);
            this.pictureBox2.TabIndex = 6;
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.Location = new System.Drawing.Point(53, 159);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(353, 306);
            this.pictureBox1.TabIndex = 5;
            this.pictureBox1.TabStop = false;
            // 
            // lblBackground2
            // 
            this.lblBackground2.BackColor = System.Drawing.Color.White;
            this.lblBackground2.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBackground2.Location = new System.Drawing.Point(26, 24);
            this.lblBackground2.Name = "lblBackground2";
            this.lblBackground2.Size = new System.Drawing.Size(364, 84);
            this.lblBackground2.TabIndex = 11;
            // 
            // lblBackground
            // 
            this.lblBackground.BackColor = System.Drawing.Color.White;
            this.lblBackground.Location = new System.Drawing.Point(573, 388);
            this.lblBackground.Name = "lblBackground";
            this.lblBackground.Size = new System.Drawing.Size(365, 77);
            this.lblBackground.TabIndex = 12;
            // 
            // lblHP
            // 
            this.lblHP.BackColor = System.Drawing.Color.White;
            this.lblHP.Font = new System.Drawing.Font("Comic Sans MS", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHP.Location = new System.Drawing.Point(630, 423);
            this.lblHP.Name = "lblHP";
            this.lblHP.Size = new System.Drawing.Size(65, 42);
            this.lblHP.TabIndex = 14;
            this.lblHP.Text = "HP";
            // 
            // lblPlayerPokemonHealth
            // 
            this.lblPlayerPokemonHealth.BackColor = System.Drawing.Color.White;
            this.lblPlayerPokemonHealth.Font = new System.Drawing.Font("Comic Sans MS", 13.25F);
            this.lblPlayerPokemonHealth.Location = new System.Drawing.Point(682, 444);
            this.lblPlayerPokemonHealth.Name = "lblPlayerPokemonHealth";
            this.lblPlayerPokemonHealth.Size = new System.Drawing.Size(131, 21);
            this.lblPlayerPokemonHealth.TabIndex = 15;
            this.lblPlayerPokemonHealth.Text = "pokemonHP";
            // 
            // playerPokemonHealthBar
            // 
            this.playerPokemonHealthBar.BackColor = System.Drawing.Color.Lime;
            this.playerPokemonHealthBar.ForeColor = System.Drawing.Color.Lime;
            this.playerPokemonHealthBar.Location = new System.Drawing.Point(687, 423);
            this.playerPokemonHealthBar.Name = "playerPokemonHealthBar";
            this.playerPokemonHealthBar.Size = new System.Drawing.Size(242, 18);
            this.playerPokemonHealthBar.TabIndex = 16;
            // 
            // btnDamage
            // 
            this.btnDamage.Location = new System.Drawing.Point(484, 258);
            this.btnDamage.Name = "btnDamage";
            this.btnDamage.Size = new System.Drawing.Size(75, 76);
            this.btnDamage.TabIndex = 17;
            this.btnDamage.Text = "damage";
            this.btnDamage.UseVisualStyleBackColor = true;
            this.btnDamage.Click += new System.EventHandler(this.btnDamage_Click);
            // 
            // btnHeal
            // 
            this.btnHeal.Location = new System.Drawing.Point(484, 12);
            this.btnHeal.Name = "btnHeal";
            this.btnHeal.Size = new System.Drawing.Size(75, 76);
            this.btnHeal.TabIndex = 18;
            this.btnHeal.Text = "heal";
            this.btnHeal.UseVisualStyleBackColor = true;
            this.btnHeal.Click += new System.EventHandler(this.BtnHeal_Click);
            // 
            // lblHP2
            // 
            this.lblHP2.BackColor = System.Drawing.Color.White;
            this.lblHP2.Font = new System.Drawing.Font("Comic Sans MS", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHP2.Location = new System.Drawing.Point(79, 66);
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
            this.lblEnemyPokemonHealth.Font = new System.Drawing.Font("Comic Sans MS", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEnemyPokemonHealth.Location = new System.Drawing.Point(128, 87);
            this.lblEnemyPokemonHealth.Name = "lblEnemyPokemonHealth";
            this.lblEnemyPokemonHealth.Size = new System.Drawing.Size(145, 21);
            this.lblEnemyPokemonHealth.TabIndex = 21;
            this.lblEnemyPokemonHealth.Text = "pokemonHP";
            // 
            // lblPlayerPokemonName
            // 
            this.lblPlayerPokemonName.BackColor = System.Drawing.Color.White;
            this.lblPlayerPokemonName.Font = new System.Drawing.Font("Comic Sans MS", 18.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPlayerPokemonName.Location = new System.Drawing.Point(576, 388);
            this.lblPlayerPokemonName.Name = "lblPlayerPokemonName";
            this.lblPlayerPokemonName.Size = new System.Drawing.Size(319, 35);
            this.lblPlayerPokemonName.TabIndex = 13;
            this.lblPlayerPokemonName.Text = "pokemonName";
            // 
            // customObject1
            // 
            this.customObject1.BackColor = System.Drawing.Color.Transparent;
            this.customObject1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.customObject1.Image = global::pokemon.Properties.Resources.customObject1;
            this.customObject1.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.customObject1.Location = new System.Drawing.Point(505, 388);
            this.customObject1.Margin = new System.Windows.Forms.Padding(0);
            this.customObject1.Name = "customObject1";
            this.customObject1.Size = new System.Drawing.Size(54, 77);
            this.customObject1.TabIndex = 22;
            this.customObject1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // customObject2
            // 
            this.customObject2.BackColor = System.Drawing.Color.Transparent;
            this.customObject2.Image = global::pokemon.Properties.Resources.customObject2;
            this.customObject2.Location = new System.Drawing.Point(408, 39);
            this.customObject2.Name = "customObject2";
            this.customObject2.Size = new System.Drawing.Size(51, 59);
            this.customObject2.TabIndex = 23;
            // 
            // lblEnemyPokemonName
            // 
            this.lblEnemyPokemonName.AutoSize = true;
            this.lblEnemyPokemonName.BackColor = System.Drawing.Color.White;
            this.lblEnemyPokemonName.Font = new System.Drawing.Font("Comic Sans MS", 18.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEnemyPokemonName.Location = new System.Drawing.Point(29, 24);
            this.lblEnemyPokemonName.Name = "lblEnemyPokemonName";
            this.lblEnemyPokemonName.Size = new System.Drawing.Size(181, 35);
            this.lblEnemyPokemonName.TabIndex = 24;
            this.lblEnemyPokemonName.Text = "pokemonName";
            // 
            // btnHeal2
            // 
            this.btnHeal2.Location = new System.Drawing.Point(484, 94);
            this.btnHeal2.Name = "btnHeal2";
            this.btnHeal2.Size = new System.Drawing.Size(75, 76);
            this.btnHeal2.TabIndex = 25;
            this.btnHeal2.Text = "heal enemy";
            this.btnHeal2.UseVisualStyleBackColor = true;
            this.btnHeal2.Click += new System.EventHandler(this.BtnHeal2_Click);
            // 
            // btnDamage2
            // 
            this.btnDamage2.Location = new System.Drawing.Point(484, 176);
            this.btnDamage2.Name = "btnDamage2";
            this.btnDamage2.Size = new System.Drawing.Size(75, 76);
            this.btnDamage2.TabIndex = 26;
            this.btnDamage2.Text = "damage enemy";
            this.btnDamage2.UseVisualStyleBackColor = true;
            this.btnDamage2.Click += new System.EventHandler(this.btnDamage2_Click);
            // 
            // btnMove1
            // 
            this.btnMove1.BackColor = System.Drawing.Color.White;
            this.btnMove1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnMove1.FlatAppearance.BorderSize = 0;
            this.btnMove1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMove1.Font = new System.Drawing.Font("Comic Sans MS", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMove1.Location = new System.Drawing.Point(12, 507);
            this.btnMove1.Name = "btnMove1";
            this.btnMove1.Size = new System.Drawing.Size(303, 62);
            this.btnMove1.TabIndex = 27;
            this.btnMove1.Text = "Move1";
            this.btnMove1.UseVisualStyleBackColor = false;
            this.btnMove1.Visible = false;
            this.btnMove1.Click += new System.EventHandler(this.BtnMove1_Click);
            this.btnMove1.MouseLeave += new System.EventHandler(this.BtnMove1_MouseLeave);
            this.btnMove1.MouseHover += new System.EventHandler(this.BtnMove1_MouseHover);
            // 
            // btnMove2
            // 
            this.btnMove2.BackColor = System.Drawing.Color.White;
            this.btnMove2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnMove2.FlatAppearance.BorderSize = 0;
            this.btnMove2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMove2.Font = new System.Drawing.Font("Comic Sans MS", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMove2.Location = new System.Drawing.Point(312, 507);
            this.btnMove2.Name = "btnMove2";
            this.btnMove2.Size = new System.Drawing.Size(306, 62);
            this.btnMove2.TabIndex = 28;
            this.btnMove2.Text = "Move2";
            this.btnMove2.UseVisualStyleBackColor = false;
            this.btnMove2.Visible = false;
            this.btnMove2.Click += new System.EventHandler(this.BtnMove2_Click);
            this.btnMove2.MouseLeave += new System.EventHandler(this.BtnMove2_MouseLeave);
            this.btnMove2.MouseHover += new System.EventHandler(this.BtnMove2_MouseHover);
            // 
            // btnMove3
            // 
            this.btnMove3.BackColor = System.Drawing.Color.White;
            this.btnMove3.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnMove3.FlatAppearance.BorderSize = 0;
            this.btnMove3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMove3.Font = new System.Drawing.Font("Comic Sans MS", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMove3.Location = new System.Drawing.Point(12, 564);
            this.btnMove3.Name = "btnMove3";
            this.btnMove3.Size = new System.Drawing.Size(303, 71);
            this.btnMove3.TabIndex = 29;
            this.btnMove3.Text = "Move3";
            this.btnMove3.UseVisualStyleBackColor = false;
            this.btnMove3.Visible = false;
            this.btnMove3.Click += new System.EventHandler(this.BtnMove3_Click);
            this.btnMove3.MouseLeave += new System.EventHandler(this.BtnMove3_MouseLeave);
            this.btnMove3.MouseHover += new System.EventHandler(this.BtnMove3_MouseHover);
            // 
            // btnMove4
            // 
            this.btnMove4.BackColor = System.Drawing.Color.White;
            this.btnMove4.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnMove4.FlatAppearance.BorderSize = 0;
            this.btnMove4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMove4.Font = new System.Drawing.Font("Comic Sans MS", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMove4.Location = new System.Drawing.Point(312, 564);
            this.btnMove4.Name = "btnMove4";
            this.btnMove4.Size = new System.Drawing.Size(306, 71);
            this.btnMove4.TabIndex = 30;
            this.btnMove4.Text = "Move4";
            this.btnMove4.UseVisualStyleBackColor = false;
            this.btnMove4.Visible = false;
            this.btnMove4.Click += new System.EventHandler(this.BtnMove4_Click);
            this.btnMove4.MouseLeave += new System.EventHandler(this.BtnMove4_MouseLeave);
            this.btnMove4.MouseHover += new System.EventHandler(this.BtnMove4_MouseHover);
            // 
            // btnPotion
            // 
            this.btnPotion.BackColor = System.Drawing.Color.White;
            this.btnPotion.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnPotion.FlatAppearance.BorderSize = 0;
            this.btnPotion.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPotion.Font = new System.Drawing.Font("Comic Sans MS", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPotion.Image = global::pokemon.Properties.Resources.potion;
            this.btnPotion.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnPotion.Location = new System.Drawing.Point(12, 507);
            this.btnPotion.Name = "btnPotion";
            this.btnPotion.Size = new System.Drawing.Size(303, 60);
            this.btnPotion.TabIndex = 31;
            this.btnPotion.Text = "potion";
            this.btnPotion.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnPotion.UseVisualStyleBackColor = false;
            this.btnPotion.Visible = false;
            this.btnPotion.Click += new System.EventHandler(this.BtnPotion_Click);
            this.btnPotion.MouseLeave += new System.EventHandler(this.BtnPotion_MouseLeave);
            this.btnPotion.MouseHover += new System.EventHandler(this.BtnPotion_MouseHover);
            // 
            // btnSPotion
            // 
            this.btnSPotion.BackColor = System.Drawing.Color.White;
            this.btnSPotion.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSPotion.FlatAppearance.BorderSize = 0;
            this.btnSPotion.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSPotion.Font = new System.Drawing.Font("Comic Sans MS", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSPotion.Image = global::pokemon.Properties.Resources.superpotion;
            this.btnSPotion.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSPotion.Location = new System.Drawing.Point(315, 507);
            this.btnSPotion.Name = "btnSPotion";
            this.btnSPotion.Size = new System.Drawing.Size(303, 60);
            this.btnSPotion.TabIndex = 32;
            this.btnSPotion.Text = "super potion";
            this.btnSPotion.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSPotion.UseVisualStyleBackColor = false;
            this.btnSPotion.Visible = false;
            this.btnSPotion.Click += new System.EventHandler(this.BtnSPotion_Click);
            this.btnSPotion.MouseLeave += new System.EventHandler(this.BtnSPotion_MouseLeave);
            this.btnSPotion.MouseHover += new System.EventHandler(this.btnSPotion_MouseHover);
            // 
            // btnHPotion
            // 
            this.btnHPotion.BackColor = System.Drawing.Color.White;
            this.btnHPotion.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnHPotion.FlatAppearance.BorderSize = 0;
            this.btnHPotion.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnHPotion.Font = new System.Drawing.Font("Comic Sans MS", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnHPotion.Image = global::pokemon.Properties.Resources.hyperpotion1;
            this.btnHPotion.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnHPotion.Location = new System.Drawing.Point(12, 564);
            this.btnHPotion.Name = "btnHPotion";
            this.btnHPotion.Size = new System.Drawing.Size(303, 71);
            this.btnHPotion.TabIndex = 33;
            this.btnHPotion.Text = "hyper potion";
            this.btnHPotion.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnHPotion.UseVisualStyleBackColor = false;
            this.btnHPotion.Visible = false;
            this.btnHPotion.Click += new System.EventHandler(this.BtnHPotion_Click);
            this.btnHPotion.MouseLeave += new System.EventHandler(this.BtnHPotion_MouseLeave);
            this.btnHPotion.MouseHover += new System.EventHandler(this.BtnHPotion_MouseHover);
            // 
            // lblInfo
            // 
            this.lblInfo.BackColor = System.Drawing.Color.White;
            this.lblInfo.Font = new System.Drawing.Font("Comic Sans MS", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblInfo.Location = new System.Drawing.Point(9, 373);
            this.lblInfo.Name = "lblInfo";
            this.lblInfo.Size = new System.Drawing.Size(504, 108);
            this.lblInfo.TabIndex = 34;
            this.lblInfo.Text = "Info";
            this.lblInfo.Visible = false;
            // 
            // lblParalyzed
            // 
            this.lblParalyzed.BackColor = System.Drawing.Color.Yellow;
            this.lblParalyzed.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblParalyzed.ForeColor = System.Drawing.Color.Black;
            this.lblParalyzed.Location = new System.Drawing.Point(829, 397);
            this.lblParalyzed.Name = "lblParalyzed";
            this.lblParalyzed.Size = new System.Drawing.Size(100, 23);
            this.lblParalyzed.TabIndex = 35;
            this.lblParalyzed.Text = "Paralyzed";
            this.lblParalyzed.Visible = false;
            // 
            // lblSleeping
            // 
            this.lblSleeping.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.lblSleeping.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSleeping.ForeColor = System.Drawing.Color.Black;
            this.lblSleeping.Location = new System.Drawing.Point(829, 396);
            this.lblSleeping.Name = "lblSleeping";
            this.lblSleeping.Size = new System.Drawing.Size(100, 23);
            this.lblSleeping.TabIndex = 36;
            this.lblSleeping.Text = "Sleeping";
            this.lblSleeping.Visible = false;
            // 
            // lblConfused
            // 
            this.lblConfused.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.lblConfused.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblConfused.ForeColor = System.Drawing.Color.Black;
            this.lblConfused.Location = new System.Drawing.Point(829, 396);
            this.lblConfused.Name = "lblConfused";
            this.lblConfused.Size = new System.Drawing.Size(100, 23);
            this.lblConfused.TabIndex = 37;
            this.lblConfused.Text = "Confused";
            this.lblConfused.Visible = false;
            // 
            // lblBurning
            // 
            this.lblBurning.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblBurning.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBurning.ForeColor = System.Drawing.Color.Black;
            this.lblBurning.Location = new System.Drawing.Point(829, 396);
            this.lblBurning.Name = "lblBurning";
            this.lblBurning.Size = new System.Drawing.Size(100, 23);
            this.lblBurning.TabIndex = 38;
            this.lblBurning.Text = "Burning";
            this.lblBurning.Visible = false;
            // 
            // lblParalyzed2
            // 
            this.lblParalyzed2.BackColor = System.Drawing.Color.Yellow;
            this.lblParalyzed2.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblParalyzed2.ForeColor = System.Drawing.Color.Black;
            this.lblParalyzed2.Location = new System.Drawing.Point(272, 34);
            this.lblParalyzed2.Name = "lblParalyzed2";
            this.lblParalyzed2.Size = new System.Drawing.Size(100, 23);
            this.lblParalyzed2.TabIndex = 39;
            this.lblParalyzed2.Text = "Paralyzed";
            this.lblParalyzed2.Visible = false;
            // 
            // lblSleeping2
            // 
            this.lblSleeping2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.lblSleeping2.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSleeping2.ForeColor = System.Drawing.Color.Black;
            this.lblSleeping2.Location = new System.Drawing.Point(272, 33);
            this.lblSleeping2.Name = "lblSleeping2";
            this.lblSleeping2.Size = new System.Drawing.Size(100, 23);
            this.lblSleeping2.TabIndex = 40;
            this.lblSleeping2.Text = "Sleeping";
            this.lblSleeping2.Visible = false;
            // 
            // lblConfused2
            // 
            this.lblConfused2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.lblConfused2.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblConfused2.ForeColor = System.Drawing.Color.Black;
            this.lblConfused2.Location = new System.Drawing.Point(272, 34);
            this.lblConfused2.Name = "lblConfused2";
            this.lblConfused2.Size = new System.Drawing.Size(100, 23);
            this.lblConfused2.TabIndex = 41;
            this.lblConfused2.Text = "Confused";
            this.lblConfused2.Visible = false;
            // 
            // lblBurning2
            // 
            this.lblBurning2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblBurning2.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBurning2.ForeColor = System.Drawing.Color.Black;
            this.lblBurning2.Location = new System.Drawing.Point(272, 33);
            this.lblBurning2.Name = "lblBurning2";
            this.lblBurning2.Size = new System.Drawing.Size(100, 23);
            this.lblBurning2.TabIndex = 42;
            this.lblBurning2.Text = "Burning";
            this.lblBurning2.Visible = false;
            // 
            // btnLumberry
            // 
            this.btnLumberry.BackColor = System.Drawing.Color.White;
            this.btnLumberry.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnLumberry.FlatAppearance.BorderSize = 0;
            this.btnLumberry.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLumberry.Font = new System.Drawing.Font("Comic Sans MS", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLumberry.Image = ((System.Drawing.Image)(resources.GetObject("btnLumberry.Image")));
            this.btnLumberry.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnLumberry.Location = new System.Drawing.Point(315, 564);
            this.btnLumberry.Name = "btnLumberry";
            this.btnLumberry.Size = new System.Drawing.Size(303, 71);
            this.btnLumberry.TabIndex = 43;
            this.btnLumberry.Text = "lum berry";
            this.btnLumberry.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnLumberry.UseVisualStyleBackColor = false;
            this.btnLumberry.Visible = false;
            this.btnLumberry.Click += new System.EventHandler(this.BtnLumberry_Click);
            this.btnLumberry.MouseLeave += new System.EventHandler(this.BtnLumberry_MouseLeave);
            this.btnLumberry.MouseHover += new System.EventHandler(this.BtnLumberry_MouseHover);
            // 
            // lblTime
            // 
            this.lblTime.BackColor = System.Drawing.Color.Transparent;
            this.lblTime.Font = new System.Drawing.Font("Comic Sans MS", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTime.Location = new System.Drawing.Point(594, 0);
            this.lblTime.Name = "lblTime";
            this.lblTime.Size = new System.Drawing.Size(180, 41);
            this.lblTime.TabIndex = 44;
            this.lblTime.Text = "time";
            // 
            // lblDamageText
            // 
            this.lblDamageText.BackColor = System.Drawing.Color.Transparent;
            this.lblDamageText.Font = new System.Drawing.Font("Comic Sans MS", 17.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDamageText.Location = new System.Drawing.Point(743, 0);
            this.lblDamageText.Name = "lblDamageText";
            this.lblDamageText.Size = new System.Drawing.Size(186, 56);
            this.lblDamageText.TabIndex = 45;
            this.lblDamageText.Text = "damage";
            // 
            // Battle
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackgroundImage = global::pokemon.Properties.Resources.background;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(964, 649);
            this.Controls.Add(this.lblDamageText);
            this.Controls.Add(this.lblTime);
            this.Controls.Add(this.btnLumberry);
            this.Controls.Add(this.lblBurning2);
            this.Controls.Add(this.lblConfused2);
            this.Controls.Add(this.lblSleeping2);
            this.Controls.Add(this.lblParalyzed2);
            this.Controls.Add(this.lblBurning);
            this.Controls.Add(this.lblConfused);
            this.Controls.Add(this.lblSleeping);
            this.Controls.Add(this.lblParalyzed);
            this.Controls.Add(this.lblInfo);
            this.Controls.Add(this.btnHPotion);
            this.Controls.Add(this.btnSPotion);
            this.Controls.Add(this.btnPotion);
            this.Controls.Add(this.btnMove4);
            this.Controls.Add(this.btnMove3);
            this.Controls.Add(this.btnMove2);
            this.Controls.Add(this.btnMove1);
            this.Controls.Add(this.btnDamage2);
            this.Controls.Add(this.btnHeal2);
            this.Controls.Add(this.lblEnemyPokemonName);
            this.Controls.Add(this.customObject2);
            this.Controls.Add(this.customObject1);
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
            this.Controls.Add(this.lblBackground2);
            this.Controls.Add(this.lblText);
            this.Controls.Add(this.listView3);
            this.Controls.Add(this.listView2);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.btnFight);
            this.Controls.Add(this.btnBag);
            this.Controls.Add(this.listView1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Battle";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Battle";
            this.Load += new System.EventHandler(this.Form2_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.Button btnBag;
        private System.Windows.Forms.Button btnFight;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.ListView listView2;
        private System.Windows.Forms.ListView listView3;
        private System.Windows.Forms.Label lblText;
        private System.Windows.Forms.Label lblBackground2;
        private System.Windows.Forms.Label lblBackground;
        private System.Windows.Forms.Label lblHP;
        private System.Windows.Forms.Label lblPlayerPokemonHealth;
        private System.Windows.Forms.ProgressBar playerPokemonHealthBar;
        private System.Windows.Forms.Button btnDamage;
        private System.Windows.Forms.Button btnHeal;
        private System.Windows.Forms.Label lblHP2;
        private System.Windows.Forms.ProgressBar enemyPokemonHealthBar;
        private System.Windows.Forms.Label lblEnemyPokemonHealth;
        private System.Windows.Forms.Label lblPlayerPokemonName;
        private System.Windows.Forms.Label customObject1;
        private System.Windows.Forms.Label customObject2;
        private System.Windows.Forms.Label lblEnemyPokemonName;
        private System.Windows.Forms.Button btnHeal2;
        private System.Windows.Forms.Button btnDamage2;
        private System.Windows.Forms.Button btnMove1;
        private System.Windows.Forms.Button btnMove2;
        private System.Windows.Forms.Button btnMove3;
        private System.Windows.Forms.Button btnMove4;
        private System.Windows.Forms.Button btnPotion;
        private System.Windows.Forms.Button btnSPotion;
        private System.Windows.Forms.Button btnHPotion;
        private System.Windows.Forms.Label lblInfo;
        private System.Windows.Forms.Label lblParalyzed;
        private System.Windows.Forms.Label lblSleeping;
        private System.Windows.Forms.Label lblConfused;
        private System.Windows.Forms.Label lblBurning;
        private System.Windows.Forms.Label lblParalyzed2;
        private System.Windows.Forms.Label lblSleeping2;
        private System.Windows.Forms.Label lblConfused2;
        private System.Windows.Forms.Label lblBurning2;
        private System.Windows.Forms.Button btnLumberry;
        private System.Windows.Forms.Label lblTime;
        private System.Windows.Forms.Label lblDamageText;
    }
}