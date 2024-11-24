using AutoMapper;
using System.Reflection;

namespace Beautify.Application.Common.MappingProfile;

public class AssemblyMappingProfile : Profile
{
    public AssemblyMappingProfile(Assembly assembly) =>
        ApplyMappingsFromAssembly(assembly);

    private void ApplyMappingsFromAssembly(Assembly assembly)
    {
        var types = assembly.GetExportedTypes()
            .Where(type=>type.GetInterfaces()
            .Any(i=>i.IsGenericType && 
        i.GetGenericTypeDefinition() == typeof(IMapWith<>)))
            .ToList();

        foreach (var type in types)
        {
            // экземпляр класса от некоторого типа
            var instance = Activator.CreateInstance(type); 
            // получить ссылку от некоторого типа, на метод который будет содержать в себе тип, который будет имплементрировать в себе определенный интерфейс 
            var metodInfo = type.GetMethod("Mapping");
            // вызов, Объект, который содержит данный тип и передовать аргумент, через профайл которым мы мапим данные
            metodInfo?.Invoke(instance, [this]);            
        }

    }
}
