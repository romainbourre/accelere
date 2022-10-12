using RacesManager.Adapters.Persistence.InMemory.Repositories;
using RacesManager.Application.Tests.Givens.Repositories;
using RacesManager.Application.UseCases.GetRaceEvents;
using RacesManager.Domain.Entities;
using RacesManager.Domain.ValueObjects;


namespace RacesManager.Application.Tests.UseCases.GetRaceEvents;

public class GetRaceIcsCalendarUseCaseTests
{
    private readonly InMemoryGrandPrixRepository grandPrixRepository = new();
    private readonly InMemoryIRaceRepositoryRepository iRaceRepositoryRepository = new();
    private readonly GetRaceIcsCalendarUseCase useCase;

    protected GetRaceIcsCalendarUseCaseTests()
    {
        useCase = new GetRaceIcsCalendarUseCase(iRaceRepositoryRepository);
    }

    public class GivenNoRace : GetRaceIcsCalendarUseCaseTests
    {
        [Fact]
        public async void ShouldReturnEmptyIcsCalendar()
        {
            string response = await useCase.Handle();
            Assert.Equal(@"BEGIN:VCALENDAR
VERSION:2.0
PRODID:romainbourre.fr
CALSCALE:GREGORIAN
METHOD:PUBLISH
END:VCALENDAR", response);
        }
    }


    public class GivenCircuit : GetRaceIcsCalendarUseCaseTests
    {

        public class GivenMotoGrandPrix : GivenCircuit
        {

            public class GivenRace : GivenMotoGrandPrix
            {

                [Fact]
                public async void ShouldReturnEventsListWithRaceEvent()
                {
                    var circuit = new Circuit("Las Vegas", new Location("🇺🇸", "US"));
                    GrandPrix grandPrix = grandPrixRepository.HaveAlreadyGrandPrix(grandPrix => grandPrix.ForCategory(GrandPrix.Categories.MotoGp).OnCircuit(circuit));
                    Race race = iRaceRepositoryRepository.HaveAlreadyRace(race => race.ForGrandPrix(grandPrix).WithName("FP2"));

                    string response = await useCase.Handle();

                    string Convert(DateTime date)
                    {
                        return $"{date:yyyy}{date:MM}{date:dd}T{date:HH}{date:mm}00";
                    }

                    Assert.Contains(@$"BEGIN:VEVENT
UID:{race.Id}
DTSTART:{Convert(race.StartAt)}
DTEND:{Convert(race.EndAt!.Value)}
SUMMARY:🏍 {race.Name} ({grandPrix.Name})
LOCATION:Circuit de {circuit.Name} {circuit.Location.icon}
CATEGORIES:MotoGP
END:VEVENT", response);
                }
            }
            
            public class GivenRaces : GivenMotoGrandPrix
            {

                [Fact]
                public async void ShouldReturnEventsListWithRaceEvent()
                {
                    var circuit = new Circuit("Las Vegas", new Location("🇺🇸", "US"));
                    GrandPrix grandPrix = grandPrixRepository.HaveAlreadyGrandPrix(grandPrix => grandPrix.ForCategory(GrandPrix.Categories.MotoGp).OnCircuit(circuit));
                    Race race1 = iRaceRepositoryRepository.HaveAlreadyRace(race => race.ForGrandPrix(grandPrix).WithName("FP1"));
                    Race race2 = iRaceRepositoryRepository.HaveAlreadyRace(race => race.ForGrandPrix(grandPrix).WithName("FP2"));

                    string response = await useCase.Handle();

                    string Convert(DateTime date)
                    {
                        return $"{date:yyyy}{date:MM}{date:dd}T{date:HH}{date:mm}00";
                    }

                    Assert.Contains(@$"BEGIN:VEVENT
UID:{race1.Id}
DTSTART:{Convert(race1.StartAt)}
DTEND:{Convert(race1.EndAt!.Value)}
SUMMARY:🏍 {race1.Name} ({grandPrix.Name})
LOCATION:Circuit de {circuit.Name} {circuit.Location.icon}
CATEGORIES:MotoGP
END:VEVENT
BEGIN:VEVENT
UID:{race2.Id}
DTSTART:{Convert(race2.StartAt)}
DTEND:{Convert(race2.EndAt!.Value)}
SUMMARY:🏍 {race2.Name} ({grandPrix.Name})
LOCATION:Circuit de {circuit.Name} {circuit.Location.icon}
CATEGORIES:MotoGP
END:VEVENT", response);
                }
            }


            public class GivenRaceWithoutEndDate : GivenCircuit
            {
                [Fact]
                public async void ShouldReturnEventsListWithRaceEvent()
                {
                    var circuit = new Circuit("Las Vegas", new Location("🇺🇸", "US"));
                    GrandPrix grandPrix2 = grandPrixRepository.HaveAlreadyGrandPrix(grandPrix => grandPrix.ForCategory(GrandPrix.Categories.MotoGp).OnCircuit(circuit));
                    Race race2 = iRaceRepositoryRepository.HaveAlreadyRace(race => race.ForGrandPrix(grandPrix2).EndAt(null).WithName("FP2"));

                    string response = await useCase.Handle();

                    string Convert(DateTime date)
                    {
                        return $"{date:yyyy}{date:MM}{date:dd}";
                    }

                    Assert.Contains(@$"BEGIN:VEVENT
UID:{race2.Id}
DTSTART;VALUE=DATE:{Convert(race2.StartAt)}
SUMMARY:🏍 {race2.Name} ({grandPrix2.Name})
LOCATION:Circuit de {circuit.Name} {circuit.Location.ToString()}
CATEGORIES:MotoGP
END:VEVENT", response);
                }
            }
        }
    }

    public class GivenF1GrandPrix : GivenCircuit
    {

        public class GivenRace : GivenF1GrandPrix
        {

            [Fact]
            public async void ShouldReturnEventsList()
            {
                GrandPrix grandPrix1 = grandPrixRepository.HaveAlreadyGrandPrix(grandPrix => grandPrix.ForCategory(GrandPrix.Categories.F1));
                Race race1 = iRaceRepositoryRepository.HaveAlreadyRace(race => race.ForGrandPrix(grandPrix1).WithName("FP1"));

                string response = await useCase.Handle();

                string Convert(DateTime date)
                {
                    return $"{date:yyyy}{date:MM}{date:dd}T{date:HH}{date:mm}00";
                }

                Assert.Equal(@$"BEGIN:VCALENDAR
VERSION:2.0
PRODID:romainbourre.fr
CALSCALE:GREGORIAN
METHOD:PUBLISH
BEGIN:VEVENT
UID:{race1.Id}
DTSTART:{Convert(race1.StartAt)}
DTEND:{Convert(race1.EndAt!.Value)}
SUMMARY:🏎 {race1.Name} ({grandPrix1.Name})
LOCATION:{grandPrix1.Circuit.ToString()}
CATEGORIES:F1
END:VEVENT
END:VCALENDAR", response);
            }
        }
    }
}
