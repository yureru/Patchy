using System;

namespace Patchy
{
    /// <summary>
    /// A Generic Binary Tree implementation.
    /// Currently it can insert elements and lookup by name.
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            Person[] items = {
                            new Person("Dennis", "Ritchie", 40, 1, false),
                            new Person("Richard", "Stallman", 63, 5, false),
                            new Person("Yukihiro", "Matsumoto", 51, 4, false),
                            new Person("Bjarne", "Stroustrup", 65, 7, false)
                         };

            GenericTree<Person> tree = new GenericTree<Person>();

            // Pollute the tree
            foreach (var elem in items)
            {
                tree = Insert(tree, new GenericTree<Person>(elem));
            }

            var item = Lookup(tree, "Yukihiro");

            if (item != null)
            {
                Console.WriteLine("Person found");
                Console.WriteLine("Name: {0}\nLastName: {1}\nAge: {2}", item._value.Name, item._value.LastName, item._value.Age);
            }
            else
            {
                Console.WriteLine("Person wasn't found");
            }

            // Allow us to see the output in the CLI
#if DEBUG
            Console.ReadKey();
#endif

        }

        #region Methods

        /// <summary>
        /// Inserts elements in the proper side of the tree, based on the Name comparison.
        /// </summary>
        /// <param name="tree">The tree's root.</param>
        /// <param name="newItem">The new item.</param>
        /// <returns></returns>
        static GenericTree<Person> Insert(GenericTree<Person> tree, GenericTree<Person> newItem)
        {
            if (tree._value == null)
            {
                return newItem;
            }

            int cmp = newItem._value.Name.CompareTo(tree._value.Name);

            if (cmp == 0)
            {
                Console.WriteLine("Insert: duplicate entry {0} ignored", newItem._value.Name);
            }
            else if (cmp > 0)
            {
                tree._right = new GenericTree<Person>();
                tree._right = Insert(tree._right, newItem);
            }
            else
            {
                tree._left = new GenericTree<Person>();
                tree._left = Insert(tree._left, newItem);
            }

            return tree;
        }

        /// <summary>
        /// Searchs for a given name in the tree.
        /// </summary>
        /// <param name="tree">The tree's root.</param>
        /// <param name="name">Name to search</param>
        /// <returns>The branch match, null otherwise.</returns>
        static GenericTree<Person> Lookup(GenericTree<Person> tree, string name)
        {
            if (tree == null)
            {
                return null;
            }

            int cmp = name.CompareTo(tree._value.Name);

            if (cmp == 0)
            {
                return tree;
            }
            else if (cmp > 0)
            {
                return Lookup(tree._right, name);
            }
            else
            {
                return Lookup(tree._left, name);
            }
        }

        #endregion // Methods
    }
}

/// <summary>
/// The Generic tree structure.
/// </summary>
/// <typeparam name="T"></typeparam>
class GenericTree<T>
{
    #region Fields

    public T _value;
    public GenericTree<T> _left;
    public GenericTree<T> _right;

    #endregion // Fields

    #region Constructors

    public GenericTree(T item)
    {
        _value = item;
    }

    public GenericTree()
    { }

    #endregion // Constructors
}

/// <summary>
/// The class to be used as type for the tree's values.
/// </summary>
class Person
{
    #region Fields

    public string Name { get; set; }
    public string LastName { get; set; }
    public int Age { get; set; }
    public int ID { get; set; }
    public bool Gender { get; set; }

    #endregion // Fields

    #region Constructors

    public Person(string name, string lastName, int age, int id, bool gender)
    {
        Name = name;
        LastName = lastName;
        Age = age;
        ID = id;
        Gender = gender;
    }

    #endregion // Constructors
}