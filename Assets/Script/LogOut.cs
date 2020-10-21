using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LogOut : MonoBehaviour
{
    // Start is called before the first frame update
     public void Quit()
     {
         #if UNITY_EDITOR
         UnityEditor.EditorApplication.isPlaying = false;
         #elif UNITY_WEBPLAYER
         Application.OpenURL(webplayerQuitURL);
         #else
         Application.Quit();
         #endif
     }
}
