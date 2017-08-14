namespace UI.ViewModels.Base
{
    public interface IEditable<T>
    {
        void Edit(T entity);
    }
}