using System.Collections.Generic;

namespace Assignment_2_Web_Client.Models {
public class Child : Person {
    
    public List<Interest> Interests { get; set; }
    public List<Pet> Pets { get; set; }
}
}