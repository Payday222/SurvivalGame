using UnityEngine;
using UnityEngine.UI;

public class Character_UI : MonoBehaviour
{
// private Sprite icon;
public Image image;
public string characterName;

void Start()
{
    image = GetComponent<Image>();
}
}
