using Core.Entities.Abstract;

namespace Entities.Concrete
{
    public class Container:IEntity
    {
        public int Id { get; set; }
        public string TypeName { get; set; }
        public double? Length { get; set; }
        public double? Width { get; set; }
        public double? Height { get; set; }
        public double? Capacity { get; set; }
        public double? CargoWeight { get; set; }
        public int ColorId { get; set; }
        public int PortId { get; set; }

    
    }
}
