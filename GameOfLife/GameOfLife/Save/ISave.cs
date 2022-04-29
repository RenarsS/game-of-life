
namespace GameOfLife.Utils
{
    public interface ISave<T>
    {
        public void Retain(T entitiy);

        public T Restore(string fileName);
    }
}
