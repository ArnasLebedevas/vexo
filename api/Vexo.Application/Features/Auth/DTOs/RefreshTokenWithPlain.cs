using Vexo.Domain.Entities;

namespace Vexo.Application.Features.Auth.DTOs;

public record RefreshTokenWithPlain(RefreshToken TokenEntity, string PlainToken);