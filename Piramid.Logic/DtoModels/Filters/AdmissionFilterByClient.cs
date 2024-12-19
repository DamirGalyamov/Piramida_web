namespace Piramida.Logic.DtoModels.Filters
{
    public sealed record AdmissionFilterByClient
    {
        public Guid ClientId { get; set; }
    }
}
