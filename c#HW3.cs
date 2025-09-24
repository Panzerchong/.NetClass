/*
Questions
1.	Describe the problem generics address.
Different variable types cannot use the same method with particular data type declaration. 
Generics can combine them into one generics method while keep type safety and performance.

2.	How would you create a list of strings, using the generic List class?
List<string> str = new List<string>();

3.	How many generic type parameters does the Dictionary class have?
The Dictionary class has two generic type parameters: TKey and TValue.

4.	True/False. When a generic class has multiple type parameters, they must all match.
False

5.	What method is used to add items to a List object?
Add()
Insert(index, item)

6.	Name two methods that cause items to be removed from a List.
Remove(item)
RemoveAt(index)
RemoveRange(index, count)
RemoveAll(Predicate<T> match)

7.	How do you indicate that a class has a generic type parameter?
Use <T>

8.	True/False. Generic classes can only have one generic type parameter.
False

9.	True/False. Generic type constraints limit what can be used for the generic type.
True

10.	True/False. Constraints let you use the methods of the thing you are constraining to.
True
*/


/*
Task 1:
Define a generic class called MyStack<T> with the following requirements:
1.	Use Stack<T> internally to store the data.
2.	Implement a Count() method that returns the number of elements in the stack.
3.	Implement a Pop() method that returns and removes the top element of the stack.
4.	Implement a Push(T obj) method that adds an element to the stack.
Finally, create an instance of MyStack<int>, push two integers into it, and print out the current number of elements in the stack.
*/

public class MyStack<T>
{
    private Stack<T> stack = new Stack<T>();
    public int Count()
    {
        return stack.Count;
    }

    public T Pop()
    {
        return stack.Pop();
    }

    public void Push(T obj)
    {
        stack.Push(obj);
    }

    public void PrintAll()
    {
        Console.WriteLine("Elements in stack:");
        foreach (T item in stack)
        {
            Console.WriteLine(item);
        }
    }

}

class Program
{
    static void Main(string[] args)
    {
        MyStack<int> numbers = new MyStack<int>();

        numbers.Push(5);
        numbers.Push(3);
        Console.WriteLine("Count: " + numbers.Count());
        numbers.PrintAll();
    }
}


/*
Task 2:
 Create a generic repository pattern in C# with the following requirements:
1.	Define a generic interface IGenericRepository<T> where T : class.

○	The interface should declare the following methods:

■	Add(T item)

■	Remove(T item)

■	Save()

■	IEnumerable<T> GetAll()

■	T GetById(int id)

2.	Implement a class GenericRepository<T> that inherits from IGenericRepository<T>.

○	Use a private List<T> field to store the data.
○	In the constructor, initialize the list as a new empty List<T>.
○	Provide method implementations for Add, Remove, GetAll, GetById. No actual implementation is needed for Save.
*/

public interface IGenericRepository<T> where T : class
{
    int Add(T item);
    int Remove(T item);
    int Save();
    IEnumerable<T> GetAll();
    T GetById(int id);
}

public class GenericRepository<T> : IGenericRepository<T> where T: class
{
    private List<T> newList;
    public GenericRepository()
    {
        newList = new List<T>();
    }

    public int Add(T item)
    {
        newList.Add(item);
        return 1;
    }

    public int Remove(T item)
    {
        if (newList != null)
        {
            newList.Remove(item);
            return 1;
        }
        return 0;
    }

    public int Save()
    {
        //No implement needed
        return 1;
    }

    public IEnumerable<T> GetAll()
    {
        return newList;
    }

    public T GetById(int id)
    {
        for (int i = 0; i < newList.Count; i++)
        {
            if (newList[i].ID == id)
            {
                return newList[i];
            }
        }
        return null;
    }
}

