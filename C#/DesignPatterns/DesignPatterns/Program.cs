namespace DesignPatterns
{    
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    using DesignPatterns.BehavioralPatterns.ChainOfResponsibilityExample;
    using DesignPatterns.BehavioralPatterns.CommandExample;
    using DesignPatterns.BehavioralPatterns.CSharpIteratorExample;
    using DesignPatterns.BehavioralPatterns.InterpreterExample;
    using DesignPatterns.BehavioralPatterns.IteratorExample;
    using DesignPatterns.BehavioralPatterns.MediatorExample;
    using DesignPatterns.BehavioralPatterns.MementoExample;
    using DesignPatterns.BehavioralPatterns.ObserverExample;
    using DesignPatterns.BehavioralPatterns.StateExample;
    using DesignPatterns.BehavioralPatterns.StrategyExample;
    using DesignPatterns.BehavioralPatterns.TemplateMethodExample;
    using DesignPatterns.BehavioralPatterns.VisitorExample;
    using DesignPatterns.CreationalPatterns.AbstractFactoryExample;
    using DesignPatterns.CreationalPatterns.BuilderExample;
    using DesignPatterns.CreationalPatterns.FactoryExample;
    using DesignPatterns.CreationalPatterns.LazyLoadingExample;
    using DesignPatterns.CreationalPatterns.ObjectPoolExample;
    using DesignPatterns.CreationalPatterns.PrototypeExample;
    using DesignPatterns.CreationalPatterns.SimpleFactoryExample;
    using DesignPatterns.CreationalPatterns.SingletonExample;
    using DesignPatterns.StructuralPatterns.AdapterExample;
    using DesignPatterns.StructuralPatterns.BridgeExample;
    using DesignPatterns.StructuralPatterns.CompositeExample;
    using DesignPatterns.StructuralPatterns.DecoratorExample;
    using DesignPatterns.StructuralPatterns.FacadeExample;
    using DesignPatterns.StructuralPatterns.FlyweightExample;
    using DesignPatterns.StructuralPatterns.ProxyExample;

    internal class Program
    {
        private static void PrintInfoForCreationalPatterns()
        {
            // Singleton Test
            WriteTitleToConsole("Singleton Test");
            var log1 = Logger.Instance;
            log1.AddError("Divided by zero!");

            var log2 = Logger.Instance;
            log2.AddError("Null reference error!", DateTime.Now);

            Console.WriteLine(string.Join("\n", log1.GetAllErrors));

            // Simple Factory Test    
            WriteTitleToConsole("\nSimple Factory Test");
            var lion = AnimalFactory.CreateAnimal(AnimalType.Lion, "Boyko");
            var ostrich = AnimalFactory.CreateAnimal(AnimalType.Ostrich, "David Cameron");
            lion.Speak();
            ostrich.Speak();

            // Factory Test
            WriteTitleToConsole("\nFactory Test");
            CarManufacturer carManufacturer = new TurkishManufacturer();
            var audi1 = carManufacturer.CreateCar();
            audi1.PrintInfo();

            carManufacturer = new GermanManufacturer();
            var audi2 = carManufacturer.CreateCar();
            audi2.PrintInfo();

            // Abstract Factory Test
            WriteTitleToConsole("\nAbstract Factory Test");
            var vehicleFactory1 = new BurgasVehicleFactory();
            var bgCar = vehicleFactory1.CreateCar();
            var bgMotor = vehicleFactory1.CreateMotor();
            bgCar.PrintInfo();
            bgMotor.PrintInfo();

            var vehicleFactory2 = new BerlinVehicleFactory();
            var deCar = vehicleFactory2.CreateCar();
            var deMotor = vehicleFactory2.CreateMotor();
            deCar.PrintInfo();
            deMotor.PrintInfo();

            // Builder Test
            WriteTitleToConsole("\nBuilder Test");
            var consoleManufacturer = new GameConsoleManufacturer();

            var goodGameConsole = consoleManufacturer.Construct(new PlayStationBuilder());
            Console.WriteLine("New Console:\n{0}", goodGameConsole);

            var oldGameConsole = consoleManufacturer.Construct(new SegaBuilder());
            Console.WriteLine("\nOld but nice Console:\n{0}", oldGameConsole);

            // Prototype Test
            WriteTitleToConsole("\nPrototype Test");
            var vasil1 = new JohnDoe("Vasil Penche", 28);
            var vasil2 = vasil1.Clone() as JohnDoe;
            vasil2.ActualName = "Blagoves Georgiev";
            Console.WriteLine("{0}\n{1}", vasil1, vasil2);

            // Lazy Loading Test
            WriteTitleToConsole("\nLazy Loading Test");
            var lazyclass = new CustomerLazy<BigClass>(() => new BigClass(1024));
            Console.WriteLine("The BigClass is not initialized yet");
            Console.WriteLine(lazyclass.Value);

            // Object Pool Test
            WriteTitleToConsole("\nObject Pool Test");
            var soldier1 = Army.GetNewSoldier();
            var soldier2 = Army.GetNewSoldier();
            var soldier3 = Army.GetNewSoldier();
            Army.PutSoldier(soldier3);
            var soldier4 = Army.GetNewSoldier();

            Console.WriteLine("{0}, {1}, {2}, {3}", soldier1.Name, soldier2.Name, soldier3.Name, soldier4.Name);
        }

        private static void PrintInfoForStructuralPatterns()
        {
            // Facade Test
            WriteTitleToConsole("Facade Test");
            string iniFilePath = @"../../StructuralPatterns/FacadeExample/IniFileTestExample/MyConfig.ini";
            var ini = new IniFile(iniFilePath);
            ini.WriteValue("System", "Version", "1.1");
            ini.WriteValue("System", "Type", "Free License");
            var typeValue = ini.ReadValue("System", "Type");
            Console.WriteLine(typeValue);

            // Composide Test
            WriteTitleToConsole("\nComposide Test");
            var mayor = new Director("Chomakov", 7800.0, 8);
            var employees = new List<CityHallEmployee>()
            {
               new CityHallEmployee( "George Gergov", 5000000, "Svinepas"),
               new CityHallEmployee( "Stefan Pavlov", 438, "Economy"),
               new CityHallEmployee( "Ana Vasileva", 450, "English Teacher"),
            };
            mayor.Employees.AddRange(employees);

            mayor.FireEmployee("Ana Vasileva");
            var employee = new CityHallEmployee("Pesho The Dragon", 1700, "Lover Level 5");
            mayor.HiresEmployee(employee);

            mayor.PrintEmployeeInformation();

            // Proxy Test
            WriteTitleToConsole("\nProxy Test");
            var email = new EmailProxy();
            var username = @"master";
            var password = "1111";//"5654<f";
            email.GoIn(username, password);

            // Decorator Test
            WriteTitleToConsole("\nDecorator Test");
            var burger = new Burger();
            Console.WriteLine("Burger:\nDescription: {0}.\nPrice: {1}.", burger.Description, burger.Cost);

            var donkeyBurger = new DonkeyBurger(burger);
            donkeyBurger.printInfo();

            var burgerWithSauces = new MayonnaiseDecorator(new KetchupDecorator(burger));
            Console.WriteLine("Burger with sauces:\nDescription: {0}.\nPrice: {1}.",
                                        burgerWithSauces.Description, burgerWithSauces.Cost);

            // Adapter Test
            WriteTitleToConsole("\nAdapter Test");
            var banana = new Banana();
            banana.ShowAllBananaInformation();
            var bananaAdapter = new BananaAdapter(banana);
            bananaAdapter.PrintInfo();

            // Bridge Test
            WriteTitleToConsole("\nBridge Test");
            var page3Diploma = new Diploma(new PageA3());
            page3Diploma.Print();
            var page4Certificate = new Certificate(new PageA4());
            page4Certificate.Print();

            // Flyweight Test
            WriteTitleToConsole("\nFlyweight Test");
            var shapeFactory = new ShapeFactory();
            var asteriskRect = shapeFactory.GetShape(ShapeType.Triangle);
            var numberSignRect = shapeFactory.GetShape(ShapeType.Triangle);

            asteriskRect.SetSymbol('*');
            asteriskRect.Draw();

            numberSignRect.SetSymbol('#');
            numberSignRect.Draw();

            Console.WriteLine("Are the addresses in memory equal: {0}", object.ReferenceEquals(asteriskRect, numberSignRect));

        }

        private static void PrintInfoForBehavioralPatterns()
        {
            // Chain Of Responsibility Test
            WriteTitleToConsole("Chain Of Responsibility Test");
            var random = new Random();
            var randomNumbers = Enumerable
                                .Repeat<Func<int, int, int>>(random.Next, 25)
                                .Select(rnd => rnd(0, 100))
                                .ToArray();
            Console.WriteLine(string.Join(",", randomNumbers));

            var algorithm = SortCombiner.GetSort();
            algorithm.ProcessSort(randomNumbers);
            Console.WriteLine(string.Join(",", randomNumbers));

            // C# Iterator Test
            WriteTitleToConsole("\nC# Iterator Test");
            var alphabet = new Alphabet("абвееегдежзийкабв");
            Console.WriteLine(string.Join(", ", alphabet));

            // Linked List Iterator Test
            WriteTitleToConsole("\nLinked List Iterator Test");
            var linkedList = new CustomList<int>();
            linkedList.Add(4);
            linkedList.Add(5);
            linkedList.Add(6);
            linkedList.Add(7);

            foreach (var item in linkedList)
            {
                Console.WriteLine(item);
            }

            linkedList.Clear();

            // Command Test
            WriteTitleToConsole("\nCommand Test");
            var engineer = new Engineer();
            engineer.Compute('+', 50);
            engineer.Compute('-', 10);
            engineer.Compute('*', 8);
            Console.WriteLine(engineer.Compute('/', 2));
            Console.WriteLine("Start Undo:");
            Console.WriteLine(engineer.Undo());
            Console.WriteLine(engineer.Undo());
            Console.WriteLine("Start Redo:");
            Console.WriteLine(engineer.Redo());
            Console.WriteLine(engineer.Redo());

            // Template Method Test
            WriteTitleToConsole("\nTemplate Method Test");
            var pepperoni = new Pepperoni();
            Console.WriteLine("Make pepperoni:");
            pepperoni.Make();

            var margherita = new Margherita();
            Console.WriteLine("\nMake margherita:");
            margherita.Make();

            // Strategy Test
            WriteTitleToConsole("\nStrategy Test");
            var general = new General(new List<IAttackStrategy>
                    {
                        new AirAttack(),
                        new LandAttack(),
                    });

            general.StartAttackOperation();

            // Observer Test
            WriteTitleToConsole("\nObserver Test");
            var school = RandomSchoolInitializer.getRandomSchool();
            var weakStudents = school.FoundAllWeakStudents().ToList();
            weakStudents.ForEach(student =>
            {
                student.Marks = new List<int>(student.Marks) { 2 };
            });

            // Mediator Test
            WriteTitleToConsole("\nMediator Test");
            var vivacom = new VivacomDispatcher();
            for (int i = 1; i <= 10; i++)
            {
                var client = new Client("Client" + (i).ToString(), i.ToString(), "Normal", DateTime.Now);
                vivacom.Register(client);
            }

            vivacom.Conect("4", "7");
            vivacom.Conect("5", "6");
            vivacom.Conect("1", "9");

            // Memento Test
            WriteTitleToConsole("\nMemento Test");
            var adder = new Adder("Bulgarian", 31, 23);
            var state = adder.getState();
            Console.WriteLine(adder.ToString());
            adder.Age += 11;
            adder.Length += 13.7;
            Console.WriteLine(adder.ToString());
            adder.RestorState(state);
            Console.WriteLine(adder.ToString());

            // State Test
            WriteTitleToConsole("\nState Test");
            var engine = new Engine(new StandardState());
            engine.Work();
            engine.SetNewState(new TurboState());
            engine.Work();

            // Interpreter Test (this example is from internet)
            WriteTitleToConsole("\nInterpreter Test (this example is from internet)");
            var input = "MCDLVII";
            var context = new Context(input);

            var tree = new List<Expression>();
            tree.Add(new ThousandExpression());
            tree.Add(new HundredExpression());
            tree.Add(new TenExpression());
            tree.Add(new OneExpression());

            foreach (var expression in tree)
            {
                expression.Interpret(context);
            }

            Console.WriteLine("{0} = {1}", input, context.Output);

            // Visitor Test
            WriteTitleToConsole("\nVisitor Test");
            var shopAssistant = new ShopAssistant()
            {
                Name = "John Doe",
                Age = 27,
                HealthCareFactor = 78,
                IsEmployed = true,
                VacantionDay = 15
            };

            shopAssistant.ShowInformation();
            shopAssistant.Accept(new HealthBonusesVisitor());
            shopAssistant.ShowInformation();
        }

        private static void WriteTitleToConsole(string title, ConsoleColor color = ConsoleColor.Red)
        {
            Console.ForegroundColor = color;
            Console.WriteLine(title);
            Console.ResetColor();
        }

        private static void WriteChapterTitleToConsole(string title, ConsoleColor color = ConsoleColor.Red)
        {
            WriteTitleToConsole(("\n" + string.Join("", Enumerable.Repeat('*', title.Length))), color);
            WriteTitleToConsole(string.Format("{0}", title), color);
            WriteTitleToConsole((string.Join("", Enumerable.Repeat('*', title.Length)) + "\n"), color);
        }

        public static void Main(string[] args)
        {
            WriteChapterTitleToConsole("CREATIONAL PATTERNS", ConsoleColor.Blue);
            PrintInfoForCreationalPatterns();

            WriteChapterTitleToConsole("STRUCTURAL PATTERNS", ConsoleColor.Blue);
            PrintInfoForStructuralPatterns();

            WriteChapterTitleToConsole("BEHAVIORAL PATTERNS", ConsoleColor.Blue);
            PrintInfoForBehavioralPatterns();
        }
    }
}
