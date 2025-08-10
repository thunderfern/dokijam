using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;
using TMPro;
using Alteruna.Trinity;

public class OverlayJoinRoom : MonoBehaviour
{
    public GameObject WorldHost;
    public Button JoinButton;
    public Button ExitButton;
    public TMP_InputField RoomCodeInput;
    private Alteruna.Multiplayer multiplayer;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        multiplayer = GameObject.FindGameObjectWithTag("NetworkManager").GetComponent<Alteruna.Multiplayer>();
        JoinButton.onClick.AddListener(() =>
        {
            if (multiplayer != null && multiplayer.IsConnected)
            {
                foreach (var room in multiplayer.AvailableRooms)
                {
                    if (room.Name.ToLower() == RoomCodeInput.text)
                    {
                        room.Join();
                        WorldHost.GetComponent<WorldHost>().ChangeScreen(WorldScreen.GAMEPLAY);
                        WorldHost.GetComponent<WorldHost>().DisableOverlay(WorldOverlay.JOIN_ROOM);
                    }
                }
            }
        });

        ExitButton.onClick.AddListener(() =>
        {
            WorldHost.GetComponent<WorldHost>().DisableOverlay(WorldOverlay.JOIN_ROOM);
        });
    }

    // Update is called once per frame
    void Update()
    {

    }
}
