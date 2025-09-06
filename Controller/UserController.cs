using Microsoft.AspNetCore.Mvc; // This gives you access to classes
                                // like ControllerBase, ApiController, and attributes like [HttpGet], [Route], etc.
namespace webapidemo.Controller; //defines which  package are you using 


public class UserController : ControllerBase
{
    [HttpGet]
    [Route("/person")]
    public ActionResult<List<Person>> GetPerson()
    {
        return Ok(PersonDB.db);
    }

    [HttpPost] // create 
    [Route("/person")]
    public ActionResult<Person> PostPerson(Person person)
    {
        PersonDB.db.Add(person);
        return Ok(person);
    }

    [HttpPut]
    [Route("/person")]
    public ActionResult<List<Person>> UpdatePerson(int id, Person updatedPerson)
    {
        var existingPerson = PersonDB.db.FirstOrDefault(p => p.Id == id);
        if (existingPerson == null)
        {
            return NotFound($"Person with Id {id} not found.");
        }

        // Update properties
        existingPerson.Name = updatedPerson.Name;
        existingPerson.Age = updatedPerson.Age;

        return Ok(PersonDB.db);
    }

    [HttpDelete]
    [Route("/person/{id}")]
    public ActionResult<Person> DeletePerson(int id)
    {
        var existingPerson = PersonDB.db.FirstOrDefault(p => p.Id == id);
        if (existingPerson == null)
        {
            return NotFound($"Person with Id {id} not found.");
        }
        PersonDB.db.Remove(existingPerson);
        return Ok(PersonDB.db);
    }

    public static class PersonDB

    {
        public static List<Person> db = new List<Person>
        {
            new Person { Id = 1, Age = 15, Name = "James" },
            new Person { Id = 2, Age = 25, Name = "Bruno" }

        };
    }

    public class Person() //simple model
    {
        public string Name { get; set; }
        public int Id { get; set; }
        public int Age { get; set; }
    }
}

