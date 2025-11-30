using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ColorPaletteBackend.Models
{
    public class Color
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string Id { get; set; } = Guid.NewGuid().ToString();

        public string Name { get; set; } = string.Empty;

        public string ColorHex { get; set; } = string.Empty;
    }
}
