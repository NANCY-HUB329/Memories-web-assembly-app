using MemoriesAssessment.Shared;
using System;
using System.Collections.Generic;
using System.Linq;

public class MemoryService
{
    // Use a static list to persist memories across instances
    private static List<Memory> memories = new List<Memory>();

    static MemoryService()
    {
        // Initialize with some sample memories if the list is empty
        if (memories.Count == 0)
        {
            memories.AddRange(new[]
            {
                new Memory
                {
                    Id = Guid.NewGuid(),
                    Name = ".NET COHORT TRAINING 2023",
                    Description = "It was such a great oortunity to participate in the 21st Cohort training at TheJitu.I learnt alot in the training,gained both technical and soft skills.",
                    Date = DateTime.Now.Date,
                    Location = "Nyeri-KDS center, Kenya"
                },
                new Memory
                {
                    Id = Guid.NewGuid(),
                    Name = "A visit to FORT Jesus",
                    Description = "It was a great opportunity to visit one of the most fascinating and historical places in Kenya.",
                    Date = DateTime.Now.AddDays(-7).Date,
                    Location = "Mombasa,Kenya"
                }
            });
        }
    }

    public List<Memory> GetMemories()
    {
        return memories;
    }

    public Memory? GetMemoryById(Guid id)
    {
        return memories.FirstOrDefault(m => m.Id == id);
    }

    public void AddMemory(Memory memory)
    {
        memory.Id = Guid.NewGuid();
        memories.Add(memory);
    }

    public void UpdateMemory(Memory updatedMemory)
    {
        var existingMemory = memories.FirstOrDefault(m => m.Id == updatedMemory.Id);
        if (existingMemory != null)
        {
            existingMemory.Name = updatedMemory.Name;
            existingMemory.Description = updatedMemory.Description;
            existingMemory.Date = updatedMemory.Date;
            existingMemory.Location = updatedMemory.Location;
        }
    }

    public void DeleteMemory(Guid id)
    {
        memories.RemoveAll(m => m.Id == id);
    }
}
