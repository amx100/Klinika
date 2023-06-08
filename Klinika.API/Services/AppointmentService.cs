using Klinika.API.Contracts.Repositories;
using Klinika.API.Contracts.Service;
using Klinika.API.Data.Dto.Appointment;
using Klinika.API.Data.Dto;
using Klinika.API.Models;
using Mapster;

namespace Klinika.API.Services
{
	public class AppointmentService : IAppointmentService
	{
		private readonly IRepositoryManager _repositoryManager;
		private readonly ResponseDto _response;


		public AppointmentService(IRepositoryManager repositoryManager)
		{
			_repositoryManager = repositoryManager;
			_response = new();
		}


		public async Task<ResponseDto> CreateAppointment(AppointmentCreateDto appointmentDto)
		{
			var appointment = appointmentDto.Adapt<Appointment>();
			_repositoryManager.AppointmentRepository.CreateAppointment(appointment);
			var result = await _repositoryManager.UnitOfWorkRepository.SaveChangesAsync();
			if (result > 0)
			{
				_response.Data = appointment;
				return _response;
			}

			_response.IsSuccess = false;
			_response.DisplayMessage = "Error Creating Appointment";
			return _response;
		}

		public async Task<ResponseDto> UpdateAppointment(int appointmentId, AppointmentUpdateDto appointmentDto)
		{
			var appointmentCheck = await _repositoryManager.AppointmentRepository.GetAppointmentById(appointmentId);
			if (appointmentCheck is null)
			{
				_response.IsSuccess = false;
				_response.DisplayMessage = "Appointment not found in Database";
				return _response;
			}
			var appointment = appointmentDto.Adapt<Appointment>();
			_repositoryManager.AppointmentRepository.Update(appointment);

			var result = await _repositoryManager.UnitOfWorkRepository.SaveChangesAsync();
			if (result > 0)
			{
				_response.Data = appointment;
				return _response;
			}

			_response.IsSuccess = false;
			_response.DisplayMessage = "Error Updating Appointment";
			return _response;
		}

		public async Task<bool> DeleteAppointment(int appointmentId)
		{
			var appointment = await _repositoryManager.AppointmentRepository.GetAppointmentById(appointmentId);
			if (appointment is not null)
			{
				_repositoryManager.AppointmentRepository.DeleteAppointment(appointment);
				return await _repositoryManager.UnitOfWorkRepository.SaveChangesAsync() == 1;
			}

			return false;
		}


		public async Task<IEnumerable<AppointmentReadOnlyDto>> GetAllAppointments()
		{
			var appointments = await _repositoryManager.AppointmentRepository.GetAllAppointments();
			return appointments.Adapt<IEnumerable<AppointmentReadOnlyDto>>();
		}

		public async Task<AppointmentReadOnlyDto> GetAppointmentById(int appointmentId)
		{
			var appointment = await _repositoryManager.AppointmentRepository.GetAppointmentById(appointmentId);
			return appointment.Adapt<AppointmentReadOnlyDto>();
		}
	}
}
