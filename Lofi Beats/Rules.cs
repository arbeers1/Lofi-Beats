
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
                int selected = 0;
                //Gets random number to set as rule
                //Do-while loop makes sure that Random number is not already selected in the first row
                do
                {
                    selected = r.Next(40);
                } while (selected == i);
                RuleSet1[1, i] = selected;
                do
                {
                    selected = r.Next(40);
                } while (selected == i);
                RuleSet1[2, i] = selected;
                new MusicNode(i);
            }

            RuleSet2 = new int[3, 10];
            for(int i = 40; i < 50; i++)
            {
                RuleSet2[0, i - 40] = i;
                RuleSet2[1, i - 40] = r.Next(40, 50);
                RuleSet2[2, i - 40] = r.Next(40, 50);
                new MusicNode(i);
            }

        }

        /// <summary>
        /// Looks up the rules for a given MusicNode. ie the two Nodes which are related to the target node.
        /// </summary>
        /// <param name="target">target to search, 0-74</param>
        /// <exception cref="ArgumentException">Throws when target is outside bounds</exception>
        /// <returns>MusicNode[] of size 2</returns>
        public static MusicNode[] LookUpRules(int target)
        {
           if(target < 0 || target > 74)
            {
                throw new ArgumentException();
            }
            MusicNode[] list;
           if(target < 40)
            {
               list = new MusicNode[] {MusicNode.MusicList[RuleSet1[1, target]], MusicNode.MusicList[RuleSet1[2, target]] };
            }
            else
            {
                list = new MusicNode[] { MusicNode.MusicList[RuleSet2[1, target - 40]], MusicNode.MusicList[RuleSet2[2, target - 40]] };
            }
            return list;
        }

    }
}