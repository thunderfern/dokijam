using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Alteruna.Trinity;

public class ScreenCreateRoom : MonoBehaviour
{
    public GameObject WorldHost;
    public Button CreateButton;
    public TMP_Dropdown ModeDropdown;

    private Alteruna.Multiplayer multiplayer;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        multiplayer = GameObject.FindGameObjectWithTag("NetworkManager").GetComponent<Alteruna.Multiplayer>();

        CreateButton.onClick.AddListener(() =>
        {
            multiplayer.CreateRoom();
            GameObject.FindGameObjectWithTag("NetworkManager").GetComponent<Alteruna.Spawner>().Spawn(0);
            WorldHost.GetComponent<WorldHost>().ChangeScreen(WorldScreen.GAMEPLAY);
        });
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
