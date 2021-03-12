
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
            Track1.Play();
            Track2.Play();
        }

        /// <summary>
        /// Pause Audio
        /// </summary>
        public void pause()
        {
            Track1.Pause();
            Track2.Pause();
        }

    }
}