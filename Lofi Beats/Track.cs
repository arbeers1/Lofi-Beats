
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
            int CurrentIndex = 0;
            //Gets random starting index, depending on track type
            if (type)
            {
                CurrentIndex = r.Next(40);
            }
            else
            {
                CurrentIndex = r.Next(40, 75);
            }
            //Initializes Queues
            MQueue = new Queue<MusicNode>(MusicNode.MusicList[CurrentIndex]);
            MusicNode[] RuleList = Rules.LookUpRules(CurrentIndex);
            MNextQueue = new Queue<MusicNode>(RuleList[0]);
            MNextQueue.Add(RuleList[1]);

        }

        /// <summary>
        /// Generates track audio
        /// </summary>
        public void StartMusic()
        {
            MusicNode CurrentNode = MQueue.Pop();
            CurrentNode.Player.Start();
        }

        /// <summary>
        /// Method called when a MusicNode Player finishes playing an audio file. Queues are updating and next audio file is selected and started.
        /// </summary>
        /// <param name="CurrentNode">The node which finished execution</param>
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