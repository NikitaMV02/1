class Program
{
    static void Main(string[] args)
    {
        bool running = true;
        while (running)
        {
            Console.WriteLine("Меню:");
            Console.WriteLine("1. Вивести вказану кількість слів з тексту 'Lorem ipsum'");
            Console.WriteLine("2. Виконати математичну операцію");
            Console.WriteLine("3. Вийти");
            Console.Write("Оберіть пункт меню (1-3): ");

            string? input = Console.ReadLine(); 

            switch (input)
            {
                case "1":
                    DisplayWords();
                    break;
                case "2":
                    MathOperations();
                    break;
                case "3":
                    running = false;
                    break;
                default:
                    Console.WriteLine("Неправильний вибір. Спробуйте ще раз.");
                    break;
            }
        }
    }

    static void DisplayWords()
    {
        Console.Write("Введіть кількість слів для виведення: ");
        string? wordCountInput = Console.ReadLine();
        if (int.TryParse(wordCountInput, out int wordCount)) 
        {
            string text = File.ReadAllText("lorem.txt"); 
            string[] words = text.Split(' ');

            for (int i = 0; i < Math.Min(wordCount, words.Length); i++)
            {
                Console.Write(words[i] + " ");
            }
            Console.WriteLine();
        }
        else
        {
            Console.WriteLine("Невірний ввід. Введіть ціле число.");
        }
    }

    static void MathOperations()
    {
        Console.Write("Введіть перше число: ");
        string? num1Input = Console.ReadLine(); 
        if (!double.TryParse(num1Input, out double num1)) 
        {
            Console.WriteLine("Невірний ввід. Введіть число.");
            return;
        }

        Console.Write("Введіть оператор (+, -, *, /): ");
        string? operationInput = Console.ReadLine(); 
        if (string.IsNullOrEmpty(operationInput) || operationInput.Length != 1) 
        {
            Console.WriteLine("Невірний ввід оператора.");
            return;
        }
        char operation = operationInput[0];

        Console.Write("Введіть друге число: ");
        string? num2Input = Console.ReadLine(); 
        if (!double.TryParse(num2Input, out double num2)) 
        {
            Console.WriteLine("Невірний ввід. Введіть число.");
            return;
        }

        double result = 0;

        switch (operation)
        {
            case '+':
                result = num1 + num2;
                break;
            case '-':
                result = num1 - num2;
                break;
            case '*':
                result = num1 * num2;
                break;
            case '/':
                if (num2 != 0)
                    result = num1 / num2;
                else
                {
                    Console.WriteLine("Ділення на нуль неможливе.");
                    return;
                }
                break;
            default:
                Console.WriteLine("Невідомий оператор.");
                return;
        }

        Console.WriteLine($"Результат: {result}");
    }
}
