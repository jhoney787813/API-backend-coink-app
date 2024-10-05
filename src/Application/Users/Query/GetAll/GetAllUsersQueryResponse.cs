namespace Application.Users.Query.GetAll
{
    public class GetAllUsersQueryResponse
    {
        public GetAllUsersQueryResponse(string identification, string fullName, string phone, string address, int cityId, string cityName)
        {
            Identification = identification;
            FullName = fullName;
            Phone = phone;
            Address = address;
            CityId = cityId;
            CityName = cityName;
        }

        public string Identification { get; set; }
        public string FullName { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public int CityId { get; set; }
        public string CityName { get; set; }
    }
}

