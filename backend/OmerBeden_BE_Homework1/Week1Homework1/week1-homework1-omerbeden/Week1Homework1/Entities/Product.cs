namespace Week1Homework1.Entity
{
    public class Product:IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }

        public override string ToString()
        {
            return this.Id + "\t" + this.Name + "\t" + this.Price;
        }
    }
}
