using CRUD_app.Data;
using CRUD_app.Models;
using CRUD_app.Models.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Numerics;

namespace CRUD_app.Controllers {

    public class ProfessorsController : Controller {

        private readonly ApplicationDbContext dbContext;

        public ProfessorsController(ApplicationDbContext dbContext) {

            this.dbContext = dbContext;
        }

        [HttpGet]
        public IActionResult Add() {

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Add(AddProfessorViewModel viewModel) {

            var professor = new Professor {
                Name = viewModel.Name,
                Email = viewModel.Email,
                Phone = viewModel.Phone,
                Subject = viewModel.Subject
            };

            await dbContext.Professors.AddAsync(professor);
            await dbContext.SaveChangesAsync();

            return RedirectToAction("List", "Professors");
        }

        [HttpGet]
        public async Task<IActionResult> List() {

            var professors = await dbContext.Professors.ToListAsync();

            return View(professors);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(Guid id) {

            var professor = await dbContext.Professors.FindAsync(id);

            return View(professor);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Professor viewModel) {

            var professor = await dbContext.Professors.FindAsync(viewModel.Id);

            if (professor is not null) {
                professor.Name = viewModel.Name;
                professor.Email = viewModel.Email;
                professor.Phone = viewModel.Phone;
                professor.Subject = viewModel.Subject;

                await dbContext.SaveChangesAsync();
            }

            return RedirectToAction("List", "Professors");
        }

        [HttpPost]
        public async Task<IActionResult> Delete(Professor viewModel) {

            var professor = await dbContext.Professors
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.Id == viewModel.Id);

            if (professor is not null) {
                dbContext.Professors.Remove(viewModel);
                await dbContext.SaveChangesAsync();
            }
            return RedirectToAction("List", "Professors");
        }
    }
}