﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

namespace pokemon
{
    public partial class SelectPokemon : Form
    {
        private List<Pokemon> pokemons;
        private List<Pokemon> selectedPokemons = new List<Pokemon>();

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
                            MessageBox.Show("Virheellinen tietomuoto tiedostossa");
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
                        MessageBox.Show($"Valittu Pokemon: {pokemonGyarados.pokemonName}");
                        btnGyarados.Enabled = false;
                        pokemonSelected++;
                        pokemonIndex++;
                        selectedPokemons.Add(pokemonGyarados);
                        LoadImageForSelectedPokemon($"C:/pokemon/Pokemon-master/pictures/gyarados.png");
                    }
                    else
                    {
                        MessageBox.Show("Gyarados ei löytynyt.");
                    }
                }
                else
                {
                    MessageBox.Show("Pokemon-statistiikat eivät ole ladattu onnistuneesti.");
                }
            }
            else
            {
                MessageBox.Show("Voit valita enintään kolme Pokemonia");
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
                        MessageBox.Show($"Valittu Pokemon: {pokemonMachamp.pokemonName}");
                        btnMachamp.Enabled = false;
                        pokemonSelected++;
                        pokemonIndex++;
                        selectedPokemons.Add(pokemonMachamp);
                    }
                    else
                    {
                        MessageBox.Show("Machamp ei löytynyt.");
                    }
                }
                else
                {
                    MessageBox.Show("Pokemon-statistiikat eivät ole ladattu onnistuneesti.");
                }
            }
            else
            {
                MessageBox.Show("Voit valita enintään kolme Pokemonia");
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
                        MessageBox.Show($"Valittu Pokemon: {pokemonCharizard.pokemonName}");
                        btnCharizard.Enabled = false;
                        pokemonSelected++;
                        pokemonIndex++;
                        selectedPokemons.Add(pokemonCharizard);
                    }
                    else
                    {
                        MessageBox.Show("Charizardia ei löytynyt.");
                    }
                }
                else
                {
                    MessageBox.Show("Pokemon-statistiikat eivät ole ladattu onnistuneesti.");
                }
            }
            else
            {
                MessageBox.Show("Voit valita enintään kolme Pokemonia");
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
                        MessageBox.Show($"Valittu Pokemon: {pokemonZapdos.pokemonName}");
                        btnZapdos.Enabled = false;
                        pokemonSelected++;
                        pokemonIndex++;
                        selectedPokemons.Add(pokemonZapdos);
                    }
                    else
                    {
                        MessageBox.Show("Zapdosia ei löytynyt.");
                    }
                }
                else
                {
                    MessageBox.Show("Pokemon-statistiikat eivät ole ladattu onnistuneesti.");
                }

            }
            else
            {
                MessageBox.Show("Voit valita enintään kolme Pokemonia");
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
                        MessageBox.Show($"Valittu Pokemon: {pokemonSnorlax.pokemonName}");
                        btnSnorlax.Enabled = false;
                        pokemonSelected++;
                        pokemonIndex++;
                        selectedPokemons.Add(pokemonSnorlax);
                    }
                    else
                    {
                        MessageBox.Show("Snorlax ei löytynyt.");
                    }
                }
                else
                {
                    MessageBox.Show("Pokemon-statistiikat eivät ole ladattu onnistuneesti.");
                }
            }
            else
            {
                MessageBox.Show("Voit valita enintään kolme Pokemonia");
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
                        MessageBox.Show($"Valittu Pokemon: {pokemonGengar.pokemonName}");
                        btnGengar.Enabled = false;
                        pokemonSelected++;
                        pokemonIndex++;
                        selectedPokemons.Add(pokemonGengar);
                    }
                    else
                    {
                        MessageBox.Show("Gengar ei löytynyt.");
                    }
                }
                else
                {
                    MessageBox.Show("Pokemon-statistiikat eivät ole ladattu onnistuneesti.");
                }
            }
            else
            {
                MessageBox.Show("Voit valita enintään kolme Pokemonia");
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
                MessageBox.Show("Starting game");
                string selectedPokemonImageFileName = GetSelectedPokemonImageFileName();
                Battle BattleScreen = new Battle(selectedPokemons, selectedPokemonImageFileName);
                BattleScreen.ShowDialog();
                this.Close();
                BattleScreen.Close();
            }
            else
            {
                MessageBox.Show("Valitse kolme Pokemonia niin voit aloittaa pelin");
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
