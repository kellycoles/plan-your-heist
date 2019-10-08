using System;
using System.Collections.Generic;

namespace PlanYourHeist {
    class Program {
        static void Main (string[] args) {
            Console.WriteLine ("Plan your heist!");

            List<Dictionary<string, string>> team = new List<Dictionary<string, string>> ();
            Console.Write ("Name> ");
          
            
            string name = Console.ReadLine ();
            Console.WriteLine ();
            while (name != "") {
                Console.Write ("skill Level> ");
                string skillLevel = Console.ReadLine ();

                Console.Write ("courage Factor> ");
                string courageFactor = Console.ReadLine ();
                Dictionary<string, string> member = new Dictionary<string, string> () { { "Name", name }, { "SkillLevel", skillLevel }, { "Courage Factor", courageFactor }
                };
                team.Add (member);
                Console.WriteLine ();
                Console.Write ("Name> ");
                name = Console.ReadLine ();

            }
            Console.Write("Please, enter number of runs> ");
            int trialRunCount =  int.Parse(Console.ReadLine());
           
            Console.WriteLine (
                $"Team Size:{team.Count}"
            );

            int teamSkill = 0;
            foreach (Dictionary<string, string> member in team) {
                string skillLevel = member["SkillLevel"];
                teamSkill = teamSkill + int.Parse(skillLevel);
            }
           for (int i = 0; i < trialRunCount; i++) //we wrapped code below in for loop. every time through the loop i'll get a new luckvalue and bank difficulty
           {
               Random generator = new Random(); //phase 4  gets random number
               int luckValue = generator.Next(-10, 11); //takes minval and maxvalue
               int bankDifficulty = 100; //needed to bring this down from the top as well.
               bankDifficulty += luckValue; //add luckvalue to bankdifficulty and set the value
               Console.WriteLine($"Team Skil level: {teamSkill}");
               Console.WriteLine($"Bank Difficulty: {bankDifficulty}");
               if (bankDifficulty > teamSkill) //did the team do better than the bank difficulty level?
               {
                   Console.WriteLine("Your heist failed :(");
               }
               else
               {
                   Console.WriteLine("You are rich!"); //run it and see if you failed or not
               }
           }
        }
    }
}