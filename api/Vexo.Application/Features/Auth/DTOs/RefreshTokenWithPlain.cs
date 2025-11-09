using Vexo.Domain.Entities;

namespace Vexo.Application.Features.Auth.DTOs;

public sealed record RefreshTokenWithPlain(RefreshToken TokenEntity, string PlainToken);