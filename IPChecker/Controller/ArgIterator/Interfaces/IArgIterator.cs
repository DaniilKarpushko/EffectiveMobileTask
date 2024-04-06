using System.Collections;

namespace Controller.ArgIterator.Interfaces;

public interface IArgIterator : IEnumerator
{
    int CurrentPosition();
}