using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Threading.Tasks;
using Events.Domain;

namespace Events.Persistence.Contracts
{
    public interface ISpeakerPersist
    {
        Task<Speaker[]> GetAllSpeakerByNameAsync(string name, bool IncludeEvent = false);
        Task<Speaker[]> GetAllSpeakersAsync( bool IncludeEvent = false);
        Task<Speaker> GetSpeakerByIdAsync(int speakerId, bool includeEvent = false);
    }
}