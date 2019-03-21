using System.Collections.Generic;

namespace ExpertCars.Data.Entities
{
  public class Model
  {
    public int Id { get; set; }
    public string Description { get; set; }
    public int BrandId { get; set; }
    public Brand Brand { get; set; }
    public List<Vehicle> Vehicles { get; set; }
    public Model()
    {
      Vehicles = new List<Vehicle>();
    }
  }
}
