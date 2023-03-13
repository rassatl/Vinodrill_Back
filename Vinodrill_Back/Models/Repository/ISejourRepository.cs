using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Vinodrill_Back.Models.EntityFramework;

namespace Vinodrill_Back.Models.Repository
{
    public interface ISejourRepository : IDataRepository<Sejour>
    {
        Task<ActionResult<IEnumerable<Sejour>>> GetAllWithParams(string? idsSejour = null, string? idsDestination = null, string? idsTheme = null, string? idsCatParticipant = null, int? limit = null, int? idSejour = null);
        Task<ActionResult<Sejour>> GetById(int id, bool includeVisite = false, bool includeDestination = false, bool includeTheme = false, bool includeCatParticipant = false, bool includaAvis = false, bool includeEtape = false, bool includeHebergement = false);
    }
}