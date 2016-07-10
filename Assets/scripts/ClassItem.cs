using UnityEngine;

public class ClassItem {

    //Puntos del objeto
    private int point = 1;
    private ActionsItem action;
    //Numero de disparos disponibles
    private int shot = 0;
    private GameObject objectShot;

    public ClassItem(Item takeItem)
    {
        this.point = takeItem.point;
        this.action = takeItem.action;
        this.shot = takeItem.shot;
        this.objectShot = takeItem.objectShot;
    }

    //Resta la cantidad de disparos disponibles
    public void diminishShot(int value)
    {
        this.shot -= value;
    }

    public int getPoint()
    {
        return this.point;
    }

    public bool isIncrementTypeAction()
    {
        return ListActions.increment.Equals(this.action.typeAction);
    }

    //Comprueba si puede incrementar o disminuira el BarNyam
    public bool isActionBarNyam()
    {
        //Si es igual a SHOOT no se incrementara o disminuira el BarNyam
        return !ListActions.shoot.Equals(this.action.typeAction);
    }

    //Comprueba si puede disparar
    public bool isShoot()
    {
        return !isActionBarNyam() && this.shot > 0;
    }

    public GameObject getObjectShot()
    {
        return this.objectShot;
    }
}
