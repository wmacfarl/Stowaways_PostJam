using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomScript : MonoBehaviour
{

    public List<GameObject> AttachedCorridors;
    public List<GameObject> Doors;
    public Room room;
    public BoxCollider2D boxCollider;
    DungeonManagerScript dungeonManager;
    public bool containPlayer;
    MeshFilter meshFilter;
    // Start is called before the first frame update
    void Awake()
    {
        boxCollider = GetComponent<BoxCollider2D>();
        dungeonManager = Object.FindObjectOfType<DungeonManagerScript>();
        meshFilter = GetComponent<MeshFilter>();
    }

    public void setMesh()
    {
        List<Vector3> points = new List<Vector3>();
        Vector3 bottomLeft = boxCollider.bounds.extents * -1;
        Vector3 topRight = boxCollider.bounds.extents;
        bottomLeft = new Vector3(0, 0, 0);
        topRight = boxCollider.bounds.extents * 2;
        Vector3 topLeft = new Vector3(bottomLeft.x, topRight.y, 0);
        Vector3 bottomRight = new Vector3(topRight.x, bottomLeft.y, 0);
        points.Add(bottomLeft);
        points.Add(topRight);
        points.Add(topLeft);
        points.Add(bottomRight);
        //        meshFilter.mesh.Clear();
        for (int i = 0; i < meshFilter.mesh.triangles.Length; i++)
        {
            Debug.Log("tris[" + i + "] = " + meshFilter.mesh.triangles[i]);
        }
        meshFilter.mesh.SetVertices(points);
    }


    // Update is called once per frame
    void Update()
    {
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            dungeonManager.SetCurrentRoom(this);
            collision.transform.parent = transform;
            containPlayer = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            dungeonManager.SetCurrentRoom(this);
            collision.transform.parent = transform;
            containPlayer = false;
        }
    }
}
