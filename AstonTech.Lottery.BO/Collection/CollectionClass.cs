using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;

namespace AstonTech.Lottery
{
    public class LotteryGameCollection : Collection<LotteryGameValue> { }
    public class LotteryDrawingCollection : Collection<LotteryDrawing> { }
    public class DrawingNumberCollection : Collection<DrawingNumber> { }
    public class DrawingTypeCollection : Collection<DrawingType> { }
    public class LotteryGameStateCollection : Collection<LotteryGameState> { }
    public class LotteryGameDetailCollection : Collection<LotteryGameDetail> { }
    public class StateNameCollection : Collection<StateName> { }
    public class OddCollection : Collection<Odd> { }
    public class MatchCollection : Collection<Match> { }
    public class WinCollection : Collection<Win> { }
    public class GameOddCollection : Collection<GameOdd> { }
}
