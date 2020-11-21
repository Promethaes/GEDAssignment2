using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.InteropServices;
public class UserMetricsLoggerScript : MonoBehaviour
{
    #region DLLStuff

    const string dllName = "UserMetricsLogger";

    [StructLayout(LayoutKind.Sequential)]
    public struct String
    {
        [MarshalAs(UnmanagedType.LPStr)]
        public string data;
        public String(string s)
        {
            data = s;
        }
    }

    [DllImport(dllName)]
    public static extern void WriteUserMetricsToFile();
    [DllImport(dllName)]
    public static extern void SetDefaultWritePath(String str);

    [DllImport(dllName)]
    public static extern void AddButtonPress(String str);

    public void csAddButtonPress(string str)
    {
        AddButtonPress(new String(str));
    }

    public void csWriteUserMetricsToFile()
    {
        WriteUserMetricsToFile();
    }
    #endregion

    // Start is called before the first frame update
    void Start()
    {
        SetDefaultWritePath(new String("./Assets/Plugins/"));
        DontDestroyOnLoad(gameObject);
    }

    float timer = 1.0f;
    // Update is called once per frame
    void Update()
    {
        //timer -= Time.deltaTime;
        //if(timer <= 0.0f){
        //    timer = 1.0f;
        //    csLogCheckpointTime(Time.time);
        //    csLogDeath(new Death("Memes",Time.time,1));
        //    csWriteUserMetricsToFile();
        //}
    }
    private void OnDestroy()
    {
        WriteUserMetricsToFile();
    }
}
