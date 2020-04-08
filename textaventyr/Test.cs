using System;
using System.Collections.Generic;
using System.Linq;

namespace textaventyr
{
    class main
    {
        static void Main(string[] args)
        {

            Player mainSpelare = new Player();


            while (true)
            {
                startGame(mainSpelare);
            }
        }

        public const int easy = 1;
        public const int normal = 2;

        private enum Raser { Alv = 8, Människa = 12, Dvärg = 16 }
        private static void startGame(Player spelare)
        {

            Console.WriteLine("Välkommen till det här spelet");
            Console.WriteLine("Målet med spelet är att besegra det sista monstret");
            Console.WriteLine("Var uppmärksam!, under vägen dit kan det dyka upp mindre monster som utgör en fara för dig");
            Console.WriteLine("Spelet varierar beroende på vilket alternativ du väljer");

            lineDivider();
            Console.WriteLine("Vilken svårighetsgrad vill du köra på? \n1. Easy \n2. Normal");

            int svarighetsgrad;
            while (!int.TryParse(Console.ReadLine(), out svarighetsgrad))
            {
                Console.WriteLine("Felaktigt svar\nVälj en svårighetsgrad");
            }


            
            Console.WriteLine("Vad är ditt namn?");
            string name = Console.ReadLine();
            while (name.Length <= 0)
            {
                Console.WriteLine("Du måste ha ett namn");
                name = Console.ReadLine();
            }
            Console.Clear();
            Console.WriteLine("Hejsan " + name);
            Console.WriteLine("Välkommen till spelet");

            //itererar alla raser
            lineDivider();
            Console.WriteLine("Välj en ras, även om alverna har minst hp vet man aldrig vad dom har för tricks.");

            int counter = 1;
            foreach (Raser eRas in Enum.GetValues(typeof(Raser)))
            {
                Console.WriteLine($"{counter}. {eRas} ({eRas.GetHashCode()} extra i hp)");
                counter++;
            }

            int ras;
            while (!int.TryParse(Console.ReadLine(), out ras) || (ras <= 0) || (ras >= 4))
            {
                Console.WriteLine("Felaktigt svar\nVälj en ras");
            }
            switch (ras)
            {
                case 1:
                    spelare.ras = Raser.Alv.ToString();
                    spelare.name = name;
                    spelare.health = Raser.Alv.GetHashCode();
                    spelare.atk = 4;
                    break;
                case 2:
                    spelare.ras = Raser.Människa.ToString();
                    spelare.name = name;
                    spelare.health = Raser.Människa.GetHashCode();
                    spelare.atk = 3;
                    break;

                case 3:
                    spelare.ras = Raser.Dvärg.ToString();
                    spelare.name = name;
                    spelare.health = Raser.Dvärg.GetHashCode();
                    spelare.atk = 2;
                    break;
            }
            Console.Clear();
            Console.WriteLine($"Ditt namn är {spelare.name} och du är en {spelare.ras}");
            Console.WriteLine("Du har " + spelare.health + " liv och " + spelare.atk + " Attack som en " + spelare.ras);
            Console.WriteLine("\nDu vaknar upp efter en tids medvetslöshet. Du är skadad och är mitt på ett öppet fält men inget minne av hur du kom hit.");
            Console.WriteLine("Du verkar ha förlorat alla vapen och utrustning du hade förut, det enda du har kvar är slitna kläder och en tom ryggsäck");
            Console.WriteLine("Tryck på valfri knapp för att gå vidare i ditt äventyr");
            Console.ReadKey();
            lineDivider();

            Console.WriteLine("Efter en tids vandrande utan något annat än stora fält och lite skog i sikte ser du ett hus en bit längre fram. \nVäl framme vid huset ser du " +
                "att huset är öde. \b Du kliver in och kollar dig omkring, det verkar övergivet." +
                " Bakom en dörr hittar du ett litet förråd med några vapen");

            lineDivider();
            Console.WriteLine("Välj att ta med ett vapen.");
            Console.WriteLine("1. Yxa");
            Console.WriteLine("2. Svärd");
            Console.WriteLine("3. Pilbåge");
            int val;
            while (!int.TryParse(Console.ReadLine(), out val) || (val <= 0) || (val >= 4))
            {
                Console.WriteLine("Felaktigt svar");
            }

            switch (val)
            {
                case 1:
                    Material item = new Material();
                    item.namn = "Yxa";
                    item.addAtk = 2;
                    spelare.atk += item.addAtk;
                    spelare.vapen = item.namn;
                    Console.Clear();
                    Console.WriteLine($"Du tog med {item.namn}. Den gav dig {item.addAtk} extra i attack\n");
                    Console.WriteLine("Tryck på valfri knapp för att fortsätta");
                    Console.ReadKey();
                    Console.Clear();
                    break;
                case 2:
                    Material item2 = new Material();
                    item2.namn = "Svärd";
                    item2.addAtk = 3;
                    spelare.atk += item2.addAtk;
                    spelare.vapen = item2.namn;
                    Console.Clear();
                    Console.WriteLine($"Du tog med {item2.namn}. Den gav dig {item2.addAtk} extra i attack");
                    Console.WriteLine("Tryck på valfri knapp för att fortsätta");
                    Console.ReadKey();
                    Console.Clear();
                    break;
                case 3:
                    Material item3 = new Material();
                    item3.addAtk = 2;
                    item3.namn = "Pilbåge";
                    spelare.atk += item3.addAtk;
                    spelare.vapen = item3.namn;
                    Console.Clear();
                    Console.WriteLine($"Du tog med {item3.namn}. Den gav dig {item3.addAtk} extra i attack");
                    Console.WriteLine("Tryck på valfri knapp för att fortsätta");
                    Console.ReadKey();
                    Console.Clear();
                    break;
            }
            firstEvent(spelare, svarighetsgrad);
        }

