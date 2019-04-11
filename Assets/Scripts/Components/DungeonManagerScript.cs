using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class DungeonManagerScript : MonoBehaviour
{

    public RoomScript CurrentRoomScript;
    public CorridorScript CurrentCorridorScript;

    public List<GameObject> DungeonFloorGameObjects;
    public GameObject PlayerGameObject;

    private void Awake()
    {
        DungeonFloorGameObjects = new List<GameObject>();
    }

    public void SetCurrentRoom(RoomScript roomScript)
    {
        CurrentRoomScript = roomScript;
    }

    public void SetCurrentCorridor(CorridorScript corridorScript)
    {
        CurrentCorridorScript = corridorScript;
    }

}
