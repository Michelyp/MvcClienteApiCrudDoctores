using Microsoft.AspNetCore.Mvc;
using MvcClienteApiCrudDoctores.Models;
using MvcClienteApiCrudDoctores.Services;

namespace MvcClienteApiCrudDoctores.Controllers
{
    public class DoctorController : Controller
    {
        private ServiceApiDoctor service;
        public DoctorController(ServiceApiDoctor service)
        {
            this.service = service;
        }
        public async Task<IActionResult> Index()
        {
            List<Doctor> doctores = await this.service.GetDoctoresAsync();
            return View(doctores);
        }
        public async Task<IActionResult> Details(int id)
        {
            Doctor doctor = await this.service.FindDoctor(id);
            return View(doctor);
        }
        public async Task<IActionResult> Delete(int id)
        {
             await this.service.DeleteDoctor(id);
            return RedirectToAction("Index");
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Doctor doc)
        {
            await this.service.InsertDocotr(doc.IdDoctor, doc.Apellido, doc.Especialidad, doc.Salario, doc.IdHospital);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Edit(int id)
        {
            Doctor doc =
                await this.service.FindDoctor(id);
            return View(doc);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Doctor doc)
        {
            await this.service.UpdateDoctor(doc.IdDoctor, doc.Apellido, doc.Especialidad, doc.Salario, doc.IdHospital);
            return RedirectToAction("Index");
        }
    }
}
