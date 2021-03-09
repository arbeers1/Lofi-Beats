
namespace Lofi_Beats
{
    /// <summary>
    /// Manages multiple tracks
    /// </summary>
    public class TrackManager
    {
        //Tracks - Each play a single audio file at a time
        private static Track Track1;

        private static Track Track2;

        public TrackManager()
        {
            Track1 = new Track(true);
            Track2 = new Track(false);
            Track1.StartMusic();
            Track2.StartMusic();
        }

        /// <summary>
        /// Play Audio
        /// </summary>
        public void play()
        {
            
        }

        /// <summary>
        /// Pause Audio
        /// </summary>
        public void pause()
        {

        }

        public static void Next(MusicNode Node)
        {
            if(Node.Id < 40)
            {
                Track1.NextMusic(Node);
            }
            else
            {
                Track2.NextMusic(Node);
            }
        }
    }
}