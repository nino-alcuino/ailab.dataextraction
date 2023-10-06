using Newtonsoft.Json;

namespace dataextraction.Models
{
    public class DefaultContext
    {
        private const string Value = "[{\"title\":\"ThingsFallApart\",\"description\":\"AclassicnovelofcolonialismanditsimpactontraditionalAfricansociety.\"},{\"title\":\"TheLordoftheRings\",\"description\":\"Anepicfantasytrilogyaboutahobbit'squesttodestroytheOneRing.\"},{\"title\":\"PrideandPrejudice\",\"description\":\"Aromanticcomedyabouttwoyoungpeoplefromdifferentsocialclasses.\"},{\"title\":\"ToKillaMockingbird\",\"description\":\"Acoming-of-agestoryaboutayounggirlwholearnsaboutracismandinjustice.\"},{\"title\":\"TheGreatGatsby\",\"description\":\"Astoryoflove,loss,andtheAmericanDream.\"},{\"title\":\"1984\",\"description\":\"Adystopiannovelaboutatotalitariansociety.\"},{\"title\":\"TheCatcherintheRye\",\"description\":\"Acoming-of-agestoryaboutateenagerwhorebelsagainstsociety.\"},{\"title\":\"Hamlet\",\"description\":\"Atragedyaboutaprincewhoseeksrevengeforhisfather'smurder.\"},{\"title\":\"TheOdyssey\",\"description\":\"AnepicpoemaboutaGreekhero'sjourneyhomefromwar.\"},{\"title\":\"TheAdventuresofHuckleberryFinn\",\"description\":\"Acoming-of-agestoryaboutaboywhorunsawayfromhomeandtravelsdowntheMississippiRiverwithanescapedslave.\"},{\"title\":\"TheColorPurple\",\"description\":\"Anovelaboutablackwoman'sjourneyfromabusetoself-discovery.\"},{\"title\":\"TheBookThief\",\"description\":\"AstoryaboutayounggirlwholearnstoreadandlovebooksinNaziGermany.\"},{\"title\":\"TheKiteRunner\",\"description\":\"AstoryabouttwoboysgrowingupinAfghanistanandthefriendshipthatbindsthemtogether.\"},{\"title\":\"TheHungerGames\",\"description\":\"Adystopiannovelaboutayoungwomanwhovolunteerstotakeheryoungersister'splaceinadeadlycompetition.\"},{\"title\":\"TheFaultinOurStars\",\"description\":\"Alovestorybetweentwoteenagerswithcancer.\"},{\"title\":\"WheretheCrawdadsSing\",\"description\":\"Acoming-of-agestoryaboutayoungwomanwhogrowsupinisolationinthemarshesofNorthCarolina.\"},{\"title\":\"NormalPeople\",\"description\":\"AlovestorybetweentwoyoungpeoplefromdifferentsocialclassesinIreland.\"},{\"title\":\"TheMidnightLibrary\",\"description\":\"Astoryaboutawomanwhohasthechancetolivedifferentlivesandseewhatcouldhavebeen.\"},{\"title\":\"ProjectHailMary\",\"description\":\"Astoryaboutanamnesiacwhowakesuponaspaceshipandmustfigureouthowtosavehumanity.\"}]";
        public string Books = string.Join(",", JsonConvert.DeserializeObject<List<Book>>(Value) ?? new List<Book>());

        public class Book
        {
            public string Title { get; set; } = string.Empty;
            public string Description { get; set; } = string.Empty;
            public bool IsAvailable { get; set; } = true;
        }

        public string BookList = string.Join(",", new List<Book>
        {
            new()
            {
                Title = "Algorithms",
                Description = "A comprehensive introduction to the most important algorithms in computer science."
            },
            new()
            {
                Title = "Introduction to Algorithms"
            },
            new()
            {
                Title = "The Pragmatic Programmer"
            },
            new()
            {
                Title = "Design Patterns: Elements of Reusable Object-Oriented Software"
            },
            new()
            {
                Title = "Head First Design Patterns"
            },
            new()
            {
                Title = "Clean Code: A Handbook of Agile Software Craftsmanship"
            },
            new()
            {Title = "The Mythical Man-Month: Essays on Software Engineering"}
        });

        public string Conditions = string.Join(",", new string[]
        {
            "your response should be base on the provided Data",
            "your response should return 'No Book Found' if not found in the list of books",
            "your response should return the title of the book base on the user input",
            "your response should base on finding the book if available"
        });

        public string Personality = string.Join(",", new string[]
        {
            "You're a Polite Librarian",
        });
    }
}
