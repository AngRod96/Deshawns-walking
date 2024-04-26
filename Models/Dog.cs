namespace DeShawns.Models; 

public class Dog
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int WalkerId { get; set; }
    public int CityId { get; set; }
    public City City { get; set; } //get city name that the dog is in 
}
