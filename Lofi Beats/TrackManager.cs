
namespace Lofi_Beats
{
    /// <summary>
    /// Manages multiple tracks
    /// </summary>
    public class TrackManager
    {
        //Tracks - Each play a single audio file at a time
        private Track Track1;

        private Track Track2;

        public TrackManager()
        {
            Track1 = new Track();
            Track2 = new Track();
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
    }
}