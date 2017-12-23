namespace AnimalRescue.Core
{
    public interface ICommand
    {
    }

    public interface ICommand<TResult> : ICommand
    {
    }
}