        //Varje event leder till valmöjligheter.
        //Event loopen ser ut på följande sätt
        //firstEvent -> firstEvent val -> secondEvent -> secondEvent val -> thirdEvent -> thirdEvent val osv. tills fifthEvent som har sista bossen
        private static void firstEvent(Player spelare, int svarighetsgrad)
        {
            statusDisplay(spelare);
            lineDivider();
            //Beskrivning
            Console.WriteLine($"Du fortsätter ditt äventyr och lämnar huset du precis var i. Du närmar dig en skog och du ser en liten väg gå igenom skogen. " +
                $"Efter en stunds vandrande delar sig vägen.");

            Console.WriteLine("\n1.Gå vänster \n2.Gå höger \n3.Öppna inventory");


            //input loop så du endast får en int som stämmer överens med antalet switch cases.
            int input;
            while (!int.TryParse(Console.ReadLine(), out input) || (input <= 0) || (input >= 4))
            {
                Console.WriteLine("Felaktigt alternativ");
            }
            //Meny inputs för firstEvent
            switch (input)
            {
                case 1:
                    Console.WriteLine("Du gick vänster");
                    fightEvent(1, spelare, svarighetsgrad);
                    secondEvent(spelare, svarighetsgrad);
                    break;
                case 2:
                    Console.WriteLine("Du gick höger, du ser en övergiven ryggsäck längs vägen, du öppnar den och i den finner du en dryck!");
                    //<-- vidare beskrivning här -->
                    Material item = new Material();
                    item.namn = "Potion of Attack";
                    item.addAtk = 3;
                    item.addHp = 0;
                    spelare.inventory.Add(item);
                    Console.WriteLine($"{item.namn} lades till i ditt inventory");
                    Console.WriteLine("Tryck på valfri knapp för att gå vidare");
                    Console.ReadKey();
                    Console.Clear();
                    secondEvent(spelare, svarighetsgrad);
                    break;
                case 3:
                    Console.Clear();
                    openInventory(spelare, svarighetsgrad);
                    firstEvent(spelare, svarighetsgrad);
                    break;
                default:
                    Console.WriteLine("Du får endast välja 1, 2, 3");
                    break;
            }
        }
        private static void secondEvent(Player spelare, int svarighetsgrad)
        {
            statusDisplay(spelare);
            lineDivider();
            Console.WriteLine("Efter några timmars vandrande kommer du fram till en flod och ser något som glimrar under vattnet, vad vill du göra?");
            lineDivider();
            Console.WriteLine("1. Hoppa ner i floden och kolla vad det är för nått");
            Console.WriteLine("2. Ignorera det som glimrar och gå vidare");
            Console.WriteLine("3. Öppna inventory");

            int input;
            while (!int.TryParse(Console.ReadLine(), out input) || (input <= 0) || (input >= 4))
            {
                Console.WriteLine("Felaktigt svar");
            }
            switch (input)
            {
                case 1:
                    Console.Clear();
                    Console.WriteLine("Du simmade ner och såg att det inte var något annat än en sten. Du kliver up ur vattnet.");
                    fightEvent(2, spelare, svarighetsgrad);
                    thirdEvent(spelare, svarighetsgrad);
                    break;
                case 2:
                    Console.Clear();
                    Material item = new Material();
                    item.namn = "Potion of Health";
                    item.addHp = 4;
                    spelare.inventory.Add(item);
                    Console.WriteLine("Du tar en sista titt på glimret, för att sedan vända dig om och gå vidare. Det tar inte lång tid \n" +
                        "innan du snubblar på något. Du tittar ner på dina fötter och ser att någon har tappat en dryck");
                    Console.WriteLine($"Du fick en {item.namn}.\nTryck för att fortsätta");
                    Console.ReadKey();
                    Console.Clear();
                    thirdEvent(spelare, svarighetsgrad);
                    break;
                case 3:
                    Console.Clear();
                    openInventory(spelare, svarighetsgrad);
                    secondEvent(spelare, svarighetsgrad);
                    break;
            }
        }
        private static void thirdEvent(Player spelare, int svarighetsgrad)
        {
            statusDisplay(spelare);
            lineDivider();
            Console.WriteLine("Du fortsätter på en väg längs floden, skogen öppnar sig lite och du ser en stor vulkan långt bort i horizonten.");
            Console.WriteLine("Du tror dig känna igen vulkanen, det kan vara vulkanen med den onda härskaren.");
            Console.WriteLine("Du följer vägen mot vulkanen, och stöter på en annan man som verkar vara på väg åt samma håll.");
            lineDivider();
            Console.WriteLine("1. Fortsätt gå mot vulkanens riktning och ignorera mannen");
            Console.WriteLine("2. Försök döda mannen och ta allt han har.");
            Console.WriteLine("3. Öppna inventory");

            int input;
            while (!int.TryParse(Console.ReadLine(), out input) || (input <= 0) || (input >= 4))
            {
                Console.WriteLine("Felaktigt svar");
            }

            switch (input)
            {
                case 1:

                    Console.Clear();
                    Console.WriteLine("Du fortsätter din färd mot vulkanen, du slänger en kort blick mot mannen, för att vända dig om och gå vidare.");
                    Console.WriteLine("Tryck på valfri knapp för att gå vidare");
                    Console.ReadKey();
                    Console.Clear();
                    fourthEvent(spelare, svarighetsgrad);
                    break;

                case 2:
                    Console.Clear();
                    statusDisplay(spelare);
                    lineDivider();
                    Console.WriteLine("Du försöker slå mannen");
                    Random rnd = new Random();
                    if (rnd.Next(1, 2) == 1)
                    {
                        Material item = new Material();
                        item.addHp = 8;
                        item.namn = "Potion of Health";

                        Console.WriteLine($"Du lyckades ta dig snabbt fram till honom utan att han märker något. Med hjälp av din {spelare.vapen} har mannen ingen chans");
                        Console.WriteLine($"Det enda han har av värde är en {item.namn} och du tog hans vapen(+5 i attack)");
                        spelare.atk += 5;
                    }
                    else
                    {
                        Console.WriteLine("Precis innan du smyger upp bakom honom vänder han sig om och sätter en pil i ditt knä. Han springer iväg");
                        Console.WriteLine("Du förlorade 5 i liv");
                        if (spelare.health <= 0)
                        {
                            gameOver(spelare);
                        }
                        spelare.health -= 5;
                    }
                    fourthEvent(spelare, svarighetsgrad);
                    break;
                case 3:
                    Console.Clear();
                    openInventory(spelare, svarighetsgrad);
                    thirdEvent(spelare, svarighetsgrad);
                    break;
            }
        }
        private static void fourthEvent(Player spelare, int svarighetsgrad)
        {
            statusDisplay(spelare);
            lineDivider();
            //Beskrvining här
            Console.WriteLine("Du är inte långt ifrån vulkanen nu. Du vandrar över ett stort träsk, leran är upp till knäna och du hör konstiga spökliga ljud.");
            Console.WriteLine("\nDu går över träsken i långsam takt. Väl över träsket ser du att det är 2 leder som går upp mot vulkanens topp");
            lineDivider();
            Console.WriteLine("\n1. Gå till höger");
            Console.WriteLine("2. Gå till vänster");
            Console.WriteLine("3. Öppna inventory");

            //Meny inputs för fourthEvent
            int input;
            while (!int.TryParse(Console.ReadLine(), out input) || (input <= 0) || (input >= 4))
            {
                Console.WriteLine("Felaktigt svar");
            }


            switch (input)
            {
                case 1:
                    Console.Clear();
                    Console.WriteLine("Du gick höger och plötsligt kommer nån bakom dig! Se upp!");
                    fightEvent(3, spelare, svarighetsgrad);
                    fifthEvent(spelare, svarighetsgrad);
                    break;
                case 2:
                    Console.Clear();
                    Console.WriteLine("Du gick vänster, efter en stunds vandrande känner du lukten av rök. Vad kan finnas här uppe på vulkanen? Det är nog bäst att vi kollar.");
                    fifthEvent(spelare, svarighetsgrad);
                    break;
                case 3:
                    Console.Clear();
                    openInventory(spelare, svarighetsgrad);
                    fifthEvent(spelare, svarighetsgrad);
                    break;
            }
        }
        private static void fifthEvent(Player spelare, int svarighetsgrad)
        {
            statusDisplay(spelare);
            lineDivider();
            //Beskrvining här
            Console.WriteLine("Du hör något högt ljud en bit fram, du är nära öppningen av vulkanen.");
            lineDivider();
            Console.WriteLine("\n1. Gå mot vulkan grottan");
            Console.WriteLine("2. Gå hem");
            Console.WriteLine("3. Öppna inventory");

            int input;
            while (!int.TryParse(Console.ReadLine(), out input) || (input <= 0) || (input >= 4))
            {
                Console.WriteLine("Felaktigt svar");
            }
            switch (input)
            {
                case 1:
                    Console.Clear();
                    Console.WriteLine("Du hör dånet av det stora monstret. Dina handflator är svettiga, knäna veka och armarna är tunga.");
                    Console.WriteLine("Tryck på valfri knapp för att gå vidare");
                    Console.ReadKey();
                    Console.Clear();
                    bossEvent(spelare, svarighetsgrad);
                    break;
                case 2:
                    Console.Clear();
                    Console.WriteLine("Du försökte gå hem, men den stora bossen tvingar dig till fighten för annars hade de varit ett dåligt spel");
                    //<-- vidare beskrivning här -->
                    bossEvent(spelare, svarighetsgrad);
                    break;
                case 3:
                    Console.Clear();
                    Console.WriteLine("Öppna inventory");
                    openInventory(spelare, svarighetsgrad);
                    fifthEvent(spelare, svarighetsgrad);
                    break;
            }


            //Meny inputs för fifthEvent
            bossEvent(spelare, svarighetsgrad);
            gameOver(spelare);
        }

