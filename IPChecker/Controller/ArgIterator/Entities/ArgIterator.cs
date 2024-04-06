using System.Collections;
using Controller.ArgIterator.Interfaces;

namespace Controller.ArgIterator.Entities;

public class ArgIterator : IArgIterator
{
    private readonly string[] _args;
    private int _position = -1;

    public ArgIterator(string[] args)
    {
        _args = args;
    }

    public ArgIterator(string args)
    {
        _args = args.Split(" ").Where(x => x.Length > 0).ToArray();
    }

    public bool MoveNext()
    {
        _position++;
        return (_position < _args.Length);
    }

    public void Reset()
    {
        _position = -1;
    }

    private string Current
    {
        get
        {
            try
            {
                return _args[_position];
            }
            catch (IndexOutOfRangeException)
            {
                throw new InvalidOperationException();
            }
        }
    }

    public int CurrentPosition()
    {
        return _position;
    }

    object IEnumerator.Current => Current;
}