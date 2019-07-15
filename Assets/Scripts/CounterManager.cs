using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Random = UnityEngine.Random;

/*
 * Zombzu
 *
 */

public class CounterManager : MonoBehaviour
{
    public List<string> Counter = new List<string>();
    public string[] items;
    public TextMeshProUGUI orders;
    public int minItems;
    public int maxItems;
    public int tableNum;


    private int numItems;
    private bool isCompleted = true;
    private Button thisButton;
    private string itemSelected;
    private string orderString;
    private string stringSelected;
    void Start()
    {
        thisButton = this.GetComponent<Button>();
    }


    public void CollectOrder()
    {
        stringSelected = GameObject.Find("GameManager").GetComponent<MainManager>().undeadSelected;
        if (Counter.Count == 0)
        {
            numItems = Random.Range(minItems, maxItems + 1);
            orders.text = orders.text + "\n" + "\n" + "Counter " + tableNum + ":";
            for (int i = 0; i != numItems; i++)
            {
                orderString = orders.text + "\n" + items[Random.Range(0, items.Length)];
                orders.text = orderString;
                Counter.Add(orderString);
            }
            isCompleted = false;
        }
        else
        {
            itemSelected = GameObject.Find(stringSelected).GetComponent<UndeadManager>().foodCarrying;
            if (Counter.Contains(itemSelected))
            {
                GameObject.Find("GameManager").GetComponent<MainManager>().gamePoints = (GameObject.Find("GameManager").GetComponent<MainManager>().gamePoints + 2);
                Counter.Remove(itemSelected);
            }
        }
    }


    
}
