using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using SMS.Domain.Entities;

namespace SMS.WebAPI.Controllers;

[Route("api/[controller]")]
[Authorize (Roles="Administrator, Instructor")]
[ApiController]
public class CoursesController(IMediator mediator) : ControllerBase
{
    [HttpPost("add")]
    [Authorize(Roles="Administrator")]
    public async Task<ActionResult> AddCourse([FromBody] AddCourseCommand command)
    {
        var commandResult = await mediator.Send(command);
        
        return Ok(commandResult);
    }

    [HttpPut("update")]
    [Authorize(Roles = "Administrator")]
    public async Task<ActionResult> UpdateCourse([FromBody] UpdateCourseCommand command)
    {
        var commandResult = await mediator.Send(command);
        
        return Ok(commandResult);
    }

    [HttpDelete("delete/{id:guid}")]
    [Authorize(Roles = "Administrator")]
    public async Task<ActionResult> DeleteCourse([FromRoute] Guid courseId)
    {
        var command = new DeleteCourseCommand{ Id = courseId};
        var commandResult = await mediator.Send(command);
        
        return Ok(commandResult);
    }

    [HttpPut("addstudent")]
    [Authorize(Roles = "Administrator")]
    public async Task<ActionResult> AddStudentToCourse([FromBody] AddStudentToCourseCommand command)
    {
        var commandResult = mediator.Send(command);
        
        return Ok(commandResult);
    }

    [HttpPut("removestudent")]
    [Authorize(Roles = "Administrator")]
    public async Task<ActionResult> RemoveStudentFromCourse([FromBody] RemoveStudentFromCourseCommand command)
    {
        var commandResult = mediator.Send(command);
    }
    
    [HttpGet("all")]
    public async Task<IActionResult> GetAllCourses()
    {
        var query = new GetListCategoryQuery();
        var queryResult = await mediator.Send(query);
        
        return Ok(queryResult);
    }

    [HttpGet("course/{id:guid}")]
    public async Task<IActionResult> GetCourseById([FromRoute] Guid id)
    {
        var query = new GetByIdCourseQuery{ Id = id};
        var queryResult = await mediator.Send(query);

        return Ok(queryResult);
    }

    [HttpGet("bydepartment/{id:long}")]
    public async Task<IActionResult> GetAllCoursesByDepartmentId([FromRoute] long id)
    {
        var query = new GetAllCoursesByDepartmentIdQuery { Id = id };
        var queryResult = await mediator.Send(query);
        
        return Ok(queryResult);
    }

    [HttpGet("bysemester/{semester}")]
    public async Task<IActionResult> GetAllCoursesBySemester([FromRoute] Semester semester)
    {
        if (!Enum.IsDefined(typeof(Semester), semester))
        {
            return BadRequest("Invalid semester value.");
        }
        
        var query = new GetAllCoursesBySemesterQuery { Semester = semester };
        var queryResult = await mediator.Send(query);
        return Ok(queryResult);
    }
}