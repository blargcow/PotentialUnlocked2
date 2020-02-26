using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Goal
{
    public Quest quest;
    public string Description;
    public bool Completed;
    public int Current;
    public int Required;


    public virtual void Init()
    {
        
    }

    public void evaluate()
    {
        if (Current >= Required)
        {
            Complete();
        }
    }

    public void Complete()
    {
        Completed = true;
        quest.CheckGoals();
        
    }

}
