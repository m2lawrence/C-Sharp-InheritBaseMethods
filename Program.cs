//C# Inheritance calling Base Methods, line 91 - 95.

using System;
using System.Text;
namespace InheritBaseMethods
{
	class Person
	{
		//was private, now protected for a derived class. 
		protected string firstName;
		protected string middleName;
		protected string lastName;
		private int age;
		
		//Add properties to access the data members.
		
		public Person()
		{
		}
		
		public Person(string fn, string ln)
		{
			firstName=fn;
			lastName=ln;
		}
		
		public Person(string fn, string mn, string ln)
		{
			firstName=fn;
			middleName=mn;
			lastName=ln;
		}
		
		public Person(string fn, string mn, string ln, int a)
		{
			firstName=fn;
			middleName=mn;
			lastName=ln;
			age=a;
		}
		
		public void displayAge()
		{
			Console.WriteLine("Age {0}", age);
		}
		
		public void displayFullName()
		{
			StringBuilder FullName = new StringBuilder();
			
			FullName.Append(firstName);
			FullName.Append(" ");
			if (middleName != "") 
			{
				FullName.Append(middleName[0]);
				FullName.Append(". ");
			}
			FullName.Append(lastName);
			
			Console.WriteLine(FullName);		
		}
	}
	
	//The 'Employee' derived class, inherits from the 'Person' base class. 
	class Employee : Person
	{
		private ushort hYear;
		public ushort hireYear
		{
			get { return(hYear); }
			set { hYear = value; }
		}
		
		public Employee() : base()
		{
		}
		
		public Employee(string fn, string ln ) : base(fn, ln)
		{
		}
		
		public Employee(string fn, string mn, string ln, int a) : base(fn, mn, ln, a)
		{
		}
		
		public Employee(string fn, string ln, ushort hy) : base(fn, ln)
		{
			hireYear = hy;
		}
		
// NEW FASTER CODE HERE!!! ----------------------------------------------------------------------------------------------
		public new void displayFullName()
		{
			Console.WriteLine("Employee: ");
			base.displayFullName(); //calling the base method, to save writing out all the code again. Shown below!
		}

//------------Normally wrote like this the long way...---------------------------------		
//		public new void displayFullName()
//		{
//			Console.WriteLine("Employee: {0} {1} {2}", firstName, middleName, lastName);
//		}
//------------Normally wrote like this the long way.-----------------------------------		

	}
		
	//NameApp class, illustrates the use of the Person class.
	class NameApp
	{
		public static void Main()
		{
			//class object =new class(); builds the objects. Then assign values to them.
			Person girl = new Person("Melissa", "Santa", "Clause", 21); //base class.
			Employee me = new Employee("Mike", "Jacques", "Lawrence", 39); //derived class, inherits from base.
			Employee you = new Employee("Tim", "Allen", 2016); //derived class, inherits from base.
			
			girl.displayFullName(); //
			girl.displayAge();
			
			me.displayFullName();
			Console.WriteLine("Year hired: {0}", me.hireYear);
			me.displayAge();
			
			Console.ReadKey(true); //pause.
		}
	}
}