using UnityEngine;
using System.Collections;
using UnityEditor;

public class GenerateObject : MonoBehaviour
{
    //Lista de objetos
    public GameObject[] items;
    //Tiempo de aparicion minima
    public float timeMin = 1f;
    //Tiempo de aparecion maxima
    public float timeMax = 2f;
    public float positionY = 0.688f;
    public PositionGenerateGameObject position;
    //Es true si el GameObject a creado un objeto
    private bool isGenerateObject = false;

    public void randomTimeInvoke()
    {
        if (this.items.Length > 0)
        {
            float timeInvoke = Random.Range(this.timeMin, this.timeMax);
            Invoke("generate", timeInvoke);
        }
        else
        {
            Debug.Log("No se asigno ningun objeto al generador.");
        }
    }

    public bool isGenerate()
    {
        return this.isGenerateObject;
    }

    public void setGenerate(bool value)
    {
        this.isGenerateObject = value;
    }

    private void generate()
    {
        int randomItem = Random.Range(0, this.items.Length);
        GameObject item = this.items[randomItem];
        Vector3 newPosition = this.transform.position;
        //Para que el objeto se genere sobre la mesa.
        newPosition.y = positionY;
        Instantiate(item, newPosition, Quaternion.identity);
        Invoke("changeGenerate", item.GetComponent<ItemDestroy>().timeDestroy);
    }

    private void changeGenerate()
    {
        setGenerate(false);
    }
}

[System.Serializable]
public class PositionGenerateGameObject
{
    public ListPositions position;
}

public enum ListPositions
{
    up = 0,
    down = 1
}

[CustomPropertyDrawer(typeof(PositionGenerateGameObject))]
class PositionGenerateGameObjectDrawer : PropertyDrawer
{
    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
    {
        EditorGUI.PropertyField(position, property.FindPropertyRelative("position"), new GUIContent() { text = "Position" });
    }
}