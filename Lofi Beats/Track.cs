
namespace Lofi_Beats
{
    public class Track
    {
        //Queue for Audio
        private Queue<MusicNode> queue;

        private Queue<MusicNode> nextQueue;

        /// <summary>
        /// Creates a new track
        /// </summary>
        /// <param name="type">Type indicates if it is a foreground track(track 1 if true) or background track(track 2 if false)</param>
        public Track(bool type)
        {

            queue = new Queue<MusicNode>(null);
            nextQueue = new Queue<MusicNode>(null);
        }
    }
}