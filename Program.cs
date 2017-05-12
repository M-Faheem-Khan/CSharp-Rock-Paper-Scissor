// real_magical_unicorn
// 5/12/2017
// program.cs
// Simple Rock Paper Scissor Game for Command line
// Language C#
// DotNet Core version 1.1.0

using System;
using System.Collections.Generic;

namespace ConsoleApplication
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.Clear();
            Console.WriteLine("Rock Paper Scissor");
            String un = "";
            Boolean flag, flagx;
            flag = true;
            while (flag){
                Console.WriteLine("Username has to be 6 charachters long.");
                Console.Write("Username: ");
                un = Console.ReadLine();
                if (un.Length == 6){
                    flag = false;
                } else {
                    Console.WriteLine("Username too long");
                    flag = true;
                }
            }

            Console.Clear();
            Console.Write("Menu\n1) " + un + " VS Computer \n2) Quit \n:");
            flagx = true;
            while(flagx){
                ConsoleKeyInfo info;
                info = Console.ReadKey();
                if (info.KeyChar == '1'){
                    start_game(un);
                    flagx = false;
                } else if(info.KeyChar == '2'){
                    Environment.Exit(0);
                    flagx = false;
                } else {
                    Console.WriteLine("\nInvalid Option");
                }
            }
        }
        public static void start_game(string un){
            String[] rps = new String[3]{"Rock", "Paper", "Scissor"};
            Console.WriteLine("The Game goes up to 5 round. \nWinner is determined by the most number of points in the five rounds");
            int u = 0, c = 0, j = 0, round_number = 0;
            int user_rps_pick;
            while (j < 5){
                j++;
                user_rps_pick = user_pick(rps);
                if (user_rps_pick == 5){
                    Console.WriteLine("\nInvalid Option");
                    System.Threading.Thread.Sleep(500);
                    user_rps_pick = user_pick(rps);
                } else{
                    Console.WriteLine("\n" + un + " Picked " + rps[user_rps_pick-1]);
                    int cpu_rps_pick;
                    cpu_rps_pick = cpu_pick();
                    Console.WriteLine("Computer Picked " + rps[cpu_rps_pick-1]);
                    // int[] rps_picks = {user_rps_pick, cpu_rps_pick};
                    int check = result(user_rps_pick, cpu_rps_pick, rps);
                    if (check == 1){
                        Console.WriteLine("\n" + un + " won this round");
                        u = u + 1;
                        round_number = round_number + 1;
                        score_board(u, c, round_number, un);
                    } else if(check == 2) {
                        Console.WriteLine("Cpu won this round");
                        c = c + 1;
                        round_number = round_number + 1;
                        score_board(u, c, round_number, un);
                    } else{
                        Console.WriteLine("Draw");
                        round_number = round_number + 1;
                        score_board(u, c, round_number, un);
                    }
                }
            }
        }

        public static int user_pick(string[] rps){
            Console.Clear();
            Console.WriteLine("Pick");
            rps_in_array(rps);
            ConsoleKeyInfo user_pick;
            Console.Write(":");
            user_pick = Console.ReadKey();
            if (user_pick.KeyChar == '1'){
                return 1;
            } else if (user_pick.KeyChar == '2'){
                return 2;
            } else if (user_pick.KeyChar == '3'){
                return 3;
            } else {
                return 5;
            }
        }

        public static void rps_in_array(string[] rps){
            for (int i = 1; i < rps.Length+1; i++){
                Console.WriteLine("{0}) {1}", i, rps[i-1]);
            }
        }

        public static int cpu_pick(){
            Random rnd = new Random();
            int cpu_rps_pick = rnd.Next(1,3);
            return cpu_rps_pick;
        }

        public static int result(int user_rps_pick, int cpu_rps_pick, string[] rps){
            // Rock = Rock
            user_rps_pick = user_rps_pick - 1;
            cpu_rps_pick = cpu_rps_pick - 1;
            if (rps[user_rps_pick] == rps[0] && rps[cpu_rps_pick] == rps[0]){
                return 3;
            } else if(rps[user_rps_pick] == rps[1] && rps[cpu_rps_pick] == rps[1]){
                return 3;
            } else if(rps[user_rps_pick] == rps[2] && rps[cpu_rps_pick] == rps[2]){
                return 3;
            } else if(rps[user_rps_pick] == rps[0] && rps[cpu_rps_pick] != rps[1]){
                return 1;
            } else if(rps[user_rps_pick] == rps[1] && rps[cpu_rps_pick] != rps[2]){
                return 1;
            } else if(rps[user_rps_pick] == rps[2] && rps[cpu_rps_pick] != rps[1]){
                return 1;
            } else {
                return 2;
            }
        }

        public static void score_board(int u, int c, int round_number, string un){
            // Console.Clear();
            Console.WriteLine("Round " + round_number);
            Console.WriteLine("\nPlayer   |   Score");
            Console.WriteLine("------------------");
            Console.WriteLine(un + "   |   " + u);
            Console.WriteLine("------------------");
            Console.WriteLine("CPU      |   " + c);
            Console.ReadKey();
            if (u > c && round_number == 5){
                Console.WriteLine("You won");
            } else {
                Console.WriteLine("CPU won");
            }
        }

    }
}
