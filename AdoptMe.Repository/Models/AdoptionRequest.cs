namespace AdoptMe.Repository.Models
{
    public class AdoptionRequest
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public string UserEmail { get; set; }
        public string Message { get; set; }
        public int PetId {  get; set; }

        public AdoptionRequest() { }

        public AdoptionRequest(int id, string name, string phone, string email, string message, int petId)
        {
            Id = id;
            Name = name;
            Phone = phone;
            UserEmail = email;
            Message = message;
            PetId = petId;
        }

        public AdoptionRequest(string name, string phone, string email, string message, int petId)
        {
            Name = name;
            Phone = phone;
            UserEmail = email;
            Message = message;
            PetId = petId;
        }
    }
}
