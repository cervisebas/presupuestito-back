namespace PresupuestitoBack.DTOs.Response
{
    public class PersonResponseDto
    {
        public int PersonId { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string? Street { get; set; }
        public string? StreetNumber { get; set; }
        public string? Locality { get; set; }
        public string PhoneNumber { get; set; }
        public string? Email { get; set; }
        public string? DNI { get; set; }
        public string? CUIT { get; set; }
    }
}
