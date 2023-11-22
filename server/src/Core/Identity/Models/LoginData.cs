using System.ComponentModel.DataAnnotations;

namespace BGS.ApplicationCore.Identity.Models;

public record LoginData([Required] string UserName, [Required] string Password);