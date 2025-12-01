namespace Vexo.Application.Common.Models;

public sealed class EmailConfirmationModel
{
    public required string UserName { get; set; }
    public required string ConfirmationLink { get; set; }
}