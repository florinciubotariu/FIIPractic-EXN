using System.Collections.Generic;

namespace ExpertCars.Data.Entities
{
  public class Brand
  {
    public int Id { get; set; }
    public string Name { get; set; }
    public string LogoURI { get; set; }
    public List<Model> Models { get; set; }
    public Brand()
    {
      Models = new List<Model>();
    }
  }
}
