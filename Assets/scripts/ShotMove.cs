using UnityEngine;
using System.Collections;

public class ShotMove : MonoBehaviour
{
    //Velocidad de disparo
    public float velocity = 1f;
    public string layerCharacter = "Characters";
    private Vector3 direction;

    public void FixedUpdate()
    {
        this.transform.position += this.direction * this.velocity * Time.deltaTime;
    }

    public void OnTriggerEnter(Collider other)
    {
        GameObject player = other.gameObject;
        if (LayerMask.LayerToName(player.layer).Equals(this.layerCharacter))
        {
            print("Disparo colision: " + player.tag);
        }
    }

    public void setDirection(Vector3 direction)
    {
        this.direction = direction;
    }
}
