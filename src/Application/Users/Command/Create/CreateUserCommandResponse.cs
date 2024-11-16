namespace Application.Users.Command.Create
{
    public class CreateUserCommandResponse
    {
        public CreateUserCommandResponse(string identification, string fulltName, string phone, string address, int cityId, string cityName)
        {
            Identification = identification;
            FullName = fulltName;
            Phone = phone;
            Address = address;
            CityId = cityId;
            CityName=  cityName;

        }

        public string Identification { get; set; }
        public string FullName { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public int CityId { get; set; }
        public string CityName { get; set; }
    }
}