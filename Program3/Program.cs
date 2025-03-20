using System.Diagnostics;
using Program3;

namespace Program3
{
    public class Program
    {
        private static List<ContainerShip> _containerShips = new List<ContainerShip>();
        private static List<Container> _containers = new List<Container>();
        
        private static ContainerShip FindShip(string shipName)
        {
            return _containerShips.FirstOrDefault(s => s.ShipName.Equals(shipName, StringComparison.OrdinalIgnoreCase)) ?? throw new InvalidOperationException();
        }

        private static Container FindContainer(string serial)
        {
            return _containers.FirstOrDefault(c => c.SerialNumber.Equals(serial, StringComparison.OrdinalIgnoreCase)) ?? throw new InvalidOperationException();
        }

        static void Main(string[] args)
        {
            bool exit = false;

            while (!exit)
            {
                PrintContainerShips();
                PrintContainers();

                if (_containerShips.Count == 0 && _containers.Count == 0)
                    PrintNothingMenu();
                else if (_containerShips.Count != 0 && _containers.Count == 0)
                    PrintNoContainersMenu();
                else if (_containerShips.Count == 0 && _containers.Count != 0)
                    PrintNoContainerShipsMenu();
                else
                    PrintFullMenu();
                
                string input = Console.ReadLine() ?? throw new InvalidOperationException();
                
                if (_containerShips.Count == 0 && _containers.Count == 0)
                {
                    switch (input)
                    {
                        case "1":
                            AddShip();
                            break;
                        case "2":
                            AddContainer();
                            break;
                        default:
                            Console.WriteLine("Invalid Input, try again");
                            break;
                    }
                }
                else if (_containerShips.Count != 0 && _containers.Count == 0)
                {
                    switch (input)
                    {
                        case "1":
                            AddContainer();
                            break;
                        case "2":
                            AddShip();
                            break;
                        case "3":
                            RemoveShip();
                            break;
                        default:
                            Console.WriteLine("Invalid Input, try again");
                            break;
                    }
                }
                else if (_containerShips.Count == 0 && _containers.Count != 0)
                {
                    switch (input)
                    {
                        case "1":
                            AddShip();
                            break;
                        case "2":
                            AddContainer();
                            break;
                        case "3":
                            RemoveContainer();
                            break;
                        default:
                            Console.WriteLine("Invalid Input, try again");
                            break;
                    }
                }
                else
                {
                    switch (input)
                    {
                        case "1":
                            AddShip();
                            break;
                        case "2":
                            RemoveShip();
                            break;
                        case "3":
                            AddContainer();
                            break;
                        case "4":
                            RemoveContainer();
                            break;
                        case "5":
                            LoadCargo();
                            break;
                        case "6":
                            UnloadContainer();
                            break;
                        case "7":
                            LoadContainerOnShip();
                            break;
                        case "8":
                            RemoveContainerFromShip();
                            break;
                        case "9":
                            TransferContainerBetweenShips();
                            break;
                        case "10":
                            ReplaceContainerOnShip();
                            break;
                        case "11":
                            PrintSingleContainer();
                            break;
                        case "12":
                            PrintSingleShip();
                            break;
                        case "0":
                            exit = true;
                            break;
                        default:
                            Console.WriteLine("Invalid Input, try again");
                            break;
                    }
                }
            }
            Console.WriteLine("\nExiting application...");
        }

        static void PrintContainerShips()
        {
            Console.WriteLine("\nLista kontenerowców:");
            if (_containerShips.Count == 0)
                Console.WriteLine("Brak");
            else
            {
                foreach (var ship in _containerShips)
                    Console.WriteLine(ship.ShipInfo());
            }
        }

        static void PrintContainers()
        {
            Console.WriteLine("\nLista kontenerów:");
            if (_containers.Count == 0)
                Console.WriteLine("Brak");
            else
                foreach (var container in _containers)
                    Console.WriteLine(container.ContainerInfo());
        }

        static void PrintNothingMenu()
        {
            Console.WriteLine("\nMożliwe akcje:");
            Console.WriteLine("1. Dodaj kontenerowiec");
            Console.WriteLine("2. Dodaj kontener");
        }
        
