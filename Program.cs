using System;
using System.Collections.Generic;

namespace PlanYourHeist
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Plan Your Heist!");

            List<TeamMember> team = new List<TeamMember>();

            Console.Write("Bank Difficulty> ");
            int bankDifficulty = int.Parse(Console.ReadLine());
            Console.WriteLine();

            // Get first team member's name
            Console.Write("Name> ");
            string name = Console.ReadLine();

            while (name != "")
            {
                Console.Write("Skill level> ");
                string skillLevel = Console.ReadLine();

                Console.Write("Courage factor> ");
                string courageFactor = Console.ReadLine();

                TeamMember member = new TeamMember();
                member.Name = name;
                member.SkillLevel = int.Parse(skillLevel);
                member.CourageFactor = double.Parse(courageFactor);

                team.Add(member);

                Console.WriteLine();

                // Get next team member's name
                Console.Write("Name> ");
                name = Console.ReadLine();
            }

            Console.WriteLine($"Team Size: {team.Count}");

            Console.WriteLine();
            Console.WriteLine("Enter number of trial runs>");
            int trialRunCount = int.Parse(Console.ReadLine());
            Console.WriteLine();

            // Determine total skill level of the team and compare it to the bank's difficulty level
            int teamSkill = 0;

            foreach (TeamMember member in team)
            {
                teamSkill += member.SkillLevel;
            }

            HeistReport report = new HeistReport();

            for (int i = 0; i < trialRunCount; i++)
            {
                // Create a random number between -10 and 10 for the heist's luck value. Add this number to the bank's difficulty level.
                Random generator = new Random();
                int luckValue = generator.Next(-10, 11);
                int trialRunBankDifficulty = bankDifficulty + luckValue;

                Console.WriteLine($"Team Skill Level: {teamSkill}");
                Console.WriteLine($"Bank Difficulty Level: {trialRunBankDifficulty}");

                if (trialRunBankDifficulty > teamSkill)
                {
                    report.FailureCount++;
                }
                else
                {
                    report.SuccessCount++;
                }

                Console.WriteLine("---------------------------");
            }

            Console.WriteLine();
            Console.WriteLine("Heist Results:");
            Console.WriteLine($"Successes: {report.SuccessCount}");
            Console.WriteLine($"Failures: {report.FailureCount}");
            Console.WriteLine("---------------------------");
        }
    }
}