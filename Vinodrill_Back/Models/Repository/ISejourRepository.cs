using Microsoft.AspNetCore.Mvc;
using Vinodrill_Back.Models.EntityFramework;

namespace Vinodrill_Back.Models.Repository
{
    public interface ISejourRepository : IDataRepository<Sejour>
    {
        Task<ActionResult<IEnumerable<Sejour>>> GetAllFromSpecificDestination(string idsDestination);
        Task<ActionResult<IEnumerable<Sejour>>> GetAllFromSpecificTheme(string idsTheme);
        Task<ActionResult<IEnumerable<Sejour>>> GetAllFromSpecificCatParticipant(string idsCatParticipant);
        Task<ActionResult<IEnumerable<Sejour>>> GetAllExceptSpecificSejour(int idSejour);
        Task<ActionResult<IEnumerable<Sejour>>> GetAllSetLimit(int limit);
        Task<ActionResult<IEnumerable<Sejour>>> GetMultipleSejour(string idsSejour);
    }
}