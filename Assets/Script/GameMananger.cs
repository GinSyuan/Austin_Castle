﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

public class GameManager: MonoBehaviour
{
        private RoomBase currentRoom;                                                  // Stores the current room the player is in
        private Dictionary<string, RoomBase> rooms = new Dictionary<string, RoomBase>();   // Use dictionary to store the rooms in the game
        private List<string> inventory = new List<string>();                       // Use list to store items the player collects (inventory)

        public GameManager()
        {
            SetupRooms();  
        // Initialize the room when game start
       
        }

        public void Play()
        {
            Console.WriteLine("                                                                                              \r\n                                                                                              \r\n                                                                                              \r\n                                                                                              \r\n                                                                                              \r\n                                                                                              \r\n                                                                                              \r\n                                                                                              \r\n                                                                                              \r\n                                                                                              \r\n          ---:::::::::::::---=-==----------:::::-::------------::::::::::::::-::::::          \r\n          ---:::::::::::::-----=--::-:-----::..::::::---::-:-----::---::------:----:          \r\n          ------::::::-:----===----:::::-::::.....:::::::::::--------------------:::          \r\n          -----:::::::----===-------:::::::...........::::::::------------:-----::::          \r\n          -::::::....:-===-----------:::........   .....::::::::-----::::::-::-::..:          \r\n          -:::::..:::-------==------::..              ....:::::...::::.::::::::..:::          \r\n          :::..::::..:-----:=------::..                 ...::..   ........::.:..::::          \r\n          :::.::::....:::----:-----:::.....            ........     ......::.:.:::.:          \r\n          ::::.:::....::::-:---:----:::::.     ..  :   ........     ........::::....          \r\n          :::::::::.:::------::::::::::::...  .=-===.... ............  ....:::......          \r\n          :::::-::::------:::::::::::::::..   :.     :  ...:................::..              \r\n          :::::-::--------:-::........:...    .:..  -:   .....        .   ...                 \r\n          ::::::--:--------:::::..........     -==:.:: .  ....         . ..                   \r\n          ::::::::----:-:--::.:::..........    --:.:::    ...      ..                         \r\n          :-::::::-:::::-::::::::....:::.......=-:.::+- .....                                 \r\n          :-::::::::---::::::::::.....::......:+=:..--+:....                                  \r\n          :--:::::::::----:::::....  ..::.....+*+:-:. =.....                                  \r\n          ---:-:...:::::--::::::..  .........:**=.... .                                       \r\n          =--::-:...:::::::::::::...   ..   ..#%+.:-.                                         \r\n          =--::----:..:::::::::::  ..         =*#--=. .                                       \r\n          =---..:---:....:::::..:.....        .@*=-+: .                                       \r\n          ---::..::::::. ::::.......           %#%%#-:=.                                      \r\n          -=--:--::::---::::......            .%%%@%@#+:                                      \r\n          -++=::--:::---:::::....             +%**##*%%* .:                       ..          \r\n          -+****+=====-:====--...           :-+*-===-##%==.               ....   ...          \r\n          :=+**+:*++++=--++++=-:.. .       -+:=+ :+=.=++##-      .    ..............          \r\n          :::*#++-****++==+++++==:.:.    --+++=--=+=:==-++=-         .......:::.::::          \r\n          =-=##*=:=#%@@###*+****++-==- :*%%*#*==*+*:.-=:-.=: .....   .......::::::::          \r\n          +-=*%=-::##@@@%#*#*+****##+++#@@%**#-+*+=..=-.:.::.::::..  :...:::::------          \r\n          @+**+=-=+%@@@@@#***#*++*+#*+@#@@####-*%*= =--: ..=-----:+..:-:::::::::---:          \r\n          @**+*=-#@*@@@@@@@%**#*+-=#*+#%@@@%%%+*%+-... . . :.:--:-*: :::::::::-:::::          \r\n          %%#+-+-*@%**@@@%%@@@%#++=+*+@@++=+*#===+---=+: -.=:::::-%+=...:::::-------          \r\n          *%++=+**@%+*@@@@@@@@@@@%##+=%@@@%####*++*=+**%*:-*:-:-=-%-=:.::--------===          \r\n          *##+--*+-::-=+**#%@@%*##%@%*#@@@@%#*#+====*++*@%=:-**#**%-:-:-===--------=          \r\n          @@#=-:+*+=*#%#@@@@@@%%@@@@@=%@@@@@##+===*.-.-:#@@#*%#**+%:.-==+++==++===-+          \r\n          %@%+:-+*#%@@%*@@@@@@@@@@@@%*@@@@%*#+*+*+= .:-:*%@*=#%@@@*-.-=-++++++=++++*          \r\n          %@@@*=+#%+*%%%@@@@@@@@@@@@@%@@@@*##@**+-. ==+=#%%+*#@@@@%*-+==*#*+++++****          \r\n          *%@@@%%%##@@%%##@@@@@@@@@@@%@%%%%@%++%*::.*+*+%#%*-%@@@@%#=:++=-=-+**#@%*+          \r\n          #@#**#@@%*@@%##@@@@@@@@@@@@#+%@@@@@#+%#---**##@%%*+#@@@@*++=:-===###%%****          \r\n          ++*%@@@@@@@@@@@@@@@@@@@@@@%%#@@@@@@@@%*++==-::::--+**#**=-==  .=****##*#**          \r\n          ====*%@@@@@@@@@@@@@@@@@@@@@@%@@@@@@@@@@#*%%++-==++=*%#*-=++-:-+##*+==--+++          \r\n          %==:-==#@@@@=--=+#%%%%@@@@@@#@@@%@@@@@@@@@##@@@%*==+=:.:-=+#=%*+*=-+%*#%%%          \r\n          %%%+=-=++*+==+=-==-=+***#%@%%%@@##@%%@@@%%##@@@@%%%=+#*-+++#*%*%@+::+###**          \r\n          #%%%*==-=-.:-.     .:=+:=*#%###%@%*+*=@@@@**@@%@@%***@@##+-#=%%@@%=-%@@*==          \r\n          %%%%*+*##*=-.          ..:=**==@@@@@@%@@%@**%@@@@@%**#@%@%-*==#%@%++@@@%*+          \r\n          *##%*+*#+%=+-:--==-....----=+-=*@*+%@@@@@@%%@%**@@%*@@@@%=:..:+@@%*-#@%%%*          \r\n          **+##%##+*====-::=   ::+*+==+-:::+#*+@@@@@%@@@%%@@%%@@@@@%@%+##%@@%+#%##*%          \r\n          =..:--=+=====-=-:-. .*%%*@%%=:.-  +%%%@@@@%%@@@@@@%*@@@@@@@**+#@%@%*+=+*++          \r\n          ::::=====+::====-:- .*@@@%#+=. .  -@@%@@@@@@@@@@@@@+@@@@@%@#@%#@@@@%##%@%#          \r\n          #::==*###%+=++*#+:+ .=#@#%*#@- .:.-@@%@@@@@@@@@@%@%#@@@@@%@@@@@@@@@@@@@@@@          \r\n          #*+#%@#@@@@%#@@@*== :*#@@@%@@-.:+.-#@@**@@@#**+*#@%++#%@@%%@@@@@@@@@@@@@@@          \r\n          @##@@@@@++#@@@@@*+%=:=+@@@@%+-.-#::+@@@*+*@@@@@@@%@%#+-=***@@@@@@@@@@@@@@@          \r\n          ##@@@@@@+#@@@@@@#*+=:=#@@@@@%+-=*.:+@@@@+*@@@@@@@@@@@@@@#*+=*%%@@@@@@#@@@@          \r\n          @@@@@@@@@@@@@@@@#*@*=-#@@@@@%*=:*+=@@@@@**@@@@@@@@@@@@@@@@@@%@#+=*###**@%@          \r\n          @@@@@@@@@@@@@@@%*+*+-=#@@@@@@@+--**%@@@%#*@@@@@@@@@@@@@@@@@@@@@@@@@@%#**##          \r\n          @@@@@@@@@@@@@@@@*+*+-=*@@@@@@@*=#*+%@@@@%*@@@@@%@@@@@@@@@@@@@@@@@@@@@@@@@@          \r\n          @@@@@@@@@@@@@@@@%@*#=**@@@@@@%*+%**@@@@@@%@@@@@@@@@@@@@@@@@@@@@@@@@@@@%@%@          \r\n          @@@@@@@@@@@@@@@@##%%+#%@@@@@@@###@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@##@@          \r\n          @@@@@@@@@@@@@@@@+**%=#*#@@@@@%*####%@@@@@#@@@@@@@@@@@@@@@@@@@@@@@@@@=-***#          \r\n          @@@@@@@@@@@@@@@@###*+%*#%@@@@%**%=+%@@@@%%%%@@@@@@@@@@@@@@@#*#***#%%*++===          \r\n          @@@@@@@@@@@@@@@@%@@%+*+%@@@@@@%+@=+#@@@@@@#*#@@@@@@@@@#@@@**+===--++==-==+          \r\n          @@@@@@@@@@@@@@@@@@@%==*@@@@%#@%**==+##@@@*=***#@@@@@@#==+=-=-:===--:.::=+#          \r\n          @@@@@@@@@@@@@@@@@@@@%#######*###*##*+++-:-+###*#*==+++=++--+*#####+==#%##@          \r\n          @@@@@@@@@@@@@@@@@@@##%#%#+=+#++==+=====+++*+++=+**===+=-=-=+##%%###*=++*#*          \r\n          @@@@@@@@@@@%%@@@@@@%*###@%##*+=-==--::-::-====:=+*+-=*=-=-*%@@%#==*#*++*##          \r\n          @@@#**#***#@%@@@@@@@@%%@%%###=+++++=--++===*++====+*********++--:---==-=+*          \r\n          #%%***##+==+*#%@@%@@@%%@@%%##%%%%%#######*++=====+##***+*####***+*++*#*##+          \r\n          @*=+@@@@#+=*@@@@@@%@@#+@@%++++**####%%%@%#*##**#%@@###%#%%%%@%%%%%%%@@@@@@          \r\n          =*@@@@@#--+++*%@%#@@#*+++=-=----=-+****%*==+**#%@@%%@@@@@@@@@@@@@#@@@@@@@@          \r\n          +==-=:. -+**++++-====---=--=+****+++*#%@@#%#*#+##%%#%%@@@@@@@@@@@@@@@@@@@@          \r\n          --====++======:===---++-==-=+**#*###@@@@@@%%%#%%##=+#*##@@@@@@@@@@@@@@@@@@          \r\n                                                                                              \r\n                                                                                              \r\n                                                                                              \r\n                                                                                              \r\n                                                                                              \r\n                                                                                              \r\n                                                                                              \r\n                                                                                              \r\n                                                                                              \r\n                                                                                              ");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("Welcome to Austin Castle!");
            Console.WriteLine("Prepare yourself for an adventure full of mystery and relaxation.");
            Console.ResetColor();

            while (true)
            {
                currentRoom.OnRoomEntered(inventory);
                Console.WriteLine($"Where would you like to go? {currentRoom.GetAvailableDirections()}");  // Display the available directions
                string direction = Console.ReadLine().ToLower();                                           // Get the player's answer

                RoomBase nextRoom = currentRoom.GetRoomInDirection(direction, inventory);                      // Get the next toom based on the player's answer
                if (nextRoom == null)
                {
                    Console.WriteLine("You can't go that way.");                                           // If ther's no room or it's blocked
                }
                else
                {
                    currentRoom.OnRoomExit();                                                              // If p;ayer can move, leave the current room 
                    currentRoom = nextRoom;                                                                // Enter the new room
                }
            }
        }

