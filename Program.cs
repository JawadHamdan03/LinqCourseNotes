using ProjectC_;
using System.Collections;

public class Program
{

    public static List<Car> cars = new List<Car>() {
     new Car(1, "Toyota", "Corolla", 2020, "VIN12345TOYOTA", "White", 180),
            new Car(2, "Honda", "Civic", 2021, "VIN12345HONDA", "Black", 200),
            new Car(3, "Ford", "Focus", 2019, "VIN12345FORD", "Blue", 190),
            new Car(4, "Tesla", "Model 3", 2022, "VIN12345TESLA", "Red", 250)};



    private static void Main(string[] args)
    {
        LinqBasics();
        selectOneElement_qry();
        DeferdAndImmediateExecution();
        Ordering();
        Append_Depend();


    }


    public static void print_LinqQry(IEnumerable qry)
    {
        Console.WriteLine("-------------------------");
        foreach (var item in qry)
        {
            Console.WriteLine(item);

        }
    }
    public static void LinqBasics()
    {


        // where -> filter         select -> choose specific attributes


        //fluent syntax
        var qr = cars.Where(e => e.manufYear > 2020).Select(e => new { name = e.name, year = e.manufYear, Color = e.color });


        // query syntax
        var qr2 = from e in cars
                  where e.MaxSpeed >= 200
                  select new { name = e.name, year = e.manufYear, Color = e.color };


        print_LinqQry(qr2);
    }
    public static void selectOneElement_qry()
    {
        // returns a single object 


        // First element 
        var qry1 = cars.First(); //  returns first element in list 
        var qry2 = cars.First(e => e.manufYear == 2020); // returns the first element with the specified criteiria 
        var qry3 = cars.FirstOrDefault(e => e.manufYear == 2020); // if nothing matches criteria then return dfeault , default is dependnt on datatype of collection 

        // Last element 
        var qry4 = cars.Last();   // returns last element 
        var qry5 = cars.Last(e => e.manufYear == 2020);  // returns last element that matches criteiria  
        var qry6 = cars.LastOrDefault(e => e.manufYear == 2020); // returns last element that matches criteiria , else default

        // Single
        var qry7 = cars.Single(c => c.id == 1); // return the lonely element of a sequence that matches the criteria  
        var qry8 = cars.SingleOrDefault(c => c.id == 1); // return the lonely element of a sequence that matches the criteria or default 

        var tempRes = new { name = qry2.name, year = qry2.manufYear, Color = qry2.color };

        Console.WriteLine(tempRes);

    }
    public static void DeferdAndImmediateExecution()
    {


        //deferd -> excutes query when you enumrate over it
        //immediate -> excutes query at definition (casting)

        var qry = cars.Where(c => c.manufYear > 2018).Select(c => new { name = c.name, year = c.manufYear, model = c.model });
        var qry1 = cars.Where(c => c.manufYear > 2018).Select(c => new { name = c.name, year = c.manufYear, model = c.model }).ToList();


        cars.Add(new Car(8, "honda", "h33", 2020, "mn55646", "RED", 180));

        Console.WriteLine("Deferd Execution");
        print_LinqQry(qry);
        Console.WriteLine("Immediate Execution");
        print_LinqQry(qry1);

    }
    public static void Ordering()
    {
        var qry = cars.Select(c => c).OrderBy(c => c.manufYear);
        print_LinqQry(qry);

        var qry2 = from c in cars
                   orderby c.manufYear
                   select c;
        print_LinqQry(qry2);
        // also you have Order and OrderDescending
    }
    public static void Any_All()
    {
        var qr = cars.Any(c => c.manufYear == 2020);
        var qr2 = cars.All(c => c.manufYear == 2020);
    }
    public static void Append_Depend()
    {
        // Append add at the end of the sequence 
        // Prepend add at the beginging of the sequence

        var qr = cars.Append(new Car(10, "mos", "BH134", 2024, "ffhfg", "BLUE", 240))
        .Prepend(new Car(10, "mos", "BH134", 2024, "ffhfg", "BLUE", 240));

        print_LinqQry(qr);

    }
    public static void UsingAggregateFunctions()
    {
        // Count() => returns number(int32) of elements of a sequence  
        int qr = cars.Count();
        Console.WriteLine(qr);
        
        //Count(expression) => returns number(int32) of elements in sequence that matches the lambda expreission criteria
        int qr2 = cars.Count(c => c.manufYear>2015);
        Console.WriteLine(qr2);

        //CountBy() => new to .NET 9  => returns number of elements for each group => IEnumrable<int,int>
        var qr3 = cars.CountBy(c => c.model);
        foreach (var c in qr3) {
            Console.WriteLine(c.Key +" ------> " +c.Value);
        }

        // Sum() => gets the summation of numbers in a sequence 
        int[] arr = new int[] {1,2,3,4,5,6,7,8,9 };
        int sum = arr.Sum();
        Console.WriteLine(sum);
        // Sum(expression) => returns the sum of numbers after condition
        int sum2 = arr.Sum(s=> s%2);
        Console.WriteLine(sum2);


    }



}
