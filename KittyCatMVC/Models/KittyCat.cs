namespace KittyCatMVC.Models
{
    public class KittyCat
    {
        public int KittyValue { get; set; }
        public int CatValue { get; set; }
        public List<string> Result { get; set; } = new();
    }
}
