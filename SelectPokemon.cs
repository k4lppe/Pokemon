using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using System.Linq;
using System.Drawing;

namespace pokemon
{
    public partial class SelectPokemon : Form
    {
        private List<Pokemon> pokemons;
        private List<Pokemon> selectedPokemons = new List<Pokemon>();
        private List<Pokemon> enemyPokemons = new List<Pokemon>();
        
        public SelectPokemon()
        {
            InitializeComponent();
            pokemons = new List<Pokemon>();
        }

        int pokemonSelected = 0;
        int pokemonIndex = 0;

        
        private void ImportPokemonStats(string path)
        {
            try
            {
                using (StreamReader reader = new StreamReader(path))
                {
                    string line;
                    while ((line = reader.ReadLine()) != null)
                    {
                        string[] stats = line.Split(',');
                        if (stats.Length == 33)
                        {
                            Pokemon pokemon = new Pokemon(
                                stats[0].Trim(), // name
                                stats[1].Trim(), // type
                                stats[2].Trim(), // type2
                                int.Parse(stats[3].Trim()), // health
                                int.Parse(stats[4].Trim()), // attack
                                int.Parse(stats[5].Trim()), // defense
                                int.Parse(stats[6].Trim()), // speed
                                int.Parse(stats[7].Trim()),  // index
                                stats[8].Trim(), //imageFile
                                int.Parse(stats[9].Trim()), //starting health
                                stats[10].Trim(), //move1
                                stats[11].Trim(), //move2
                                stats[12].Trim(), //move3
                                stats[13].Trim(), //move4
                                int.Parse(stats[14].Trim()), //move1Damage
                                int.Parse(stats[15].Trim()), //move2Damage
                                int.Parse(stats[16].Trim()), //move3Damage
                                int.Parse(stats[17].Trim()),  //move4Damage
                                bool.Parse(stats[18].Trim()), //pokemonParalyzed
                                bool.Parse(stats[19].Trim()), //pokemonConfused
                                bool.Parse(stats[20].Trim()), //pokemonCriticalHit
                                bool.Parse(stats[21].Trim()), //pokemonFlinch
                                bool.Parse(stats[22].Trim()), //pokemonBurning
                                bool.Parse(stats[23].Trim()), //pokemonSleeping
                                int.Parse(stats[24].Trim()), //startMove1Damage
                                int.Parse(stats[25].Trim()), //startMove2Damage
                                int.Parse(stats[26].Trim()), //startMove3Damage
                                int.Parse(stats[27].Trim()), //startMove4Damage
                                int.Parse(stats[28].Trim()), //specialAttack
                                int.Parse(stats[29].Trim()),  //specialDefence
                                int.Parse(stats[30].Trim()),  //starting defence
                                int.Parse(stats[31].Trim()), //starting specialAttack
                                int.Parse(stats[32].Trim()) // starting specialDefence
                            );
                            pokemons.Add(pokemon);
                        }
                        else
                        {
                            MessageBox.Show("Incorrect data format in the file");
                        }
                    }
                }
            }
            catch (Exception exp)
            {
                MessageBox.Show(exp.Message);
            }

        }

