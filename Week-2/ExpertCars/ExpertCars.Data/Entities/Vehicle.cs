namespace ExpertCars.Data.Entities
{
  public class Vehicle
  {
    public int Id { get; set; }
    public string VIN { get; set; }
    public int ModelId { get; set; }
    public Model Model { get; set; }
  }
}
