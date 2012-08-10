using Sparks.Core;

namespace WebSample.Core.Model
{
    public class Person : PersistentObject
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Phone { get; set; }
    }
}