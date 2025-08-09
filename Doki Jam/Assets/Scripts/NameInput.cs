using UnityEngine;
using System.Collections.Generic;
using TMPro;

public class InputText : MonoBehaviour {
    private string currentName;
    public TMP_Text textObject;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        textObject.text = textObject.text.Remove(textObject.text.Length - 1);
        for (int i = (int)KeyCode.A; i <= (int)KeyCode.Z; i++)
        {
            if (Input.GetKeyDown((KeyCode)i))
            {
                Debug.Log((KeyCode)i);
                if (textObject.text.Length < 20)
                {
                    if (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift)) textObject.text += (char)(i - (int)('a' - 'A'));
                    else textObject.text += (char)i;
                }
            }
        }
        if (Input.GetKeyDown(KeyCode.Backspace))
        {
            if (textObject.text.Length > 0)
            {
                textObject.text = textObject.text.Remove(textObject.text.Length - 1);
            }
        }
        textObject.text += '|';
    }
}