        static void PrintNoContainersMenu()
        {
            Console.WriteLine("\nMożliwe akcje:");
            Console.WriteLine("1. Dodaj kontener");
            Console.WriteLine("2. Dodaj kontenerowiec");
            Console.WriteLine("3. Usuń kontenerowiec");
        }
        
        static void PrintNoContainerShipsMenu()
        {
            Console.WriteLine("\nMożliwe akcje:");
            Console.WriteLine("1. Dodaj kontenerowiec");
            Console.WriteLine("2. Dodaj kontener");
            Console.WriteLine("3. Usuń kontener");
        }

        static void PrintFullMenu()
        {
            Console.WriteLine("\nMożliwe akcje:");
            Console.WriteLine("1. Dodaj kontenerowiec");
            Console.WriteLine("2. Usuń kontenerowiec");
            Console.WriteLine("3. Dodaj kontener");
            Console.WriteLine("4. Usuń kontener");
            Console.WriteLine("5. Załaduj ładunek");
            Console.WriteLine("6. Rozładuj ładunek");
            Console.WriteLine("7. Załaduj kontener na kontenerowiec");
            Console.WriteLine("8. Usuń kontener z kontenerowca");
            Console.WriteLine("9. Przenieś kontener między statkami");
            Console.WriteLine("10. Zastąp kontener na statku z innym");
            Console.WriteLine("11. Wyświetl informacje o kontenerze");
            Console.WriteLine("12. Wyświetl informacje o statku");
            Console.WriteLine("\n0. Zamknij program");
            Console.Write("Wybierz opcję: ");
        }

        static void AddShip()
        {
            Console.Write("Nazwa statku: ");
            var name = Console.ReadLine() ?? throw new InvalidOperationException();
            Console.Write("Maksymalna liczba kontenerów: ");
            var maxNum = int.Parse(Console.ReadLine() ?? throw new InvalidOperationException());
            Console.Write("Maksymalne obciążenie (tony): ");
            var maxWeight = double.Parse(Console.ReadLine() ?? throw new InvalidOperationException());
            Console.Write("Maksymalna prędkość (węzły): ");
            var maxSpeed = int.Parse(Console.ReadLine() ?? throw new InvalidOperationException());

            var newShip = new ContainerShip(name, maxSpeed, maxNum, maxWeight);
            _containerShips.Add(newShip);
            Console.WriteLine($"Dodano {newShip.ShipName}");
        }

        static void RemoveShip()
        {
            Console.Write("Podaj nazwę statku do usunięcia: ");
            string name = Console.ReadLine() ?? throw new InvalidOperationException();

            var ship = FindShip(name);
            if (ship == null)
            {
                Console.WriteLine($"{name} nie znaleziony");
                return;
            }

            _containerShips.Remove(ship);
            Console.WriteLine($"{name} został usunięty");
        }

