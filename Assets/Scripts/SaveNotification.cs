using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SaveNotification : MonoBehaviour
{
    public Text NotifText;

    // Start is called before the first frame update
    void Start()
    {
#if PLATFORM_ANDROID && !UNITY_EDITOR
        NotifText.text = "Data Saved to" + "\n" + "Headset Storage.";
#elif UNITY_EDITOR
        NotifText.text = "Data Saved to" + "\n" + "Desktop.";
#endif
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
