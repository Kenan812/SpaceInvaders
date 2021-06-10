using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using SpaceInvaders.AllShipTypes;
using SpaceInvaders.Ammos;


namespace SpaceInvaders
{
    class Game
    {
        public int EnemyShipSpawnTime { get; set; }

        public int MaxNumberOfEnemyShips { get; set; }


        public int PlayerLives { get; set; }

        public int EnemyShipsToDestroy { get; set; }

        public int CurrentNumberOfEnemyShipsDestroyed { get; set; }

        public int EnemyShipsMissed { get; set; }

        public int AllowedEnemyShipMisses { get; set; }


        PlayerShip playerShip;




        public Game(int difficulty) 
        {
            Console.Clear();

            Console.WriteLine("Make game fullscreen :)\n");

            CurrentNumberOfEnemyShipsDestroyed = 0;
            EnemyShipsMissed = 0;

            // Easy
            if (difficulty == 1)
            {
                Console.WriteLine("You are playing on difficulty: easy");
                EnemyShipSpawnTime = 6;
                MaxNumberOfEnemyShips = 2;
                PlayerLives = 3;
                EnemyShipsToDestroy = 25;
                AllowedEnemyShipMisses = 5;
            }

            // Medium
            else if (difficulty == 2)
            {
                Console.WriteLine("You are playing on difficulty: medium");
                EnemyShipSpawnTime = 5;
                MaxNumberOfEnemyShips = 3;
                PlayerLives = 2;
                EnemyShipsToDestroy = 35;
                AllowedEnemyShipMisses = 3;
            }

            // Hard
            else if (difficulty == 3)
            {
                Console.WriteLine("You are playing on difficulty: hard");
                EnemyShipSpawnTime = 4;
                MaxNumberOfEnemyShips = 3;
                PlayerLives = 1;
                EnemyShipsToDestroy = 50;
                AllowedEnemyShipMisses = 1;
            }

            else
            {
                Console.WriteLine("OOPS! Someting went wrong");
                System.Environment.Exit(0);
            }
            
            Console.WriteLine("\nPress any key to consinue...");
            Console.ReadKey();
            Console.Clear();
        }

        
        public void Play()
        {
            StartGame();
            PrintAdditionalFeatures();


            PrintBoard();

            bool gamePlayed = PlayingGame();

            if (!gamePlayed)
            {
                GameLost();
            }
            else
            {
                GameWon();
            }
        }



        #region Game Preparation (Used only once during game (At Start) )