        //metod för att avsluta spelet samt ge möjligheten för att starta om spelet.
        //**BEHÖVER ERROR HANDLING**
        private static void gameOver(Player spelare)
        {
            lineDivider();
            Console.WriteLine("Vill du spela igen? \n1. Skriv 1 för att spela igen\n2. Skriv 2 för att avsluta");
            int input;
            while (!int.TryParse(Console.ReadLine(), out input))
            {
                Console.WriteLine("Felaktigt ");
            }
            if (input == 1)
            {
                startGame(spelare);
            }
            else
            {
                Environment.Exit(0);
            }

        }


        private static void specialRaceEvent(Player spelare)
        {
            statusDisplay(spelare);
            lineDivider();
            if (spelare.ras == Raser.Alv.ToString())
            {
                Console.WriteLine($"Du hör en viskning i ditt öra, den säger:\n" +
                    $"psst... {spelare.name}, det är Legolas, låt mig välsigna dig med Alvernas snabbhet." +
                    $" Du fick 5 extra i liv!");
                spelare.health += 7;
            }
            else if (spelare.ras == Raser.Dvärg.ToString())
            {
                Console.WriteLine($"Du hör en röst i ditt öra, den säger:\n" +
                    $"hörru... {spelare.name}, det är Gimli, Kungen av Dvärgriket. Må du svinga ditt vapen med en styrka som motsvarar 10 000 dvärgar!" +
                    $"Du fick 6 extra i attack!");
                spelare.atk += 5;
            }
            else
            {
                Console.WriteLine($"Du hör en röst närma sig, den säger:\n" +
                    $"Var hälsad {spelare.name}. Det är Nicholas Collinus, härskaren av de de 7 rikena, dräparen av den stora draken NetITus." +
                    $"Du kan klara detta, jag tror på dig!" +
                    $"Du fick 3 extra i liv och 3 extra i attack!");
            }
        }

