namespace Domain.Entities
{
	public class User
	{
        public User(string identification, string fulltName, string phone, string address, int cityId)
        {
            Identification = identification;
            FullName = fulltName;
            Phone = phone;
            Address = address;
            CityId = cityId;


        }

        public string Identification { get; set; }
        public string FullName { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public int CityId { get; set; }
    }
}