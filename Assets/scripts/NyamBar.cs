using UnityEngine;
using System.Collections;

public class NyamBar : MonoBehaviour
{
    //Valor maximo de la barra
    public int maxNyamBar = 100;
    //Nombre de la barra del personaje
    public string tagBarNyamBar = "BarNyamBar";
    //Barra del ÑamBar
    private GameObject barNyamBar;
    //Valor de la barra
    private int increment = 0;

    public void Awake()
    {
        this.barNyamBar = GameObject.FindGameObjectWithTag(tagBarNyamBar);
    }

    // Use this for initialization
    void Start()
    {
        setBarNyamBar(0f);
    }

    public void diminishNyamBar(int points)
    {
        int aux = this.increment - points;
        if (aux > 0)
        {
            changeBarNyamBar(aux);
        }
        else
        {
            setBarNyamBar(0);
        }
    }

    public void incrementNyamBar(int points)
    {
        int aux = this.increment + points;
        if (aux < this.maxNyamBar)
        {
            changeBarNyamBar(aux);
        }
        else
        {
            setBarNyamBar(this.maxNyamBar);
        }
    }

    private void changeBarNyamBar(int newValue)
    {
        this.increment = newValue;
        float x = this.increment / maxNyamBar;
        setBarNyamBar(x);
    }

    //Cambia la escala en X de la barra
    private void setBarNyamBar(float x)
    {
        if (this.barNyamBar == null)
        {
            Debug.Log("No se encontro el objeto con TAG: " + this.tagBarNyamBar);
        }
        else
        {
            Vector3 scaleBar = this.barNyamBar.transform.localScale;
            Vector3 newScale = new Vector3(x, scaleBar.y, scaleBar.z);
            this.barNyamBar.transform.localScale = newScale;
        }
    }

    //Comprueba si un personaje ha llenado la barra.
    public bool checkWinLoss()
    {
        return this.increment == this.maxNyamBar;
    }
}
