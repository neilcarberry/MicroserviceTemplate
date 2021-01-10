namespace ObjectMapper.Interfaces
{
    public interface IGenericMapper<TIn,TOut>
    {
        TOut Map(TIn inob);
        TIn Map(TOut inob);
        void MapToList();
    }
}