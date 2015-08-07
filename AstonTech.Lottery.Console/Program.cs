

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AstonTech.Lottery.DAL;


namespace AstonTech.Lottery
{
    class Program
    {
        static void Main(string[] args)
        {
            Project();
        }

        //    private static void PowerBall()
        //    {
        //        string firstGame = "PowerBall";
        //        DateTime dt = DateTime.Parse("18 Dec 2013");
        //        int firstNumber= 7;
        //        int secondNumber= 24;
        //        int thirdNumber= 37;
        //        int fourthNumber= 39;
        //        int fifthNumber = 40;
        //        int powerBall = 1;
        //        string estimatedJackpot = "$60,000,000";
        //        string estimatedCashoption = "$33,300,000";
        //        DateTime jackpotDrawingdate = DateTime.Parse("21 Dec 2013");

        //        System.Console.WriteLine(firstGame);
        //        System.Console.WriteLine(dt);
        //        System.Console.WriteLine(firstNumber);
        //        System.Console.WriteLine(secondNumber);
        //        System.Console.WriteLine(thirdNumber);
        //        System.Console.WriteLine(fourthNumber);
        //        System.Console.WriteLine(fifthNumber); 
        //        System.Console.WriteLine(powerBall);
        //        System.Console.WriteLine(estimatedJackpot);
        //        System.Console.WriteLine(estimatedCashoption);
        //        System.Console.WriteLine(jackpotDrawingdate);
        //    }

        //    private static void MegaMillions()
        //{
        //    string secondGame= "Mega Millions";
        //    DateTime dt = DateTime.Parse("17 Dec 2013");
        //    int firstNumber = 8;
        //    int secondNumber = 14;
        //    int thirdNumber = 17;
        //    int fourthNumber = 20;
        //    int fifthNumber = 39;
        //    int megaBall = 7;
        //    string estimatedJackpot = "$15,000,000";
        //    string estimatedCashoption = "$8,000,000";
        //    DateTime jackpotDrawingdate = DateTime.Parse("20 Dec 2013");

        //    System.Console.WriteLine(secondGame);
        //    System.Console.WriteLine(dt);
        //    System.Console.WriteLine(firstNumber);
        //    System.Console.WriteLine(secondNumber);
        //    System.Console.WriteLine(thirdNumber);
        //    System.Console.WriteLine(fourthNumber);
        //    System.Console.WriteLine(fifthNumber);
        //    System.Console.WriteLine(megaBall);
        //    System.Console.WriteLine(estimatedJackpot);
        //    System.Console.WriteLine(estimatedCashoption);
        //    System.Console.WriteLine(jackpotDrawingdate);
        //}

        //private static void HotLotto()
        //{
        //    string thirdGame = "Mega Millions";
        //    DateTime dt = DateTime.Parse("18 Dec 2013");
        //    int firstNumber = 8;
        //    int secondNumber = 27;
        //    int thirdNumber = 32;
        //    int fourthNumber = 40;
        //    int fifthNumber = 46;
        //    int hotBall = 4;
        //    string estimatedJackpot = "$1,950,000";
        //    DateTime jackpotDrawingdate = DateTime.Parse("21 Dec 2013");

        //    System.Console.WriteLine(thirdGame);
        //    System.Console.WriteLine(dt);
        //    System.Console.WriteLine(firstNumber);
        //    System.Console.WriteLine(secondNumber);
        //    System.Console.WriteLine(thirdNumber);
        //    System.Console.WriteLine(fourthNumber);
        //    System.Console.WriteLine(fifthNumber);
        //    System.Console.WriteLine(hotBall);
        //    System.Console.WriteLine(estimatedJackpot);
        //    System.Console.WriteLine(jackpotDrawingdate);
        //}

        //private static void Gopher5()
        //{
        //    string fourthGame = "Gopher 5";
        //    DateTime dt = DateTime.Parse("18 Dec 2013");
        //    int firstNumber = 2;
        //    int secondNumber = 9;
        //    int thirdNumber = 12;
        //    int fourthNumber = 36;
        //    int fifthNumber = 39;
        //    string estimatedJackpot = "$130,000";
        //   // DateTime jackpotDrawingDate = DateTime.Parse("20 Dec 2013");
        //    DateTime jackpotDrawingDate = new DateTime(2013, 12, 20);


