using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TheOtherRoles.Modules;

public class TaskQueue : ManagerBase<TaskQueue>
{
    public Queue<Task> Tasks = [];

    public bool TaskStarting;

    public string CurrentId;

    public Task CurrentTask;
    
    public void StartTask(Action action, string Id)
    {
        var task = new Task(() =>
        {
            CurrentId = Id;
            Info($"Start TaskQueue Id:{Id}");
            try
            {
                action();
            }
            catch (Exception e)
            {
                Exception(e);
                Error($"加载失败 TaskQueue Id:{Id}");
            }
            
        });
        Tasks.Enqueue(task);
        
        if (!TaskStarting)
        {
            StartNew();
        }
    }

    public void StartNew()
    {
        if (!Tasks.Any() || TaskStarting) return;
        TaskStarting = true;
        Task.Run(() =>
            {
                Start();
                TaskStarting = false;
            }
        );
        return;

        void Start()
        {
            if (!Tasks.Any()) return;
            CurrentTask = Tasks.Dequeue();
            CurrentTask.Start();
            CurrentTask.GetAwaiter().OnCompleted(Start);
        }
    }
}