        public void SetupRooms()        // Set up all the room and the links between them
        {
            // Create instances of all the rooms
            RoomBase entranceHall = new EntranceHall();
            RoomBase guestRoom = new GuestRoom();
            RoomBase smallBackyard = new SmallBackyard();
            RoomBase weaponRoom = new WeaponRoom();
            RoomBase garden = new GardenRoom();
            RoomBase storageRoom = new StorageRoom();
            RoomBase entertainmentRoom = new EntertainmentRoom();
            RoomBase artRoom = new ArtRoom();
            RoomBase cellar = new Cellar();


            // Set all rooms link 
            entranceHall.East = guestRoom;
            guestRoom.West = entranceHall;
            guestRoom.East = smallBackyard;
            guestRoom.South = garden;
            smallBackyard.West = guestRoom;
            weaponRoom.East = garden;
            garden.North = guestRoom;
            garden.West = weaponRoom;
            garden.East = storageRoom;
            garden.South = artRoom;
            storageRoom.West = garden;
            entertainmentRoom.East = artRoom;
            artRoom.North = garden;
            artRoom.West = entertainmentRoom;
            artRoom.East = cellar;
            cellar.West = artRoom;
            

            // Add obstacles in certain directions that need items to pass
            guestRoom.AddObstacle("east", "Ivy", "Sword");
            garden.AddObstacle("south", "Broken", "Wood");
            artRoom.AddObstacle("east", "Locked", "Key");


            // Add all rooms to the dictionary
            rooms.Add("Entrance Hall", entranceHall);
            rooms.Add("Guest Room", guestRoom);
            rooms.Add("Small Backyard", smallBackyard);
            rooms.Add("Weapon Room", weaponRoom);
            rooms.Add("Garden", garden);
            rooms.Add("Storage Room", storageRoom);
            rooms.Add("Entertainment Room", entertainmentRoom);
            rooms.Add("Art Room", artRoom);
            rooms.Add("Cellar", cellar);


            // Set the starting room to entrace hall
            currentRoom = entranceHall;
        }
    }