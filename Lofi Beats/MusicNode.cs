
using System.Collections.Generic;

namespace Lofi_Beats
{
    public class MusicNode
    {
        //Id, and location in List
        public int Id { get; private set; }

        //Audio File
        public Android.Media.MediaPlayer Player { get; private set; }

        //Pointer to next MusicNdoe
        public MusicNode Next { get; set; }

        //Static List of all MusicNodes
        public static List<MusicNode> MusicList { get; private set; }

        public MusicNode(int Id)
        {
            this.Id = Id;
            Player = null;
            Next = null;

            if(MusicList == null)
            {
                MusicList = new List<MusicNode>();
            }
            MusicList.Add(this);
        }
    }
}