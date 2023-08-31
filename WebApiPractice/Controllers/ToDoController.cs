using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApiPractice.Entities;
using WebApiPractice.Requests;
using WebApiPractice.ResponseDto;

namespace WebApiPractice.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ToDoController : ControllerBase
    {
        //make this static so that you have only one instance 
        private static List<Todo> _todos = new List<Todo>()
        {
            { new Todo()
                {
                    Id = Guid.NewGuid(),
                    Title = "Todo one", 
                    Description = "Todo one description",
                }
            }
        };

        private readonly IMapper _mapper;
        public ToDoController(IMapper mapper)
        {
            _mapper = mapper;
        }
        //get todos
        [HttpGet]
        public ActionResult<List<TodoResponse>> GetAllToDo() 
        {
            //transformation
           // var todos = _mapper.Map<List<TodoResponse>>(_todos);
            var todos = _mapper.Map<List<Todo>, List<TodoResponse>>(_todos);
            return Ok(todos);
        }

        [HttpGet("{id}")]
        public ActionResult<TodoResponse> GetToDo(Guid id)
        {
            //find 
            try 
            {
                var existingTodo = _todos.First(x => x.Id == id);
                //transformation
                var todo = _mapper.Map<TodoResponse>(existingTodo);
                return Ok(todo);
            }
            catch(Exception ex) 
            {
                return BadRequest(ex.Message);
            }
        }

        //adding a new entry to a list
        [HttpPost]
        //public ActionResult<TodoSuccess> AddTodo([FromBody]AddTodo todo)
        public ActionResult<TodoSuccess> AddTodo(AddTodo todo)
        {
            //automapper - to add a todo to the list it's supposed to be a type todo
            //but we are getting the body as type AddTodo
            //2 different classes
            //change from an instance of AddTodo to an instance of Todo and we use automap
            var newTodo = _mapper.Map<Todo>(todo);
           newTodo.Id = Guid.NewGuid();
            _todos.Add(newTodo);
            return Ok(new TodoSuccess(201, "Todo Created Successfully"));
        }

        [HttpPut("{id}")]
        public ActionResult<TodoSuccess> UpdateTodo(Guid id, AddTodo updateTodo) 
        {
            var existingTodo = _todos.FirstOrDefault(x => x.Id == id);
            if (existingTodo != null)
            {
                //update
                //existingTodo.Title = updateTodo.Title; 
                //existingTodo.Description = updateTodo.Description;
                //return Ok(new TodoSuccess(204, "Todo Updated successfully"));

                //or 
                _mapper.Map(updateTodo, existingTodo);
                return Ok(new TodoSuccess(204, "Todo Updated successfully"));
            }
                return NotFound("Todo not found");
        }

        [HttpDelete("{id}")]
        public ActionResult<TodoSuccess> DeleteTodo(Guid id )
        {
            var existingTodo = _todos.FirstOrDefault(x => x.Id == id);
            if (existingTodo != null)
            {
                _todos.Remove(existingTodo);
                return Ok(new TodoSuccess(204, "Todo Deleted Successfully"));
            }
            return NotFound("Todo not found");
        }
    }
}
