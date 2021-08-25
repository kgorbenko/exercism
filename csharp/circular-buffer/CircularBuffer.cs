using System;
using System.Collections.Generic;

public class CircularBuffer<T>
{
    private readonly Queue<T> queue;
    private readonly int capacity;

    public CircularBuffer(int capacity)
    {
        queue         = new Queue<T>(capacity);
        this.capacity = capacity;
    }

    public T Read() => queue.Dequeue();

    public void Write(T value)
    {
        if (queue.Count == capacity)
        {
            throw new InvalidOperationException("Full buffer can't be written to.");
        }

        queue.Enqueue(value);
    }

    public void Overwrite(T value)
    {
        if (queue.Count == capacity)
        {
            queue.Dequeue();
        }

        Write(value);
    }

    public void Clear() => queue.Clear();
}