using UnityEngine;
using System.Collections.Generic;

public enum WorldScreen
{
    MENU,
    ROOM_LIST,
    CREATE_ROOM,
    GAMEPLAY
}

public enum WorldOverlay
{
    JOIN_ROOM,
    SETTINGS
}

public class WorldHost : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    public List<GameObject> worldScreens;
    public List<GameObject> worldOverlays;

    private WorldScreen currentScreen;

    void Start()
    {
        foreach (GameObject ws in worldScreens)
        {
            ws.SetActive(false);
        }
        foreach (GameObject wo in worldOverlays)
        {
            wo.SetActive(false);
        }
        currentScreen = WorldScreen.MENU;
        ChangeScreen(WorldScreen.MENU);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void ChangeScreen(WorldScreen worldScreen)
    {
        worldScreens[(int)currentScreen].SetActive(false);
        worldScreens[(int)worldScreen].SetActive(true);
        currentScreen = worldScreen;
    }

    public void EnableOverlay(WorldOverlay worldOverlay)
    {
        worldOverlays[(int)worldOverlay].SetActive(true);
    }

    public void DisableOverlay(WorldOverlay worldOverlay)
    {
        worldOverlays[(int)worldOverlay].SetActive(false);
    }
}
