using UnityEngine;
using System.Collections;

public class CharacterShoot : MonoBehaviour
{
    //Tiempo de carga
    public float coolDown = 3f;
    public string tagGenerateShot = "GenerateShot";
    private GameObject generateShot;
    //Si es True tiene tiempo de carga.
    private bool isCoolDown;
    private ClassItem scriptItem;
    private TakeGameObject scriptTakeGameObject;
    private CharacterMove scriptCharacterMove;
    private CharacterSelectCrt scriptCharacterSelectCtr;

    public void Awake()
    {
        this.generateShot = GameObject.FindGameObjectWithTag(this.tagGenerateShot);
        this.scriptTakeGameObject = this.GetComponent<TakeGameObject>();
        this.scriptCharacterMove = this.GetComponent<CharacterMove>();
        this.scriptCharacterSelectCtr = this.GetComponent<CharacterSelectCrt>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isShot())
        {
            shot();
        }
    }

    //Cambia su valor de True a False y viceversa.
    public void changeIsColdDown()
    {
        this.isCoolDown = !this.isCoolDown;
    }

    //Disparar
    private void shot()
    {
        GameObject shot = this.scriptItem.getObjectShot();
        this.scriptItem.diminishShot(1);
        if (shot == null)
        {
            Debug.Log("El item no tiene el objeto de disparo.");
        }
        else
        {
            if (this.generateShot == null)
            {
                Debug.Log("No se encontro el objeto con TAG: " + this.tagGenerateShot);
            }
            else
            {
                this.isCoolDown = true;
                Invoke("changeIsColdDown", this.coolDown);
                Vector3 position = this.transform.position + this.scriptCharacterMove.getRadioCharacter();
                shot = (GameObject)Instantiate(shot, position, Quaternion.identity);
                ShotMove scriptShot = shot.GetComponent<ShotMove>();
                scriptShot.setDirection(this.scriptCharacterMove.getDirection());
            }
        }
    }

    //Es true si puede disparar
    private bool isShot()
    {
        return isScriptItem() && this.scriptCharacterSelectCtr.keyShot(this.tag) && hasShot() && checkCoolDown() && checkSpeed();
    }

    private bool checkSpeed()
    {
        return this.scriptCharacterMove.isMove();
    }

    //Es true si tiene disparos
    private bool hasShot()
    {
        return this.scriptItem.isShoot();
    }

    //Es true si ha terminado o no tiene tiempo de carga
    private bool checkCoolDown()
    {
        return !this.isCoolDown;
    }

    //Si es True el jugador ha tomado un objeto
    private bool isScriptItem()
    {
        this.scriptItem = this.scriptTakeGameObject.getTakeItem();
        return this.scriptItem != null;
    }
}
