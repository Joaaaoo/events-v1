using System;
using System.Collections.Generic;

namespace Events.Domain;

    public class Event
    {
        public int Id { get; set; }
        public string Location { get; set; }
        public DateTime? Date { get; set; }
        public string Theme { get; set; }
        public int Attendance { get; set; }
        public string ImgURL { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public IEnumerable<Batch> Batchs { get; set; }
        public IEnumerable<Social> Socials { get; set; }
        public IEnumerable<SpeakerEvent> SpeakersEvents { get; set; }

    }
