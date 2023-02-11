using IlhadasLendasAPI.Domain.Entities.Base;

namespace IlhadasLendasAPI.Application.Utilities.Image
{
    public class UploadB64Methods<TEntity> where TEntity : UploadBase64Base
    {
        public async Task UploadImagem(string caminho, string base64string)
        {
            string filePath = Path.Combine(Directory.GetCurrentDirectory(), caminho);
            await File.WriteAllBytesAsync(filePath, Convert.FromBase64String(base64string));
        }

        public async Task DeleteImage(TEntity uploadB64)
        {
            if (File.Exists(uploadB64.CaminhoFisico))
                File.Delete(uploadB64.CaminhoFisico);

            await Task.CompletedTask;
        }
    }
}