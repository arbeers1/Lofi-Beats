
using Android.Media;
using Java.Lang;
using System;
using System.Collections.Generic;

namespace Lofi_Beats
{
    public class Track
    {
        //Audio Player
        private MediaPlayer Player;

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
            MQueue = new Queue<MusicNode>();
            MQueue.Enqueue(MusicNode.MusicList[CurrentIndex]);
            MusicNode[] RuleList = Rules.LookUpRules(CurrentIndex);
            MNextQueue = new Queue<MusicNode>();
            MNextQueue.Enqueue(RuleList[0]);
            MNextQueue.Enqueue(RuleList[1]);
        }

        /// <summary>
        /// Generates track audio
        /// </summary>
        public void StartMusic()
        {
            MusicNode CurrentNode = MQueue.Dequeue();
            Player = MediaPlayer.Create(MusicNode.MainAct, CurrentNode.ResourceLocation);
            Player.Start();

            Player.Completion += (sender, e) =>
            {
                Player.Release();
                TrackManager.Next(CurrentNode);
            };
        }

        /// <summary>
        /// Method called when a MusicNode Player finishes playing an audio file. Queues are updating and next audio file is selected and started.
        /// </summary>
        /// <param name="CurrentNode">The node which finished execution</param>
        public void NextMusic(MusicNode CurrentNode)
        {
            //Case for if queue is empty
            if (MQueue.Count == 0)
            {
                MQueue = MNextQueue;
                CurrentNode = MQueue.Dequeue();
                MusicNode[] RuleList = Rules.LookUpRules(CurrentNode.Id);
                MNextQueue = new Queue<MusicNode>();
                MNextQueue.Enqueue(RuleList[0]);
                MNextQueue.Enqueue(RuleList[1]);
            }
            else //Case for when Queue is not empty
            {
                CurrentNode = MQueue.Dequeue();
                MusicNode[] RuleList = Rules.LookUpRules(CurrentNode.Id);
                MNextQueue.Enqueue(RuleList[0]);
                MNextQueue.Enqueue(RuleList[1]);
            }
            //Play new sound 
            Player = MediaPlayer.Create(MusicNode.MainAct ,CurrentNode.ResourceLocation);
            Player.Start();
            Player.Completion += (sender, e) =>
            {
                Player.Release();
                TrackManager.Next(CurrentNode);
            };
        }
   }
}