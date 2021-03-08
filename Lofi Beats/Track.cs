
namespace Lofi_Beats
{
    public class Track
    {
        //Queue for Audio
        private Queue queue;

        private Queue nextQueue;

        public Track()
        {
            queue = new Queue();
            nextQueue = new Queue();
        }
    }
}