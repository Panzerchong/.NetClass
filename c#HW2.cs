
/*
1.	What are the six combinations of access modifier keywords and what do they do?
Public: the class can be accessed anywhere
Private: the class can be accessed within the same class
Protected: the class and its child class even not in the same project can access the class
Internal: the class can be accessed in the project scope
Protected internal: the class can be accessed in the project scope and its child class
Private protected: the class can be accessed by itself and derived class only they are in the same project.

2.	What is the difference between the static, const, and readonly keywords when applied to a type member?
static: belongs to the type itself, not to any specific instance of the type.
const: it needs to initialized when declaration, can only be used for primitive types, enums, or strings.
readonly: it needs to initialized. Set value at runtime. Cannot be reassigned after construction, but different instances can have different value.

3.	What does a constructor do?
It runs automatically when creating the object of the class and initialized object.

4.	Why is the partial keyword useful?
It can split large code into different files, helpful for auto- generated code and team collaboration.

5.	What is a tuple?
Tuple is data structure that holds different values in one object.

6.	What does the C# record keyword do?
A record in C# is a class or struct that provides special syntax and behavior for working with data models. 
The record modifier instructs the compiler to synthesize members that are useful for types whose primary role is storing data.	

7.	What does overloading and overriding mean?
Overloading: different methods have same name but with different parameters.
Overriding: new implementation for a method defined in the base class virtual method.

8.	What is the difference between a field and a property?
Field is variables that a class or struct have
Property is a collection of field with get and set method

9.	How do you make a method parameter optional?
Create default parameter values so the method will use default value when no value is passed to the method.

10.	What is an interface and how is it different from an abstract class?
Interface is a contract specifying a set of members. It will contain only the declaration of the members. 
The implementation of its members must be done by the class who implements the interface.
Abstract class is a class that cannot be instantiated directly. It's the base of derived class.
It can contain both abstract method or concrete method.

11.	What accessibility level are members of an interface by default?
By default, all members of interface are public

12.	True/False: Polymorphism allows derived classes to provide different implementations of the same method.
True

13.	True/False: The override keyword is used to indicate that a method in a derived class is providing its own implementation.
True

14.	True/False: The new keyword is used to indicate that a method in a derived class is providing its own implementation.
False

15.	True/False: Abstract methods can be used in a normal (non-abstract) class.
False

16.	True/False: Normal (non-abstract) methods can be used in an abstract class.
True

17.	True/False: Derived classes can override methods that were virtual in the base class.
True

18.	True/False: Derived classes can override methods that were abstract in the base class.
True

19.	True/False: Derived classes must override the abstract methods from the base class.
True

20.	True/False: In a derived class, you can override a method that was neither virtual nor abstract in the base class.
False

21.	True/False: A class that implements an interface does not have to provide an implementation for all of the members of the interface.
False

22.	True/False: A class that implements an interface is allowed to have other members in addition to the interface members.
True

23.	True/False: A class can inherit from more than one base class.
False

24.	True/False: A class can implement more than one interface.
True
*/


/*
Create 3 classes in Program.cs:
a. Person class
●	Create an abstract class Person with the following members:

○	An Id property (int).

○	A private field salary with a public property Salary that only accepts positive values; throw an exception if a negative value is assigned.

○	A DateOfBirth property (DateTime).

○	An Address property (List of strings).

________________________________________
b. Instructor class
●	Create a class Instructor that inherits from Person.

○	Add a DepartmentId property (int).


________________________________________
c. Student class
●	Create a class Student that inherits from Person.

○	Add a property SelectedCourses, which is a list of Course objects.
*/

public abstract class Person
{
    public int ID { get; set; }

    private decimal salary;

    public decimal Salary
    {
        get { return salary; }
        set
        {
            if (value < 0)
            {
                throw new ArgumentOutOfRangeException("Salary should be positive!");
            }
            salary = value;
        }
    }

    public DateTime DateOfBirth { get; set; }
    public List<string> Address { get; set; } = new List<string>();

}

public class Instructor : Person
{
    public int DepartmentId { get; set; }
}

public class Course
{
    public int CourseId { get; set; }
    public required string Name { get; set; }
}

public class Student : Person
{
    public List<Course> SelectedCourses { get; set; } = new List<Course>();
}
