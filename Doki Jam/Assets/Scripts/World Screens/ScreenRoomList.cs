using UnityEngine;
using UnityEngine.UI;
using Alteruna;
using System.Collections.Generic;

public class ScreenRoomList : MonoBehaviour
{

    public GameObject WorldHost;
    public Multiplayer _multiplayer;

    public Button JoinPrivateRoomButton;
    public GameObject LobbyEntryPrefab;
    public GameObject RoomListList;
    public List<RoomEntry> RoomEntries;
    private float refreshTimer;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

        JoinPrivateRoomButton.onClick.AddListener(() =>
        {
            WorldHost.GetComponent<WorldHost>().EnableOverlay(WorldOverlay.JOIN_ROOM);
        });

        _multiplayer = GameObject.FindGameObjectWithTag("NetworkManager").GetComponent<Multiplayer>();
        RoomEntries = new List<RoomEntry>();
        refreshTimer = 0f;
        UpdateRoomList();
    }

    // Update is called once per frame
    void Update()
    {
        refreshTimer += Time.deltaTime;
        if (refreshTimer >= 5)
        {
            UpdateRoomList();
            refreshTimer = 0f;
        }
    }

    void UpdateRoomList()
    {
        for (int i = 0; i < RoomEntries.Count; i++)
        {
            Destroy(RoomEntries[i].roomObject);
        }
        RoomEntries = new List<RoomEntry>();
        for (int i = 0; i < _multiplayer.AvailableRooms.Count; i++)
        {
            Room room = _multiplayer.AvailableRooms[i];

            if (room.InviteOnly || (room.MaxUsers == room.GetUserCount())) continue;

            RoomEntry createdEntry = new RoomEntry();

            createdEntry.roomRoom = room;
            createdEntry.roomObject = Instantiate(LobbyEntryPrefab, RoomListList.transform);

            createdEntry.roomObject.transform.GetComponentInChildren<Button>().onClick.AddListener(() =>
            {
                createdEntry.roomRoom.Join();
                WorldHost.GetComponent<WorldHost>().ChangeScreen(WorldScreen.GAMEPLAY);
            });

            RoomEntries.Add(createdEntry);

        }
    }

}

public class RoomEntry
{
    public GameObject roomObject;
    public Room roomRoom;
}
