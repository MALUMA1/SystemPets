namespace SysPet.Services
{
    public interface IPdfService<in T>
    {
        byte[] GeneratePdf(IEnumerable<T> model);
    }
}
