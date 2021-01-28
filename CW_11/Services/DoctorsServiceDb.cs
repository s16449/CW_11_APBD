using CW_11.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CW_11.Services
{
    public class DoctorsServiceDb : IDoctorsDbService
    {
        private readonly Medic_DbContext _context;

        public DoctorsServiceDb(Medic_DbContext context)
        {
            _context = context;
        }
        public IEnumerable<Doctor> GetDoctors()
        {
            return _context.Doctors.ToList();

        }

        public Doctor CreateDoctor(Doctor doctor)
        {
            _context.Doctors.Add(doctor);
            _context.SaveChanges();
            return _context.Doctors.Single(d => d.IdDoctor.Equals(doctor.IdDoctor));
        }

        public Doctor EditDoctor(Doctor doctor, int id)
        {
            var doc = new Doctor
            {
                IdDoctor = id,
                FirstName = doctor.FirstName,
                LastName = doctor.LastName,
                Email = doctor.Email
            };
            _context.Attach(doc);
            _context.Entry(doc).Property("FirstName").IsModified = true;
            _context.Entry(doc).Property("LastName").IsModified = true;
            _context.Entry(doc).Property("Email").IsModified = true;
            _context.SaveChanges();

            return doc;
        }

        public Doctor DeleteDoctor(int id)
        {
            var deleteDoc = _context.Doctors.Where(e => e.IdDoctor.Equals(id)).First();
            _context.Doctors.Remove(deleteDoc);
            _context.SaveChanges();

            return deleteDoc;
        }
    }
}
