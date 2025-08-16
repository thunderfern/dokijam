using UnityEngine;
using UnityEngine.UI;

public class ScreenMenu : MonoBehaviour
{
    public GameObject WorldHost;
    public Button CreateRoomButton;
    public Button JoinRoomButton;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        CreateRoomButton.onClick.AddListener(() =>
        {
            GameObject.FindGameObjectWithTag("SoundManager").GetComponent<SoundManager>().PlaySound(AudioName.Click);
            WorldHost.GetComponent<WorldHost>().ChangeScreen(WorldScreen.CREATE_ROOM);
        });
        
        JoinRoomButton.onClick.AddListener(() => {
            GameObject.FindGameObjectWithTag("SoundManager").GetComponent<SoundManager>().PlaySound(AudioName.Click);
            WorldHost.GetComponent<WorldHost>().ChangeScreen(WorldScreen.ROOM_LIST);
        });
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
