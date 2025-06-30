using System;
using UnityEngine;
using System.Collections.Generic;
using Cysharp.Threading.Tasks;

public class AnimationObjectsPool<T>
{
    private readonly List<T> _active = new List<T>();
    private readonly Func<T> _preloadFunc;
    private readonly Action<T> _getAction;
    private readonly Action<T> _returnAction;

    public Queue<T> Pool { get; private set; } = new Queue<T>();
        
    public AnimationObjectsPool(Func<T> preloadFunc, Action<T> getAction, Action<T> returnAction, int preloadCount)
    {
        _preloadFunc = preloadFunc;
        _getAction = getAction;
        _returnAction = returnAction;

        if (preloadFunc == null)
        {
            Debug.LogError("Preload function is null");
            return;
        }

        Preload(preloadCount);
    }
        
    public async UniTask<T> Get()
    {
        T item = Pool.Count > 0 ? Pool.Dequeue() : _preloadFunc();
        _active.Add(item);
        _getAction(item);

        return item;
    }
        
    public void Return(T item)
    {
        _returnAction(item);
        Pool.Enqueue(item);
        _active.Remove(item);
    }
        
    private void Preload(int count)
    {
        for (int i = 0; i < count; i++)
        {
            T item = _preloadFunc();
            Return(item);
        }
    }
}