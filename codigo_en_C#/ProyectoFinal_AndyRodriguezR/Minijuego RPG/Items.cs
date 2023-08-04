namespace EspacioItems;

// Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);
    public class Result
    {
        public string index { get; set; }
        public string name { get; set; }
        public string url { get; set; }
    }

    public class Items
    {
        public int count { get; set; }
        public List<Result> results { get; set; }
    }



    