        //    System.Console.WriteLine(fourthGame);
        //    System.Console.WriteLine(dt);
        //    System.Console.WriteLine(firstNumber);
        //    System.Console.WriteLine(secondNumber);
        //    System.Console.WriteLine(thirdNumber);
        //    System.Console.WriteLine(fourthNumber);
        //    System.Console.WriteLine(fifthNumber);
        //    System.Console.WriteLine(estimatedJackpot);
        //    System.Console.WriteLine(jackpotDrawingDate);
        //}

        //private static void ListArray()
        //{
        //    List<string> GameName = new List<string>();
        //    string[] WinningNumber = new string[4];
        //    string[] EstimatedJackpot = new string[4];

        //    GameName.Add("PowerBall");
        //    WinningNumber[0] = "7  24 37 39 40 1";
        //    EstimatedJackpot[0] = "$60,000,000";
        //    GameName.Add("Mega Millions");
        //    WinningNumber[1] = "8 14 17 20 39 7";
        //    EstimatedJackpot[1] = "$15,000,000";
        //    GameName.Add("Hot Lotto");
        //    WinningNumber[2] = "8 27 32 40 46 4";
        //    EstimatedJackpot[2] = "$1,950,000";
        //    GameName.Add("Gopher 5");
        //    WinningNumber[3] = "2 9 12 36 39";
        //    EstimatedJackpot[3] = "$130,000";


        //    int i = 0;
        //    foreach (string stringValue in GameName)
        //    {
        //        System.Console.WriteLine(stringValue);
        //        System.Console.WriteLine(WinningNumber[i]);
        //        System.Console.WriteLine(EstimatedJackpot[i]);
        //        i++;
        //    }
        //}

        //private static void Menu()
        //{


        //    System.Console.WriteLine("Please select from the following options to view lottery game info:");
        //    System.Console.WriteLine("----------------------------------------------------------");
        //    System.Console.WriteLine("1 : Powerball");
        //    System.Console.WriteLine("2 : Mega Millions");
        //    System.Console.WriteLine("3 : Hot Lotto");
        //    System.Console.WriteLine("4 : Gopher 5");
        //    System.Console.WriteLine("----------------------------------------------------------");

        //    string GameName1, GameName2, GameName3, GameName4;
        //    string WinningNumber1, WinningNumber2, WinningNumber3, WinningNumber4;
        //    string EstimatedJackpot1, EstimatedJackpot2, EstimatedJackpot3, EstimatedJackpot4;

        //    GameName1 = "PowerBall";
        //    WinningNumber1 = "7  24 37 39 40 1";
        //    EstimatedJackpot1 = "$60,000,000";
        //    GameName2 = "Mega Millions";
        //    WinningNumber2 = "8 14 17 20 39 7";
        //    EstimatedJackpot2 = "$15,000,000";
        //    GameName3 = "Hot Lotto";
        //    WinningNumber3 = "8 27 32 40 46 4";
        //    EstimatedJackpot3 = "$1,950,000";
        //    GameName4 = "Gopher 5";
        //    WinningNumber4 = "2 9 12 36 39";
        //    EstimatedJackpot4 = "$130,000";

        //    string Games = System.Console.ReadLine();


        //    try
        //    {  
        //        switch (Games)
        //        {

        //            case "1":
        //                System.Console.WriteLine(GameName1);
        //                System.Console.WriteLine(WinningNumber1);
        //                System.Console.WriteLine(EstimatedJackpot1);
        //                break;

        //            case "2":
        //                System.Console.WriteLine(GameName2);
        //                System.Console.WriteLine(WinningNumber2);
        //                System.Console.WriteLine(EstimatedJackpot2);
        //                break;

        //            case "3":
        //                System.Console.WriteLine(GameName3);
        //                System.Console.WriteLine(WinningNumber3);
        //                System.Console.WriteLine(EstimatedJackpot3);
        //                break;

        //            case "4":
        //                System.Console.WriteLine(GameName4);
        //                System.Console.WriteLine(WinningNumber4);
        //                System.Console.WriteLine(EstimatedJackpot4);
        //                break;

        //            default:
        //                System.Console.WriteLine("Please select a valid number!");
        //                break;


