namespace Models {
public class Adult : Person {
    public Job JobTitle { get; set; }

    public Adult()
    {
        JobTitle = new Job();
    }

    public override string ToString()
    {
        return FirstName;
    }
}
}