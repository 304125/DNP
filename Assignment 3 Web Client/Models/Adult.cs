namespace Assignment_2_Web_Client.Models {
public class Adult : Person {
    public Job JobTitle { get; set; }

    public Adult()
    {
        JobTitle = new Job();
    }
}
}