        //        }
        //    }
        //    catch (FormatException ex)
        //    {
        //        System.Console.WriteLine("Exception: " + ex.Message);
        //    }

        //    finally
        //    {
        //        System.Console.WriteLine("Program has completed regardless of Exceptions.");
        //    }            

        //}

        private static void Code()
        {
            int game = 0;
            int drawing = 0;
            int number = 0;

            game = Convert.ToInt32(Console.ReadLine());
            drawing = Convert.ToInt32(Console.ReadLine());
            number = Convert.ToInt32(Console.ReadLine());



            LotteryGameValue pb = new LotteryGameValue();
            pb = LotteryGameDAL.GetItem(game);

            LotteryDrawing mb = new LotteryDrawing();
            mb = LotteryDrawingDAL.GetItem(drawing);

            DrawingNumberCollection numc = new DrawingNumberCollection();
            numc = DrawingNumberDAL.GetCollection(number);

            int id = 0;
            int page = 0;
            int row = 0;

            id = Convert.ToInt32(Console.ReadLine());
            page = Convert.ToInt32(Console.ReadLine());
            row = Convert.ToInt32(Console.ReadLine());

            LotteryDrawingCollection drawc = new LotteryDrawingCollection();
            drawc = LotteryDrawingDAL.GetCollection(id, page, row);

            foreach (LotteryDrawing item in drawc)
            {
                System.Console.WriteLine(item.GetDrawing());
            }
            System.Console.ReadKey();
            //System.Console.WriteLine("");
            //foreach (DrawingNumber item in number)
            //{
            //    System.Console.WriteLine(item.GetItem());
            //}

            //System.Console.WriteLine(pb.GetGame());
            //System.Console.ReadKey();
            //System.Console.WriteLine("");




            //LotteryDrawing drawing = new LotteryDrawing();
            //drawing = LotteryDrawingDAL.GetItem(12);

            // System.Console.WriteLine(drawing.GetDrawing());

            //DrawingNumberCollection number = new DrawingNumberCollection();
            //number = DrawingNumberDAL.GetCollection(5);

            //foreach (DrawingNumber item in number)
            //{
            //    System.Console.WriteLine(item.GetItem());
            //}

            //LotteryGameCollection drawing = new LotteryGameCollection();
            //drawing = LotteryGameDAL.GetCollection();

            //foreach (LotteryGameValue item in drawing)
            //{
            //    System.Console.WriteLine(item.GetGame());
            //}

            //LotteryDrawingCollection drawing = new LotteryDrawingCollection();
            //drawing = LotteryDrawingDAL.GetCollection(4,1,5);

            //foreach (LotteryDrawing item in drawing)
            //{
            //    System.Console.WriteLine(item.GetDrawing());
            //}
        }

        private static void Project()
        {
            bool exit = false;



            do
            {

                System.Console.Clear();
                System.Console.WriteLine("-----------------------------------------------------------------------");
                System.Console.WriteLine("***********************************************************************");
                System.Console.WriteLine("-----------------------------------------------------------------------");
                System.Console.WriteLine("");
                System.Console.WriteLine("             --      --       --        --        --     --");
                System.Console.WriteLine("              --    -- --    --         --        -- --  --");
                System.Console.WriteLine("               --  --   --  --          --        --  -- --");
                System.Console.WriteLine("                 --      --             --        --     --");
                System.Console.WriteLine("");
                System.Console.WriteLine("");
                System.Console.WriteLine("1. PowerBall");
                System.Console.WriteLine("2. Mega Millions");
                System.Console.WriteLine("3. Gopher 5");
                System.Console.WriteLine("4. Northstar Cash");
                System.Console.WriteLine("");
                System.Console.WriteLine("-----------------------------------------------------------------------");
                System.Console.WriteLine("***********************************************************************");
                System.Console.WriteLine("-----------------------------------------------------------------------");
                System.Console.WriteLine("");
                System.Console.Write("Please enter a number to view game details or type 0 to exit:");

                string selection = System.Console.ReadLine();
                int game;

                game = int.Parse(selection);


                switch (game)
                {

                    case 1:
                        PowerBall();
                        break;
                    case 2:
                        Mega();
                        break;

                    case 3:
                        Gopher();
                        break;
                    case 4:
                        North();
                        break;

                    case 0:
                        exit = true;
                        continue;
                    default:
                        if (game > 4)
                        {
                            Error();
                        }
                        else
                            Error();
                        continue;
                }

                System.Console.Clear();

            } while (!exit);
        }


