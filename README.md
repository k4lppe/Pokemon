# Pokemonpeli

## Toiminta ja käyttötarkoitus

Tämä projekti on C#-ohjelmointi näyttötehtävä

Peli perustuu perinteiseen Pokémon taisteluun, missä kaksi eri Pokémonia taistelevat kahdestaan, käyttäjä tietokonetta vastaan. Pelin käynnistyttyä käyttäjä valitsee kolme Pokémonia kuudesta vaihtoehdosta, sitten painaa "Start". Vastustaja saa ne kolme Pokémonia mitä et valinnut. Peli lataa uuden ikkunan jossa taistelu alkaa. Uuden Battle ikkunan oikealla puolella valitsemasi Pokémonin nimen ja elämäpisteet. Elämäpisteet näkyvät vihreänä palkkina ja lukuna. Ruudun vasemmassa yläreunassa on vastustajasi Pokémonin nimi ja elämäpisteet. Ruudun oikeassa alakulmassa on kaksi nappia "Fight" ja "Bag". Fight napista avaat Pokémonin liikevalikon, sieltä valitset neljästä eri vaihtoehdosta minkä liikkeen käytät. Pitämällä hiirtä jonkun liikkeen päällä avaa tietoruudun jossa kerrotaan tarkemmin mitä liike tekee. Bag napista avaat Pokémonin parannusesinevalikon, siellä on neljä eri parannusvälinettä Potions, Super Potions, Hyper Potions ja Lum berries. Pitämällä hiirtä niiden päällä kertoo miten ne parantavat Pokémonia. Kun olet valinnut liikkeen, Pokémon käyttää sen ja tekee vastustajan Pokémoniin vahinkoa, parantaa itsensä tilastoja, huonontaa vastustajan tilastoja tai antaa viholliselle tilavaikutuksen (status condition). Tilavaikutuksia ovat palaminen, nukkuminen, hämmennys ja halvaus. Palamisella menetät joka kierros pienen määrän elämäpisteitä hyökkäyksesi jälkeen ja fyysisten iskujesi vahinko puolittuu, sen voi parantaa vain Lum Berryllä. Nukkumisella Pokémonisi nukahtaa ja ei voi hyökätä kunnes se herää, Pokémon herää antamalla sille Lum Berry tai 1-7 vuoron päästä automaattisesti. Hämmennyksessä on 50% mahdollisuus että Pokémon hyökkää itseensä, sen voi parantaa Lum Berryllä tai 2-4 vuoron päästä automaattisesti. Jos Pokémon on halvaantunut, on 25% mahdollisuus, että se ei hyökkää, sen voi parantaa Lum Berryllä tai 2-4 vuoron päästä automaattisesti. Hyökkäyksen jälkeen on vastustajan vuoro, ja se hyökkää ja voi aiheuttaa samat tilavaikutukset. Vastustaja voi myös parantaa Pokémonia. Pelin voittaa jos kukistaa kaikki vastustajan Pokémonit ja häviää jos vastustaja kukistaa käyttäjän kaikki Pokémonit.

## Vuokaavio pelistä

