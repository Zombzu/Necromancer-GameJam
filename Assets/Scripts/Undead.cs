using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Undead : MonoBehaviour
{
    private int undead;

    public float mana;
    public float undeadCost;
    public Slider manaSlider;
    public int numUndead;
    public GameObject undeadSpawn;
    public GameObject canvas;
    public float minX;
    public float minY;
    public float maxX;
    public float maxY;


    public string task;
    private static int i = 1;


    // Update is called once per frame
    void Update()
    {
        manaSlider.value = mana; 
    }

    public void Summon()
    {
        if (mana >= undeadCost)
        {
            undeadSpawn.name = "Undead" + i++;
            undead++;
            mana = mana - undeadCost;
            numUndead++;
            float x = Random.Range(minX, maxX);
            float y = Random.Range(minY,maxY);
            GameObject zombie = Instantiate(undeadSpawn, new Vector3(x,y, 120), Quaternion.identity);
            zombie.transform.SetParent(canvas.transform, false);
        }
   
    }

 


}
