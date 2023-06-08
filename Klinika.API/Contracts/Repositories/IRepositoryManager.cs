namespace Klinika.API.Contracts.Repositories
{
    public interface IRepositoryManager
    {
        IPatientRepository PatientRepository { get; }
        IDoctorRepository DoctorRepository { get; }   
        IAppointmentRepository AppointmentRepository { get; }
        IDepartmentRepository DepartmentRepository { get; }
        IDiagnoseRepository DiagnoseRepository { get; }
        IUnitOfWorkRepository UnitOfWorkRepository { get; }
    }
}
