using UnityEngine;
using System.Collections;
using UnityEditor;

public class Item : MonoBehaviour
{
    //Puntos del objeto
    public int point = 1;
    public ActionsItem action;
    //Numero de disparos disponibles
    public int shot = 0;
    public GameObject objectShot;
}

[System.Serializable]
public class ActionsItem
{
    public ListActions typeAction;
}

public enum ListActions
{
    increment = 0,
    diminish = 1,
    shoot = 2
}

[CustomPropertyDrawer(typeof(ActionsItem))]
class ListActionsDrawer : PropertyDrawer
{
    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
    {
        EditorGUI.PropertyField(position, property.FindPropertyRelative("typeAction"), new GUIContent() { text = "Actions" });
    }
}