
using System;

namespace Lofi_Beats
{
    public class Track
    {
        //Queue for Audio
        private Queue<MusicNode> MQueue;

        //Future Queue when queue finishes
        private Queue<MusicNode> MNextQueue;

        /// <summary>
        /// Creates a new track
        /// </summary>
        /// <param name="type">Type indicates if it is a foreground track(track 1 if true) or background track(track 2 if false)</param>
        public Track(bool type)
        {
            Random r = new Random();
            if (type)
            {
                int CurrentIndex = r.Next(40);
                MQueue = new Queue<MusicNode>(MusicNode.MusicList[CurrentIndex]);
                MusicNode[] RuleList = Rules.LookUpRules(CurrentIndex);
                MNextQueue = new Queue<MusicNode>(RuleList[0]);
                MNextQueue.Add(RuleList[1]);
            }
            
        }

        /// <summary>
        /// Generates track audio
        /// </summary>
        public void StartMusic()
        {
            MusicNode CurrentNode = MQueue.Pop();
            CurrentNode.Player.Start();
        }

        public void NextMusic(MusicNode CurrentNode)
        {
            //Case for if queue is empty
            if (MQueue.isEmpty())
            {
                MQueue = MNextQueue;
                CurrentNode = MQueue.Pop();
                MusicNode[] RuleList = Rules.LookUpRules(CurrentNode.Id);
                MNextQueue = new Queue<MusicNode>(RuleList[0]);
                MNextQueue.Add(RuleList[1]);
            }
            else //Case for when Queue is not empty
            {
                CurrentNode = MQueue.Pop();
                MusicNode[] RuleList = Rules.LookUpRules(CurrentNode.Id);
                MNextQueue.Add(RuleList[0]);
                MNextQueue.Add(RuleList[1]);
            }

            //Play new sound 
            CurrentNode.Player.Start();
        }
   }
}