using UnityEngine;
using System.Collections;

public class ItemDestroy : MonoBehaviour
{
    //Tiempo para destruir automaticamente el Item
    public float timeDestroy = 5f;
    public string tagCharacters = "Characters";
    private HandleGenerateObjects scriptHandleGenerateObjects;

    public void Awake()
    {
        this.scriptHandleGenerateObjects = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<HandleGenerateObjects>();
    }

    // Use this for initialization
    void Start()
    {
        Invoke("destroy", this.timeDestroy);
    }

    public void OnTriggerEnter(Collider other)
    {
        GameObject player = other.gameObject;
        if (LayerMask.LayerToName(player.layer).Equals(this.tagCharacters))
        {
            destroy();
        }
    }

    private void destroy()
    {
        this.scriptHandleGenerateObjects.diminishCountItem();
        Destroy(this.gameObject);
    }
}
