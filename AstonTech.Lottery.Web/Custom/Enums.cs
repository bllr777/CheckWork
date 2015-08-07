using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AstonTech.Lottery.Web
{
    public enum LotteryNavigation
    {
        /// <summary>
        /// 
        /// </summary>
        None,
        LotteryBasic,
        Drawing,
        WinningNumber,
        State,
        Match,
        Odd,
        Win
        
    }

    public enum MasterNavigation
    {
        None,
        LotteryGames,
        Drawings,
        Maintenance
    }

    public enum LotteryMaintenanceNavigation
    {
        None,
        LotteryLookup
    }
}