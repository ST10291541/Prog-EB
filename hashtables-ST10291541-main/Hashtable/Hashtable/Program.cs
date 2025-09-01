namespace Hashtable
{
    public class Program
    {
        static void Main(string[] args)
        {
            InfluencerHashtable influencers = new InfluencerHashtable();

            // Insert influencers
            influencers.Insert("TravelQueen", new Influencer("TravelQueen", 50000, new DateTime(2019, 5, 1), "Exploring Paris!"));
            influencers.Insert("FoodieGuy", new Influencer("FoodieGuy", 120000, new DateTime(2018, 3, 15), "Best pizza in New York!"));
            influencers.Insert("TechGuru", new Influencer("TechGuru", 75000, new DateTime(2020, 1, 20), "Latest iPhone Review"));

            Console.WriteLine("Retrieve Influencer:");
            var influencer = influencers.Get("FoodieGuy");
            Console.WriteLine(influencer);

            Console.WriteLine("\nRemoving Influencer: TechGuru");
            influencers.Remove("TechGuru");

            var removedInfluencer = influencers.Get("TechGuru");
            Console.WriteLine(removedInfluencer == null ? "TechGuru not found." : removedInfluencer.ToString());
        }
    }
}
