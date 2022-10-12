using RacesManager.Domain.Entities;


namespace RacesManager.Application.Ports;

public interface IRacesRepository
{

    Task<IEnumerable<Race>> All();
}
