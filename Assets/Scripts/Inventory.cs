﻿using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

public class Inventory : MonoBehaviour
{

    public GameObject inventory;
    public GameObject slotHolder;
    public GameObject itemManager;
    private bool inventoryEnabled;

    private int slots;
    private Transform[] slot;

    private GameObject itemPickedUp;
    private bool itemAdded;

    public void Start()
    {
        // Slots Being Detected
        slots = slotHolder.transform.childCount;
        slot = new Transform[slots];
        DetectInventorySlots();
    }

    public void Update()
    {
        if(Input.GetKeyDown(KeyCode.I))
        {
            inventoryEnabled = !inventoryEnabled;
        }

        if (inventoryEnabled)
            inventory.GetComponent<Canvas>().enabled = true;
        else
            inventory.GetComponent<Canvas>().enabled = false;
    }


    public void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Item")
        {
            print("Colliding");
            itemPickedUp = other.gameObject;
            AddItem(itemPickedUp);
        }
    }

    public void OnTriggerExit(Collider other)
    {
        if(other.tag == "Item")
        {
            itemAdded = false;
        }
    }


    public void AddItem(GameObject item)
    {
        for (int i = 0; i < slots; i++)
        {
            if (slot[i].GetComponent<Slot>().empty && itemAdded == false)
            {
                slot[i].GetComponent<Slot>().item = itemPickedUp;
                slot[i].GetComponent<Slot>().itemIcon = itemPickedUp.GetComponent<Item>().icon;

                item.transform.parent = itemManager.transform;
                item.transform.position = itemManager.transform.position;

                if (item.GetComponent<MeshRenderer>())
                    item.GetComponent<MeshRenderer>().enabled = false;

                Destroy(item.GetComponent<Rigidbody>());


                itemAdded = true;
            }
        }
    }

    public void DetectInventorySlots()
    {
        
        

        for(int i = 0; i < slots; i++)
        {
            slot[i] = slotHolder.transform.GetChild(i);
           
        }
    

    }
}
