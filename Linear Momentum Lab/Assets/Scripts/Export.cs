using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.UI;
using UnityEditor;

public class Export : MonoBehaviour
{
    public float rangeRight;
    public float rangeLeft;
    public GameObject RightAnch;
    public GameObject LeftAnch;

    public bool pushed = false;
    public Renderer rend;

    private float startX;
    private float startY;
    private float startZ;
    private float pushedY;

    public AudioSource pressedsound;
    private float Timer = 0f;
    public GameObject SaveNotification;
    private bool NotificationExists;

    private static string reportDirectoryName = "LinearMomentumLab";
    private static string reportFileName = "LinearMomentumData.csv";
    private static string reportSeparator = ",";
    private static string[] reportHeaders = new string[3]
    {
        "Target",
        "GPM",
        "Force"
    };
    private static string timeStampHeader = "Time Stamp";

    public static void AppendToReport(string[] strings)
    {
        VerifyDirectory();
        VerifyFile();
        using (StreamWriter sw = File.AppendText(GetFilePath()))
        {
            string finalString = "";
            for (int i = 0; i < strings.Length; i++)
            {
                if (finalString != "")
                {
                    finalString += reportSeparator;
                }
                finalString += strings[i];
            }
            finalString += reportSeparator + GetTimeStamp();
            sw.WriteLine(finalString);
        }
    }

    public static void CreateReport()
    {
        VerifyDirectory();
        using (StreamWriter sw = File.CreateText(GetFilePath()))
        {
            string finalString = "";
            for (int i = 0; i < reportHeaders.Length; i++)
            {
                if (finalString != "")
                {
                    finalString += reportSeparator;
                }
                finalString += reportHeaders[i];
            }
            finalString += reportSeparator + timeStampHeader;
            sw.WriteLine(finalString);
        }
    }

    static void VerifyDirectory()
    {
        string dir = GetDirectoryPath();
        if (!Directory.Exists(dir))
        {
            Directory.CreateDirectory(dir);
        }
    }

    static void VerifyFile()
    {
        string file = GetFilePath();
        if (!File.Exists(file))
        {
            CreateReport();
        }
    }

    static string GetDirectoryPath()
    {
#if PLATFORM_ANDROID && !UNITY_EDITOR
        return Application.persistentDataPath + "/../../../../" + reportDirectoryName;
#elif UNITY_EDITOR
        return System.Environment.GetFolderPath(System.Environment.SpecialFolder.Desktop) + "/" + reportDirectoryName;
#endif
    }

    static string GetFilePath()
    {
        return GetDirectoryPath() + "/" + reportFileName;
    }

    static string GetTimeStamp()
    {
        return System.DateTime.Now.ToString();
    }

    // Start is called before the first frame update
    void Start()
    {
        rend = GetComponent<Renderer>();
        startX = this.gameObject.transform.localScale.x;
        startY = this.gameObject.transform.localScale.y;
        startZ = this.gameObject.transform.localScale.z;
        pushedY = (float)0.6 * startY;
        CreateReport();
    }

    // Update is called once per frame
    void Update()
    {
        NotificationExists = (GameObject.FindWithTag("SaveNotif") != null);

        int targetvalue = GameObject.Find("Force Text").GetComponent<ForceReader>().degrees;
        float gpmvalue = GameObject.Find("GPM Text").GetComponent<GPMReader>().gpm;
        double forcevalue = GameObject.Find("Force Text").GetComponent<ForceReader>().forcetext;

        rangeRight = Vector3.Distance(RightAnch.transform.position, this.gameObject.transform.position);
        if (OVRInput.GetDown(OVRInput.Button.Two) && rangeRight <= 0.25)
        {
            pressedsound.Play(0);
            rend.material.color = Color.green;
            this.gameObject.transform.localScale = new Vector3(startX, pushedY, startZ);
            AppendToReport
            (
                new string[3]
                {
                    targetvalue.ToString(),
                    gpmvalue.ToString("0.##"),
                    forcevalue.ToString("0.####")
                }
            );
            if (NotificationExists == false)
            {
                Instantiate(SaveNotification);
                Destroy(GameObject.FindWithTag("SaveNotif"), 1);
            }
        }
        else if (OVRInput.GetUp(OVRInput.Button.Two))
        {
            rend.material.color = new Color(1, 0, 0, 0.75f);
            this.gameObject.transform.localScale = new Vector3(startX, startY, startZ);
        }

        rangeLeft = Vector3.Distance(LeftAnch.transform.position, this.gameObject.transform.position);
        if (OVRInput.GetDown(OVRInput.Button.Four) && rangeLeft <= 0.25)
        {
            pressedsound.Play(0);
            rend.material.color = Color.green;
            this.gameObject.transform.localScale = new Vector3(startX, pushedY, startZ);
            AppendToReport
            (
                new string[3]
                {
                    targetvalue.ToString(),
                    gpmvalue.ToString("0.##"),
                    forcevalue.ToString("0.####")
                }
            );
            if (NotificationExists == false)
            {
                Instantiate(SaveNotification);
                Destroy(GameObject.FindWithTag("SaveNotif"), 1);
            }
        }
        else if (OVRInput.GetUp(OVRInput.Button.Four))
        {
            rend.material.color = new Color(1,0,0,0.75f);
            this.gameObject.transform.localScale = new Vector3(startX, startY, startZ);
        }
    }
}
