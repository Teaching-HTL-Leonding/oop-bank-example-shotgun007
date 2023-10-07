namespace Bank.Logic;
public abstract class Account
{
    public Account(string accountNumber, string accountHolder, decimal currentBalance)
    {
        AccountNumber = accountNumber;
        AccountHolder = accountHolder;
        CurrentBalance = currentBalance;
    }
    public string AccountNumber { get; }
    public string AccountHolder { get; }
    public decimal CurrentBalance { get; set; }

    public abstract bool IsAllowed(Transaction t);
    public bool TryExecute(Transaction t)
    {
        if (IsAllowed(t))
        {
            CurrentBalance = CurrentBalance + t.Amount;
            Console.WriteLine($"Transaction executed successfully. The new current balance is {CurrentBalance}$.");
            return true;
        }
        else
        {
            Console.WriteLine("Transaction not allowed.");
            return false;
        }
    }
    
}

public class Savings : Account
{
    public Savings(string accountNumber, string accountHolder, decimal currentBalance)
        : base(accountNumber, accountHolder, currentBalance) { }

    public override bool IsAllowed(Transaction t)
    {
        if (t.TAccountNumber == AccountNumber)
        {
            if (CurrentBalance + t.Amount >= 0)
            {
                if (CurrentBalance + t.Amount <= 100000000)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }
        else
        {
            return false;
        }
    }
}

public class CheckingAccount : Account
{
    public CheckingAccount(string accountNumber, string accountHolder, decimal currentBalance)
        : base(accountNumber, accountHolder, currentBalance) { }
    public override bool IsAllowed(Transaction t)
    {
        if (t.TAccountNumber == AccountNumber)
        {
            if (CurrentBalance + t.Amount >= -10000)
            {
                if (CurrentBalance + t.Amount <= 10000000)
                {
                    if (t.Amount <= 10000)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }
        else
        {
            return false;
        }
    }
}

public class BusinessAccount : Account
{
    public BusinessAccount(string accountNumber, string accountHolder, decimal currentBalance)
        : base(accountNumber, accountHolder, currentBalance) { }
    public override bool IsAllowed(Transaction t)
    {
        if (t.TAccountNumber == AccountNumber)
        {
            if (CurrentBalance + t.Amount >= -1000000)
            {
                if (CurrentBalance + t.Amount <= 100000000)
                {
                    if (t.Amount <= 100000)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }
        else
        {
            return false;
        }
    }
}




public class Transaction
{
    public Transaction(string tAccountNumber, string description, DateTime time, decimal amount)
    {
        TAccountNumber = tAccountNumber;
        Description = description;
        Time = time;
        Amount = amount;
    }
    public string TAccountNumber { get; set; }
    public string Description { get; set; }
    public DateTime Time { get; set; }
    public decimal Amount { get; set; }
}
