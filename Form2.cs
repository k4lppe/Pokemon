using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace pokemon
{
    public partial class Battle : Form
    {
        private List<Pokemon> selectedPokemons;
        private string selectedPokemonImageFileName;

        public Battle(List<Pokemon> selectedPokemons, string selectedPokemonImageName)
        {
            InitializeComponent();
            this.selectedPokemons = selectedPokemons;
            this.selectedPokemonImageFileName = selectedPokemonImageName;

            if (selectedPokemons.Count > 0)
            {
                string imageFileName = @"C:\pokemon\Pokemon-master\pictures\" + selectedPokemons[0].ImageFileName + ".png";
                LoadImageForSelectedPokemon(imageFileName);
            }
        }

        private void LoadImageForSelectedPokemon(string imageFileName)
        {
            try
            {
                if (!string.IsNullOrEmpty(imageFileName) && System.IO.File.Exists(imageFileName))
                {
                    pictureBox1.ImageLocation = imageFileName;
                }
                else
                {
                    pictureBox1.Image = null;
                }
            }
            catch(Exception e)
            {
                MessageBox.Show($"Virhe kuvan lataamisessa: {e.Message}");
            }
        }

        private void ChangePictureBoxImage(string imageName)
        {
            string imagePath = Path.Combine(Application.StartupPath, "pictures", imageName + ".png");

            if(File.Exists(imagePath))
            {
                pictureBox1.Image = Image.FromFile(imagePath);
            }
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            lblPlayerPokemonName.Text = $"{selectedPokemons[0].pokemonName}";
            lblPlayerPokemonHealth.Text = $"{selectedPokemons[0].pokemonHealth}/{selectedPokemons[0].pokemonStartHealth}";
            playerPokemonHealthBar.Minimum = 0;
            playerPokemonHealthBar.Maximum = selectedPokemons[0].pokemonHealth;
            playerPokemonHealthBar.Value = selectedPokemons[0].pokemonHealth;
            
        }

        private void label1_Click(object sender, EventArgs e)
        {  
            lblText.Text = $"Valittu Pokemon: {selectedPokemons[0].pokemonName}\nValittu Pokemon: {selectedPokemons[1].pokemonName}\nValittu Pokemon: {selectedPokemons[2].pokemonName}";

        }
       

        private void btnDamage_Click(object sender, EventArgs e)
        {
            selectedPokemons[0].pokemonHealth = selectedPokemons[0].pokemonHealth - 10;
            lblPlayerPokemonHealth.Text = $"{selectedPokemons[0].pokemonHealth}/{selectedPokemons[0].pokemonStartHealth}";
          
        }

        private void btnHeal_Click(object sender, EventArgs e)
        {
            selectedPokemons[0].pokemonHealth = selectedPokemons[0].pokemonHealth + 10;
            lblPlayerPokemonHealth.Text = $"{selectedPokemons[0].pokemonHealth}/{selectedPokemons[0].pokemonStartHealth}";
        }
    }
}
