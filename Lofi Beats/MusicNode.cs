using Android.Media;
using System.Collections.Generic;

namespace Lofi_Beats
{
    public class MusicNode
    {
        //Id, and location in List
        public int Id { get; private set; }

        //Audio File
        public MediaPlayer Player { get; private set; }

        //Pointer to next MusicNdoe
        public MusicNode Next { get; set; }

        public static MainActivity MainAct { private get; set; }

        //Static List of all MusicNodes
        public static List<MusicNode> MusicList { get; private set; }

        public MusicNode(int Id)
        {
            this.Id = Id;
            Next = null;

            //Initializes the Music Player
            Player = MediaPlayer.Create(MainAct, Resource.Raw.testSound);
            Player.Completion += (sender, e) =>
            {
                TrackManager.Next(this);
            };

            //Loads into list
            if (MusicList == null)
            {
                MusicList = new List<MusicNode>();
            }
            MusicList.Add(this);
        }
    } 
}