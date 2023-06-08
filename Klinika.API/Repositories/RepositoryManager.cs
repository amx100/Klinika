using Application.Repositories;
using Klinika.API.Contracts.Repositories;
using Klinika.API.Data;

namespace Klinika.API.Repositories
{
    public class RepositoryManager : IRepositoryManager
    {
        private readonly Lazy<IPatientRepository> _lazyPatientRepository;
        private readonly Lazy<IDoctorRepository> _lazyDoctorRepository;
        private readonly Lazy<IDiagnoseRepository> _lazyDiagnoseRepository;
        private readonly Lazy<IAppointmentRepository> _lazyAppointmentRepository;
        private readonly Lazy<IDepartmentRepository> _lazyDepartmentRepository;
        private readonly Lazy<IUnitOfWorkRepository> _lazyUnitOfWork;

       public RepositoryManager(ApplicationDbContext context)
        {
           _lazyPatientRepository = new Lazy<IPatientRepository>(() => new PatientRepository(context));
            _lazyDepartmentRepository = new Lazy<IDepartmentRepository>(() => new DepartmentRepository(context));
            _lazyDoctorRepository = new Lazy<IDoctorRepository>(() => new DoctorRepository(context));
           _lazyDiagnoseRepository = new Lazy<IDiagnoseRepository>(() => new DiagnoseRepository(context));
           _lazyAppointmentRepository = new Lazy<IAppointmentRepository>(() => new AppointmentRepository(context));
            _lazyUnitOfWork = new Lazy<IUnitOfWorkRepository>(() => new UnitOfWorkRepository(context));
        }

        public IPatientRepository PatientRepository => _lazyPatientRepository.Value;
        public IDoctorRepository DoctorRepository => _lazyDoctorRepository.Value;
        public IDiagnoseRepository DiagnoseRepository => _lazyDiagnoseRepository.Value;
        public IAppointmentRepository AppointmentRepository => _lazyAppointmentRepository.Value;
        public IDepartmentRepository DepartmentRepository =>  _lazyDepartmentRepository.Value;
        public IUnitOfWorkRepository UnitOfWorkRepository => _lazyUnitOfWork.Value;

        
    }
}