        // Contains:
        //    Choosing ship(player)
        //    Sets Ship to playerShip
        public void StartGame() 
        {

            Console.Clear();
            Console.WriteLine("\nUse '↓' or '↑' to navigate\nPress 'Enter' to confirm chioce\nPress 'esc' to quit playing\n");


            Console.SetCursorPosition(76, 5);
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("CHOOSE YOUR SHIP");
            Console.ForegroundColor = ConsoleColor.White;

            PlayerShip ps1 = new PlayerShip(new PlayerShip_Type_1());
            PlayerShip ps2 = new PlayerShip(new PlayerShip_Type_2());
            PlayerShip ps3 = new PlayerShip(new PlayerShip_Type_3());


            ps1.SpawnShip(40, 15 - ps1.Height);
            ps1.PrintShip();
            Console.SetCursorPosition(35, 17);
            Console.WriteLine("   Characteristics");

            Console.SetCursorPosition(35, 19);
            Console.Write("Speed: ");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Fast");    
            Console.ForegroundColor = ConsoleColor.White;


            Console.SetCursorPosition(35, 20);
            Console.Write("Armor: ");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Light");
            Console.ForegroundColor = ConsoleColor.White;

            Console.SetCursorPosition(35, 21);
            Console.Write("Damage: ");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Low");
            Console.ForegroundColor = ConsoleColor.White;

            Console.SetCursorPosition(35, 22);
            Console.Write("Size: ");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Small");
            Console.ForegroundColor = ConsoleColor.White;




            ps2.SpawnShip(80, 15 - ps2.Height);
            ps2.PrintShip();
            Console.SetCursorPosition(75, 17);
            Console.WriteLine("   Characteristics");

            Console.SetCursorPosition(75, 19);
            Console.Write("Speed: ");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Medium");
            Console.ForegroundColor = ConsoleColor.White;

            Console.SetCursorPosition(75, 20);
            Console.Write("Armor: ");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Enhansed Light");
            Console.ForegroundColor = ConsoleColor.White;

            Console.SetCursorPosition(75, 21);
            Console.Write("Damage: ");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Multiple Low");
            Console.ForegroundColor = ConsoleColor.White;

            Console.SetCursorPosition(75, 22);
            Console.Write("Size: ");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Medium");
            Console.ForegroundColor = ConsoleColor.White;




            ps3.SpawnShip(120, 15 - ps3.Height);
            ps3.PrintShip();
            Console.SetCursorPosition(115, 17);
            Console.WriteLine("   Characteristics");
            Console.SetCursorPosition(115, 19);
            Console.Write("Speed: ");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Very slow");
            Console.ForegroundColor = ConsoleColor.White;

            Console.SetCursorPosition(115, 20);
            Console.Write("Armor: ");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Heavy");
            Console.ForegroundColor = ConsoleColor.White;

            Console.SetCursorPosition(115, 21);
            Console.Write("Damage: ");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("High");
            Console.ForegroundColor = ConsoleColor.White;

            Console.SetCursorPosition(115, 22);
            Console.Write("Size: ");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Huge");
            Console.ForegroundColor = ConsoleColor.White;


            int c = 1;
            int l = 43;

            Console.ForegroundColor = ConsoleColor.Yellow;

            Console.SetCursorPosition(l, 25);
            Console.Write("▲");

            while (true)
            {
                ConsoleKeyInfo k = Console.ReadKey();

                if (k.Key == ConsoleKey.Enter)
                {
                    break;
                }

                else if (k.Key == ConsoleKey.LeftArrow && l > 50)
                {
                    Console.SetCursorPosition(l, 25);
                    Console.Write(" ");
                    l -= 40;
                    c--;
                    Console.SetCursorPosition(l, 25);
                    Console.Write("▲");
                }
                
                else if (k.Key == ConsoleKey.RightArrow && l < 100)
                {
                    Console.SetCursorPosition(l, 25);
                    Console.Write(" ");
                    l += 40;
                    c++;
                    Console.SetCursorPosition(l, 25);
                    Console.Write("▲");
                }

                else if (k.Key == ConsoleKey.Escape)
                {
                    Console.ForegroundColor = ConsoleColor.White;
                    System.Environment.Exit(0);
                }

                else
                {
                    Console.SetCursorPosition(l + 1, 25);
                }


            }

            Console.ForegroundColor = ConsoleColor.White;


            switch (c)
            {
                case 1:
                    playerShip = new PlayerShip(new PlayerShip_Type_1());
                    break;

                case 2:
                    playerShip = new PlayerShip(new PlayerShip_Type_2());
                    break;

                case 3:
                    playerShip = new PlayerShip(new PlayerShip_Type_3());
                    break;

                default:
                    playerShip = new PlayerShip(new PlayerShip_Type_0());
                    break;
            }


            Console.Clear();

        }



        // Prints Play Ground
        public void PrintBoard() 
        {
                // Top Part of Board

            Console.SetCursorPosition(34, 0);

            Console.Write("╔");

            for (int i = 0; i <= 100; i++)
                Console.Write("═");

            Console.Write("╗");



                // Middle part of board

            for (int i = 1; i < 40; i++)
            {
                Console.SetCursorPosition(34, i);
                Console.Write("║");

                Console.SetCursorPosition(136, i);
                Console.WriteLine("║");
            }



                // Bottom part of board

            Console.SetCursorPosition(34, 40);

            Console.Write("╚");

            for (int i = 0; i <= 100; i++)
                Console.Write("═");

            Console.Write("╝");
        }


