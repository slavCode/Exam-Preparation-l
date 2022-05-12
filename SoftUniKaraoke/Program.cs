using System;
using System.Collections.Generic;
using System.Linq;

namespace SoftUniKaraoke
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var realParticipants = Console.ReadLine()
                                         .Split(new string[] { ", " }, StringSplitOptions.RemoveEmptyEntries)
                                         .ToList();
            var songs = Console.ReadLine()
                                        .Split(new string[] { ", " }, StringSplitOptions.RemoveEmptyEntries)
                                        .ToList();

            var resultedParticipants = new Dictionary<string, Dictionary<string, string>>();
            string input = Console.ReadLine();
            while (input != "dawn")
            {
                string[] parts = input.Split(new string[] { ", " }, StringSplitOptions.RemoveEmptyEntries);
                string participant = parts[0];
                string song = parts[1];
                string awardName = parts[2];

                if (realParticipants.Contains(participant) && songs.Contains(song))
                {
                    if (!resultedParticipants.ContainsKey(participant))
                    {
                        var award = new Dictionary<string, string>();
                        award.Add(awardName, song);
                        resultedParticipants.Add(participant, award);
                    }
                    else if (!resultedParticipants[participant].ContainsKey(awardName))
                    {
                        resultedParticipants[participant].Add(awardName, song);
                    }
                }
                input = Console.ReadLine();
            };

            if (resultedParticipants.Count < 1)
            {
                Console.WriteLine("No awards");
                return;
            }

            var sortedParticipants = resultedParticipants
                                        .OrderByDescending(a => a.Value.Count()).ThenBy(p => p.Key);
            foreach (var participant in sortedParticipants)
            {
                Console.WriteLine($"{participant.Key}: {participant.Value.Count()} awards");
                foreach (var award in participant.Value.OrderBy(a => a.Key))
                {
                    Console.WriteLine($"--{award.Key}");
                }
            }
        }
    }
}
