﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour {
    public Image[] itemImages = new Image[numItemSlots];
    public Item[] items = new Item[numItemSlots];

    public const int numItemSlots = 4;


    public void AddItem(Item ItemToAdd)
    {
        for(int i = 0; i < items.Length; i++)
        {
            if(items[i] == null)
            {
                items[i] = ItemToAdd;
                itemImages[i].sprite = ItemToAdd.sprite;
                itemImages[i].enabled = true;
                return;
            }
        }

    }
    public void RemoveItem(Item itemToRemove)
    {
        for (int i = 0; i < items.Length; i++)
        {
            if (items[i] == itemToRemove)
            {
                items[i] = null;
                itemImages[i].sprite = null;
                itemImages[i].enabled = false;
                return;
            }
        }

    }


}
