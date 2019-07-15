using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodManager : MonoBehaviour
{
    private string stringSelected;
    public float speed;
    public void Interact()
    {
        stringSelected = GameObject.Find("GameManager").GetComponent<MainManager>().undeadSelected;
        var selectedUndead = GameObject.Find(stringSelected);
        selectedUndead.GetComponent<UndeadManager>().foodCarrying = this.gameObject.tag;
        selectedUndead.GetComponent<UndeadManager>().MoveObject(GetComponent<RectTransform>(), speed);
        Debug.Log(selectedUndead.GetComponent<UndeadManager>().foodCarrying);
      Destroy(this.gameObject);
    }
}
