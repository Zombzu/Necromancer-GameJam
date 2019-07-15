using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StationManager : MonoBehaviour
{
    public Slider progressBar ;
    private GameObject selectedUndead;
    public float progressTime;
    public List<string> zombiesWorking = new List<string>();  
    public float speed;
    private float barProgress = 0;
    private int numCompleted = 0;
    private bool isBusy = false;
    private bool isIn = false;
    private string stringSelected;

    //for instantiating prefab
    public GameObject foodSpawn;
    public GameObject canvas;
    public float minX;
    public float minY;
    public float maxX;
    public float maxY;


    private void Update()
    {
        progressBar.value = barProgress;
       
    }
    public void Interact()        
    {        
        {
            if ((zombiesWorking.Count < 4))
            {
                stringSelected = GameObject.Find("GameManager").GetComponent<MainManager>().undeadSelected;
                selectedUndead = GameObject.Find(stringSelected);
                InvokeRepeating("CheckExists", 0.1f, 0.01f);
            }
            if ((stringSelected != null)  && (!zombiesWorking.Contains(stringSelected)))
            {
                selectedUndead.GetComponent<UndeadManager>().MoveObject(GetComponent<RectTransform>(), speed);
                InvokeRepeating("CheckIn", 0.1f, 0.01f);
            }
                
           
           

        }
        
    }
    private void ProgressBar()
    {
        if (isBusy == true)
        {
            if (barProgress < 100)
            {
                barProgress = barProgress + 10;
            }
            else
            {
                numCompleted++;
                InstantiateFood();
                isBusy = false;
            }
        }
       
    }

    private void InstantiateFood()
    {
        float x = Random.Range(minX, maxX);
        float y = Random.Range(minY, maxY);
        GameObject food = Instantiate(foodSpawn, new Vector3(x, y, 120), Quaternion.identity);
        food.transform.SetParent(canvas.transform, false);
    }
    private void CheckIn()
    {
       

        isIn = selectedUndead.GetComponent<UndeadManager>().isIn;
        if (isIn)
        {
            zombiesWorking.Add(stringSelected);
            isBusy = true;
            GameObject.Find("GameManager").GetComponent<MainManager>().undeadSelected = null;
            InvokeRepeating(nameof(ProgressBar), 1.0f, progressTime / 10 * zombiesWorking.Count);
            CancelInvoke("CheckIn");
            
        }
    }
    private void CheckExists()
    {
        if (GameObject.Find(stringSelected) == null)
        {
            isBusy = false;
            stringSelected = null;
            CancelInvoke();
        }
    }
}
