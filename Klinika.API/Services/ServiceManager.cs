using Klinika.API.Contracts.Repositories;
using Klinika.API.Contracts.Service;
using Klinika.API.Contracts.Services;
using Klinika.API.Services.Application.Services;

namespace Klinika.API.Services
{
	public class ServiceManager : IServiceManager
	 
	{
		private readonly Lazy<IDoctorService> _lazyDoctorService;
		private readonly Lazy<IPatientService> _lazyPatientService;
		private readonly Lazy<IDepartmentService> _lazyDepartmentService;
		private readonly Lazy<IDiagnoseService> _lazyDiagnoseService;
		private readonly Lazy<IAppointmentService> _lazyAppointmentService;

		public ServiceManager(IRepositoryManager repositoryManager)
		{
			_lazyDoctorService = new Lazy<IDoctorService>(() => new DoctorService(repositoryManager));
			_lazyPatientService = new Lazy<IPatientService>(() => new PatientService(repositoryManager));
			_lazyDepartmentService = new Lazy<IDepartmentService>(() => new DepartmentService(repositoryManager));
			_lazyAppointmentService = new Lazy<IAppointmentService>(() => new AppointmentService(repositoryManager));
			_lazyDiagnoseService = new Lazy<IDiagnoseService>(() => new DiagnoseService(repositoryManager));

		}

		
	
		public IDoctorService DoctorService => _lazyDoctorService.Value;

		public IAppointmentService AppointmentService => _lazyAppointmentService.Value;

		public IPatientService PatientService => _lazyPatientService.Value;

		public IDiagnoseService DiagnoseService => _lazyDiagnoseService.Value;

		public IDepartmentService DepartmentService => _lazyDepartmentService.Value;
	}
}
