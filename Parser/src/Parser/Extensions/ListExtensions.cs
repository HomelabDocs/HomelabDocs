namespace Parser.Extensions;

public static class ListExtensions
{
    public static T AddNewEntity<T>(this List<T> input, T entity)
    {
        input.Add(entity);
        return entity;
    }
}