        //Öppnar en spelare inventory som är en <list> som innehåller <Material> klassen.
        private static void openInventory(Player spelare, int svarighetsgrad)
        {
            statusDisplay(spelare);
            lineDivider();
            //Kollar om spelaren har tomt inventory
            if (spelare.inventory.Count == 0)
            {
                Console.WriteLine("Du har inga föremål i ditt inventory");
                Console.WriteLine("Tryck på valfri knapp för att gå vidare.");
                Console.ReadKey();
                Console.Clear();
                lineDivider();
            }
            else
            {
                Console.WriteLine("Skriv siffran på föremålet du vill använda");
                lineDivider();
                //Endast för att iterera över hela inventoryt och visa vad som finns dynamiskt
                int counter = 1;
                foreach (Material item in spelare.inventory)
                {

                    if (item.addHp > 0)
                    {
                        Console.WriteLine($"{counter}: för att använda {item.namn}, den ger dig {item.addHp} extra i hp");
                    }
                    else
                    {
                        Console.WriteLine($"{counter}: för att använda {item.namn}, den ger dig {item.addAtk} extra i attack");
                    }
                    counter++;
                }
                lineDivider();

                //Jämför input value för att kunna konsumera korrekt item med hjälp av en for och if loop. Väldigt lätt att råka göra en offby1 bugg.
                //**BEHÖVER ERROR HANDLING**
                Console.WriteLine("Skriv in 0 för att lämna inventory");
                int input;
                while (!int.TryParse(Console.ReadLine(), out input))
                {
                    Console.WriteLine("Felaktigt alternativ");
                }
                for (int i = 1; i <= spelare.inventory.Count; i++)
                {
                    if (input == i)
                    {
                        Console.Clear();
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine($"Du använde en {spelare.inventory[i - 1].namn}");
                        spelare.inventory[i - 1].bonus(spelare);
                        spelare.inventory.RemoveAt(i - 1);
                        Console.ResetColor();
                        break;
                    }
                    if (input == 0)
                    {
                        Console.Clear();
                        break;
                    }
                }
            }
        }

