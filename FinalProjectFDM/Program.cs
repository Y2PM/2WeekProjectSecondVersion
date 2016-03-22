using DBLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using WCFServiceCL.Create;

namespace FinalProjectFDM
{
    public class Program
    {
        static void Main(string[] args)
        { 
            /*
            DecathonGame decgame = new DecathonGame();
            List<int> lotto = decgame.Lottery();
            //foreach (var num in lotto)
            //{
            //    Console.WriteLine(num);
            //}
            List<int> userlotto = decgame.Userlottery(48, 35, 27, 11, 14, 8);
            if (decgame.Lotteryresult(lotto, userlotto) == true)
            {
                Console.WriteLine("You have won!");
            }
            else
            {
                Console.WriteLine("You have lost. Better Luck Next Time.");
            }
            Console.Read();
            */

            /*
            //Trying Bet method.
            BetClass BC = new BetClass();
            List<string> TryGame = BC.Bet(73, 5);
            Console.WriteLine("You "+TryGame[0] + ", your return is £"+TryGame[1]+"p");
            Console.ReadLine();
            */

            /*
            //Testing service with a makeshift client:
            EndpointAddress endpoint = new EndpointAddress("http://trnlon11566:8081/CreateGameService");
            ICreateGameService proxy = ChannelFactory<ICreateGameService>.CreateChannel(new BasicHttpBinding(), endpoint);
            //             Contract                                                      Binding            Address
            Game game = new Game();
            game.game_id = 10;
            game.name = "Game1";
            game.payout = 20;
            proxy.CreateGameServiceMethod(game);
            */
            
        }
    }
}
