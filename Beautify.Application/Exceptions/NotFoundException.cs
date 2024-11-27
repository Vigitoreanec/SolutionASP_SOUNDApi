namespace Beautify.Application.Exceptions;

public class NotFoundException(string name, object objKey) : Exception($"Entity {name} ({objKey}) not found")
{   

}