        private static void bossEvent(Player spelare, int svarighetsgrad)
        {
            //skapa
            Monster boss = new Monster();
            boss.name = "Ceesharpius";
            boss.damage = 5;
            boss.hp = 15 * svarighetsgrad;
            boss.tier = 4;

            bool fight = true;
            Console.WriteLine($"Den ondaste av de alla, härskaren över vulkanen är här. {boss.name}, hoppas du är väl förberedd!");
            specialRaceEvent(spelare);
            lineDivider();
            while (fight)
            {
                if (spelare.health <= 0)
                {
                    fight = false;
                    Console.WriteLine($"Game over, {boss.name} besegrade dig");
                    gameOver(spelare);
                }
                if (boss.hp <= 0)
                {
                    fight = false;
                    Console.Write($"Du besegrade {boss.name}, tryck på valfri knapp för att gå vidare.");
                    gameOver(spelare);
                }
                statusDisplay(spelare);
                monsterDisplay(boss);
                lineDivider();
                Console.WriteLine($"1. Slå {boss.name} med ditt vapen \n2. Försök undvik hans slag \n3. Öppna inventory");
                int input;
                while (!int.TryParse(Console.ReadLine(), out input))
                {
                    Console.WriteLine("Felaktigt alternativ");
                }
                switch (input)
                {
                    case 1:
                        //här sker spellogik som random skada på dig eller skada på monstret
                        Console.Clear();
                        spelare.health -= boss.damage;
                        boss.hp -= spelare.atk;
                        if (boss.hp <= 0)
                        {
                            boss.hp = 0;
                        }
                        if (spelare.health <= 0)
                        {
                            spelare.health = 0;
                        }
                        Console.WriteLine($"Du slog {boss.name} för {spelare.atk} i skada. " +
                        $"\n{boss.name} slog dig för {boss.damage} i skada. Du har {spelare.health} i liv kvar och " +
                        $"{boss.name} har {boss.hp} i liv kvar.");
                        lineDivider();
                        break;
                    case 2:
                        Random rnd = new Random();
                        if (rnd.Next(1, 3) == 1)
                        {
                            Console.Clear();
                            Console.WriteLine("Du lyckades undvika hans slag, samtidigt fick du in ett slag mot honom.");
                            Console.WriteLine($"Du skadade {boss.name} med {spelare.atk} liv");
                            boss.hp -= spelare.atk;
                        }
                        else
                        {
                            Console.Clear();
                            Console.WriteLine($"Du försökte undvika {boss.name} slag, men han är för snabb. Han gjorde dubbla skada på dig");
                            spelare.health -= boss.damage * 2;
                        }
                        break;
                    case 3:
                        openInventory(spelare, svarighetsgrad);
                        break;
                }
                //End of fight Debugging

            }
        }

