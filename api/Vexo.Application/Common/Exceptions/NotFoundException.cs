namespace Vexo.Application.Common.Exceptions;

public abstract class NotFoundException(string message) : Exception(message) { }