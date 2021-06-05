using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SpaceInvaders.AllShipTypes;
using SpaceInvaders.Ammos;


namespace SpaceInvaders
{
    class Game
    {
        public int EnemyShipSpawnTime { get; set; }

        public int MaxNumberOfEnemyShips { get; set; }

        PlayerShip playerShip;




        public Game() 
        {
            EnemyShipSpawnTime = 5;
            MaxNumberOfEnemyShips = 3;
        }

        
        public void Play()
        {
            PrepareGame();
            StartGame();
            PrintAdditionalFeatures();


            PrintBoard();

            bool gamePlayed = PlayingGame();

            if (!gamePlayed)
            {
                Console.Clear();
                Console.WriteLine("You lost");
            }
        }


        #region Game Preparation (Used only once during game (At Start) )



        // Contains:
        //    Instructions
        //    Possible plot
        public void PrepareGame() { }


        // Contains:
        //    Choosing ship(player)
        //    Sets Ship to playerShip
        public void StartGame() 
        {
            // player choice



            // player choice




            // temporary solution

            playerShip = new PlayerShip(new PlayerShip_Type_0());

            // temporary solution
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
        //    Number of Lives(possible)
        //    Health points(possible)
        //    Key Assignment
        //    Number of enemy ships killed
        //    Number of enemy ships missed
        public void PrintAdditionalFeatures() { }




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


            List<EnemyShip> enemyShipsOnBoard = new List<EnemyShip>();


            playerShip.SpawnShip(85, 33);
            playerShip.PrintShip();


            while(true)
            {
                try
                {
                    #region Player making a move

                    /* Player makes a move */

                    if (Console.KeyAvailable)
                    {
                        ConsoleKeyInfo consoleKeyinfo = Console.ReadKey();
                
                        if (consoleKeyinfo.Key == ConsoleKey.Spacebar)
                        {
                            playerShip.Shoot();
                        
                            foreach (var item in playerShip.ShipType.ShipArmament)
                            {
                                ammosOnBoard.Add((Ammo)item.Clone());
                            }
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
                                return false;
                            }
                        }
                    }

                    #endregion



                    #region Spawn enemy ship

                    /* Spawn ship if needed */


                    // To add:
                    //      spawn various types of enemy ships


                    if (enemyShipsOnBoard.Count < MaxNumberOfEnemyShips)
                    {
                        if (DateTime.Now.Subtract(enemyShipSpawnTime).TotalSeconds >= EnemyShipSpawnTime)
                        {
                            EnemyShip newEnemyShip = new EnemyShip(new EnemyShip_Type_0());
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


                                if (enemyShipsOnBoard[i].PosY + enemyShipsOnBoard[i].Height >= 39)
                                {
                                    enemyShipsOnBoard[i].Disappear();

                                    enemyShipsOnBoard.RemoveAt(i);

                                    // ADD 1 TO MISSED SHIPS
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
                        if (enemyShipsOnBoard[i].HP == 0)
                        {
                            enemyShipsOnBoard[i].Disappear();

                            enemyShipsOnBoard.RemoveAt(i);

                        }
                    }
                    #endregion





                    if (playerShip.HP <= 0) return false;


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

    }
}
