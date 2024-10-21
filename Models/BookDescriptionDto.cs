namespace TomBooks.Models;

public class BookDescriptionDto
{
    public BookDescriptionDto(string description)
    {
        Description = description;
    }

    public string Description { get; set; }
}
