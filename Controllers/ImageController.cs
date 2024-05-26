using ImageConverter.Models;
using ImageConverter.Services;
using Microsoft.AspNetCore.Mvc;
using System.Drawing;
using System.IO;

namespace ImageConverter.Controllers
{
    [ApiController]
    [Route("images")]
    public class ImageController : ControllerBase
    {
        [HttpPost]
        public ActionResult<string> ConverterImagem([FromBody] ImageInput imageInput)
        {
            if (!ModelState.IsValid)
            {
                var errors = ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage).ToList();
                return BadRequest(new { Errors = errors });
            }

            try
            {
                byte[] imageBytes = Convert.FromBase64String(imageInput.Base64Image);
                using (MemoryStream ms = new MemoryStream(imageBytes))
                {
                    Image image = Image.FromStream(ms);

                    // Cria um objeto Graphics a partir da imagem para desenhar nela
                    using (Graphics graphics = Graphics.FromImage(image))
                    {
                        Font font = new Font(imageInput.TextFont, imageInput.TextSize);
                        Color textColor = ColorTranslator.FromHtml(imageInput.TextColor);
                        Brush brush = new SolidBrush(textColor);

                        SizeF textSize = graphics.MeasureString(imageInput.WatermarkText, font);

                        // Verifica se a posição da marca d'água ultrapassa os limites da imagem
                        if (imageInput.PositionX < 0 || imageInput.PositionY < 0 ||
                            imageInput.PositionX + textSize.Width > image.Width ||
                            imageInput.PositionY + textSize.Height > image.Height)
                        {
                            return BadRequest($"A posição da marca d'água está fora dos limites da imagem. A imagem possui uma largura de {image.Width} e uma altura de {image.Height}. " +
                                "Certifique-se de que a posição e o tamanho da marca d'água se encaixem dentro desses limites");
                        }

                        Point position = new Point(imageInput.PositionX, imageInput.PositionY);
                        graphics.DrawString(imageInput.WatermarkText, font, brush, position);
                    }

                    return ImageService.ImageToBase64(image);
                }
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro ao converter imagem: {ex.Message}");
            }
        }
    }
}