        private static void PowerBall()
        {
            bool l = false;



            do
            {
                System.Console.Clear();
                System.Console.WriteLine("-----------------------------------------------------------------------");
                System.Console.WriteLine("***********************************************************************");
                System.Console.WriteLine("-----------------------------------------------------------------------");
                System.Console.WriteLine("");
                System.Console.WriteLine("             --      --       --        --        --     --");
                System.Console.WriteLine("              --    -- --    --         --        -- --  --");
                System.Console.WriteLine("               --  --   --  --          --        --  -- --");
                System.Console.WriteLine("                 --      --             --        --     --");
                System.Console.WriteLine("");
                System.Console.WriteLine("                                POWERBALL");
                System.Console.WriteLine("");
                System.Console.WriteLine("");
                System.Console.WriteLine("1. View Latest Drawing and its Winning Numbers ");
                System.Console.WriteLine("2. View Game Collection of Drawings");
                System.Console.WriteLine("3. To return to the Main Menu");
                System.Console.WriteLine("");
                System.Console.WriteLine("-----------------------------------------------------------------------");
                System.Console.WriteLine("***********************************************************************");
                System.Console.WriteLine("-----------------------------------------------------------------------");
                System.Console.WriteLine("");
                System.Console.Write("Please make your selection:");


                string select = System.Console.ReadLine();
                int power;

                int page = 0;
                int row = 0;


                power = int.Parse(select);

                LotteryDrawing drawing = new LotteryDrawing();
                drawing = LotteryDrawingDAL.GetItem(1);

                DrawingNumberCollection number = new DrawingNumberCollection();
                number = DrawingNumberDAL.GetCollection(4);



                switch (power)
                {

                    case 0:
                        l = true;
                        continue;

                    case 1:
                        System.Console.Clear();
                        System.Console.WriteLine(drawing.GetDrawing());
                        foreach (DrawingNumber item in number)
                        {
                            //System.Console.WriteLine(item.GetItem());
                        }
                        System.Console.WriteLine("");
                        System.Console.WriteLine(" Press any key to return to Menu");
                        break;
                    case 2:
                        System.Console.Clear();
                        System.Console.WriteLine("Enter Page Number\t\t");
                        page = Convert.ToInt32(System.Console.ReadLine());

                        System.Console.WriteLine("Enter Number of Rows to view\t\t");
                        row = Convert.ToInt32(System.Console.ReadLine());
                        System.Console.Clear();

                        LotteryDrawingCollection draw = new LotteryDrawingCollection();
                        draw = LotteryDrawingDAL.GetCollection(1, page, row);
                        foreach (LotteryDrawing item in draw)
                        {
                            System.Console.WriteLine(item.GetDrawing());
                        }

                        System.Console.WriteLine("");
                        System.Console.WriteLine(" Press any key to return to Menu");
                        break;

                    case 3:
                        Project();
                        break;
                    case 4:
                        North();
                        break;

                    default:
                        if (power > 4)
                        {
                            Error();
                        }
                        else
                            Error();
                        continue;
                }

                System.Console.ReadKey();
                System.Console.Clear();

            } while (!l);



        }

