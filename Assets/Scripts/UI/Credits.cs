﻿using UnityEngine;
using System.Collections;
 
public class Credits : MonoBehaviour
{
    public string[] intro;
    public float off;
    public float speed = 100;
    public GUIStyle font;
 
    public void OnGUI()
    {
        off -= Time.deltaTime * speed;
        for (int i = 0; i < intro.Length; i++)
        {
            float roff = (intro.Length*+28) - (i*20 - off);
            float alph = Mathf.Sin((roff/Screen.height)*180*Mathf.Deg2Rad);
            GUI.color = new Color(1,1,1,alph);
            GUI.Label(new Rect(0,roff,Screen.width, 100),intro[i],font);
            GUI.color = new Color(1,1,1,1);
        }
	Start();
    }
    
    IEnumerator Start ()
    {
       	yield return new WaitForSeconds (31);
   	Application.LoadLevel ("StartScreen");
    }
 
}
