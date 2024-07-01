using Microsoft.AspNetCore.Mvc;
using WebAPI.DB;
using WebAPI.Mappers;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("api/comment")]
    public class CommentController : ControllerBase
    {
        private readonly ApplicationDBContext _context;
        public CommentController(ApplicationDBContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetAll() 
        {
            var comments = _context.Comments.Select(s => s.ToCommentDto()).ToList();
            return Ok(comments);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var comment = _context.Comments.Find(id);
            if (comment is null)
            {
                return NotFound();
            }
            return Ok(comment.ToCommentDto());
        }
    }
}