        private void BtnGyarados_Click(object sender, EventArgs e)
        {
            if (pokemonSelected < 3)
            {
                if (pokemons.Count > 0)
                {
                    Pokemon pokemonGyarados = pokemons.Find(p => p.pokemonName == "Gyarados");
                    if (pokemonGyarados != null)
                    {

                        btnGyarados.Enabled = false;
                        pokemonSelected++;
                        pokemonIndex++;
                        selectedPokemons.Add(pokemonGyarados);
                       
                        
                    }
                    else
                    {
                        MessageBox.Show("Gyarados could not be found.");
                    }
                }
                else
                {
                    MessageBox.Show("Pokemon stats have not been loaded successfully.");
                }
            }
            else
            {
                MessageBox.Show("You can choose up to three Pokémon.");
            }

        }
        private void BtnMachamp_Click(object sender, EventArgs e)
        {
            if (pokemonSelected < 3)
            {
                if (pokemons.Count > 0)
                {
                    Pokemon pokemonMachamp = pokemons.Find(p => p.pokemonName == "Machamp");
                    if (pokemonMachamp != null)
                    {
                        btnMachamp.Enabled = false;
                        pokemonSelected++;
                        pokemonIndex++;
                        selectedPokemons.Add(pokemonMachamp);
                    }
                    else
                    {
                        MessageBox.Show("Machamp could not be found.");
                    }
                }
                else
                {
                    MessageBox.Show("Pokemon stats have not been loaded successfully.");
                }
            }
            else
            {
                MessageBox.Show("You can choose up to three Pokémon.");
            }

        }
        private void BtnCharizard_Click(object sender, EventArgs e)
        {
            if (pokemonSelected < 3)
            {
                if (pokemons.Count > 0)
                {
                    Pokemon pokemonCharizard = pokemons.Find(p => p.pokemonName == "Charizard");
                    if (pokemonCharizard != null)
                    {
                        //MessageBox.Show($"Valittu Pokemon: {pokemonCharizard.pokemonName}");
                        btnCharizard.Enabled = false;
                        pokemonSelected++;
                        pokemonIndex++;
                        selectedPokemons.Add(pokemonCharizard);
                    }
                    else
                    {
                        MessageBox.Show("Charizard could not be found.");
                    }
                }
                else
                {
                    MessageBox.Show("Pokemon stats have not been loaded successfully.");
                }
            }
            else
            {
                MessageBox.Show("You can choose up to three Pokémon.");
            }

        }
        private void BtnZapdos_Click(object sender, EventArgs e)
        {
            if (pokemonSelected < 3)
            {
                if (pokemons.Count > 0)
                {
                    Pokemon pokemonZapdos = pokemons.Find(p => p.pokemonName == "Zapdos");
                    if (pokemonZapdos != null)
                    {
                        //MessageBox.Show($"Valittu Pokemon: {pokemonZapdos.pokemonName}");
                        btnZapdos.Enabled = false;
                        pokemonSelected++;
                        pokemonIndex++;
                        selectedPokemons.Add(pokemonZapdos);
                    }
                    else
                    {
                        MessageBox.Show("Zapdos could not be found.");
                    }
                }
                else
                {
                    MessageBox.Show("Pokemon stats have not been loaded successfully.");
                }

            }
            else
            {
                MessageBox.Show("You can choose up to three Pokémon.");
            }
        }
        private void BtnSnorlax_Click(object sender, EventArgs e)
        {
            if (pokemonSelected < 3)
            {
                if (pokemons.Count > 0)
                {
                    Pokemon pokemonSnorlax = pokemons.Find(p => p.pokemonName == "Snorlax");
                    if (pokemonSnorlax != null)
                    {
                        //MessageBox.Show($"Valittu Pokemon: {pokemonSnorlax.pokemonName}");
                        btnSnorlax.Enabled = false;
                        pokemonSelected++;
                        pokemonIndex++;
                        selectedPokemons.Add(pokemonSnorlax);
                    }
                    else
                    {
                        MessageBox.Show("Snorlax could not be found.");
                    }
                }
                else
                {
                    MessageBox.Show("Pokemon stats have not been loaded successfully.");
                }
            }
            else
            {
                MessageBox.Show("You can choose up to three Pokémon.");
            }
        }
        private void BtnGengar_Click(object sender, EventArgs e)
        {
            if (pokemonSelected < 3)
            {
                if (pokemons.Count > 0)
                {
                    Pokemon pokemonGengar = pokemons.Find(p => p.pokemonName == "Gengar");
                    if (pokemonGengar != null)
                    {
                        //MessageBox.Show($"Valittu Pokemon: {pokemonGengar.pokemonName}");
                        btnGengar.Enabled = false;
                        pokemonSelected++;
                        pokemonIndex++;
                        selectedPokemons.Add(pokemonGengar);
                    }
                    else
                    {
                        MessageBox.Show("Gengar could not be found.");
                    }
                }
                else
                {
                    MessageBox.Show("Pokemon stats have not been loaded successfully.");
                }
            }
            else
            {
                MessageBox.Show("You can choose up to three Pokémon.");
            }
        }

        public string GetSelectedPokemonImageFileName()
        {
            if (selectedPokemons.Count > 0)
            {
                return selectedPokemons[0].ImageFileName;
            }
            return null;
        }

        private void BtnStartGame_Click(object sender, EventArgs e)
        {
            if (pokemonSelected == 3)
            {
                enemyPokemons = pokemons.Except(selectedPokemons).ToList();

                if(enemyPokemons.Count >= 3)
                {
                    string selectedPokemonImageFileName = GetSelectedPokemonImageFileName();
                    Battle BattleScreen = new Battle(selectedPokemons, selectedPokemonImageFileName, enemyPokemons);
                    
                    BattleScreen.ShowDialog();                 
                    this.Close();
                    BattleScreen.Close();
                    
                }
              
            }
            else
            {
                MessageBox.Show("Choose three Pokémon to start the game.");
            }
            

        }

        private void SelectPokemon_Load_1(object sender, EventArgs e)
        {
            const string path = @"C:\pokemon\pokemonStats.txt";
            ImportPokemonStats(path);


        }

        private void BtnGyarados_MouseHover(object sender, EventArgs e)
        {
            lblHover.Text = "Current Pokémon: Gyarados";
            lblStats.Text = $"Type: Water, Flying, HP: 95, ATK: 125, DEF: 79, SPD: 81";
        }

        private void btnCharizard_MouseHover(object sender, EventArgs e)
        {
            lblHover.Text = "Current Pokémon: Charizard";
            lblStats.Text = "Type: Fire, Flying, HP: 78, ATK: 84, DEF: 78, SPD: 100";
        }

