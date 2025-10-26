﻿using AspCorewebApiCRUD.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AspCorewebApiCRUD.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentApiControlleR : ControllerBase
    {
        private readonly CodefirstDb1Context context;

        public StudentApiControlleR(CodefirstDb1Context context)
        {
            this.context = context;
        }
        [HttpGet]
        public async Task<ActionResult<List<Student>>> GetAllStudents()
        {
            var students = await context.Students.ToListAsync();
            return Ok(students);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<Student>> GetStudentByID(int id
            )
        {
            var student = await context.Students.FindAsync(id);
            if (student == null)
            {
                return NotFound();
            }
            return student;
        }

        [HttpPost]
   
        public async Task<ActionResult<Student>> CreateStudent(Student std)
        {
            await context.Students.AddAsync(std);
            await context.SaveChangesAsync();
            return Ok(std); 
                }

        [HttpPut("{id}")]
        public async Task<ActionResult<Student>> UpdateStudent(int id, Student std)
        {
            if (id != std.Id)
            {
                return BadRequest();
            }
            context.Entry(std).State = EntityState.Modified;
            await context.SaveChangesAsync();
            return Ok(std);

        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Student>> DeleteStudent(int id)
        {
            if (id == 0)
            {
                return BadRequest();
            }
            {
                var     std = await context.Students.FindAsync(id);
                if (std == null)
                {
                    return NotFound();
                } 

                     context.Students.Remove(std);
                     await context.SaveChangesAsync();
                     return Ok(std);
            }
          

        }
    }
}
