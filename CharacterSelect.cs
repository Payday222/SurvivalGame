using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class CharacterSelect : MonoBehaviour
{
    public List<Sprite> CharacterSprites = new List<Sprite>(); 
    public List<Character_UI> characters = new List<Character_UI>();  

    public Character_UI currentCharacter;
        public int li = 0; //list index

    void Start()
    {
        this.gameObject.SetActive(false);
        for(int i = characters.Count; i > 1; i--) {
            characters[i].gameObject.SetActive(false); // hide all characters except first one
        }
    }
    public void ShowCharacterSelect() {
        this.gameObject.SetActive(true);
    }
    void Update() {
        while(this.gameObject.activeSelf) {
            SelectCharacter();
        }
    }

    public void SelectCharacter() {
        currentCharacter = characters.ElementAt(li); //! this is probs the valid way to go about this
        currentCharacter.image.sprite = CharacterSprites.ElementAt(li);
        if(this.gameObject.activeSelf) {
    if(Input.GetKey(KeyCode.RightArrow)) {
        if(li < CharacterSprites.Count) {
        currentCharacter.gameObject.SetActive(false);
        li++;
        ShowSelectedCharacter();
        }
    }
    if(Input.GetKeyDown(KeyCode.LeftArrow)) {
        if(li != 0) {
        currentCharacter.gameObject.SetActive(false);
        li--;
        ShowSelectedCharacter();
        }
        
    }
        }
    }

public void ShowSelectedCharacter() {
    if(currentCharacter != null) {
        currentCharacter.transform.position = new Vector2(0,0);
    // currentCharacter.image.sprite = CharacterSprites.ElementAt(li);        
    }
}

    

    
}
