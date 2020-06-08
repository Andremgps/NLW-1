namespace backend.Data.Abstract
{
    public interface IDatabaseTransaction : System.IDisposable
    {
        void Commit();
        void Rollback();
    }
}