        private static void Mega()
        {
            bool m = false;



            do
            {
                System.Console.Clear();
                System.Console.WriteLine("-----------------------------------------------------------------------");
                System.Console.WriteLine("***********************************************************************");
                System.Console.WriteLine("-----------------------------------------------------------------------");
                System.Console.WriteLine("");
                System.Console.WriteLine("             --      --       --        --        --     --");
                System.Console.WriteLine("              --    -- --    --         --        -- --  --");
                System.Console.WriteLine("               --  --   --  --          --        --  -- --");
                System.Console.WriteLine("                 --      --             --        --     --");
                System.Console.WriteLine("");
                System.Console.WriteLine("                                Mega Millions");
                System.Console.WriteLine("");
                System.Console.WriteLine("");
                System.Console.WriteLine("1. View Latest Drawing and its Winning Numbers ");
                System.Console.WriteLine("2. View Game Collection of Drawings");
                System.Console.WriteLine("3. To return to the Main Menu");
                System.Console.WriteLine("");
                System.Console.WriteLine("-----------------------------------------------------------------------");
                System.Console.WriteLine("***********************************************************************");
                System.Console.WriteLine("-----------------------------------------------------------------------");
                System.Console.WriteLine("");
                System.Console.Write("Please make your selection:");


                string select = System.Console.ReadLine();
                int power;

                int page = 0;
                int row = 0;


                power = int.Parse(select);

                LotteryDrawing drawing = new LotteryDrawing();
                drawing = LotteryDrawingDAL.GetItem(2);

                DrawingNumberCollection number = new DrawingNumberCollection();
                number = DrawingNumberDAL.GetCollection(8);



                switch (power)
                {

                    case 0:
                        m = true;
                        continue;

                    case 1:
                        System.Console.Clear();
                        System.Console.WriteLine(drawing.GetDrawing());
                        foreach (DrawingNumber item in number)
                        {
                            //System.Console.WriteLine(item.GetItem());
                        }
                        System.Console.WriteLine("");
                        System.Console.WriteLine(" Press any key to return to Menu");
                        break;
                    case 2:
                        System.Console.Clear();
                        System.Console.WriteLine("Enter Page Number\t\t");
                        page = Convert.ToInt32(System.Console.ReadLine());

                        System.Console.WriteLine("Enter Number of Rows to view\t\t");
                        row = Convert.ToInt32(System.Console.ReadLine());
                        System.Console.Clear();

                        LotteryDrawingCollection draw = new LotteryDrawingCollection();
                        draw = LotteryDrawingDAL.GetCollection(2, page, row);
                        foreach (LotteryDrawing item in draw)
                        {
                            System.Console.WriteLine(item.GetDrawing());
                        }

                        System.Console.WriteLine("");
                        System.Console.WriteLine(" Press any key to return to Menu");
                        break;

                    case 3:
                        Project();
                        break;


                    default:
                        if (power > 3)
                        {
                            Error();
                        }
                        else
                            Error();
                        continue;
                }

                System.Console.ReadKey();
                System.Console.Clear();

            } while (!m);


        }

        private static void Gopher()
        {
            bool l = false;



            do
            {
                System.Console.Clear();
                System.Console.WriteLine("-----------------------------------------------------------------------");
                System.Console.WriteLine("***********************************************************************");
                System.Console.WriteLine("-----------------------------------------------------------------------");
                System.Console.WriteLine("");
                System.Console.WriteLine("             --      --       --        --        --     --");
                System.Console.WriteLine("              --    -- --    --         --        -- --  --");
                System.Console.WriteLine("               --  --   --  --          --        --  -- --");
                System.Console.WriteLine("                 --      --             --        --     --");
                System.Console.WriteLine("");
                System.Console.WriteLine("                                Gopher 5");
                System.Console.WriteLine("");
                System.Console.WriteLine("");
                System.Console.WriteLine("1. View Latest Drawing and its Winning Numbers ");
                System.Console.WriteLine("2. View Game Collection of Drawings");
                System.Console.WriteLine("3. To return to the Main Menu");
                System.Console.WriteLine("");
                System.Console.WriteLine("-----------------------------------------------------------------------");
                System.Console.WriteLine("***********************************************************************");
                System.Console.WriteLine("-----------------------------------------------------------------------");
                System.Console.WriteLine("");
                System.Console.Write("Please make your selection:");


                string select = System.Console.ReadLine();
                int power;

                int page = 0;
                int row = 0;


                power = int.Parse(select);

                LotteryDrawing drawing = new LotteryDrawing();
                drawing = LotteryDrawingDAL.GetItem(3);

                DrawingNumberCollection number = new DrawingNumberCollection();
                number = DrawingNumberDAL.GetCollection(14);



                switch (power)
                {

                    case 0:
                        l = true;
                        continue;

                    case 1:
                        System.Console.Clear();
                        System.Console.WriteLine(drawing.GetDrawing());
                        foreach (DrawingNumber item in number)
                        {
                            //System.Console.WriteLine(item.GetItem());
                        }
                        System.Console.WriteLine("");
                        System.Console.WriteLine(" Press any key to return to Menu");
                        break;
                    case 2:
                        System.Console.Clear();
                        System.Console.WriteLine("Enter Page Number\t\t");
                        page = Convert.ToInt32(System.Console.ReadLine());

                        System.Console.WriteLine("Enter Number of Rows to view\t\t");
                        row = Convert.ToInt32(System.Console.ReadLine());
                        System.Console.Clear();

                        LotteryDrawingCollection draw = new LotteryDrawingCollection();
                        draw = LotteryDrawingDAL.GetCollection(3, page, row);
                        foreach (LotteryDrawing item in draw)
                        {
                            System.Console.WriteLine(item.GetDrawing());
                        }

                        System.Console.WriteLine("");
                        System.Console.WriteLine(" Press any key to return to Menu");
                        break;

                    case 3:
                        Project();
                        break;
                    case 4:
                        North();
                        break;

                    default:
                        if (power > 4)
                        {
                            Error();
                        }
                        else
                            Error();
                        continue;
                }

                System.Console.ReadKey();
                System.Console.Clear();

            } while (!l);
        }

