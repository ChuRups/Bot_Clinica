using System;

namespace Clinic.Bot.Common.Models.MedicalAppointment
{
    public class MedicalAppointmentModel
    {
        public string id { get; set; }
        public string idUser { get; set; }
        public DateTime date { get; set; }
        public int time { get; set; }
    }
}
