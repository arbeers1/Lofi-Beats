using Android.Content.Res;
using System.Collections.Generic;

namespace Lofi_Beats
{
    public class MusicNode
    {
        //Id, and location in List
        public int Id { get; private set; }

        //Pointer to next MusicNdoe
        public MusicNode Next { get; set; }

        //int id associated with the audio file location in resources
        public int ResourceLocation { get; private set; }

        //Static List of all MusicNodes
        public static List<MusicNode> MusicList { get; private set; }

        public static MainActivity MainAct { get; set; }

        public static Resources Resources { private get; set; }


        public MusicNode(int Id)
        {
            this.Id = Id;
            Next = null;

            string soundId = "a" + (Id+1).ToString();
            ResourceLocation = Resources.GetIdentifier(soundId, "raw", "com.companyname.lofi_beats");

            //Loads into list
            if (MusicList == null)
            {
                MusicList = new List<MusicNode>();
            }
            MusicList.Add(this);
        }
    } 
}