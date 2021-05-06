namespace NTIER.Common.Interface
{
    public interface IModuleEntity
    {
        short ModuleId { get; set; }
        string ModuleName { get; set; }
        long ValidPermission { get; set; }
    }
}
