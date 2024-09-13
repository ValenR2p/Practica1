namespace Application.Interface
{
    public interface ITaskCommand
    {
        public System.Threading.Tasks.Task InsertTask(Domain.Entities.Task task);
        public System.Threading.Tasks.Task UpdateTask(Domain.Entities.Task task);
    }
}
