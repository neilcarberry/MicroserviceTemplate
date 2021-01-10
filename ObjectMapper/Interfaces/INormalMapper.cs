namespace ObjectMapper.Interfaces
{
    public interface INormalMapper<TIn, TOut>
    {
        TOut Map(TIn @in);
        TIn Map(TOut @in);
    }
}
