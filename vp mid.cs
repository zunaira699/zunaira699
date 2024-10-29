using System;
using System.Collections.Generic;

public class ClubRole
{
    string Name { get; set; }
    string Role { get; set; }
    string ContactInfo { get; set; }

    public ClubRole(string name, string role, string contactInfo)
    {
        Name = name;
        Role = role;
        ContactInfo = contactInfo;
    }
}

public class Society
{
    string Name { get; set; }
    ClubRole TeamLead { get; set; }
    ClubRole AssistantTeamLead { get; set; }
    List<string> Activities { get; set; }
    double FundingAmount { get; set; }

    public Society(string name, ClubRole teamLead, ClubRole assistantTeamLead)
    {
        Name = name;
        TeamLead = teamLead;
        AssistantTeamLead = assistantTeamLead;
        Activities = new List<string>();
        FundingAmount = 0;
    }

    public void AddActivity(string activity)
    {
        Activities.Add(activity);
    }

    public void ReceiveFunding(double amount)
    {
        FundingAmount += amount;
    }

    public string GetFundingInfo()
    {
        return $" Funding Amount: ${FundingAmount}";
    }
}

public class StudentClub
{
    List<Society> societies;
    double totalBudget;
    ClubRole president;
    ClubRole vicePresident;
    ClubRole generalSecretary;
    ClubRole financeSecretary;

    public StudentClub(double budget, ClubRole president, ClubRole vicePresident, ClubRole generalSecretary, ClubRole financeSecretary)
    {
        societies = new List<Society>();
        totalBudget = budget;
        this.president = president;
        this.vicePresident = vicePresident;
        this.generalSecretary = generalSecretary;
        this.financeSecretary = financeSecretary;
    }

    public void RegisterSociety(Society society)
    {
        societies.Add(society);
    }

    public void DisperseFunds()
    {
        foreach (var society in societies)
        {
            double amountToDisperse = 500;
            if (totalBudget >= amountToDisperse)
            {
                society.ReceiveFunding(amountToDisperse);
                totalBudget -= amountToDisperse;
            }
        }
    }

    public void DisplaySocietyFundingInfo()
    {
        foreach (var society in societies)
        {
            Console.WriteLine(society.GetFundingInfo());
        }
    }

    public void DisplaySocietyEvents(string societyName)
    {
        foreach (var society in societies)
        {
            if (society.Name == societyName)
            {
                Console.WriteLine($"Events for {societyName}:");
                foreach (var event  society.Events)
                {
        Console.WriteLine($"- {event}");
    }
                return;
    }
}
Console.WriteLine("Society not found.");
    }
}

public class Program
{
    public static void Main()
    {
        var clubManagement = new StudentClub(3000,
            new ClubRole("President", "President Role"),
            new ClubRole("Vice President", "Vice President Role"),
            new ClubRole("General Secretary", "General Secretary Role"),
            new ClubRole("Finance Secretary")
        );

        var techSociety = new Society("Tech Society",
            new ClubRole("Team Lead", "Tech Lead Role"),
            new ClubRole("Assistant Team Lead", "Tech Assistant Role"));

        var literatureSociety = new Society("Literature Society",
            new ClubRole("Team Lead", "Literature Lead Role", "literatureLead@society.com"),
        new ClubRole("Assistant Team Lead", "Literature Assistant Role"));

        var sportsSociety = new Society("Sports Society",
            new ClubRole("Team Lead", "Sports Lead Role"),
            new ClubRole("Assistant Team Lead", "Sports Assistant Role"));

        clubManagement.RegisterSociety(techSociety);
        clubManagement.RegisterSociety(literatureSociety);
        clubManagement.RegisterSociety(sportsSociety);

        // User interface (simplified)
        while (true)
        {
            Console.WriteLine("1. Register a new society");
            Console.WriteLine("2. Allocate funding to societies");
            Console.WriteLine("3. Register for a society event");
            Console.WriteLine("4. Display society funding info");
            Console.WriteLine("5. Display events for a society");
            Console.WriteLine("6. Exit");
            Console.Write("Enter your choice: ");

            int choice = int(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    break;
                case 2:
                    clubManagement.DisperseFunds();
                    break;
                case 3:
                    break;
                case 4:
                    clubManagement.DisplaySocietyFundingInfo();
                    break;
                case 5:
                    Console.Write("Enter society name: ");
                    string societyName = Console.ReadLine();
                    clubManagement.DisplaySocietyEvents(societyName);
                    break;
                case 6:
                    Environment.Exit(0);
                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    break;
            }
        }
        Cosole.ReadLine();
    }
}