        #endregion


        // Prints:
        //    Number of Lives
        //    Key Assignment
        //    Number of enemy ships killed
        //    Number of enemy ships missed
        public void PrintAdditionalFeatures() 
        {
            #region Printing Number of Player Lives

            Console.ForegroundColor = ConsoleColor.Red;

            Console.SetCursorPosition(138, 4);
            Console.Write("█   █ █   █ ████  ███");
            Console.SetCursorPosition(138, 5);
            Console.Write("█   █  █ █  █     █    █");
            Console.SetCursorPosition(138, 6);
            Console.Write("█   █  █ █  ████  ███");
            Console.SetCursorPosition(138, 7);
            Console.Write("█   █   █   █       █  █");
            Console.SetCursorPosition(138, 8);
            Console.Write("███ █   █   ████  ███");


            PrintPlayerNumberOfLives(164, 4);


            Console.ForegroundColor = ConsoleColor.White;



            #endregion



            #region Key Assignment


            Console.SetCursorPosition(8, 2);
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("KEY ASSIGNMENT");
            Console.ForegroundColor = ConsoleColor.White;


            Console.SetCursorPosition(2, 4);
            Console.Write("Use '");

            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Write("←");
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("', '");

            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Write("↑");
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("', '");

            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Write("→");
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("', '");

            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Write("↓");

            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("' to move");



            Console.SetCursorPosition(2, 6);
            Console.Write("Use '");

            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Write("space");

            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("' to shoot");



            Console.SetCursorPosition(2, 8);
            Console.Write("Use '");

            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Write("p");

            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("' to pause");



            Console.SetCursorPosition(2, 10);
            Console.Write("Use '");

            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Write("esc");

            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("' to quit the game");

            #endregion



            #region Game Stats


            Console.SetCursorPosition(8, 15);
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Game Statistics");

            Console.SetCursorPosition(2, 17);
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("Enemy Ships To Destroy: ");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(EnemyShipsToDestroy);

            Console.SetCursorPosition(2, 19);
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("Allowed Enemy Ship Misses: ");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(AllowedEnemyShipMisses);

            Console.SetCursorPosition(2, 23);
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("Enemy ships destroyed: ");
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine(CurrentNumberOfEnemyShipsDestroyed);

            Console.SetCursorPosition(2, 25);
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("Enemy ships missed: ");
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine(EnemyShipsMissed);


            Console.ForegroundColor = ConsoleColor.White;


            #endregion

        }




