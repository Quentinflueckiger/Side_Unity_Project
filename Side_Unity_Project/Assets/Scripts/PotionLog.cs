﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PotionLog : MonoBehaviour, IConsumable
{
    public void Consume()
    {
        Debug.Log("You drank a sip of the potion. Cool !");
    }

    public void Consume(CharacterStats stats)
    {
        Debug.Log("You drank a sip of the potion. Rad !");
    }
}
