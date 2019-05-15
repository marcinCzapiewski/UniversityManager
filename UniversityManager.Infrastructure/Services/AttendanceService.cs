using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using UniversityManager.Core.Domain;
using UniversityManager.Core.Repositories;
using UniversityManager.Infrastructure.DTOs;
using UniversityManager.Infrastructure.Services.Interfaces;

namespace UniversityManager.Infrastructure.Services
{
    public class AttendanceService : IAttendanceService
    {
        private readonly IAttendanceRepository _attendanceRepository;
        private readonly IUserRepository _userRepository;
        private readonly ILectureRepository _lectureRepository;
        private readonly IMapper _mapper;

        public AttendanceService(IAttendanceRepository attendanceRepository, IUserRepository userRepository, ILectureRepository lectureRepository,IMapper mapper)
        {
            _attendanceRepository = attendanceRepository;
            _userRepository = userRepository;
            _lectureRepository = lectureRepository;
            _mapper = mapper;
        }

        public async Task Add(Guid studentId, Guid lectureId, bool present)
        {
            var student = await _userRepository.Get(studentId);
            var lecture = await _lectureRepository.Get(lectureId);

            var attendance = new Attendance(lecture, (Student)student, present);
            await _attendanceRepository.Add(attendance);
        }

        public async Task<IEnumerable<AttendanceDto>> Browse()
        {
            var attendances = await _attendanceRepository.GetAll();

            return _mapper.Map<IEnumerable<Attendance>, IEnumerable<AttendanceDto>>(attendances);
        }

        public async Task<AttendanceDto> Get(Guid id)
        {
            var attendance = await _attendanceRepository.Get(id);

            return _mapper.Map<Attendance, AttendanceDto>(attendance);
        }

        public async Task<IEnumerable<AttendanceDto>> GetStudentAttendences(Guid studentId)
        {
            var attendance = await _attendanceRepository.GetStudentAttendances(studentId);

            return _mapper.Map<IEnumerable<Attendance>, IEnumerable<AttendanceDto>>(attendance);
        }

        public async Task Remove(Guid id)
        {
            await _attendanceRepository.Remove(id);
        }
    }
}
