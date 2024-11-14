using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Hosting;
using System.IO;
using System.Threading.Tasks;
using KoiCareSystem.BussinessObject;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.RazorPages;
using KoiCareSystem.Service.Interfaces;

namespace KoiCareSystem.Pages.AccountPage
{
    public class EditModel : PageModel
    {
        private readonly IAccountService _accountService;
        private readonly IWebHostEnvironment _environment;

        public EditModel(IAccountService accountService, IWebHostEnvironment environment)
        {
            _accountService = accountService;
            _environment = environment;
        }

        [BindProperty]
        public Account Account { get; set; } = default!;

        [BindProperty]
        public IFormFile AvatarFile { get; set; }  // For avatar upload

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            // Use the account service to get the account by ID
            Account = _accountService.GetAccountById(id.Value);
            if (Account == null)
            {
                return NotFound();
            }

            return Page();
        }

        // To handle file uploads and other updates
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            // Handle file upload if a file is provided
            if (AvatarFile != null)
            {
                // Define the folder to save the avatar image (in wwwroot/avatars)
                var uploadsFolder = Path.Combine(_environment.WebRootPath, "avatars");

                // Ensure the folder exists
                if (!Directory.Exists(uploadsFolder))
                {
                    Directory.CreateDirectory(uploadsFolder);
                }

                // Create a unique file name to avoid overwriting existing files
                var fileName = Path.GetFileName(AvatarFile.FileName);
                var filePath = Path.Combine(uploadsFolder, fileName);

                // Save the uploaded file
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    await AvatarFile.CopyToAsync(fileStream);
                }

                // Set the new avatar path
                Account.Avatar = $"/avatars/{fileName}";
            }

            try
            {
                // Update the account details in the database
                _accountService.UpdateAccount(Account);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AccountExists(Account.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool AccountExists(int id)
        {
            return _accountService.GetAccountById(id) != null;
        }
    }
}
