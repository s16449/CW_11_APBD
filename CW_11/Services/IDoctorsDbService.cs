using CW_11.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CW_11.Services
{
    public interface IDoctorsDbService
    {
        public IEnumerable<Doctor> GetDoctors();
        public Doctor CreateDoctor(Doctor doctor);
        public Doctor EditDoctor(Doctor doctor, int idDoctor);
        public Doctor DeleteDoctor(int id);
    }
}
