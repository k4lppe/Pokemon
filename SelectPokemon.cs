using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using System.Linq;

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
                        if (stats.Length == 10)
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
                                int.Parse(stats[9].Trim()) //starting health
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

        private void btnGyarados_Click(object sender, EventArgs e)
        {
            if (pokemonSelected < 3)
            {
                if (pokemons.Count > 0)
                {
                    Pokemon pokemonGyarados = pokemons.Find(p => p.pokemonName == "Gyarados");
                    if (pokemonGyarados != null)
                    {
                        //MessageBox.Show($"Valittu Pokemon: {pokemonGyarados.pokemonName}");
                        btnGyarados.Enabled = false;
                        pokemonSelected++;
                        pokemonIndex++;
                        selectedPokemons.Add(pokemonGyarados);
                       
                        LoadImageForSelectedPokemon($"C:/pokemon/Pokemon-master/pictures/gyarados.png");
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
        private void btnMachamp_Click(object sender, EventArgs e)
        {
            if (pokemonSelected < 3)
            {
                if (pokemons.Count > 0)
                {
                    Pokemon pokemonMachamp = pokemons.Find(p => p.pokemonName == "Machamp");
                    if (pokemonMachamp != null)
                    {
                        //MessageBox.Show($"Valittu Pokemon: {pokemonMachamp.pokemonName}");
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
        private void btnCharizard_Click(object sender, EventArgs e)
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
        private void btnZapdos_Click(object sender, EventArgs e)
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
        private void btnSnorlax_Click(object sender, EventArgs e)
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
        private void btnGengar_Click(object sender, EventArgs e)
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

        private void btnStartGame_Click(object sender, EventArgs e)
        {         
            if (pokemonSelected == 3)
            {
                enemyPokemons = pokemons.Except(selectedPokemons).ToList();

                if(enemyPokemons.Count >= 3)
                {
                    MessageBox.Show("Starting game");

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
        private void LoadImageForSelectedPokemon(string imageFileName)
        {
         
        }

        private void SelectPokemon_Load_1(object sender, EventArgs e)
        {
            const string path = @"C:\pokemon\Pokemon-master\pokemonStats.txt";
            ImportPokemonStats(path);


        }

        private void btnGyarados_MouseHover(object sender, EventArgs e)
        {
            lblHover.Text = "Current Pokémon: Gyarados";
            lblStats.Text = $"Type: Water, Flying, HP: 95, ATK: 125, DEF: 79, SPD: 81";
        }

        private void btnCharizard_MouseHover(object sender, EventArgs e)
        {
            lblHover.Text = "Current Pokémon: Charizard";
            lblStats.Text = "Type: Fire, Flying, HP: 78, ATK: 84, DEF: 78, SPD: 100";
        }

        private void btnZapdos_MouseHover(object sender, EventArgs e)
        {
            lblHover.Text = "Current Pokémon: Zapdos";
            lblStats.Text = "Type: Electric, Flying, HP: 90, ATK: 90, DEF: 85, SPD: 100";
        }

        private void btnSnorlax_MouseHover(object sender, EventArgs e)
        {
            lblHover.Text = "Current Pokémon: Snorlax";
            lblStats.Text = "Type: Normal, HP: 160, ATK 110, DEF: 65, SPD: 30";
        }

        private void btnGengar_MouseHover(object sender, EventArgs e)
        {
            lblHover.Text = "Current Pokémon: Gengar";
            lblStats.Text = "Type: Ghost, Poison, HP: 60, ATK: 65, DEF: 60, SPD: 110";
        }

        private void btnMachamp_MouseHover(object sender, EventArgs e)
        {
            lblHover.Text = "Current Pokémon: Machamp";
            lblStats.Text = "Type: Fighting, HP: 90, ATK: 130, DEF: 80, \nSPD: 55";
        }

        private void SelectPokemon_MouseHover(object sender, EventArgs e)
        {
            lblHover.Text = "";
            lblStats.Text = "";
        }

        private void btnStartGame_MouseHover(object sender, EventArgs e)
        {
            lblHover.Text = "Start the Game!";
            lblStats.Text = "";
        }

        private void lblStats_MouseHover(object sender, EventArgs e)
        {
            lblHover.Text = "";
            lblStats.Text = "";
        }

        private void lblHover_MouseHover(object sender, EventArgs e)
        {
            lblHover.Text = "";
            lblStats.Text = "";
        }

        private void label1_MouseHover(object sender, EventArgs e)
        {
            lblHover.Text = "";
            lblStats.Text = "";
        }
    }


    public class Pokemon : IEquatable<Pokemon>
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

        public bool Equals(Pokemon other)
        {
            return this.pokemonName.Equals(other.pokemonName, StringComparison.OrdinalIgnoreCase);
        }

        public Pokemon(string pokemonName, string pokemonType, string pokemonType2, int pokemonHealth, int attack, int defense, int speed, int index, string imageFile, int pokemonStartHealth)
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
        }

    }
   


}
