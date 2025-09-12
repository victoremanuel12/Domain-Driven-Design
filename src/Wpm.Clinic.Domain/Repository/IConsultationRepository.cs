using Wpm.Clinic.Domain.Entities;

namespace Wpm.Clinic.Domain.Repository.Interfaces
{
    public interface IConsultationRepository
    {
        Consultation? GetById(Guid id);
        IEnumerable<Consultation> GetAll();
        void Insert(Consultation consultation);
        void Update(Consultation consultation);
        void Delete(Guid id);
    }
}
