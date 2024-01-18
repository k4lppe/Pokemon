# Pokemonpeli

## Toiminta ja käyttötarkoitus

Tämä projekti on C#-ohjelmointi näyttötehtävä

Peli perustuu perinteiseen Pokémon taisteluun, missä kaksi eri Pokémonia taistelevat kahdestaan, käyttäjä tietokonetta vastaan. Pelin käynnistyttyä käyttäjä valitsee kolme Pokémonia kuudesta vaihtoehdosta, sitten painaa "Start". Vastustaja saa ne kolme Pokémonia mitä et valinnut. 
Peli lataa uuden ikkunan jossa taistelu alkaa. Uuden Battle ikkunan oikealla puolella valitsemasi Pokémonin nimen ja elämäpisteet. Elämäpisteet näkyvät vihreänä palkkina ja lukuna. Ruudun vasemmassa yläreunassa on vastustajasi Pokémonin nimi ja elämäpisteet. Ruudun oikeassa alakulmassa on kaksi nappia "Fight" ja "Bag". Fight napista avaat Pokémonin liikevalikon, sieltä valitset neljästä eri vaihtoehdosta minkä liikkeen käytät. Pitämällä hiirtä jonkun liikkeen päällä avaa tietoruudun jossa kerrotaan tarkemmin mitä liike tekee. Bag napista avaat Pokémonin parannusesinevalikon, siellä on neljä eri parannusvälinettä Potions, Super Potions, Hyper Potions ja Lum berries. Pitämällä hiirtä niiden päällä kertoo miten ne parantavat Pokémonia. 
Kun olet valinnut liikkeen, Pokémon käyttää sen ja tekee vastustajan Pokémoniin vahinkoa, parantaa itsensä tilastoja, huonontaa vastustajan tilastoja tai antaa viholliselle tilavaikutuksen (status condition). Tilavaikutuksia ovat palaminen, nukkuminen, hämmennys ja halvaus. 
Palamisella menetät joka kierros pienen määrän elämäpisteitä hyökkäyksesi jälkeen ja fyysisten iskujesi vahinko puolittuu, sen voi parantaa vain Lum Berryllä. 
Nukkumisella Pokémonisi nukahtaa ja ei voi hyökätä kunnes se herää, Pokémon herää antamalla sille Lum Berry tai 1-7 vuoron päästä automaattisesti. 
Hämmennyksessä on 50% mahdollisuus että Pokémon hyökkää itseensä, sen voi parantaa Lum Berryllä tai 2-4 vuoron päästä automaattisesti. 
Jos Pokémon on halvaantunut, on 25% mahdollisuus, että se ei hyökkää, sen voi parantaa Lum Berryllä tai 2-4 vuoron päästä automaattisesti. 
Hyökkäyksen jälkeen on vastustajan vuoro, ja se hyökkää ja voi aiheuttaa samat tilavaikutukset. Vastustaja voi myös parantaa Pokémonia. Pelin voittaa jos kukistaa kaikki vastustajan Pokémonit ja häviää jos vastustaja kukistaa käyttäjän kaikki Pokémonit.
