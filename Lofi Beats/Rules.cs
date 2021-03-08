
using System;

namespace Lofi_Beats
{
    /// <summary>
    /// Defines the logic of the music composition algorithm. Any given music node must follow a specific path as defined by rules.
    /// Example:
    /// 
    /// If rules are defined by:
    /// 1 -> 2, 3
    /// 2 -> 1
    /// 3 -> 2
    /// 
    /// Then the algorithm follows:
    /// Iteration 1: 1
    /// Iteration 2: 2, 3
    /// Iteration 3: 1, 2
    /// Iteration 4: 2, 3, 1
    /// </summary>
    public static class Rules
    {
        //Defines the rule set for track 1
        public static int[,] RuleSet1 { get; private set; }

        //Defines the rule set for track 2
        public static int[,] RuleSet2 { get; private set; }

        /// <summary>
        /// Defines the rule set for RuleSets 1&2.
        /// 1st row contains int id of MusicNode in order. (Same as column index)
        /// 2nd & 3rd row contain 2 other random ints within the size of the array which refer to another MusicNode
        /// </summary>
        public static void GenerateRules()
        {
            if(RuleSet1 != null)
            {
                return;
            }

            Random r = new Random();
            RuleSet1 = new int[3, 40];
            for(int i = 0; i < 40; i++)
            {
                RuleSet1[0, i] = i;
                RuleSet1[1, i] = r.Next(40);
                RuleSet1[2, i] = r.Next(40);
                new MusicNode(i);
            }

        }

        public static int[] LookUp(int target)
        {
            return null;
        }

    }
}