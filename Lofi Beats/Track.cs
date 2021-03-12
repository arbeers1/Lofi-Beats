
using Android.Media;
using System;
using System.Collections.Generic;

namespace Lofi_Beats
{
    public class Track
    {
        //Audio Player
        private MediaPlayer Player;

        private Random r;

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
            r = new Random();
            int CurrentIndex = 0;
            //Gets random starting index, depending on track type
            if (type)
            {
                CurrentIndex = r.Next(40);
            }
            else
            {
                CurrentIndex = r.Next(40, 50);
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
            BuildPlayer(CurrentNode);
            Player.Start();
        }

        /// <summary>
        /// Method called when a MusicNode Player finishes playing an audio file. Queues are updating and next audio file is selected and started.
        /// </summary>
        /// <param name="CurrentNode">The node which finished execution</param>
        private void NextMusic(MusicNode CurrentNode)
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
            BuildPlayer(CurrentNode);
            Player.Start();
        }

        /// <summary>
        /// Builds the desired MediaPlayer given a MusicNode
        /// </summary>
        /// <param name="CurrentNode">Node to build music player from</param>
        private void BuildPlayer(MusicNode CurrentNode)
        {
            int iterations = r.Next(1, 4);
            Player.Release();
            Player = MediaPlayer.Create(MusicNode.MainAct, CurrentNode.ResourceLocation);
            if (CurrentNode.Id > 39)
            {
                Player.SetVolume((float) .1, (float) .1);
            }
            Player.Completion += (sender, e) =>
            {
                iterations--;
                if (iterations == 0)
                {
                    Player.Release();
                    NextMusic(CurrentNode);
                }
                else
                {
                    Player.SeekTo(0);
                    Player.Start();
                }
            };
        }
   }
}