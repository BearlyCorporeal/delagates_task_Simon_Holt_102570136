using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using ObjectLibrary;
using System.Text;


namespace FileParser {
    
    //public class Person { }  // temp class delete this when Person is referenced from dll
    
    public class PersonHandler {
        public List<Person> People;

        /// <summary>
        /// Converts List of list of strings into Person objects for People attribute.
        /// </summary>
        /// <param name="people"></param>
        public PersonHandler(List<List<string>> people) {
            people.Remove(people[0]);
            DataParser dp = new DataParser();
            List<List<string>> newpeople = new List<List<string>>();
            People = new List<Person>();
            int id;
            DateTime dob;
            Person p;
            string trimed;
            List<string> line = new List<string>();
            foreach (var person in people)
            {
                foreach (var item in person)
                {
                    trimed = item;
                    var sb = new StringBuilder();
                    foreach (char c in trimed)
                    {
                        if (c != '#')
                            sb.Append(c);
                    }
                    trimed = sb.ToString();
                    line.Add(trimed);
                }

                newpeople.Add(line);
                line = new List<string>();
            }
            newpeople = dp.StripWhiteSpace(newpeople);
            newpeople = dp.StripQuotes(newpeople);
            foreach (var person in newpeople)
            {
                id = int.Parse(person[0]);
                dob = new DateTime(long.Parse(person[3]));
                p = new Person(id, person[1], person[2], dob);
                People.Add(p);
            }
        }

        /// <summary>
        /// Gets oldest people
        /// </summary>
        /// <returns></returns>
        public List<Person> GetOldest() {
            List<Person> oldest = new List<Person>();
            List<DateTime> dates = new List<DateTime>();
            foreach (var person in People)
            {
                dates.Add(person.Dob);
            }
            DateTime oldestdate = dates.Min();
            foreach(var person in People)
            {
                if(person.Dob == oldestdate)
                {
                    oldest.Add(person);
                }
            }
            return oldest; //-- return result here
        }

        /// <summary>
        /// Gets string (from ToString) of Person from given Id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public string GetString(int id) {
            string fn="";
            string ln="";
            string dob="";
            foreach(var Person in People)
            {
                if(Person.Id == id)
                {
                    fn = Person.FirstName;
                    ln = Person.Surname;
                    DateTime date = Person.Dob;
                    dob = date.ToString("dd/MM/yyyy");
                }
            }
            return fn+" "+ln+" "+dob;  //-- return result here
        }

        public List<Person> GetOrderBySurname() {
            List<Person> orderedlist = new List<Person>();
            foreach (var person in People)
            {
                orderedlist.Add(person);
            }
            orderedlist.Sort((x, y) => x.Surname.CompareTo(y.Surname));
            return orderedlist;  //-- return result here
        }

        /// <summary>
        /// Returns number of people with surname starting with a given string.  Allows case-sensitive and case-insensitive searches
        /// </summary>
        /// <param name="searchTerm"></param>
        /// <param name="caseSensitive"></param>
        /// <returns></returns>
        public int GetNumSurnameBegins(string searchTerm, bool caseSensitive) {
            int counter=0;
            foreach (var person in People)
            {
                if (caseSensitive == true)
                {
                    if (person.Surname.StartsWith(searchTerm)== true)
                    {
                        counter++;
                    }
                }
                else if (caseSensitive == false)
                {
                    if (person.Surname.ToLower().StartsWith(searchTerm.ToLower())== true)
                    {
                        counter++;
                    }
                }
            }
            return counter;  //-- return result here
        }
        
        /// <summary>
        /// Returns a string with date and number of people with that date of birth.  Two values seperated by a tab.  Results ordered by date.
        /// </summary>
        /// <returns></returns>
        public List<string> GetAmountBornOnEachDate() {
            int existenceMark = 0;
            string trimed;
            List<string> result = new List<string>();
            List<DateTime> dates = new List<DateTime>();
            dates.Add(People[0].Dob);
            foreach (var person in People)
            {
                foreach(var Date in dates)
                {
                    if(person.Dob == Date)
                    {
                        existenceMark = 1;
                    }
                }
                if (existenceMark == 0)
                {
                    dates.Add(person.Dob);
                }
                existenceMark = 0;
            }
            dates.Sort();
            int counter = 0;
            foreach(var date in dates)
            {
                foreach(var person in People)
                {
                    if(person.Dob == date)
                    {
                        counter++;
                    }
                }
                string datenew = date.ToString("dd/MM/yyyy");
                var sb = new StringBuilder();
                foreach (char c in datenew)
                {
                    if (c != ' ')
                        sb.Append(c);
                }
                datenew = sb.ToString();
                result.Add(datenew +" "+ counter.ToString());
                counter =0;
            }
            //result.Sort();
            return result;  //-- return result here
        }
    }
}