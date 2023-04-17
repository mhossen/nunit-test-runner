namespace nunit.tests;

public class TestAssemblyReference
{
  private static readonly Assembly Assembly = typeof(TestAssemblyReference).Assembly;
  private static readonly Type[] Types = Assembly.GetTypes().Where(t => t.Assembly.GetName().Name!.Equals(AssemblyName) && !t.IsDefined(typeof(System.Runtime.CompilerServices.CompilerGeneratedAttribute), inherit: false)).ToArray();

  private static readonly MethodInfo[] Methods = Types
    .SelectMany(t => t.GetMethods())
    .Where(m => m.GetCustomAttributes(typeof(TestAttribute), false)
      .Any()).ToArray();

  public static readonly string? AssemblyName = Assembly.GetName().Name;

  public static readonly IReadOnlyList<string> TestNames = Array
    .ConvertAll(Methods, m => $"{m.DeclaringType?.Namespace}.{m.DeclaringType?.Name}.{m.Name}")
    .ToList().AsReadOnly();
}