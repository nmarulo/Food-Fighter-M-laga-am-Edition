using UnityEngine;
using System.Collections;
using System;

public class TakeGameObject : MonoBehaviour
{
    public string tagItem = "Item";
    //Script
    private NyamBar nyamBar;
    //Objeto tomado por el jugado.
    private ClassItem classItem;

    public void Awake()
    {
        this.nyamBar = GetComponent<NyamBar>();
    }

    public void OnTriggerEnter(Collider other)
    {
        GameObject item = other.gameObject;
        if (item.tag.Equals(this.tagItem))
        {
            this.classItem = new ClassItem(item.GetComponent<Item>());
            if (this.classItem.isActionBarNyam())
            {
                changeBarNyamBar();
            }
        }
    }

    private void changeBarNyamBar()
    {
        int point = this.classItem.getPoint();

        if (this.classItem.isIncrementTypeAction())
        {
            this.nyamBar.incrementNyamBar(point);
        }else
        {
            this.nyamBar.diminishNyamBar(point);
        }
    }

    public ClassItem getTakeItem()
    {
        return this.classItem;
    }
}
