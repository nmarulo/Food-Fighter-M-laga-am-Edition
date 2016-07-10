using UnityEngine;
using System.Collections;

public class GeneratePlayer : MonoBehaviour {

    //Personajes del juego
    public GameObject[] characters;
    private string tagCharacter;
    private string selectCharacterName = "Cube";

	// Use this for initialization
	void Start () {
        if (selectTagCharacter())
        {
            generatePlayer();
        }
	}

    private void generatePlayer()
    {
        bool exit = false;
        int count = this.characters.Length;
        GameObject player;

        for(byte i = 0; i < count && !exit; ++i)
        {
            if (this.characters[i].name.Equals(this.selectCharacterName))
            {
                player = (GameObject)Instantiate(this.characters[i], this.transform.position, Quaternion.identity);
                configPlayer(player);
                exit = true;
            }
        }
    }

    private void configPlayer(GameObject player)
    {
        print("configurando jugador " + this.tagCharacter);
    }

    private bool selectTagCharacter()
    {
        bool output = true;

        if (this.name.Equals("PlayerOne"))
        {
            this.tagCharacter = "CharacterOne";
        }
        else if (this.name.Equals("PlayerTwo"))
        {
            this.tagCharacter = "CharacterTwo";
        }
        else
        {
            output = false;
            Debug.Log("Jugador no definido.");
        }
        return output;
    }
}
