﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ASP.Models
{
    public class GamesModel
    {
        public int one { get; set; }
        public int two { get; set; }
        public int three { get; set; }
        public int four { get; set; }
        public int five { get; set; }
        public int six { get; set; }
        public int usernumber { get; set; }
        public decimal priceO { get; set; }
        public decimal priceL { get; set; }
        public decimal priceLN { get; set; }
        public string fundserrorO { get; set; }
        public string fundserrorL { get; set; }
        public string fundserrorLN { get; set; }
        public string lotteryerror { get; set; }
        public string resultmessageO { get; set; }
        public string resultmessageL { get; set; }
        public string resultmessageLN { get; set; }
        public List<int> lotterynumbers { get; set; }
        public string luckynumber { get; set; }
        public string oddevennumber { get; set; }
        public string spaces { get; set; }
        public string announceO { get; set; }
        public string announceL { get; set; }
        public string announceLN { get; set; }

    }
}
