using Clinic.Bot.Common.Models.MedicalAppointment;
using Clinic.Bot.Common.Models.Qualification;
using Clinic.Bot.Common.Models.User;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace Clinic.Bot.Data
{
    public class DataBaseService: DbContext, IDataBaseService
    {
        private readonly DbContextOptions _options;
        public DataBaseService(DbContextOptions options): base(options) // Para invocar desde cualquier parte
        {
            _options = options;
            Database.EnsureCreated(); // Para crear la bdd si es que no existe
        }
        public DataBaseService()
        {
            Database.EnsureCreated();
        }

        public DbSet<UserModel> User { get; set; }
        public DbSet<QualificationModel> Qualification { get; set; }
        public DbSet<MedicalAppointmentModel> MedicalAppointment { get; set; }

        // Método para crear los contenedores de los modelos // Para confirmar el guardado de los datos
        public async Task<bool> SaveAsync()
        {
            return (await SaveChangesAsync() > 0);
        }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserModel>().ToContainer("User").HasPartitionKey("channel").HasNoDiscriminator().HasKey("id"); // Para que no se cree una variable que identifica el tipo de particion que va a tener el modelo
            modelBuilder.Entity<QualificationModel>().ToContainer("Qualification").HasPartitionKey("idUser").HasNoDiscriminator().HasKey("id");
            modelBuilder.Entity<MedicalAppointmentModel>().ToContainer("MedicalAppointment").HasPartitionKey("idUser").HasNoDiscriminator().HasKey("id");
        }
    }
}
