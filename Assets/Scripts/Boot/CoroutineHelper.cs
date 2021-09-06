using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoroutineHelper : AbstractSingleton<CoroutineHelper>
{
    public IEnumerator YieldCoroutines(IEnumerator enumerator, Action onFinish = null)
    {
        List<IEnumerator> enumeratorList = new List<IEnumerator>();
        enumeratorList.Add(enumerator);
        IEnumerator listCall = YieldCoroutines(enumeratorList, onFinish);
        yield return StartCoroutine(listCall);
    }

    public IEnumerator YieldCoroutines(List<IEnumerator> enumeratorList, Action onFinish = null)
    {
        List<Coroutine> coroutineList = new List<Coroutine>();
        foreach (IEnumerator forEnumerator in enumeratorList)
        {
            Coroutine coroutine = StartCoroutine(forEnumerator);
            coroutineList.Add(coroutine);
        }
        foreach (Coroutine forCoroutine in coroutineList)
        {
            yield return forCoroutine;
        }
        onFinish?.Invoke();
    }
}
