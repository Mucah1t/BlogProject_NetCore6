using System.ComponentModel.DataAnnotations;

namespace BlogProjectUI.Models
{
    public class RoleViewModel
    {
        [Required(ErrorMessage ="Please enter a role name.")]
        public string name { get; set; }
    }
}
