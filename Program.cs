using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

public class Task
{
    public int Id { get; set; }
    public string Description { get; set; }
    public string Status { get; set; } = "todo"; // Estado inicial é "todo"
    public DateTime CreatedAt { get; set; } = DateTime.Now;
    public DateTime UpdatedAt { get; set; } = DateTime.Now;
}

public class TaskManager
{
    private const string FileName = "tasks.json";

    public List<Task> LoadTasks()
    {
        if (!File.Exists(FileName))
        {
            File.WriteAllText(FileName, "[]");
        }

        string json = File.ReadAllText(FileName);
        return JsonSerializer.Deserialize<List<Task>>(json);
    }

    public void SaveTasks(List<Task> tasks)
    {
        string json = JsonSerializer.Serialize(tasks, new JsonSerializerOptions { WriteIndented = true });
        File.WriteAllText(FileName, json);
    }

    public void AddTask(string description)
    {
        var tasks = LoadTasks();
        int nextId = tasks.Count > 0 ? tasks[^1].Id + 1 : 1;

        Task newTask = new Task
        {
            Id = nextId,
            Description = description,
            CreatedAt = DateTime.Now,
            UpdatedAt = DateTime.Now
        };

        tasks.Add(newTask);
        SaveTasks(tasks);
        Console.WriteLine($"Tarefa adicionada com sucesso (ID: {newTask.Id})");
    }

    public void UpdateTask(int id, string newDescription)
    {
        var tasks = LoadTasks();
        var task = tasks.Find(t => t.Id == id);

        if (task != null)
        {
            task.Description = newDescription;
            task.UpdatedAt = DateTime.Now;
            SaveTasks(tasks);
            Console.WriteLine($"Tarefa {id} atualizada com sucesso.");
        }
        else
        {
            Console.WriteLine($"Tarefa com ID {id} não encontrada.");
        }
    }

    public void DeleteTask(int id)
    {
        var tasks = LoadTasks();
        var task = tasks.Find(t => t.Id == id);

        if (task != null)
        {
            tasks.Remove(task);
            SaveTasks(tasks);
            Console.WriteLine($"Tarefa {id} excluída com sucesso.");
        }
        else
        {
            Console.WriteLine($"Tarefa com ID {id} não encontrada.");
        }
    }

    public void ListTasks(string status = null)
    {
        var tasks = LoadTasks();
        if (!string.IsNullOrEmpty(status))
        {
            tasks = tasks.FindAll(t => t.Status == status);
        }

        if (tasks.Count == 0)
        {
            Console.WriteLine("Nenhuma tarefa encontrada.");
        }
        else
        {
            Console.WriteLine("Lista de Tarefas:");
            foreach (var task in tasks)
            {
                Console.WriteLine($"ID: {task.Id}, Descrição: {task.Description}, Status: {task.Status}, Criada em: {task.CreatedAt}, Atualizada em: {task.UpdatedAt}");
            }
        }
    }

    public void MarkInProgress(int id)
    {
        var tasks = LoadTasks();
        var task = tasks.Find(t => t.Id == id);

        if (task != null)
        {
            task.Status = "in-progress";
            task.UpdatedAt = DateTime.Now;
            SaveTasks(tasks);
            Console.WriteLine($"Tarefa {id} marcada como em andamento.");
        }
        else
        {
            Console.WriteLine($"Tarefa com ID {id} não encontrada.");
        }
    }

    public void MarkDone(int id)
    {
        var tasks = LoadTasks();
        var task = tasks.Find(t => t.Id == id);

        if (task != null)
        {
            task.Status = "done";
            task.UpdatedAt = DateTime.Now;
            SaveTasks(tasks);
            Console.WriteLine($"Tarefa {id} marcada como concluída.");
        }
        else
        {
            Console.WriteLine($"Tarefa com ID {id} não encontrada.");
        }
    }
}

class Program
{
    static void Main(string[] args)
    {
        TaskManager taskManager = new TaskManager();

        if (args.Length == 0)
        {
            Console.WriteLine("Por favor, insira um comando.");
            return;
        }

        string command = args[0];

        switch (command)
        {
            case "add":
                if (args.Length > 1)
                {
                    string description = args[1];
                    taskManager.AddTask(description);
                }
                else
                {
                    Console.WriteLine("Por favor, insira a descrição da tarefa.");
                }
                break;

            case "update":
                if (args.Length > 2)
                {
                    int id = int.Parse(args[1]);
                    string newDescription = args[2];
                    taskManager.UpdateTask(id, newDescription);
                }
                else
                {
                    Console.WriteLine("Por favor, insira o ID e a nova descrição.");
                }
                break;

            case "delete":
                if (args.Length > 1)
                {
                    int id = int.Parse(args[1]);
                    taskManager.DeleteTask(id);
                }
                else
                {
                    Console.WriteLine("Por favor, insira o ID da tarefa.");
                }
                break;

            case "mark-in-progress":
                if (args.Length > 1)
                {
                    int id = int.Parse(args[1]);
                    taskManager.MarkInProgress(id);
                }
                else
                {
                    Console.WriteLine("Por favor, insira o ID da tarefa.");
                }
                break;

            case "mark-done":
                if (args.Length > 1)
                {
                    int id = int.Parse(args[1]);
                    taskManager.MarkDone(id);
                }
                else
                {
                    Console.WriteLine("Por favor, insira o ID da tarefa.");
                }
                break;

            case "list":
                if (args.Length > 1)
                {
                    string status = args[1]; // ex: "todo", "in-progress", "done"
                    taskManager.ListTasks(status);
                }
                else
                {
                    taskManager.ListTasks();
                }
                break;

            default:
                Console.WriteLine("Comando não reconhecido.");
                break;
        }
    }
}
