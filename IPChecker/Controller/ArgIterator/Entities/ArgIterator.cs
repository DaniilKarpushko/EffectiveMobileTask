using System.Collections;

namespace Controller.ArgIterator.Entities;

public class ArgIterator : IEnumerator
{
    private string[] _args;
    private int _position = -1;

    public bool MoveNext()
    {
        _position++;
        return (_position < _args.Length);
    }

    public void Reset()
    {
        _position = -1;
    }

    public string Current
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

    object IEnumerator.Current => Current;
}