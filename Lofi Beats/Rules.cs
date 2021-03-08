using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

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
        public static int[][] RuleSet1 { get; private set; }

        //Defines the rule set for track 2
        public static int[][] RuleSet2 { get; private set; }

        public static void GenerateRules()
        {
   
        }

        public static int[] LookUp(int target)
        {
            return null;
        }

    }
}