        // Contains:
        //    Player Making Move
        //    Enemy Ship Making Move(bot)
        //    List of all Ammos on Board and move them
        //    Returns true if player won the game, false otherwise
        public bool PlayingGame() 
        {
            bool wasMove = false;  // Used to detect if ammos on the board move


            DateTime prevTimeAmmoMoved = DateTime.Now;  // Indicates time of previous ammo move 
            DateTime enemyShipSpawnTime = DateTime.Now;  // Last time enemy ship spawned


            // Instruction:
            //    Fill with ammos
            //    Delete ammos when it dissappeares(hit the ship or board)
            List<Ammo> ammosOnBoard = new List<Ammo>();


            // Contains all enemy ships on board 
            List<EnemyShip> enemyShipsOnBoard = new List<EnemyShip>();

           


            playerShip.SpawnShip(85, 33);
            playerShip.PrintShip();

            playerShip.SendDeathMessage += InformAboutDeath;


            while(true)
            {
                try
                {
                    #region Player making a move

                    /* Player makes a move */

                    if (Console.KeyAvailable)
                    {
                        ConsoleKeyInfo consoleKeyinfo = Console.ReadKey();
                
                        // Player shoots

                        if (consoleKeyinfo.Key == ConsoleKey.Spacebar)
                        {
                            playerShip.Shoot();
                        
                            foreach (var item in playerShip.ShipType.ShipArmament)
                            {
                                ammosOnBoard.Add((Ammo)item.Clone());
                            }
                        }

                        // PLayer exits the game

                        else if (consoleKeyinfo.Key == ConsoleKey.Escape)
                        {
                            return false;
                        }
                       
                        else if (consoleKeyinfo.Key == ConsoleKey.P)
                        {
                            Console.SetCursorPosition(81, 19);
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Pause");
                            Console.ForegroundColor = ConsoleColor.White;

                            Console.SetCursorPosition(0, 40);

                            Console.WriteLine("Press any key to consinue...");
                            Console.ReadKey();
                            Console.SetCursorPosition(0, 40);
                            Console.WriteLine("                               ");
                            Console.SetCursorPosition(81, 19);
                            Console.WriteLine("     ");
                        }
                    

                        playerShip.ClearAppearance();
                        playerShip.Move(consoleKeyinfo.Key);
                        playerShip.PrintShip();
                    }


                    #endregion



                    #region Check For Ship Hit


                    /* Checks if player ship hits enemy ship */

                    // Ends Game if player hits enemy ship  
                    if (enemyShipsOnBoard.Count != 0)
                    {
                        foreach (var item in enemyShipsOnBoard)
                        {
                            if (playerShip.CheckForShipHit(item))
                            {
                                PlayerLives--;

                                if (PlayerLives == 0) return false;


                                playerShip.DestroyShip();
                                playerShip.SpawnShip(85, 33);
                                playerShip.PrintShip();

                                PrintAdditionalFeatures();
                            }
                        }
                    }

                    #endregion



                    #region Spawn enemy ship

                    /* Spawn ship if needed */



                    if (enemyShipsOnBoard.Count < MaxNumberOfEnemyShips)
                    {
                        if (DateTime.Now.Subtract(enemyShipSpawnTime).TotalSeconds >= EnemyShipSpawnTime)
                        {

                            EnemyShip newEnemyShip = new EnemyShip(EnemyShipTypes.GetRandomEnemyShip());
                            
                            
                            newEnemyShip.Appear();
                            enemyShipsOnBoard.Add(newEnemyShip);

                            enemyShipSpawnTime = DateTime.Now;
                        }
                    }

                    #endregion



                    #region Move Enemy Ships


                    /* Enemy ships moving */

                    if (enemyShipsOnBoard.Count != 0)
                    {

                        for (int i = 0; i < enemyShipsOnBoard.Count; i++)
                        {
                            if (DateTime.Now.Subtract(enemyShipsOnBoard[i].PreviousMoveTime).TotalSeconds >= enemyShipsOnBoard[i].ShipType.SecondsToMove)
                            {
                                enemyShipsOnBoard[i].PreviousMoveTime = DateTime.Now;

                                enemyShipsOnBoard[i].ClearAppearance();
                                enemyShipsOnBoard[i].Move(enemyShipsOnBoard[i].ShipType.ShipMainMovingDirection);
                                enemyShipsOnBoard[i].PrintShip();


                                // If collision with board happens
                                if (enemyShipsOnBoard[i].PosY + enemyShipsOnBoard[i].Height >= 39)
                                {
                                    enemyShipsOnBoard[i].Disappear();

                                    enemyShipsOnBoard.RemoveAt(i);

                                    EnemyShipsMissed++;

                                    UpdateMissedShipInfo();
                                }
                            }
                        }
                    }

                    #endregion



                    #region Enemy Ships Shooting

                    if (enemyShipsOnBoard.Count != 0)
                    {
                        foreach (var ship in enemyShipsOnBoard)
                        {
                            if (DateTime.Now.Subtract(ship.PreviousShootTime).TotalSeconds >= ship.TimeToShoot)
                            {
                                ship.Shoot();

                                foreach (var item in ship.ShipType.ShipArmament)
                                {
                                    ammosOnBoard.Add((Ammo)item.Clone());
                                }

                                ship.PreviousShootTime = DateTime.Now;
                            }
                        }
                    }

                    #endregion



                    #region Moving Ammos and Check For Ammo Hit 

                    /* Moving all ammos on the board */

                    for (int i = 0; i < ammosOnBoard.Count; i++)
                    {
                        if (DateTime.Now.Subtract(prevTimeAmmoMoved).TotalSeconds >= ammosOnBoard[i].SecondsToMove)
                        {
                            wasMove = true;
                            ammosOnBoard[i].AmmoClearAppearance();
                            ammosOnBoard[i].AmmoMove();


                            // When ammo touches the board
                            if (CollisionWithBoard(ammosOnBoard[i]))
                                ammosOnBoard.RemoveAt(i);
                            else
                            {
                                ammosOnBoard[i].AmmoPrint();


                                #region Check for Ammo hitting ship


                                // Check if ammo hit any enemy ship

                                if (ammosOnBoard[i].AmmoMovingDirection == ConsoleKey.UpArrow)  // If ammo was shot by player
                                {
                                    for (int j = 0; j < enemyShipsOnBoard.Count; j++)
                                    {
                                        if (CollisionWithAmmo(ammosOnBoard[i], enemyShipsOnBoard[j]))
                                        {
                                            enemyShipsOnBoard[j].HP -= ammosOnBoard[i].Damage;


                                            // Removing ammo from board if collision happened
                                            ammosOnBoard.RemoveAt(i);
                                        }
                                    }
                                }
                                else if (ammosOnBoard[i].AmmoMovingDirection == ConsoleKey.DownArrow)  // If ammo was shot by enemy ship
                                {
                                    if (CollisionWithAmmo(ammosOnBoard[i], playerShip))
                                    {
                                        playerShip.HP -= ammosOnBoard[i].Damage;

                                        ammosOnBoard.RemoveAt(i);
                                    }
                                }



                               
                                #endregion



                            }
                        }
                    }

                    if (wasMove)
                    {
                        prevTimeAmmoMoved = DateTime.Now;
                        wasMove = false;
                    }

                    #endregion



                    #region Removing Enemy Ships With 0 HP 

                    for (int i = 0; i < enemyShipsOnBoard.Count; i++)
                    {
                        if (enemyShipsOnBoard[i].HP <= 0)
                        {
                            enemyShipsOnBoard[i].Disappear();

                            enemyShipsOnBoard.RemoveAt(i);

                            CurrentNumberOfEnemyShipsDestroyed++;

                            UpdateDestroyedShipInfo();
                        }
                    }
                    #endregion



                    
                    // Player loses life
                    if (playerShip.HP <= 0)
                    {
                        PlayerLives--;

                        if (PlayerLives == 0) return false;


                        playerShip.DestroyShip();
                        playerShip.SpawnShip(85, 33);
                        playerShip.PrintShip();

                        PrintAdditionalFeatures();
                    }


                    // Player loses game
                    if (EnemyShipsMissed > AllowedEnemyShipMisses)
                        return false;


                    // Player won game
                    if (CurrentNumberOfEnemyShipsDestroyed >= EnemyShipsToDestroy)
                        break;
                }

                catch (ArgumentOutOfRangeException)
                {
                    // Will happen from time to time

                    // Just ignore everything
                }

                catch (Exception e)
                {
                    Console.SetCursorPosition(0, 50);
                    Console.WriteLine(e.Message);
                    Console.WriteLine(e.StackTrace);
                    throw;
                }



            }

            return true; 
        }



