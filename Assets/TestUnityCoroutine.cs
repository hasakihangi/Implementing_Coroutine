using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestUnityCoroutine : MonoBehaviour
{
    private float timer = -1f;
    private const float duration = 2f;
    
    void Start()
    {
        StartCoroutine(MyUnityCoroutine());
    }
    
    void Update()
    {
        
    }

    IEnumerator MyUnityCoroutine()
    {
        MyYield myYield = new MyYield(() =>
        {
            timer -= Time.deltaTime;
            bool b = timer > 0f;
            if (!b)
                timer = duration;
            return b;
        });
        yield return myYield;
        print(1);
        yield return myYield;
        print(2);
        yield return myYield;
        print(3);
    }
}

public class MyYield: CustomYieldInstruction
{
    public MyYield(Func<bool> method)
    {
        this.method = method;
    }

    private Func<bool> method;
    
    public override bool keepWaiting
    {
        get
        {
            return method();
        }
    }
}
