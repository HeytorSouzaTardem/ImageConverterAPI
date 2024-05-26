using System.ComponentModel.DataAnnotations;

namespace ImageConverter.Models
{
    public class ImageInput
    {
        [Required(ErrorMessage = "O campo Base64Image é obrigatório.")]
        public string Base64Image { get; set; }

        [Required(ErrorMessage = "O campo WatermarkText é obrigatório.")]
        public string WatermarkText { get; set; }

        [Required(ErrorMessage = "O campo TextFont é obrigatório.")]
        public string TextFont { get; set; }

        [Required(ErrorMessage = "O campo TextSize é obrigatório.")]
        [Range(1, int.MaxValue, ErrorMessage = "TextSize deve ser maior que zero.")]
        public int TextSize { get; set; }

        [Required(ErrorMessage = "O campo TextColor é obrigatório.")]
        public string TextColor { get; set; }

        [Required(ErrorMessage = "O campo PositionX é obrigatório.")]
        public int PositionX { get; set; }

        [Required(ErrorMessage = "O campo PositionY é obrigatório.")]
        public int PositionY { get; set; }
    }
}
