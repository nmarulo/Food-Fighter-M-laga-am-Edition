using UnityEngine;
using System.Collections;

public class CheckWindLoss : MonoBehaviour
{

    public string tagPlayerOne = "CharacterOne";
    public string tagPlayerTwo = "CharacterTwo";
    private NyamBar playerOne;
    private NyamBar playerTwo;
    private string tagPlayerWin;

    public void Awake()
    {
        //this.playerOne = GameObject.FindGameObjectWithTag(this.tagPlayerOne).GetComponent<NyamBar>();
        //this.playerTwo = GameObject.FindGameObjectWithTag(this.tagPlayerTwo).GetComponent<NyamBar>();
    }

    // Update is called once per frame
    void Update()
    {
        //if (this.playerOne.checkWinLoss())
        //{
        //    this.tagPlayerWin = this.tagPlayerOne;
        //}
        //else if (this.playerTwo.checkWinLoss())
        //{
        //    this.tagPlayerWin = this.tagPlayerTwo;
        //}
        //print("Ganador: " + this.tagPlayerWin);
    }
}
