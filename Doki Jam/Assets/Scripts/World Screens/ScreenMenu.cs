using UnityEngine;
using UnityEngine.UI;

public class ScreenMenu : MonoBehaviour
{
    public GameObject WorldHost;
    public Button PlayButton;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        PlayButton.onClick.AddListener(() => {
            WorldHost.GetComponent<WorldHost>().ChangeScreen(WorldScreen.ROOM_LIST);
        });
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