        private static void North()
        {
            bool l = false;



            do
            {
                System.Console.Clear();
                System.Console.WriteLine("-----------------------------------------------------------------------");
                System.Console.WriteLine("***********************************************************************");
                System.Console.WriteLine("-----------------------------------------------------------------------");
                System.Console.WriteLine("");
                System.Console.WriteLine("             --      --       --        --        --     --");
                System.Console.WriteLine("              --    -- --    --         --        -- --  --");
                System.Console.WriteLine("               --  --   --  --          --        --  -- --");
                System.Console.WriteLine("                 --      --             --        --     --");
                System.Console.WriteLine("");
                System.Console.WriteLine("                                Northstar Cash");
                System.Console.WriteLine("");
                System.Console.WriteLine("");
                System.Console.WriteLine("1. View Latest Drawing and its Winning Numbers ");
                System.Console.WriteLine("2. View Game Collection of Drawings");
                System.Console.WriteLine("3. To return to the Main Menu");
                System.Console.WriteLine("");
                System.Console.WriteLine("-----------------------------------------------------------------------");
                System.Console.WriteLine("***********************************************************************");
                System.Console.WriteLine("-----------------------------------------------------------------------");
                System.Console.WriteLine("");
                System.Console.Write("Please make your selection:");


                string select = System.Console.ReadLine();
                int power;

                int page = 0;
                int row = 0;


                power = int.Parse(select);

                LotteryDrawing drawing = new LotteryDrawing();
                drawing = LotteryDrawingDAL.GetItem(4);

                DrawingNumberCollection number = new DrawingNumberCollection();
                number = DrawingNumberDAL.GetCollection(28);



                switch (power)
                {

                    case 0:
                        l = true;
                        continue;

                    case 1:
                        System.Console.Clear();
                        System.Console.WriteLine(drawing.GetDrawing());
                        foreach (DrawingNumber item in number)
                        {
                            //System.Console.WriteLine(item.GetItem());
                        }
                        System.Console.WriteLine("");
                        System.Console.WriteLine(" Press any key to return to Menu");
                        break;
                    case 2:
                        System.Console.Clear();
                        System.Console.WriteLine("Enter Page Number\t\t");
                        page = Convert.ToInt32(System.Console.ReadLine());

                        System.Console.WriteLine("Enter Number of Rows to view\t\t");
                        row = Convert.ToInt32(System.Console.ReadLine());
                        System.Console.Clear();

                        LotteryDrawingCollection draw = new LotteryDrawingCollection();
                        draw = LotteryDrawingDAL.GetCollection(4, page, row);
                        foreach (LotteryDrawing item in draw)
                        {
                            System.Console.WriteLine(item.GetDrawing());
                        }

                        System.Console.WriteLine("");
                        System.Console.WriteLine(" Press any key to return to Menu");
                        break;

                    case 3:
                        Project();
                        break;
                    case 4:
                        North();
                        break;

                    default:
                        if (power > 4)
                        {
                            Error();
                        }
                        else
                            Error();
                        continue;
                }

                System.Console.ReadKey();
                System.Console.Clear();

            } while (!l);
        }

        private static void Error()
        {
            System.Console.Clear();
            System.Console.WriteLine("                   Please select a valid Number!");
        }

    }


}



