namespace InterpressExam.Data
{
    public class BaseRepository
    {
        public BaseRepository()
        {
            Context = new RssContext();
        }

        public RssContext Context;

    }
}
