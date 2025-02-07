using System.Threading.Tasks;

namespace CleanArchitecture.ApplicationCore.Common.Interfaces
{
    public interface IDocumentService
    {
        Task<byte[]> GeneratePdf(string headercontent, string bodycontent, string footercontent);
    }
}
