using UnityEngine;
using UnityEngine.UI;

public class ScreenRoomList : MonoBehaviour
{
    public GameObject WorldHost;
    public Button JoinPrivateRoomButton;
    public Button LobbyEntryPrefab;
    public GameObject RoomListList;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
        JoinPrivateRoomButton.onClick.AddListener(() =>
        {
            WorldHost.GetComponent<WorldHost>().EnableOverlay(WorldOverlay.JOIN_ROOM);
        });
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
