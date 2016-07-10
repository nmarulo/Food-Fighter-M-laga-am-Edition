using UnityEngine;
using System.Collections;

public class CharacterSelectCrt : MonoBehaviour
{
    private CheckWindLoss scriptCheckWinLoss;
    private string tagCharacterOne = "", tagCharacterTwo = "";

    public void Awake()
    {
        this.scriptCheckWinLoss = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<CheckWindLoss>();
    }

    // Use this for initialization
    void Start()
    {
        this.tagCharacterOne = this.scriptCheckWinLoss.tagPlayerOne;
        this.tagCharacterTwo = this.scriptCheckWinLoss.tagPlayerTwo;
    }

    public bool keyJump(string tagCharacter)
    {
        bool output = false;
        if (this.tagCharacterOne.Equals(tagCharacter))
        {
            output = Input.GetKey(KeyCode.C);
        }
        else
        {
            output = Input.GetKey(KeyCode.Keypad1);
        }
        return output;
    }

    public bool keyShot(string tagCharacter)
    {
        bool output = false;
        if (this.tagCharacterOne.Equals(tagCharacter))
        {
            output = Input.GetKey(KeyCode.V);
        }
        else
        {
            output = Input.GetKey(KeyCode.Keypad2);
        }
        return output;
    }

    public bool keyMoveHorizontal(string tagCharacter, string button)
    {
        bool output = false;
        if (this.tagCharacterOne.Equals(tagCharacter))
        {
            if (button.Equals("right"))
            {
                output = Input.GetKey(KeyCode.A);
            }
            else if (button.Equals("left"))
            {
                output = Input.GetKey(KeyCode.D);
            }
        }
        else
        {
            if (button.Equals("right"))
            {
                output = Input.GetKey(KeyCode.LeftArrow);
            }
            else if (button.Equals("left"))
            {
                output = Input.GetKey(KeyCode.RightArrow);
            }
        }
        return output;
    }

    public bool keyMoveVertical(string tagCharacter, string button)
    {
        bool output = false;
        if (this.tagCharacterOne.Equals(tagCharacter))
        {
            if (button.Equals("down"))
            {
                output = Input.GetKey(KeyCode.W);
            }
            else if (button.Equals("up"))
            {
                output = Input.GetKey(KeyCode.S);
            }
        }
        else
        {
            if (button.Equals("down"))
            {
                output = Input.GetKey(KeyCode.UpArrow);
            }
            else if (button.Equals("up"))
            {
                output = Input.GetKey(KeyCode.DownArrow);
            }
        }

        return output;
    }
}
