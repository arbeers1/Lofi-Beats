
namespace Lofi_Beats
{
    public class MusicNode
    {
        public int Id { get; }

        public Android.Media.MediaPlayer Player { get; }

        public MusicNode Next { get; set; }

        public MusicNode(int Id)
        {
            this.Id = Id;
            Player = null;
            Next = null;
        }
    }
}