        //fightEvent tar in en tier samt en spelarklass. Tier är svårighetsgraden eller hur långt man kommit, tier går från 1-3. Tier ökar INTE damage på monster
        private static void fightEvent(int tier, Player spelare, int difficulty)
        {
            //Skapa nya monster här med hjälp av en lista av Monster.
            List<Monster> monsters = new List<Monster>();
            monsters.Add(new Monster()
            {
                hp = 3,
                name = "Varg",
                damage = 2,
                tier = 1,
            });
            
            monsters.Add(new Monster()
            {
                hp = 3,
                name = "Räv",
                damage = 2,
                tier = 1,
            });
            monsters.Add(new Monster()
            {
                hp = 3,
                name = "Vildsvin",
                damage = 2,
                tier = 1,
            });
            monsters.Add(new Monster()
            {
                hp = 6,
                name = "Krokodil",
                damage = 2,
                tier = 2,

            });
            monsters.Add(new Monster()
            {
                hp = 6,
                name = "Björn",
                damage = 2,
                tier = 2,
                beskrvining = "Du möter en björn, den är en tjock hud och päls som är svår penetrerad"
            });
            monsters.Add(new Monster()
            {
                hp = 4,
                name = "Trollum",
                damage = 2,
                tier = 3,
                beskrvining = "Trollum, påminner mycket om någon.. Han ser ganska svag och mager ut"
            });


            //linq för att få ut korrekt tier av monster
            IEnumerable<Monster> filteredMonster =
            from monster in monsters
            where monster.tier == tier
            select monster;

            Random monsterRnd = new Random();
            monsterRnd.Next(0, filteredMonster.Count());

            //random monster av de filtrerade monstren
            Monster currentMonster = filteredMonster.ElementAt(monsterRnd.Next(0, filteredMonster.Count()));

            currentMonster.hp = currentMonster.hp * difficulty;

            bool fight = true;
            /*
            Console.Clear();
            statusDisplay(spelare);
            monsterDisplay(currentMonster);
            lineDivider();
            */

            while (fight)
            {
                Console.Clear();
                statusDisplay(spelare);
                monsterDisplay(currentMonster);
                lineDivider();
                Console.WriteLine($"Plötsligt kommer {currentMonster.name} framför dig, vad gör du?");
                lineDivider();
                //kolla först om spelaren är vid liv
                if (spelare.health <= 0)
                {
                    fight = false;
                    Console.WriteLine($"Game over, {currentMonster.name} besegrade dig, du slogs tappert, men {currentMonster.name} blev din död");
                    gameOver(spelare);
                }

                Console.WriteLine($"1. Slå {currentMonster.name} med ditt vapen \n2. Försök fly \n3. Öppna inventory");
                int input;
                while (!int.TryParse(Console.ReadLine(), out input))
                {
                    Console.WriteLine("Felaktigt alternativ");
                }
                switch (input)
                {
                    case 1:
                        //här sker spellogik som random skada på dig eller skada på monstret

                        if (currentMonster.hp <= 0)
                        {
                            if (spelare.health <= 0)
                            {
                                fight = false;
                                Console.WriteLine($"Game over, {currentMonster.name} besegrade dig, du slogs tappert, men {currentMonster.name} blev din död");
                                gameOver(spelare);
                            }
                            fight = false;
                            currentMonster.hp -= spelare.atk;
                            //Console.Write($"Du slog {currentMonster.name} med {spelare.atk} och ");
                            Console.Write($"Du besegrade {currentMonster.name}, tryck på valfri knapp för att gå vidare.");
                            Console.ReadKey();
                            Console.Clear();
                        }
                        else
                        {
                            spelare.health -= currentMonster.damage;
                            currentMonster.hp -= spelare.atk;
                            if (currentMonster.hp < 0) { currentMonster.hp = 0; }
                            Console.Clear();
                            Console.WriteLine($"Du slog {currentMonster.name} för {spelare.atk} i skada. " +
                            $"\n{currentMonster.name} slog dig för {currentMonster.damage} i skada. Du har {spelare.health} i liv kvar och " +
                            $"{currentMonster.name} har {currentMonster.hp} i liv kvar.");
                            lineDivider();
                            Console.ReadKey();
                            if (spelare.health <= 0)
                            {
                                fight = false;
                                Console.WriteLine($"Game over, {currentMonster.name} besegrade dig, du slogs tappert, men {currentMonster.name} blev din död");
                                gameOver(spelare);
                            }
                            if (currentMonster.hp <= 0)
                            {
                                fight = false;
                                Console.Write($"Du besegrade {currentMonster.name}");
                                Console.Write($"\nDu fick 3 extra liv för att du besegrade monstret. Tryck på valfri knapp för att gå vidare.");
                                spelare.health += 3;
                                Console.ReadKey();
                                Console.Clear();
                            }
                        }

                        break;
                    case 2:
                        Console.Clear();
                        Console.WriteLine("Försök fly");
                        Random rnd = new Random();
                        if (rnd.Next(1, 3) == 1)
                        {
                            Console.WriteLine("Du lyckades fly");
                            fight = false;
                            break;
                        }
                        else
                        {
                            spelare.health -= currentMonster.damage;
                            Console.WriteLine($"Du lyckades inte fly! Du tog {currentMonster.damage} i skada");
                            break;
                        }

                    case 3:
                        //random funktion för att försöka fly, 10% chans att lyckas?
                        openInventory(spelare, difficulty);
                        break;
                }
                //End of fight Debugging

            }
        }

        private static void monsterDisplay(Monster monster)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"Monster: {monster.name}; Attack: {monster.damage}; Hälsa: {monster.hp}");
            Console.ResetColor();
        }

        public static void statusDisplay(Player player)
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine($"Namn: {player.name}; Attack: {player.atk}; Hälsa: {player.health}; Antal Föremål: {player.inventory.Count()}");
            Console.ResetColor();
        }

        public static void lineDivider()
        {
            Console.WriteLine("------------------------------------------------------------------------------------------");
        }
    }
}