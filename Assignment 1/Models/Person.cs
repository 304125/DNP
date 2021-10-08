using System.ComponentModel.DataAnnotations;

namespace Models {
public class Person {
    
    public int Id { get; set; }
    
    [Required, MaxLength(128), Display(Name = "First name")]
    public string FirstName { get; set; }
    
    [Required, MaxLength(128), Display(Name = "Last name")]
    public string LastName { get; set; }
    public string HairColor { get; set; }
    public string EyeColor { get; set; }
    
    [Range(1, 130, ErrorMessage = "Age must be bigger than {1} and smaller than {2}")]
    public int Age { get; set; }
    
    [Range(2, 200, ErrorMessage = "Weight must be bigger than {1} and smaller than {2}")]
    public float Weight { get; set; }
    
    [Range(30, 280, ErrorMessage = "Height must be bigger than {1} and smaller than {2}")]
    public int Height { get; set; }
    public string Sex { get; set; }
}


}