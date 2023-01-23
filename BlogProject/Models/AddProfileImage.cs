using Microsoft.AspNetCore.Http;

namespace BlogProjectUI.Models
{
    public class AddProfileImage
    {
        public int WriterID { get; set; }
        public string WriterName { get; set; }
        public string WriterAbout { get; set; }
        public IFormFile WriterImage { get; set; } //to be able to select a image from file
        public string WriterMail { get; set; }
        public string WriterPassword { get; set; }
        public string WriterConfirmPassword { get; set; }

        public bool WriteStatus { get; set; }
    }
}
