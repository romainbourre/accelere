using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using RacesManager.Adapters.Persistence.InMemory.Repositories;
using RacesManager.Domain.Entities;
using RacesManager.Domain.ValueObjects;


namespace RacesManager.Api.Data;

[ExcludeFromCodeCoverage]
public static class RaceFiller
{
    public static InMemoryIRaceRepositoryRepository FillData(this InMemoryIRaceRepositoryRepository iRaceRepositoryRepository)
    {
        iRaceRepositoryRepository.Races.AddRange(new List<Race>
        {
            new(Guid.NewGuid(), "Course", Convert("05/03/2023 00:00"), null, new F1GrandPrix("Grand Prix de Bahreïn", new Circuit("Sakhir", new Location("🇧🇭", "Bahreïn")))),
            new(Guid.NewGuid(), "Course", Convert("19/03/2023 00:00"), null, new F1GrandPrix("Grand Prix d'Arabie Saoudite", new Circuit("Djeddah", new Location("🇸🇦", "Arabie Saoudite")))),
            new(Guid.NewGuid(), "Course", Convert("02/04/2023 00:00"), null, new F1GrandPrix("Grand Prix d'Australie", new Circuit("Melbourne", new Location("🇦🇺", "Australie")))),
            new(Guid.NewGuid(), "Course", Convert("16/04/2023 00:00"), null, new F1GrandPrix("Grand Prix de Chine", new Circuit("Shanghaï", new Location("🇨🇳", "Chine")))),
            new(Guid.NewGuid(), "Course", Convert("30/04/2023 00:00"), null, new F1GrandPrix("Grand Prix d'Azerbaïdjan", new Circuit("Bakou", new Location("🇦🇿", "Azerbaïdjan")))),
            new(Guid.NewGuid(), "Course", Convert("07/05/2023 00:00"), null, new F1GrandPrix("Grand Prix de Miami", new Circuit("Miami", new Location("🇺🇸", "États-Unis")))),
            new(Guid.NewGuid(), "Course", Convert("21/05/2023 00:00"), null, new F1GrandPrix("Grand Prix d'Émilie-Romagne", new Circuit("Imola", new Location("🇮🇹", "Italie")))),
            new(Guid.NewGuid(), "Course", Convert("28/05/2023 00:00"), null, new F1GrandPrix("Grand Prix de Monaco", new Circuit("Monte-Carlo", new Location("🇲🇨", "Monaco")))),
            new(Guid.NewGuid(), "Course", Convert("04/06/2023 00:00"), null, new F1GrandPrix("Grand Prix d'Espagne", new Circuit("Barcelone", new Location("🇪🇸","Espagne")))),
            new(Guid.NewGuid(), "Course", Convert("18/06/2023 00:00"), null, new F1GrandPrix("Grand Prix du Canada", new Circuit("Montréal", new Location("🇨🇦", "Canada")))),
            new(Guid.NewGuid(), "Course", Convert("02/07/2023 00:00"), null, new F1GrandPrix("Grand Prix d'Autriche", new Circuit("Spielberg", new Location("🇦🇹", "Autriche")))),
            new(Guid.NewGuid(), "Course", Convert("09/07/2023 00:00"), null, new F1GrandPrix("Grand Prix de Grande-Bretagne", new Circuit("Silverstone", new Location("🇬🇧", "Royaume-Uni")))),
            new(Guid.NewGuid(), "Course", Convert("23/07/2023 00:00"), null, new F1GrandPrix("Grand Prix d'Hongrie", new Circuit("Budapest", new Location("🇭🇺", "Hongrie")))),
            new(Guid.NewGuid(), "Course", Convert("30/07/2023 00:00"), null, new F1GrandPrix("Grand Prix de Belgique", new Circuit("Spa-Francorchamps", new Location("🇧🇪", "Belgique")))),
            new(Guid.NewGuid(), "Course", Convert("27/08/2023 00:00"), null, new F1GrandPrix("Grand Prix des Pays-Bas", new Circuit("Zandvoort", new Location("🇳🇱", "Pays-Bas")))),
            new(Guid.NewGuid(), "Course", Convert("03/09/2023 00:00"), null, new F1GrandPrix("Grand Prix d'Italie", new Circuit("Monza", new Location("🇮🇹", "Italie")))),
            new(Guid.NewGuid(), "Course", Convert("17/09/2023 00:00"), null, new F1GrandPrix("Grand Prix de Singapour", new Circuit("Marina Bay", new Location("🇸🇬", "Singapour")))),
            new(Guid.NewGuid(), "Course", Convert("24/09/2023 00:00"), null, new F1GrandPrix("Grand Prix du Japon", new Circuit("Suzuka", new Location("🇯🇵", "Japon")))),
            new(Guid.NewGuid(), "Course", Convert("08/10/2023 00:00"), null, new F1GrandPrix("Grand Prix du Quatar", new Circuit("Losail", new Location("🇶🇦", "Quatar")))),
            new(Guid.NewGuid(), "Course", Convert("22/10/2023 00:00"), null, new F1GrandPrix("Grand Prix des État-Unis", new Circuit("Austin", new Location("🇺🇸", "État-Unis")))),
            new(Guid.NewGuid(), "Course", Convert("29/10/2023 00:00"), null, new F1GrandPrix("Grand Prix du Mexique", new Circuit("Mexico", new Location("🇲🇽", "Mexique")))),
            new(Guid.NewGuid(), "Course", Convert("05/11/2023 00:00"), null, new F1GrandPrix("Grand Prix du Brésil", new Circuit("São Paulo", new Location("🇧🇷", "Brésil")))),
            new(Guid.NewGuid(), "Course", Convert("05/11/2023 00:00"), null, new F1GrandPrix("Grand Prix de Las Vegas", new Circuit("Las Vegas", new Location("🇺🇸", "État-Unis")))),
            new(Guid.NewGuid(), "Course", Convert("26/11/2023 00:00"), null, new F1GrandPrix("Grand Prix d'Abu Dhabi", new Circuit("Yas Marina", new Location("🇦🇪", "Émirats Arabes Unis")))),
        });
        
        iRaceRepositoryRepository.Races.AddRange(new List<Race>
        {
            new(Guid.NewGuid(), "Course", Convert("26/03/2023 00:00"), null, new MotoGpGrandPrix("Grand Prix du Portugal", new Circuit("Portimão", new Location("🇵🇹", "Portugal")))),
            new(Guid.NewGuid(), "Course", Convert("02/04/2023 00:00"), null, new MotoGpGrandPrix("Grand Prix d'Argentine", new Circuit("Termas de Río Hondo", new Location("🇦🇷", "Argentine")))),
            new(Guid.NewGuid(), "Course", Convert("16/04/2023 00:00"), null, new MotoGpGrandPrix("Grand Prix des Amériques", new Circuit("Austin", new Location("🇺🇸", "États-Unis")))),
            new(Guid.NewGuid(), "Course", Convert("30/04/2023 00:00"), null, new MotoGpGrandPrix("Grand Prix d'Espagne", new Circuit("Jerez", new Location("🇪🇸", "Espagne")))),
            new(Guid.NewGuid(), "Course", Convert("14/05/2023 00:00"), null, new MotoGpGrandPrix("Grand Prix de France", new Circuit("Le Mans", new Location("🇫🇷", "France")))),
            new(Guid.NewGuid(), "Course", Convert("11/06/2023 00:00"), null, new MotoGpGrandPrix("Grand Prix d'Italie", new Circuit("Mugello", new Location("🇮🇹", "Italie")))),
            new(Guid.NewGuid(), "Course", Convert("18/06/2023 00:00"), null, new MotoGpGrandPrix("Grand Prix d'Allemagne", new Circuit("Sachsenring", new Location("🇩🇪", "Allemagne")))),
            new(Guid.NewGuid(), "Course", Convert("25/06/2023 00:00"), null, new MotoGpGrandPrix("Grand Prix des Pays-Bas", new Circuit("Assen", new Location("🇳🇱", "Pays-Bas")))),
            new(Guid.NewGuid(), "Course", Convert("09/07/2023 00:00"), null, new MotoGpGrandPrix("Grand Prix du Kazakhstan", new Circuit("Sokol", new Location("🇰🇿", "Kazakhstan")))),
            new(Guid.NewGuid(), "Course", Convert("06/08/2023 00:00"), null, new MotoGpGrandPrix("Grand Prix de Grande-Bretagne", new Circuit("Silverstone", new Location("🇬🇧", "Royaume-Uni")))),
            new(Guid.NewGuid(), "Course", Convert("20/08/2023 00:00"), null, new MotoGpGrandPrix("Grand Prix d'Autriche", new Circuit("Red Bull Ring", new Location("🇦🇹", "Autriche")))),
            new(Guid.NewGuid(), "Course", Convert("03/09/2023 00:00"), null, new MotoGpGrandPrix("Grand Prix de Catalogne", new Circuit("Barcelone", new Location("🇪🇸", "Espagne")))),
            new(Guid.NewGuid(), "Course", Convert("10/09/2023 00:00"), null, new MotoGpGrandPrix("Grand Prix de Saint-Marin", new Circuit("Misano", new Location("🇮🇹", "Italie")))),
            new(Guid.NewGuid(), "Course", Convert("24/09/2023 00:00"), null, new MotoGpGrandPrix("Grand Prix d'Inde", new Circuit("Buddh", new Location("🇮🇳", "Inde")))),
            new(Guid.NewGuid(), "Course", Convert("01/10/2023 00:00"), null, new MotoGpGrandPrix("Grand Prix du Japon", new Circuit("Motegi", new Location("🇯🇵", "Japon")))),
            new(Guid.NewGuid(), "Course", Convert("15/10/2023 00:00"), null, new MotoGpGrandPrix("Grand Prix d'Indonésie", new Circuit("Mandalika", new Location("🇮🇩", "Indonésie")))),
            new(Guid.NewGuid(), "Course", Convert("22/10/2023 00:00"), null, new MotoGpGrandPrix("Grand Prix d'Australie", new Circuit("Philip Island", new Location("🇦🇺", "Australie")))),
            new(Guid.NewGuid(), "Course", Convert("29/10/2023 00:00"), null, new MotoGpGrandPrix("Grand Prix de Thaïlande", new Circuit("Buriram", new Location("🇹🇭", "Thaïlande")))),
            new(Guid.NewGuid(), "Course", Convert("12/11/2023 00:00"), null, new MotoGpGrandPrix("Grand Prix de Malaisie", new Circuit("Sepang", new Location("🇲🇾", "Malaisie")))),
            new(Guid.NewGuid(), "Course", Convert("12/11/2023 00:00"), null, new MotoGpGrandPrix("Grand Prix de Valence", new Circuit("Valence", new Location("🇪🇸", "Espagne")))),
        });
        
        return iRaceRepositoryRepository;
    }
    
    private static DateTime Convert(string textDate)
    {
        return DateTime.ParseExact(textDate, "dd/MM/yyyy HH:mm", CultureInfo.InvariantCulture);
    }
}
