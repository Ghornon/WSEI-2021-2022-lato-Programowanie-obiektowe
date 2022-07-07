namespace ToDoApp.Models
{
    /// <summary>
    ///   Model of Status
    /// </summary>
    public class Status
    {
        /// <summary>
        /// ID - int, not null, primary key
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// Name - string, not null
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Return Name as string
        /// </summary>
        public override string ToString() => this.Name;
    }
}