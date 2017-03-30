namespace Carespot.Models
{
    public class Beoordeling
    {
        public int Id { get; private set; }
        public string Opmerking { get; private set; }
        public int VoorGebruikersId { get; private set; }
        public int Cijfer { get; private set; }
        public string Reactie { get; private set; }
    }
}