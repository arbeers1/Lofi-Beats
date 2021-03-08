
namespace Lofi_Beats
{
    public class Track
    {
        //Queue for Audio
        private Queue<MusicNode> queue;

        private Queue<MusicNode> nextQueue;

        public Track()
        {
            queue = new Queue<MusicNode>(null);
            nextQueue = new Queue<MusicNode>(null);
        }
    }
}