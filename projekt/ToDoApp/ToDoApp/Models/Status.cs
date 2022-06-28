namespace ToDoApp.Models
{
    /// <summary>
    ///   Model of Status
    /// </summary>
    public class Status
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public override string ToString() => this.Name;
    }
}