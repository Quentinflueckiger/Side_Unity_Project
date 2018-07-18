using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterStats : MonoBehaviour {

    public List<BaseStat> Stats = new List<BaseStat>();

    private void Start()
    {

        Stats.Add(new BaseStat(4, "Power", "Your power level."));
        Stats.Add(new BaseStat(2, "Vitality", "Your vitality level."));
    }

    public void AddStatBonus(List<BaseStat> statBonuses)
    {
        foreach(BaseStat statBonus in statBonuses)
        {
            // Maybe change the x.StatName to x.ID and implement an ID system.
            Stats.Find(x => x.StatName == statBonus.StatName).AddStatBonus(new StatBonus(statBonus.BaseValue));
        }
    }

    public void RemoveStatBonus(List<BaseStat> statBonuses)
    {
        foreach (BaseStat statBonus in statBonuses)
        {
            // Maybe change the x.StatName to x.ID and implement an ID system.
            Stats.Find(x => x.StatName == statBonus.StatName).RemoveStatBonus(new StatBonus(statBonus.BaseValue));
        }
    }
}
