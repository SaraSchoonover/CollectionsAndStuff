using System;
using System.Collections.Generic;

namespace CollectionsAndStuff
{
    class Program
    {
        static void Main(string[] args)
        {
            // ALL OF THESE METHODS MUTATE THE ORGINAL COLLECTION
            // List<T>
            // is a generic Type: a type that requires me to tell it what type of stuff it does or uses.
            // can store anything inside of a genertic list class
            // inside the angle brackets are Type Parameters used to tell the List how to work. ex: int, string
            var e14Names = new List<string>();

            // add a single item
            // works like .Push and adds to the end of list.
            e14Names.Add("Martin");
            e14Names.Add("Chie");
            e14Names.Add("Holly");

            // takes in numberic index of where you want to put the thing
            e14Names.Insert(1, "Chris");

            // Collection Initializer -  curlt braes with elements inside
            var teacherNames = new List<string> { "Nathan", "Jameka", "Dylan", "Tom" };

            // add one list to the other
            e14Names.AddRange(teacherNames);

            // remove Tom (this uses a thing called reference equality)
            e14Names.Remove("Tom");

            // remove bg index
            e14Names.RemoveAt(0);

            // remove by expression 
            // takes in a string and returns a boolean
            e14Names.RemoveAll(name => name.StartsWith("N"));

            // normal c# foreach loop
            foreach (var name in e14Names)
            {
                Console.WriteLine($"{name} is in e14");
            }

            // list specific loop, takes in an Action<T> (Like a fat arrow function)
            e14Names.ForEach(name => Console.WriteLine($"{name} is in e14 again!"));

            // get the item at the index of 0
            var firstStudent = e14Names[0];

            // dictionary<TKey, TValue> -- Open Generic (no one has specified what type of thing it is yet)
            // Arity -('2)how many generic type parameters a type has.
            // like a physical dictionary, kinda
            // keys have to be unique
            // our dictionary is keyed by string, and also has string values
            // find one thing really fast
            // Good for: infrequently updated but often read data
            // Good for: loading information at startup or in the backgorund and fast retrieval on demand (cacheing)
            var dictionary = new Dictionary<string, string>(); // Closed Generic (we have told it how to behave)

            dictionary.Add("penultimate", "second to last");
            dictionary.Add("Jib", "The things that stick out of rollercoasters");
            dictionary.Add("arbitrary", "Someone who doesn't like Arby's");

            // get one things based on it's key.
            var definition = dictionary["arbitrary"];

            // this wont work: dictionaries require each key to be unique
            // dictionary.Add("penultimate", "Thing said too many times in the Olympics");

            // try methods return a boolean indicating success or failure
            // kind og expensive just to find out if the key exists.
            if (!dictionary.TryAdd("penultimate", "Thing said too many times in the Olympics"))
            {
                Console.WriteLine("It's already in the dictionary. I couldn't add it.");
            }

            if (!dictionary.ContainsKey("penultimate"))
            {
                dictionary["penultimate"] = "Things said too many times in the Olympics";
            }

            // give me all the keys in a collection
            var allTheWords = dictionary.Keys;

            // item holds two different values, key value pair.
            foreach (var item in dictionary)
            {
                Console.WriteLine($"{item.Key}'s definition is {item.Value}");
            }

            // c# destructuring
            foreach (var (word, def) in dictionary)
            {
                Console.WriteLine($"{word}'s definition is {def}");
            }

            var complicatedDictionary = new Dictionary<string, List<string>>();

            complicatedDictionary.Add("Soup", new List<string> { "Hot or cold liquid you eat." });
            var soupDefinition = complicatedDictionary["Soup"];


            // Hashset<T>
            // like a list in that they store a value at an index
            // like a dictionary in that the value has to be unique
            // completely different in that it eliminates non-unique stuff without errors
            // pretty slow at adding data
            //super fast getting data out, comparing data
            // only store unique values! one copy of a thing, won't store two copies of a thing!
            
            
            //var jamekasName = "Jameka";
            //jamekasName.GetHashCode();

            var uniqueNames = new HashSet<string>();
            uniqueNames.Add("Jameka");
            uniqueNames.Add("Jameka");
            uniqueNames.Add("Jameka");
            uniqueNames.Add("Jameka");
            uniqueNames.Add("Dylan");
            uniqueNames.Add("Dylan");

            uniqueNames.Remove("Dylan");

            foreach (var name in uniqueNames)
            {
                Console.WriteLine($"{name} is unique");
            }

            // Queue<T>
            // FIFO (First In, First Out) based collection
            // things that have to be done in order
            // not vety iterible 
            var queue = new Queue<int>();
            queue.Enqueue(3);
            queue.Enqueue(5);
            queue.Enqueue(7);
            queue.Enqueue(2);
            queue.Enqueue(100);
            queue.Enqueue(6);

            while(queue.Count > 0)
            {
                Console.WriteLine($"dequeueing {queue.Dequeue()}");
            }

            // Stack<T>
            // LIFO (Last In, First Out) based collection
            // things done in order, but with a bias towards recency
            var stack = new Stack<int>();

            stack.Push(2);
            stack.Push(5);
            stack.Push(24);
            stack.Push(23);
            stack.Push(200);
            stack.Push(2231);

            while (stack.Count > 0)
            {
                Console.WriteLine($"popping {stack.Pop()}");
            }
        }


    }
}
