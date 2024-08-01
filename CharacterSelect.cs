using System.Collections.Generic;
using System.Linq;
using UnityEngine;
public class CharacterSelect : MonoBehaviour
{
    public List<Character_UI> characters = new List<Character_UI>();
    public Character_UI currentCharacter;
    public Character_UI previousCharacter;
    public int i = 0;
    public player player;
    void Start()
    {        
        this.gameObject.SetActive(true);
        currentCharacter = characters.ElementAt(i); //init
    }
    void Update()
    {
        if(this.gameObject.activeSelf) {
        SelectCharacter();
        // currentCharacter.transform.position = new Vector2(0,0);
        } else {
            Destroy(this.gameObject);
        }
    }

    public void SelectCharacter() {
        if(Input.GetKeyDown(KeyCode.E)) {
            previousCharacter = currentCharacter;
            i++;
            if(i >= characters.Count) {
                i = 0;
            }
            currentCharacter = characters.ElementAt(i);
             Transition();
            Debug.Log(i);
        }
        if(Input.GetKeyDown(KeyCode.Q)) {
            previousCharacter = currentCharacter;
            i--;
            if(i < 0) {
                i = characters.Count -1;
            }
            currentCharacter = characters.ElementAt(i);
             Transition();
            Debug.Log(i);
            

        }
        if(Input.GetKeyDown(KeyCode.Space)) {
            Debug.Log(characters.ElementAt(i).sprite.ToString());
            characters.ElementAt(i).sprite = player.spR.sprite;
            characters.ElementAt(i).sprite = player.sprite;
            foreach(Character_UI character in characters) {
                Destroy(character.gameObject);
            }
            Destroy(this.gameObject);
        }
        
    }
    public void Transition() {
        //if (character changed)
            // currentCharacter.transform.position = new Vector2(3,600);
            currentCharacter.gameObject.SetActive(true);
            // currentCharacter.anim.SetTrigger("Drop");
            // previousCharacter.anim.SetTrigger("Explode");
            previousCharacter.gameObject.SetActive(false);
            // currentCharacter.transform.position = Vector2.zero; 
            // Animation.Play();
            
    }

}
