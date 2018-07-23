using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConsumableController : MonoBehaviour {

    CharacterStats characterStats;

	// Use this for initialization
	void Start () {

        characterStats = GetComponent<CharacterStats>();
	}

    public void ConsumeItem(Item item)
    {
        // The path will change to bo "Consumables/" + item.Type + item.ObjectSlug later on when Type of item will be added.
        GameObject itemToSpawn = Instantiate(Resources.Load<GameObject>("Consumables/" + item.ObjectSlug));
        if (item.ItemModifier)
        {
            itemToSpawn.GetComponent<IConsumable>().Consume(characterStats);
        }
        else
        {
            itemToSpawn.GetComponent<IConsumable>().Consume();
        }
    }
	
}
