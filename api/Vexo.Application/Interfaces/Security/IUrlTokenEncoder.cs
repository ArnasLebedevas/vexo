namespace Vexo.Application.Interfaces.Security;

public interface IUrlTokenEncoder
{
    string Encode(string value);
    string Decode(string value);
}