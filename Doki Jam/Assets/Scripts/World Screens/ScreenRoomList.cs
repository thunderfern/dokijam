using UnityEngine;
using UnityEngine.UI;
using Alteruna;
using System.Collections.Generic;
using TMPro;

public class ScreenRoomList : MonoBehaviour
{

    public GameObject WorldHost;
    public Multiplayer _multiplayer;

    public Button LobbyEntryPrefab;
    public GameObject RoomListList;
    public List<RoomEntry> RoomEntries;
    private float refreshTimer;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

        _multiplayer = GameObject.FindGameObjectWithTag("NetworkManager").GetComponent<Multiplayer>();
        RoomEntries = new List<RoomEntry>();
        refreshTimer = 0f;
        UpdateRoomList();
    }

    // Update is called once per frame
    void Update()
    {
        if (!_multiplayer) _multiplayer = GameObject.FindGameObjectWithTag("NetworkManager").GetComponent<Multiplayer>();

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
            Destroy(RoomEntries[i].roomObject.gameObject);
        }
        RoomEntries = new List<RoomEntry>();
        float addAmount = 0f;
        for (int i = 0; i < _multiplayer.AvailableRooms.Count; i++)
        {
            Room room = _multiplayer.AvailableRooms[i];

            if (room.InviteOnly || (room.MaxUsers == room.GetUserCount())) continue;

            RoomEntry createdEntry = new RoomEntry();

            createdEntry.roomRoom = room;
            createdEntry.roomObject = Instantiate(LobbyEntryPrefab, RoomListList.transform);

            createdEntry.roomObject.GetComponentInChildren<TMP_Text>().text = room.Name;

            createdEntry.roomObject.transform.position = createdEntry.roomObject.transform.position + new Vector3(0f, addAmount, 0f);
            addAmount += 70f;

            createdEntry.roomObject.onClick.AddListener(() =>
            {
                GameObject.FindGameObjectWithTag("SoundManager").GetComponent<SoundManager>().PlaySound(AudioName.Click);
                createdEntry.roomRoom.Join();
                WorldHost.GetComponent<WorldHost>().ChangeScreen(WorldScreen.GAMEPLAY);
            });

            RoomEntries.Add(createdEntry);

        }
    }

}

public class RoomEntry
{
    public Button roomObject;
    public Room roomRoom;
}
