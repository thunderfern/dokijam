using UnityEngine;
using TMPro;

public class PlayerMovement : MonoBehaviour
{

    private Alteruna.Avatar _avatar;
    public TMP_Text nametag;
    public TMP_Text nameInput;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _avatar = GetComponent<Alteruna.Avatar>();

        if (!_avatar.IsMe) return;

        Canvas playerCanvas = GameObject.FindWithTag("PlayerCanvas").GetComponent<Canvas>();
        TMP_Text nameInput = GameObject.FindWithTag("NameInput").GetComponent<TMP_Text>();

        playerCanvas.worldCamera = Camera.main;
        nametag.text = nameInput.text;
    }

    // Update is called once per frame
    void Update()
    {
        if (!_avatar.IsMe) return;
        if (Input.GetKeyDown(KeyCode.A))
        {
            transform.position = transform.position + new Vector3(0, 0.1f, 0);
        }
    }
}