        #region Collision Checks


        // Returns true if collision with board appeared
        // Returns false otherwise
        public bool CollisionWithBoard(Ammo ammo)
        {
            if (ammo.Y == 0 || ammo.Y == 40)
                return true;

            return false;
        }


        // Returns true if collision of ship with ammo appeared
        // Returns false otherwise
        public bool CollisionWithAmmo(Ammo ammo, Ship ship)
        {
            if (ammo.X >= ship.PosX && ammo.X <= ship.PosX + ship.Width)
                if (ammo.Y >= ship.PosY && ammo.Y <= ship.PosY + ship.Height)
                    return true;

            return false;
        }


        #endregion




        #region Helper Funtions

        public void PrintPlayerNumberOfLives(int start_x, int start_y)
        {

            // Clear previous number

            Console.SetCursorPosition(start_x, start_y);
            Console.Write("   ");
            Console.SetCursorPosition(start_x, start_y + 1);
            Console.Write("   ");
            Console.SetCursorPosition(start_x, start_y + 2);
            Console.Write("   ");
            Console.SetCursorPosition(start_x, start_y + 3);
            Console.Write("   ");
            Console.SetCursorPosition(start_x, start_y + 4);
            Console.Write("   ");



            if (PlayerLives == 1)
            {
                Console.SetCursorPosition(start_x, start_y);
                Console.Write("███");
                Console.SetCursorPosition(start_x, start_y + 1);
                Console.Write("  █");
                Console.SetCursorPosition(start_x, start_y + 2);
                Console.Write("  █");
                Console.SetCursorPosition(start_x, start_y + 3);
                Console.Write("  █");
                Console.SetCursorPosition(start_x, start_y + 4);
                Console.Write("  █");

            }

            else if (PlayerLives == 2)
            {
                Console.SetCursorPosition(start_x, start_y);
                Console.Write("███");
                Console.SetCursorPosition(start_x, start_y + 1);
                Console.Write("  █");
                Console.SetCursorPosition(start_x, start_y + 2);
                Console.Write("███");
                Console.SetCursorPosition(start_x, start_y + 3);
                Console.Write("█");
                Console.SetCursorPosition(start_x, start_y + 4);
                Console.Write("███");
            }

            else if (PlayerLives == 3)
            {
                Console.SetCursorPosition(start_x, start_y);
                Console.Write("███");
                Console.SetCursorPosition(start_x, start_y + 1);
                Console.Write("  █");
                Console.SetCursorPosition(start_x, start_y + 2);
                Console.Write("███");
                Console.SetCursorPosition(start_x, start_y + 3);
                Console.Write("  █");
                Console.SetCursorPosition(start_x, start_y + 4);
                Console.Write("███");
            }
        }


