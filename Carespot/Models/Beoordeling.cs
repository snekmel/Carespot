namespace Carespot.Models
{
    public class Beoordeling
    {
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

        public int Id { get; private set; }
        public string Opmerking { get; private set; }

        //ID van de vrijwilliger waarvoor deze beoordeling is
        public int VrijwilligerId { get; private set; }

        public int Cijfer { get; private set; }
        public string Reactie { get; private set; }

        //ID van de auteur van de beoordeling
        public int HulpbehoevendeId { get; private set; }
    }
}