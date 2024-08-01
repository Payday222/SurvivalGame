using UnityEngine;

public class player : MonoBehaviour, IDataPersistence
{
    //TODO:
    //2.Health dies are chosen upon character selection
    
    private Vector2 direction;

public Inventory inventory;
public GameObject SwordSwing;
public int maxHealth;
public int currentHealth;
public HealthBar healthbar;
public SoulsBar soulsBar;
public CardsInventory cardinv;
public int counter = 0;
public enum Dice {
        d4,
        d6,
        d8,
        d10,
        d12,
        d20,
}
public Dice dice;

public int speed =  1;
public SpriteRenderer spR;
public Sprite sprite;
public int soulsCount;
void Start()
{   


if(counter == 0) {
        this.currentHealth = 5 * Random.Range(1, 7);
        counter++;
}
    healthbar.SetHealth();    
    soulsBar.SetSouls();

}
#region Data
public void LoadData(GameData data) {
    this.currentHealth = data.playerHealth; 
    this.transform.position = data.playerPosition;
    Debug.Log("playerhp" + currentHealth);
    counter = data.playerHealthSetCounter;
    this.sprite = data.playerSprite;
}

public void SaveData(ref GameData data) {
    data.playerHealth = this.currentHealth;
    data.playerPosition = this.transform.position;
    data.playerHealthSetCounter = counter;
    data.playerSprite = this.sprite;
    Debug.Log("saved player hp");
}


#endregion Data
void Update()
{
    // spR.sprite = sprite;
    Movement();
    Vector2 distance = new Vector2 (this.transform.position.x + 5, this.transform.position.y + 10);
}

void OnTriggerEnter2D(Collider2D other)
{
    
    if(other.gameObject.tag == "Enemy") {
      other.gameObject.GetComponent<enemy>().RollDamageDie();
      currentHealth -= other.gameObject.GetComponent<enemy>().damage;
        Debug.Log("current health of player" + currentHealth);
      Debug.Log("damage: " + other.gameObject.GetComponent<enemy>().damage);
      // testing testing, attention please: check
        healthbar.SetHealth();
      if(currentHealth <= 0) {
        Destroy(this.gameObject);
      }
    }
}
public void Movement() {
        if(Input.GetKey(KeyCode.W)) {
        direction = Vector2.up * speed;
    } else if(Input.GetKey(KeyCode.A)) {
        direction = Vector2.left * speed;
} else if(Input.GetKey(KeyCode.S)) {
    direction = Vector2.down * speed;
} else if(Input.GetKey(KeyCode.D)){
    direction = Vector2.right * speed;
} 
if(Input.GetKeyUp(KeyCode.W) || (Input.GetKeyUp(KeyCode.UpArrow)) 
|| Input.GetKeyUp(KeyCode.A) || (Input.GetKeyUp(KeyCode.LeftArrow))
|| Input.GetKeyUp(KeyCode.S) || Input.GetKeyUp(KeyCode.DownArrow)
|| Input.GetKeyUp(KeyCode.D) || Input.GetKeyUp(KeyCode.RightArrow)) {
    direction = Vector2.zero;
}
}
void FixedUpdate()
{
    #region movement
    transform.position = new Vector2(
        transform.position.x + direction.x,
        transform.position.y + direction.y
    );
    #endregion movement
}
private void Awake()
{
    cardinv = new CardsInventory(5);
    inventory = new Inventory(24);
}

public void DropItem(item item) {
    Vector2 spawnlocation = transform.position;

    Vector2 spawnOffset = UnityEngine.Random.insideUnitCircle * 1.25f;

    item droppedItem = Instantiate(item, spawnlocation + spawnOffset, Quaternion.identity);
    droppedItem.rb.AddForce(spawnOffset * 2f, ForceMode2D.Impulse);
 }
public bool CheckForSword() {
    for(int i = this.inventory.slots.Count - 1; i >= 0; i--) {
        if(this.inventory.slots[i].itemname == "Sword") {
        Debug.Log("Player has a sword in their inventory, execute attack");
            return true;
        }
    }
    return false;
} // checking: works

}

