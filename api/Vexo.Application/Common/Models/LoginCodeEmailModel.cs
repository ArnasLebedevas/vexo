namespace Vexo.Application.Common.Models;

public record class LoginCodeEmailModel(string Email, string Code, string LoginUrl);