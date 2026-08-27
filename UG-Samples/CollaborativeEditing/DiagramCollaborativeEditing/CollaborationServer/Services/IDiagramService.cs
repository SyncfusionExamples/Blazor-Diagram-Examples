using DiagramServer.Models;

namespace DiagramServer.Services
{
    public interface IDiagramService
    {
        Task<DiagramData?> GetDiagramAsync(string diagramId);
        Task<bool> SaveDiagramDataAsync(string diagramId, string diagramData, string userId);
    }
}