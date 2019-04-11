using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CorridorScript : MonoBehaviour
{
    public bool containPlayer;
    public GameObject Room1;
    public GameObject Room2;
    public Corridor corridor;
    public GameObject Door1;
    public GameObject Door2;
    public BoxCollider2D boxCollider;
    DungeonManagerScript dungeonManager;


    // Start is called before the first frame update
    void Start()
    {
        boxCollider = GetComponent<BoxCollider2D>();
        dungeonManager= Object.FindObjectOfType<DungeonManagerScript>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            dungeonManager.SetCurrentCorridor(this);
            collision.transform.parent = transform;
            containPlayer = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            dungeonManager.SetCurrentCorridor(this);
            collision.transform.parent = transform;
            containPlayer = false;
        }
    }
}
