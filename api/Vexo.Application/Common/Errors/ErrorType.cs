﻿namespace Vexo.Application.Common.Errors;

public enum ErrorType
{
    None,
    Validation,
    Business,
    NotFound,
    Unauthorized,
    Conflict,
    System,
    Email,
    UnsupportedProvider,
}