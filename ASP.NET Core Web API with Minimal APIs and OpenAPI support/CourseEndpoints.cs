using Microsoft.EntityFrameworkCore;
using ASP.NET_Core_Web_API_with_Minimal_APIs_and_OpenAPI_support.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.OpenApi;
namespace ASP.NET_Core_Web_API_with_Minimal_APIs_and_OpenAPI_support;

public static class CourseEndpoints
{
    public static void MapCourseEndpoints (this IEndpointRouteBuilder routes)
    {
        var group = routes.MapGroup("/api/Course").WithTags(nameof(Course));

        group.MapGet("/", async (ContosoUniversityContext db) =>
        {
            return await db.Course.ToListAsync();
        })
        .WithName("GetAllCourses")
        .WithOpenApi();

        group.MapGet("/{id}", async Task<Results<Ok<Course>, NotFound>> (int courseid, ContosoUniversityContext db) =>
        {
            return await db.Course.FindAsync(courseid)
                is Course model
                    ? TypedResults.Ok(model)
                    : TypedResults.NotFound();
        })
        .WithName("GetCourseById")
        .WithOpenApi();

        group.MapPut("/{id}", async Task<Results<NotFound, NoContent>> (int courseid, Course course, ContosoUniversityContext db) =>
        {
            var foundModel = await db.Course.FindAsync(courseid);

            if (foundModel is null)
            {
                return TypedResults.NotFound();
            }
            
            db.Update(course);
            await db.SaveChangesAsync();

            return TypedResults.NoContent();
        })
        .WithName("UpdateCourse")
        .WithOpenApi();

        group.MapPost("/", async (Course course, ContosoUniversityContext db) =>
        {
            db.Course.Add(course);
            await db.SaveChangesAsync();
            return TypedResults.Created($"/api/Course/{course.CourseId}",course);
        })
        .WithName("CreateCourse")
        .WithOpenApi();

        group.MapDelete("/{id}", async Task<Results<Ok<Course>, NotFound>> (int courseid, ContosoUniversityContext db) =>
        {
            if (await db.Course.FindAsync(courseid) is Course course)
            {
                db.Course.Remove(course);
                await db.SaveChangesAsync();
                return TypedResults.Ok(course);
            }

            return TypedResults.NotFound();
        })
        .WithName("DeleteCourse")
        .WithOpenApi();
    }
}