        public void GameLost()
        {
            Console.Clear();
            Console.SetCursorPosition(81, 19);
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("You lost");
            Console.ForegroundColor = ConsoleColor.White;

            Console.SetCursorPosition(0, 40);

            Console.WriteLine("Press any key to consinue...");
            Console.ReadKey();
            System.Environment.Exit(0);
        }

        public void GameWon()
        {
            Console.Clear();
            Console.SetCursorPosition(81, 19);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("You Won");
            Console.ForegroundColor = ConsoleColor.White;

            Console.SetCursorPosition(0, 40);

            Console.WriteLine("Press any key to consinue...");
            Console.ReadKey();
            System.Environment.Exit(0);
        }


        public void UpdateDestroyedShipInfo(int PosX = 25, int PosY = 23)
        {
            Console.SetCursorPosition(PosX, PosY);
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine(CurrentNumberOfEnemyShipsDestroyed);
            Console.ForegroundColor = ConsoleColor.White;
        }


        public void UpdateMissedShipInfo(int PosX = 22, int PosY = 25)
        {
            Console.SetCursorPosition(PosX, PosY);
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine(EnemyShipsMissed);
            Console.ForegroundColor = ConsoleColor.White;
        }


        #endregion



        public void InformAboutDeath(object sender, PlayerShipEventHandler playerShipEventHandler)
        {
            Console.SetCursorPosition(73, 19);
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(playerShipEventHandler.Message);
            Console.ForegroundColor = ConsoleColor.White;
            Thread.Sleep(4000);
            Console.SetCursorPosition(73, 19);
            Console.WriteLine(playerShipEventHandler.PrintClearMessaage);
        }
    }
}
