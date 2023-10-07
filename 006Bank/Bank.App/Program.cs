using Bank.Logic;

Account bank;
Console.Write("Type of account ([c]hecking, [b]usiness, [s]avings): ");
string accountType = Console.ReadLine()!;

Console.Write("Enter your account number: ");
string accountNumber = Console.ReadLine()!;
Console.Write("Enter the account holder: ");
string accountHolder = Console.ReadLine()!;
Console.Write("Enter your current balance: ");
decimal currentBalance = decimal.Parse(Console.ReadLine()!);
Console.Write("Enter the account of the transaction: ");
string tAccountNumber = Console.ReadLine()!;
Console.Write("Enter a description of the transaction: ");
string description = Console.ReadLine()!;
Console.Write("Enter the amount of the transaction: ");
decimal amount = decimal.Parse(Console.ReadLine()!);
Console.Write("Enter the transaction timestamp: ");
DateTime time = DateTime.Parse(Console.ReadLine()!);

var transaction = new Bank.Logic.Transaction(tAccountNumber, description, time, amount);
switch (accountType)
{
    case "c":
        bank = new CheckingAccount(accountNumber, accountHolder, currentBalance);
        bank.IsAllowed(transaction);
        bank.TryExecute(transaction);
        break;
    case "b":
        bank = new BusinessAccount(accountNumber, accountHolder, currentBalance);
        bank.IsAllowed(transaction);
        bank.TryExecute(transaction);
        break;
    case "s":
        bank = new Savings(accountNumber, accountHolder, currentBalance);
        bank.IsAllowed(transaction);
        bank.TryExecute(transaction);
        break;
    default:
        Console.WriteLine("ERROR! Invalid account type.");
        break;
}






