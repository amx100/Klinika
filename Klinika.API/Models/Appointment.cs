﻿using System.ComponentModel.DataAnnotations;

namespace Klinika.API.Models
{
	public class Appointment
	{
		[Key]
		public int appointmentID { get; set; }
		public int patientID { get; set; }
		public Patient Patient { get; set; }
		public int doctorID { get; set; }
		public Doctor Doctor { get; set; }
		public DateTime appointmentDate { get; set; }
		public AppointmentStatus status { get; set; } 
		
	}

	public enum AppointmentStatus
	{
		Pending,
		Cancelled,
		Completed
	}
}
