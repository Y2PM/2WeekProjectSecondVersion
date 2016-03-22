using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProjectFDM
{
    public class DecathonGame
    {
        List<int> lotterylist;
        List<int> userlotterylist;
        int result;
        int matchcount;

        public int GetOneTen()
        {
            Random rand = new Random();
            int result = rand.Next(1, 10);
            //generates a random number between 1 and 10
            return result;
        }

        public bool DecWin()
        {
            if (GetOneTen() % 2 == 0)
            {
                //if the result is even
                //add from the context the game payout value to the user account value
                return true;
            }
            else
            {
                return false;
            }
        }

        public List<int> Lottery()
        {
            Random rand = new Random();

            List<int> unsortedlotterylist = new List<int>();
            
            while (unsortedlotterylist.Count < 6)
            {
                            result = rand.Next(1, 50);
                            if (unsortedlotterylist.Contains(result))
                            {
                                result ++;
                            }
                            unsortedlotterylist.Add(result);
            }
            // this makes sure the list contains 6 unique, random numbers between 1 and 50
            lotterylist = unsortedlotterylist.OrderBy(v => v).ToList();
            //this sorts the list in ascending order
            return lotterylist;
            
        }

        public bool userlottovalidate(int one, int two, int three, int four, int five, int six)
        {
            //returns true if the user's 6 given numbers are between 1 and 50
            List<int> numbers = new List<int>();
            List<int> unsorteduserlotterylist = new List<int>();
            numbers.Add(one);
            numbers.Add(two);
            numbers.Add(three);
            numbers.Add(four);
            numbers.Add(five);
            numbers.Add(six);

                foreach (var numb in numbers)
                {
                    if (!unsorteduserlotterylist.Contains(numb) && numb >= 1 && numb <= 50)
                    {
                        unsorteduserlotterylist.Add(numb);
                    }
                }
                if (unsorteduserlotterylist.Count == 6)
                {
                    return true;
                }
                else
                {
                    return false;
                }
        }

        public List<int> Userlottery(int one, int two, int three, int four, int five, int six)
        {
            List<int> unsorteduserlotterylist = new List<int>();
            if (userlottovalidate(one, two, three, four, five, six) == true)
            {
                //if the user's numbers pass validation (6 distinct numbers between 1 and 50)
                unsorteduserlotterylist.Add(one);
                unsorteduserlotterylist.Add(two);
                unsorteduserlotterylist.Add(three);
                unsorteduserlotterylist.Add(four);
                unsorteduserlotterylist.Add(five);
                unsorteduserlotterylist.Add(six);
                //the user's six numbers are added to a list
            }

            userlotterylist = unsorteduserlotterylist.OrderBy(v => v).ToList();
            //the list is sorted so it can be compared
            return userlotterylist;
        }

        public int Matcher(List<int> game, List<int> user)
        {
            //counts how many of the user's numbers occur in the lottery numbers
            foreach (var n in user)
            {
                if (game.Contains(n))
                {
                    matchcount++;
                }
            }
            return matchcount;
        }

        public bool Lotteryresult(List<int> game, List<int> user)
        {
            if (game == user)
            {
                //if the generated numbers are the same as the users return true
                return true;
            }
            else
            {
                return false;
            }
        }


        public bool LottoWin(int o, int t, int th, int f, int fi, int s)
        {
            List<int> game = Lottery();
            List<int> user = Userlottery(o, t, th, f, fi, s);
            int matches = Matcher(game, user);
            if (Lotteryresult(game, user) == true)
            {
                //when the generated numbers and the user numbers match
                //add from the context the game payout value to the user account value
                return true;
            }
            else if (matches == 4)
            {
                //if the user has 4 of the winning numbers the can get a quarter of the payout
                //decimal winamount = decimal payout value / 4
                //update member account to add winamount
                return true;
            }
            else if (matches == 5)
            {
                //the user gets a third of the payout
                //decimal winamount = decimal payout value / 3
                //update member account to add winamount
                //no other lotto conditions warrant a payout
                return true;
            }
            else
            {
                return false;
            }
        }

        public List<int> LuckyNumber()
        {
            //generates a number between 1 and 10. makes it occur 3 times in a list and all other values are distinct

            int lnumber = GetOneTen();
            List<int> numberlist = new List<int>();
            numberlist.Add(lnumber);
            numberlist.Add(lnumber);
            numberlist.Add(lnumber);

            while (numberlist.Count < 9)
            {
                result = GetOneTen();
                if (!numberlist.Contains(result))
                {
                    numberlist.Add(result);
                }
            }
            return numberlist;
        }

        public bool LuckyNWin(int user)
            {
            //if the user's number is the lucky number occuring 3 times in the list, they win
            List<int> lnumbers = LuckyNumber();
            int numcount = lnumbers.Where(x => x.Equals(user)).Count();
            if (numcount >= 3)
            {
                //add payout value to the user's account
                return true;
            }
            else
            {
                return false;
            }
    }

    }
}
