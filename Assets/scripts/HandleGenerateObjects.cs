using UnityEngine;
using System.Collections;

public class HandleGenerateObjects : MonoBehaviour
{
    public string tagObjectsRandom = "GenerateRandom";
    public int maxGenerateItems = 2;
    private GameObject[] generatesObjects;
    private int countItems = 0;

    public void Awake()
    {
        this.generatesObjects = GameObject.FindGameObjectsWithTag(this.tagObjectsRandom);
    }

    public void Start()
    {
        if (this.maxGenerateItems > this.generatesObjects.Length)
        {
            this.maxGenerateItems = this.generatesObjects.Length;
        }
    }

    public void Update()
    {
        generateItems();
    }

    public void diminishCountItem()
    {
        --this.countItems;
    }

    private void generateItems()
    {
        if (this.countItems < this.maxGenerateItems)
        {
            GenerateObject scriptGenerate = getRandomGenerateObject();
            scriptGenerate.randomTimeInvoke();
            ++this.countItems;
        }
    }

    private GenerateObject getRandomGenerateObject()
    {
        int count = this.generatesObjects.Length;
        GameObject selectObject = this.generatesObjects[Random.Range(0, count)];
        GenerateObject scriptGenerate = selectObject.GetComponent<GenerateObject>();

        while (scriptGenerate.isGenerate())
        {
            selectObject = this.generatesObjects[Random.Range(0, count)];
            scriptGenerate = selectObject.GetComponent<GenerateObject>();
        }
        scriptGenerate.setGenerate(true);
        return scriptGenerate;
    }
}
