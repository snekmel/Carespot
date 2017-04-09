namespace Carespot.Models
{
    public class Beoordeling
    {
        public Beoordeling()
        {
        }

        public Beoordeling(string opmerking, int cijfer, int voorGebruikersId, int hulpbehoevendeId)
        {
            Opmerking = opmerking;
            Cijfer = cijfer;
            VrijwilligerId = voorGebruikersId;
            HulpbehoevendeId = hulpbehoevendeId;
        }

        public Beoordeling(int id, string opmerking, int cijfer, string reactie, int voorGebruikersId,
            int hulpbehoevendeId)
        {
            Id = id;
            Opmerking = opmerking;
            VrijwilligerId = voorGebruikersId;
            Cijfer = cijfer;
            Reactie = reactie;
            HulpbehoevendeId = hulpbehoevendeId;
        }

        public int Id { get; set; }
        public string Opmerking { get; set; }

        //ID van de vrijwilliger waarvoor deze beoordeling is
        public int VrijwilligerId { get; set; }

        public int Cijfer { get; set; }
        public string Reactie { get; set; }

        //ID van de auteur van de beoordeling
        public int HulpbehoevendeId { get; set; }

        public override string ToString()
        {
            return "ID:" + Id + " Opmerking: " + Opmerking + " Cijfer: " + Cijfer;
        }
    }
}