using Microsoft.AspNetCore.Mvc;
using TMS.Models;
using TMS.Services;

namespace TMS.Api.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class TaskController : ControllerBase
    {
        private readonly TaskServices _taskServices;

        public TaskController(TaskServices taskServices)
        {
            _taskServices = taskServices;
        }

        [HttpGet]
        public ActionResult<List<AllTasks>> GetTasks()
        {
            var tasks = _taskServices.GetTasks();
            return Ok(tasks);
        }

        [HttpGet("{id}")]
        public ActionResult<AllTasks> GetTaskById(int id)
        {
            var task = _taskServices.GetTaskById(id);
            if (task == null)
            {
                return NotFound();
            }
            return Ok(task);
        }

        /* [HttpPost]
         public ActionResult<string> AddTask(AllTasks task)
         {
             var result = _taskServices.AddTasks(task);
             return Ok(result);
         }*/
        [HttpPost]
        public ActionResult<AllTasks> AddTask(AllTasks task)
        {
            try
            {
                var addedTask = _taskServices.AddTask(task);
                return Ok(addedTask);
            }
            catch (Exception ex)
            {
                // Log or handle the exception
                return StatusCode(500, "Internal server error"); // Return a 500 error response
            }
        }


        [HttpPut("{id}")]
        public ActionResult<string> UpdateTask(int id, AllTasks task)
        {
            var result = _taskServices.UpdateTask(id, task);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public ActionResult<string> DeleteTask(int id)
        {
            _taskServices.DeleteTasks(id);
            return Ok("Task deleted successfully");
        }
    }
}