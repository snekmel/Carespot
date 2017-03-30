namespace Carespot.Models
{
    public class Vaardigheid
    {
        public Vaardigheid(string v)
        {
            VaardigheidText = v;
        }

        public int Id { get; set; }

        public string VaardigheidText { get; set; }
    }
}