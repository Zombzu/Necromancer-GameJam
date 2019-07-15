using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class UndeadManager : MonoBehaviour
{
    public string foodCarrying;
    public bool isIn = false;
    public void Select()
    {
        GameObject.Find("GameManager").GetComponent<MainManager>().undeadSelected = this.gameObject.name;
    }

    public void MoveObject(RectTransform otherRect, float speed)
    {
        Rigidbody2D rigidbody = GetComponent<Rigidbody2D>();
        rigidbody.transform.rotation = Quaternion.LookRotation(otherRect.position);
        rigidbody.AddForce((otherRect.position - transform.position) * speed);
        var color = new Color(0.32f, 0.26f, 0.42f);
        shallMove = true;
        this.currentBody = rigidbody;
        this.currentRect = otherRect;
    }

    static bool shallMove = false;
    RectTransform currentRect;
    Rigidbody2D currentBody;
    public void Update()
    {
        if (shallMove)
        {
            //Debug.Log("Current Y: " + rigidbody.transform.position.y + "\nRect Y: " + currentRect.position.y);
            if (this.currentBody.transform.position.y >= this.currentRect.transform.position.y)
            {   
                Debug.Log("Im in it");
                isIn = true;
                this.currentBody.velocity = Vector2.zero;
                shallMove = false;              
}
        }
    }
}

