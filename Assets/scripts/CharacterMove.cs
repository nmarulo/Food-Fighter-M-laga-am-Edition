using UnityEngine;
using System.Collections;

public class CharacterMove : MonoBehaviour
{
    //Velocidad del personaje
    public float velocity = 15f;
    //Fuerza de salto
    public float jumpForce = 1f;
    //Velocidad de animacion
    public float animateVelocity = 1f;
    public string tagIsGrounded = "isGrounded";
    public LayerMask maskGrounded;
    //Fuerza de gravedad luego de saltar.
    [Range(1f, 4f)]
    public float gravityForce = 1f;
    //Radio en el que aparecera el disparo
    public float colliderRadio = 0.5f;
    //RigidBody del personaje
    private Rigidbody rbCharacter;
    private GameObject objectIsGround;
    //Es true si el personaje no esta en el aire
    private bool isGrounded;
    //Es true si el personaje puede saltar
    private bool isJump;
    //Movimiento en "X" y "Z" del personaje
    private Vector3 newVelocity;
    //Radio de comprobacion del suelo
    private float radioIsGrounded = 0.07f;
    private Vector3 radioCharacter;
    private bool isMoveCharacter;
    private CharacterSelectCrt scriptCharacterSelectCtr;

    public void Awake()
    {
        this.rbCharacter = this.GetComponent<Rigidbody>();
        this.objectIsGround = GameObject.FindGameObjectWithTag(this.tagIsGrounded);
        this.scriptCharacterSelectCtr = this.GetComponent<CharacterSelectCrt>();
        //GameObject game = GameObject.Find("Character/isGrounded");
        //GameObject gamet = GameObject.Find("Character/GenerateShot");
    }

    public void Start()
    {
        this.rbCharacter.freezeRotation = true;
    }

    public void FixedUpdate()
    {
        checkPressButtom();
        checkGroundStatus();
        move();
    }

    private void checkPressButtom()
    {
        float x = 0f, z = 0f, auxX = 0f, auxZ = 0f;
        if (this.scriptCharacterSelectCtr.keyMoveHorizontal(this.tag, "left"))
        {
            x = -1f;
            auxX = -1 * this.colliderRadio;
        }
        else if (this.scriptCharacterSelectCtr.keyMoveHorizontal(this.tag, "right"))
        {
            x = 1f;
            auxX = this.colliderRadio;
        }

        if (this.scriptCharacterSelectCtr.keyMoveVertical(this.tag, "up"))
        {
            z = 1f;
            auxZ = this.colliderRadio;
        }
        else if (this.scriptCharacterSelectCtr.keyMoveVertical(this.tag, "down"))
        {
            z = -1f;
            auxZ = -1 * this.colliderRadio;
        }
        this.isMoveCharacter = z != 0 || x != 0;
        this.radioCharacter = new Vector3(auxX, 0f, auxZ);
        setVelocity(x, 0f, z);
    }

    //Si es True el personaje se esta moviendo
    public bool isMove()
    {
        return this.isMoveCharacter;
    }

    public void Update()
    {
        if (!this.isJump && this.isGrounded)
        {
            this.isJump = this.scriptCharacterSelectCtr.keyJump(this.tag);
        }
    }

    //Comprueba si esta tocando el suelo
    private void checkGroundStatus()
    {
        if (this.objectIsGround == null)
        {
            Debug.Log("No se encontro el objeto con TAG: " + this.tagIsGrounded);
        }
        else
        {
            this.isGrounded = Physics.CheckSphere(this.objectIsGround.transform.position, this.radioIsGrounded, this.maskGrounded);
        }
    }

    private void move()
    {
        if (this.isJump)
        {
            this.rbCharacter.AddForce(Vector3.up * this.jumpForce, ForceMode.Impulse);
            this.isGrounded = false;
            this.isJump = false;
        }
        else if (!this.isGrounded)
        {
            Vector3 extraGravityForce = (Physics.gravity * this.gravityForce) - Physics.gravity;
            this.rbCharacter.AddForce(extraGravityForce);
        }
        else
        {
            this.rbCharacter.velocity = this.newVelocity * this.velocity * Time.deltaTime;
            if (this.rbCharacter.velocity != Vector3.zero)
            {
                this.transform.rotation = Quaternion.LookRotation(new Vector3(this.rbCharacter.velocity.x, 0f, this.rbCharacter.velocity.z));
            }
        }
    }

    private void setVelocity(float x, float y, float z)
    {
        this.newVelocity = new Vector3(x, y, z);
    }

    public Vector3 getDirection()
    {
        return this.newVelocity;
    }

    public Vector3 getRadioCharacter()
    {
        return this.radioCharacter;
    }
}