namespace solutions;
public class MyStack<T>
{
    private readonly Queue<T> q = new();
    private readonly Queue<T> temp = new();

    public void Push(T x)
    {
        while (temp.Count > 0)
        {
            q.Enqueue(temp.Dequeue());
        }
        q.Enqueue(x);
    }

    public T Pop()
    {
        while (q.Count > 1)
        {
            temp.Enqueue(q.Dequeue());
        }
        var r = q.Dequeue();

        while (temp.Count > 0)
        {
            q.Enqueue(temp.Dequeue());
        }

        return r;
    }

    public T Top()
    {
        while (q.Count > 1)
        {
            temp.Enqueue(q.Dequeue());
        }
        var r = q.Peek();
        temp.Enqueue(q.Dequeue());

        while (temp.Count > 0)
        {
            q.Enqueue(temp.Dequeue());
        }

        return r;
    }

    public bool Empty()
    {
        return q.Count == 0;
    }
}