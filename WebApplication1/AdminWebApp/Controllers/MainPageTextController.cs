using System.ComponentModel.DataAnnotations;
using aliksoft.DataAccessLayer;
using aliksoft.DataAccessLayer.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace aliksoft.AdminWebApp.Controllers
{
    public class MainPageTextController : Controller
    {
        private readonly ApplicationDbContext _context;

        public MainPageTextController(ApplicationDbContext context)
        {
            _context = context;
        }

        
        public async Task<IActionResult> Edit()
        {
            var textEntity = await GetMainPageEntity();
            return View(new MainPageTextViewModel { Content = textEntity.Content });
        }

        private async Task<PagesContent> GetMainPageEntity()
        {
            return await _context.Contents.SingleAsync(x => x.PageId == PageId.Main);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(MainPageTextViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(viewModel);
            }

            var textEntity = await GetMainPageEntity();
            
            textEntity.Content = viewModel.Content;
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Edit));
        }
    }

    public class MainPageTextViewModel
    {
        [Required]
        public string Content { get; init; } = null!;
    }
}
