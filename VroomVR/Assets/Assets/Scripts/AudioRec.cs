using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public class AudioRec : MonoBehaviour {
	AudioClip myAudioClip; 
    public AudioSource UnityChan;
    public AudioClip UnitySpeaks;
    public int filecount;
    
    void Start() {
        filecount = 0;
       Application.runInBackground = true;
     }
     void Update () {
       ReadString();
        AssetDatabase.Refresh();
         
     }
    //[MenuItem("Tools/Read file")]
    void ReadString()
    {
        //Debug.Log(filecount);
        string path = "output" + filecount;
        if (File.Exists("Assets/Resources/" + path + ".mp3") && Resources.Load<AudioClip>(path) != null) 
        {
            filecount++;
            Debug.Log(path);
            //UnityChan.clip = (AudioClip) Resources.Load<AudioClip>(path) as AudioClip;
            AudioClip currClip = Resources.Load<AudioClip>(path);
            Debug.Log((AudioClip)Resources.Load(path, typeof(AudioClip)));
            UnityChan.pitch = 1.3f;
            UnityChan.PlayOneShot(currClip);
            
           // WriteString();
        }
        /*string path = "Assets/text.txt";

        //Read the text from directly from the test.txt file
        StreamReader reader = new StreamReader(path); 
        string val = reader.ReadToEnd();
        Debug.Log(val);
        reader.Close();
        if () {Equals(val, "1")) {
            
            UnityChan.clip = UnitySpeaks;
            UnityChan.pitch = 1.3f;
            UnityChan.Play();
            WriteString();
        }*/
    }
     void WriteString()
    {
        string path = "Assets/text.txt";

        //Write some text to the test.txt file
        StreamWriter writer = new StreamWriter(path, false);
        writer.WriteLine("0");
        Debug.Log("zeroed");
        writer.Close();
    }
    void OnGUI()
    {
         if (GUI.Button(new Rect(10,10,60,50),"Record"))
         { 
             myAudioClip = Microphone.Start ( null, false, 10, 44100 );
             

         }
         if (GUI.Button(new Rect(10,70,60,50),"Save"))
         {
             SavWav.Save("audio", myAudioClip);
            
     //        audio.Play();
        }

    }
}
class HasTalked {
    public char talked;
}
