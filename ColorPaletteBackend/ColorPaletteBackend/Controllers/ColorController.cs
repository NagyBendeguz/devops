using ColorPaletteBackend.Data;
using ColorPaletteBackend.Models;
using ColorPaletteBackend.Models.Dtos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ColorPaletteBackend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ColorController : ControllerBase
    {
        ColorDbContext ctx;

        public ColorController(ColorDbContext ctx)
        {
            this.ctx = ctx;
        }

        [HttpGet]
        public async Task<List<ColorViewDto>> GetColorPalette()
        {
            return await ctx.Colors.AsNoTracking().Select(c => new ColorViewDto()
            {
                Name = c.Name,
                ColorHex = c.ColorHex
            }).ToListAsync();
        }

        [HttpPost]
        public async Task<IActionResult> CreateColor([FromBody] ColorCreateDto dto)
        {
            try
            {
                var newColor = new Color()
                {
                    Name = dto.Name,
                    ColorHex = dto.ColorHex
                };
                await this.ctx.Colors.AddAsync(newColor);
                await this.ctx.SaveChangesAsync();
                return Ok(newColor);

            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }
    }
}
