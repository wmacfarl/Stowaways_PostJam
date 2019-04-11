using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorScript : MonoBehaviour
{


    public enum DoorType
    {
        EAST_WEST=0,
        NORTH_SOUTH=1
    }
    public DoorType doorType;
    public GameObject Room;
    public GameObject Corridor;

    public Sprite openSprite;
    public Sprite closedSprite;
    SpriteRenderer spriteRenderer;
    public bool IsOpen;
    BoxCollider2D collisionCollider;
    BoxCollider2D triggerCollider;
    DungeonManagerScript dungeonManager;

    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        IsOpen = false;
        BoxCollider2D[] colliders = GetComponents<BoxCollider2D>();
        foreach (BoxCollider2D collider in colliders)
        {
            if (collider.isTrigger)
            {
                triggerCollider = collider;
            }
            else
            {
                collisionCollider = collider;
            }
        }
    }

    private void Awake()
    {
        dungeonManager = Object.FindObjectOfType<DungeonManagerScript>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!IsOpen)
        {
            spriteRenderer.sprite = closedSprite;
            collisionCollider.enabled = true;
        }
        else {
            spriteRenderer.sprite = openSprite;
            collisionCollider.enabled = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            IsOpen = true;
            dungeonManager.SetCurrentCorridor(Corridor.GetComponent<CorridorScript>());
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            IsOpen = false;
            if (Corridor.GetComponent<CorridorScript>().containPlayer == false)
            {
                dungeonManager.SetCurrentCorridor(null);
            }
        }
    }
}
