public class FactSeed : Seed
{

    Seed createSeed(TypePlant plant)
    {

        switch (plant)
        {
            case Elb : return new Seed(Elb, 2, 1);
            break;
            case Egro : return new Seed(Egro, 2, 1);
            break;
            case Ajos : return new Seed(Ajos);
            break;
            case Siam : return new Seed(Siam);
            break;
            case Ouch : return new Seed(Ouch);
            break;
            case Echav : return new Seed(Echav);
            break;
            case Ontoum : return new Seed(Ontoum);
            break;
            case Eluop : return new Seed(Euluop);
            break;
            case Nipal : return new Seed(Nipal);
            break;
            case Azloc : return new Seed(Azloc);
            break;
            default:
        }

    }

}