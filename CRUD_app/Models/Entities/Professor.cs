namespace CRUD_app.Models.Entities {

    public class Professor {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public bool Subject { get; set; }
    }
}