using UnityEngine;
using System.Collections;

public class ShotDestroy : MonoBehaviour {

    public float timeDestroy = 5f;

    // Use this for initialization
    void Start () {
        Invoke("destroy", this.timeDestroy);
	}
	
	private void destroy()
    {
        Destroy(this.gameObject);
    }
}
