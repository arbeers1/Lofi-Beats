using Android.Content.Res;
using Android.Media;
using System.Collections;
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

        //Static List of all MusicNodes
        public static List<MusicNode> MusicList { get; private set; }

        public static MainActivity MainAct { private get; set; }

        public static Resources Resources { private get; set; }

        public MusicNode(int Id)
        {
            this.Id = Id;
            Next = null;

            //Initializes the Music Player

            string soundId = "a" + (Id+1).ToString();
            System.Diagnostics.Debug.WriteLine(soundId);
            Player = MediaPlayer.Create(MainAct, Resources.GetIdentifier(soundId, "raw", "com.companyname.lofi_beats"));
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