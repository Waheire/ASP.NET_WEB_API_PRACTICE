using AutoMapper;
using WebApiPractice.Entities;
using WebApiPractice.Requests;
using WebApiPractice.ResponseDto;

namespace WebApiPractice.TodoProfiless
{
    public class TodosProfile : Profile
    {
        public TodosProfile()
        {
            CreateMap<Todo, TodoResponse>().ReverseMap();

            CreateMap<AddTodo, Todo>().ReverseMap();
        }
    }
}