        static void AddContainer()
        {
            Console.WriteLine("Wybierz zawartość kontenera: L=Płyny, G=Gaz, C=Produkty chłodzone");
            string type = Console.ReadLine() ?? throw new InvalidOperationException();
            Console.Write("Masa kontenera (w kilogramach): ");
            int containerMass = int.Parse(Console.ReadLine() ?? throw new InvalidOperationException());
            Console.Write("Wysokość kontenera (w centymetrach): ");
            int height = int.Parse(Console.ReadLine() ?? throw new InvalidOperationException());
            Console.Write("Głębokość kontenera (w centymetrach): ");
            int depth = int.Parse(Console.ReadLine() ?? throw new InvalidOperationException());
            Console.Write("Maksymalna ładowność (w tonach): ");
            int maxCargoMass = int.Parse(Console.ReadLine() ?? throw new InvalidOperationException());

            Container container = null;

            switch (type.ToLower())
            {
                case "l":
                    Console.Write("Czy produkt jest niebezpieczny? (true/false): ");
                    bool isDangerous = bool.Parse(Console.ReadLine() ?? throw new InvalidOperationException());
                    container = new LiquidContainer(height, depth, containerMass, maxCargoMass, isDangerous);
                    break;
                case "g":
                    Console.Write("Ciśnienie (w atmosferach): ");
                    double pressure = double.Parse(Console.ReadLine() ?? throw new InvalidOperationException());
                    container = new GasContainer(height, depth, containerMass, maxCargoMass, pressure);
                    break;
                case "c":
                    foreach (var product in TemperatureDictionary.Temperatures.Keys)
                    {
                        Console.WriteLine($"{product}");
                    }
                    Console.Write("Typ produktu: ");
                    string productType = Console.ReadLine() ?? throw new InvalidOperationException();
                    Console.Write("Temperatura  (stopnie Celsjusza): ");
                    double temperature = double.Parse(Console.ReadLine() ?? throw new InvalidOperationException());
                    container = new CoolerContainer(height, depth, containerMass, maxCargoMass, productType, temperature);
                    break;
                default:
                    Console.WriteLine("Nieznany typ produktu. Spróbuj jeszcze raz");
                    return;
            }
            
            _containers.Add(container);
            Console.WriteLine($"Container {container.SerialNumber} was created and added to the containers list.");
        }

        static void RemoveContainer()
        {
            Console.Write("Podaj numer seryjny kontenera do usunięcia: ");
            string serial = Console.ReadLine() ?? throw new InvalidOperationException();

            var container = FindContainer(serial);
            if (container == null)
            {
                Console.WriteLine($"Kontener {serial} nie znaleziony");
                return;
            }

            _containers.Remove(container);
            Console.WriteLine($"Kontener {serial} został usunięty");
        }

        static void LoadCargo()
        {
            Console.WriteLine("Podaj numer seryjny kontenera do załadowania: ");
            string serial = Console.ReadLine() ?? throw new InvalidOperationException();
            Console.WriteLine("Podaj wagę towaru (w kilogramach): ");
            double mass = double.Parse(Console.ReadLine() ?? throw new InvalidOperationException());
            
            var container = FindContainer(serial);
            if (container == null)
            {
                Console.WriteLine($"Kontener {serial} nie znaleziony");
                return;
            }
            
            container.LoadCargo(mass);
            Console.WriteLine($"Załadowano towar do {container.SerialNumber}");
        }

        static void UnloadContainer()
        {
            Console.Write("Podaj numer seryjny kontenera do rozładunku: ");
            string serial = Console.ReadLine() ?? throw new InvalidOperationException();

            var container = FindContainer(serial);
            if (container == null)
            {
                Console.WriteLine($"Kontener {serial} nie znaleziony");
                return;
            }

            container.UnloadCargo(); 
            Console.WriteLine($"Rozładowano towar z {container.SerialNumber}");
        }

        static void LoadContainerOnShip()
        {
            Console.Write("Podaj nazwę statku: ");
            string shipName = Console.ReadLine() ?? throw new InvalidOperationException();

            var ship = FindShip(shipName);
            if (ship == null)
            {
                Console.WriteLine($"{shipName} nie znaleziony");
                return;
            }

            Console.Write("Podaj numer seryjny kontenera: ");
            string serial = Console.ReadLine() ?? throw new InvalidOperationException();

            var container = FindContainer(serial);
            if (container == null)
            {
                Console.WriteLine($"Nie znaleziono kontenera {serial}");
                return;
            }

            try
            {
                ship.LoadContainer(container);
                Console.WriteLine($"Kontener {serial} został załadowany na {shipName}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Kontener {serial} NIE został załadowany na {shipName}: {ex.Message}");
            }
        }

        static void RemoveContainerFromShip()
        {
            Console.Write("Podaj nazwę statku: ");
            string shipName = Console.ReadLine() ?? throw new InvalidOperationException();

            var ship = FindShip(shipName);
            if (ship == null)
            {
                Console.WriteLine($"{shipName} nie znaleziony");
                return;
            }

            Console.Write("Podaj numer seryjny kontenera: ");
            string serial = Console.ReadLine() ?? throw new InvalidOperationException();
            
            var container = FindContainer(serial);
            if (container == null)
            {
                Console.WriteLine($"Nie znaleziono kontenera {serial}");
                return;
            }
            try
            {
                ship.RemoveContainer(serial);
                Console.WriteLine($"Kontener {serial} został zdjęty z {shipName}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Kontener {serial} NIE został zdjęty z {shipName}: {ex.Message}");
            }
        }

