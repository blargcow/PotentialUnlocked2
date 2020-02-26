using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.UI;

public class Quest : MonoBehaviour
{
    public List<Goal> Goals = new List<Goal>();
    public string QuestName;
    public string Description;
    public int reward;
    public bool completed;


    public void CheckGoals()
    {
        completed = (Goals.All(g => g.Completed));
        if (completed)
        {
            //questUI.SetActive(false);
            //GiveReward();
            //Debug.Log("Quest Finished");
            FindObjectOfType<DialogueManager>().setPart(2);
        }
        else
        {
            FindObjectOfType<DialogueManager>().setPart(3);
        }
            
    }

    public void GiveReward()
    {
        //Debug.Log("Quest Finished");
    }
    
 
}
