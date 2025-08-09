using UnityEngine;
using UnityEngine.UI;

public class ScreenRoomList : MonoBehaviour
{
    public GameObject WorldHost;
    public Button CreateRoomButton;
    public Button JoinPrivateRoomButton;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        CreateRoomButton.onClick.AddListener(() =>
        {
            WorldHost.GetComponent<WorldHost>().ChangeScreen(WorldScreen.CREATE_ROOM);
        });
        
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