![pokemonvuokaavio](https://github.com/k4lppe/Pokemon/assets/151001970/9098b151-f4fd-4a84-a5bf-6b83d9081bd3)


## Kuvakaappauksia pelistä

![alt Kuvakaappaus Pokemonin valitsemis ruudusta](https://github.com/k4lppe/Pokemon/assets/151001970/52b8dc56-993e-40fd-932d-ed2d247875d3)

![Battle kuva 1](https://github.com/k4lppe/Pokemon/assets/151001970/fe90812e-e65f-4a08-a9a6-c556176945af)

![Battle kuva 2](https://github.com/k4lppe/Pokemon/assets/151001970/ff40affa-542f-4f1e-bd7f-387442304762)

![Battle kuva 3](https://github.com/k4lppe/Pokemon/assets/151001970/a575cc85-f721-4bb2-b172-e2ac3036b492)

![Battle kuva 4](https://github.com/k4lppe/Pokemon/assets/151001970/d4ea66d3-962e-4d04-a0c8-097a540b45b0)

![Battle kuva 5](https://github.com/k4lppe/Pokemon/assets/151001970/361ff036-327d-49b5-8db2-91c140b447ec)

![Battle kuva 6](https://github.com/k4lppe/Pokemon/assets/151001970/8ab2c7d5-225c-4400-a6da-7825822c4435)

![Battle kuva 7](https://github.com/k4lppe/Pokemon/assets/151001970/62e01254-52fe-415c-84de-7bd1daec468f)

![FinalSummary](https://github.com/k4lppe/Pokemon/assets/151001970/692a5d14-2806-4525-a397-e5e89adbd9c0)

## Koodin esittely
Koodi lukee ulkoisesta tiedostosta pokemonien tilastot ja luo niille objektin pokemon luokkaan.
![Koodi1](https://github.com/k4lppe/Pokemon/assets/151001970/801f5fee-70a5-47d6-8589-d63e48c4850f)
![stats](https://github.com/k4lppe/Pokemon/assets/151001970/a8e3dd1c-5075-485b-89f0-b8f9bb0597e4)

Pokemon luokka, joka määrittelee mitä muuttujia pokemon objektille pitää antaa.
![koodi2](https://github.com/k4lppe/Pokemon/assets/151001970/28fdf405-2951-4c2e-9a21-bab400e0b7d2)
Pokemonin fyysisten iskujen vahingonlaskukaava
![koodi3](https://github.com/k4lppe/Pokemon/assets/151001970/63c81927-1207-4927-b926-a0d5ec5fc47a)
Pokemonin erikois iskujen vahingonlaskukaava
![koodi4](https://github.com/k4lppe/Pokemon/assets/151001970/ec750982-83ef-4c50-a639-4ff365514cc9)

Koodi kun valitaan pokemonin ensimmäinen hyökkäysliike. Ensin varmistetaan että on pelaajan vuoro. Sitten tarkistetaan flinch, eli säpsähdys, jotkut liikkeet voivat aiheuttaa sitä, jos säpsähdys on totta niin pokemon ei voi sillä vuorolla hyökätä. Sitten tarkistetaan tilavaikutukset. Paralysis eli halvaannuus. Siinä on yksi neljästä mahdollisuus, että pokemon ei voi liikkua, tarkistetaan myös palaako pokemon, jos se palaa sen elämäpisteistä vähennetään kahdeksasosa. Nukkumisessa sama juttu kuin säpsähdyksessä että ei voi hyökätä jos nukkuu. lopuksi tarkastetaan hämmennys. Ylempänä arvottiin yksi kolmesta mahdollisuus, että pokemon satuttaa itseään. Koodissa kutsutaan myös paljon funktioita, MoveDelayStart käynnistää viiveen vihollisen vuoron alkamiselle. PlayerPokemonFaints tarkistaa onko pokemonin elämäpisteet 0, jos on niin se vaihtaa pokemonin uuteen. UpdateProgressBar päivittää pokemonin elämäpalkin. await Task.Delay() luo pienen viiveen koodin välille niin pelaaja ehtii lukea tekstin mikä lukee ruudulla.
![koodi5](https://github.com/k4lppe/Pokemon/assets/151001970/a957cca4-ddd9-4cf8-88c3-86603d4e8351)
Tämä on samaa funktiota missä valittiin hyökkäysliike 1. Käytössä on switch ehtorakenne ja sillä verrataan tämänhetkisen pokemonin ensimmäistä liikettä. Caset on merkitty pokemonien liikkeiden nimellä.
![koodi6](https://github.com/k4lppe/Pokemon/assets/151001970/66bbf79e-e18a-4521-87a1-2e8120d58603)

## Jatkokehitysideat

- Uusien Pokemonien lisääminen
- Pokemon vaihtaminen kesken pelin
- Jonkinlainen erikoisisku jos vaikka on tehnyt tietyn määrän vahinkoa viholliseen
- Mahdollisuus valita 6 pokemonia 3 sijasta
- Lisää tilavaikutuksia
- Lisää pokemonin parannusvälineitä
  
