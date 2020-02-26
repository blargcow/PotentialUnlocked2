using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuestGoal : Goal
{
    public int NPCID;
    //public static Chad_interaction cd = new Chad_interaction();
    public QuestGoal(Quest quest, int ID, string description, bool completed, int current, int required)
    {
        this.quest = quest;
         
        this.Description = description;
        this.Completed = completed;
        this.Current = current;
        this.Required = required;
        this.NPCID = ID;

        
    }

    public override void Init()
    {
        base.Init();
        Chad_interaction.onAnyInteract += Interacted;
    }

    public void Interacted(Interactable npc)
    {
        if (npc.ID == this.NPCID)
        {
            this.Current++;
            evaluate();
        }
    }


}