        private void BtnZapdos_MouseHover(object sender, EventArgs e)
        {
            lblHover.Text = "Current Pokémon: Zapdos";
            lblStats.Text = "Type: Electric, Flying, HP: 90, ATK: 90, DEF: 85, SPD: 100";
        }

        private void BtnSnorlax_MouseHover(object sender, EventArgs e)
        {
            lblHover.Text = "Current Pokémon: Snorlax";
            lblStats.Text = "Type: Normal, HP: 160, ATK 110, DEF: 65, SPD: 30";
        }

        private void BtnGengar_MouseHover(object sender, EventArgs e)
        {
            lblHover.Text = "Current Pokémon: Gengar";
            lblStats.Text = "Type: Ghost, Poison, HP: 60, ATK: 65, DEF: 60, SPD: 110";
        }

        private void BtnMachamp_MouseHover(object sender, EventArgs e)
        {
            lblHover.Text = "Current Pokémon: Machamp";
            lblStats.Text = "Type: Fighting, HP: 90, ATK: 130, DEF: 80, SPD: 55";
        }

        private void SelectPokemon_MouseHover(object sender, EventArgs e)
        {
            lblHover.Text = "";
            lblStats.Text = "";
        }

        private void BtnStartGame_MouseHover(object sender, EventArgs e)
        {
            lblHover.Text = "Start the Game!";
            lblStats.Text = "";
        }

        private void LblStats_MouseHover(object sender, EventArgs e)
        {
            lblHover.Text = "";
            lblStats.Text = "";
        }

        private void LblHover_MouseHover(object sender, EventArgs e)
        {
            lblHover.Text = "";
            lblStats.Text = "";
        }

        private void Label1_MouseHover(object sender, EventArgs e)
        {
            lblHover.Text = "";
            lblStats.Text = "";
        }
    }


    public class Pokemon  
    {
        
        public string ImageFileName { get; set; }

        public string pokemonName;
        public int pokemonHealth;
        public string pokemonType;
        public string pokemonType2;
        public int defense;
        public int attack;
        public int speed;
        public int index;
        public int pokemonStartHealth;
        public string move1;
        public string move2;
        public string move3;
        public string move4;
        public int move1Damage;
        public int move2Damage;
        public int move3Damage;
        public int move4Damage;
        public bool pokemonParalyzed;
        public bool pokemonConfused;
        public bool pokemonCriticalHit;
        public bool pokemonFlinch;
        public bool pokemonBurning;
        public bool pokemonSleeping;
        public int startMove1Damage;
        public int startMove2Damage;
        public int startMove3Damage;
        public int startMove4Damage;
        public int specialAttack;
        public int specialDefence;
        public int startDefence;
        public int startSpecialAttack;
        public int startSpecialDefence;

        public Pokemon(string pokemonName, string pokemonType, string pokemonType2, int pokemonHealth, int attack, int defense, int speed, int index, string imageFile, int pokemonStartHealth, string move1, string move2, string move3, string move4, int move1Damage, int move2Damage, int move3Damage, int move4Damage, bool pokemonParalyzed, bool pokemonConfused, bool pokemonCriticalHit, bool pokemonFlinch, bool pokemonBurning, bool pokemonSleeping, int startMove1Damage, int startMove2Damage, int startMove3Damage, int startMove4Damage, int specialAttack, int specialDefence, int startDefence, int startSpecialAttack, int startSpecialDefence)
        {
            this.pokemonName = pokemonName;
            this.pokemonHealth = pokemonHealth;
            this.pokemonType = pokemonType;
            this.pokemonType2 = pokemonType2;
            this.defense = defense;
            this.attack = attack;
            this.speed = speed;
            this.index = index;
            this.ImageFileName = imageFile;
            this.pokemonStartHealth = pokemonStartHealth;
            this.move1 = move1;
            this.move2 = move2;
            this.move3 = move3;
            this.move4 = move4;
            this.move1Damage = move1Damage;
            this.move2Damage = move2Damage;
            this.move3Damage = move3Damage;
            this.move4Damage = move4Damage;
            this.pokemonParalyzed = pokemonParalyzed;
            this.pokemonConfused = pokemonConfused;
            this.pokemonCriticalHit = pokemonCriticalHit;
            this.pokemonFlinch = pokemonFlinch;
            this.pokemonBurning = pokemonBurning;
            this.pokemonSleeping = pokemonSleeping;
            this.startMove1Damage = startMove1Damage;
            this.startMove2Damage = startMove2Damage;
            this.startMove3Damage = startMove3Damage;
            this.startMove4Damage = startMove4Damage;
            this.specialAttack = specialAttack;
            this.specialDefence = specialDefence;
            this.startDefence = startDefence;
            this.startSpecialAttack = startSpecialAttack;
            this.startSpecialDefence = startSpecialDefence;
       
        }

    }
   


}
