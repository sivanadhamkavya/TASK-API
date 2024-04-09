using System.Linq;
using TMS.Data;
using TMS.Models;

namespace TMS.Services
{
    public class TaskServices
    {
        private readonly DbContextDemo _dbContextDemo;

        public TaskServices(DbContextDemo dbContext)
        {
            _dbContextDemo = dbContext;
        }

        public List<AllTasks> GetTasks()
        {
            return _dbContextDemo.Tasks.ToList();
        }

        /* public string AddTasks(AllTasks task)
         {
             if (task == null)
             {
                 return "Task data is null";
             }

             if (_dbContextDemo.Tasks.Any(a => a.Id == task.Id))
             {
                 return "Task already exists";
             }

             _dbContextDemo.Tasks.Add(task);
             _dbContextDemo.SaveChanges();
             return "Task added successfully";
         }
        */
        public AllTasks AddTask(AllTasks task)
        {
            if (task == null)
            {
                throw new ArgumentNullException(nameof(task), "Task data is null");
            }

            try
            {
                if (_dbContextDemo.Tasks.Any(a => a.Id == task.Id))
                {
                    throw new InvalidOperationException("Task already exists");
                }

                _dbContextDemo.Tasks.Add(task);
                _dbContextDemo.SaveChanges();

                return task; // Return the added task object
            }
            catch (Exception ex)
            {
                // Log or handle the exception
                throw; // Rethrow the exception
            }
        }

        public void DeleteTasks(int id)
        {
            var taskToDelete = _dbContextDemo.Tasks.FirstOrDefault(t => t.Id == id);
            if (taskToDelete != null)
            {
                _dbContextDemo.Tasks.Remove(taskToDelete);
                _dbContextDemo.SaveChanges();
            }
        }

        public AllTasks GetTaskById(int id)
        {
            return _dbContextDemo.Tasks.FirstOrDefault(t => t.Id == id);
        }

        public AllTasks UpdateTask(int id, AllTasks updatedTask)
        {
            if (updatedTask == null)
            {
                return null;
            }

            var existingTask = _dbContextDemo.Tasks.FirstOrDefault(t => t.Id == id);
            if (existingTask != null)
            {
                existingTask.Title = updatedTask.Title;
                existingTask.Description = updatedTask.Description;
                existingTask.DueDate = updatedTask.DueDate;
                _dbContextDemo.SaveChanges();
            }
            return existingTask;
        }
    }
}