        static void TransferContainerBetweenShips()
        {
            Console.Write("Podaj nazwę statku nadawczego: ");
            string sourceShipName = Console.ReadLine() ?? throw new InvalidOperationException();
            var sourceShip = FindShip(sourceShipName);
            if (sourceShip == null)
            {
                Console.WriteLine($"{sourceShipName} nie znaleziony");
                return;
            }

            Console.Write("Podaj nazwę statku odbiorczego: ");
            string targetShipName = Console.ReadLine() ?? throw new InvalidOperationException();
            var targetShip = FindShip(targetShipName);
            if (targetShip == null)
            {
                Console.WriteLine($"{targetShipName} nie znaleziony");
                return;
            }

            Console.Write("Podaj numer seryjny kontenera: ");
            string serial = Console.ReadLine() ?? throw new InvalidOperationException();
            
            try
            {
                var container = sourceShip.Containers.FirstOrDefault(c => c.SerialNumber.Equals(serial, StringComparison.OrdinalIgnoreCase));
                if (container == null)
                {
                    Console.WriteLine($"Nie znaleziono kontenera {serial} na {sourceShipName}");
                    return;
                }
                
                sourceShip.RemoveContainer(serial);
                targetShip.LoadContainer(container);

                Console.WriteLine($"Kontener {serial} został przeniesiony z {sourceShipName} na {targetShipName}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Problem przy przenoszeniu kontenera {serial}: {ex.Message}");
            }
        }

        static void ReplaceContainerOnShip()
        {
            Console.Write("Podaj nazwę statku: ");
            string shipName = Console.ReadLine() ?? throw new InvalidOperationException();
            
            var ship = FindShip(shipName);
            if (ship == null)
            {
                Console.WriteLine($"{shipName} nie znaleziony");
                return;
            }

            Console.Write("Podaj numer seryjny kontenera na statku: ");
            string oldSerial = Console.ReadLine() ?? throw new InvalidOperationException();
            
            var oldContainer = ship.Containers.FirstOrDefault(c => c.SerialNumber.Equals(oldSerial, StringComparison.OrdinalIgnoreCase));
            if (oldContainer == null)
            {
                Console.WriteLine($"Kontener {oldSerial} nie został znaleziony na {shipName}");
                return;
            }

            Console.Write("Podaj numer seryjny nowego kontenera: ");
            string newSerial = Console.ReadLine() ?? throw new InvalidOperationException();
            var newContainer = FindContainer(newSerial);
            if (newContainer == null)
            {
                Console.WriteLine($"Nie znaleziono kontenera {newSerial}");
                return;
            }

            try
            {
                ship.SwapContainers(oldContainer, newSerial);
                Console.WriteLine($"Kontener {oldSerial} został zamieniony z {newSerial} na statku {shipName}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Błąd przy przenoszeniu kontenerów na statku {shipName}: {ex.Message}");
            }
        }

        static void PrintSingleContainer()
        {
            Console.Write("Podaj numer seryjny kontenera: ");
            string serial = Console.ReadLine() ?? throw new InvalidOperationException();

            var container = FindContainer(serial);
            if (container == null)
            {
                Console.WriteLine($"Nie znaleziono kontenera {serial}");
                return;
            }
            
            Console.WriteLine(container.ToString());
        }
        
        static void PrintSingleShip()
        {
            Console.Write("Podaj nazwę statku: ");
            string shipName = Console.ReadLine() ?? throw new InvalidOperationException();

            var ship = FindShip(shipName);
            if (ship == null)
            {
                Console.WriteLine($"{shipName} nie znaleziony");
                return;
            }

            Console.WriteLine(ship.ToString());
        }
    }
}