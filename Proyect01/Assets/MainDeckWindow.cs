using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class MainDeckWindow : EditorWindow {

    private GUIStyle _tittleStyle;
    private int newWindowAmount;


    [MenuItem("CustomTools/MyDeckBuilder")]
    public static void OpenWindow()
    {
        MainDeckWindow myWindow = (MainDeckWindow)GetWindow(typeof(MainDeckWindow));
        myWindow.wantsMouseMove = true;
        myWindow.Show();
    }

    private void OnEnable()
    {
        _tittleStyle = new GUIStyle();
        _tittleStyle.fontStyle = FontStyle.BoldAndItalic;
        _tittleStyle.alignment = TextAnchor.MiddleCenter;
        _tittleStyle.fontSize = 20;
        _tittleStyle.normal.textColor = Color.black;



    }

    private void OnGUI()
    {
        EditorGUILayout.Space();
        EditorGUILayout.Space();
        EditorGUI.DrawRect(GUILayoutUtility.GetRect(100, 2), Color.black);
        EditorGUILayout.Space();
        EditorGUI.DrawRect(GUILayoutUtility.GetRect(100, 2), Color.black);
        EditorGUILayout.Space();

        DrawTittle();
        EditorGUILayout.Space();
        EditorGUILayout.Space();

        DrawText();

        EditorGUILayout.Space();
        EditorGUILayout.Space();
        EditorGUI.DrawRect(GUILayoutUtility.GetRect(100, 2), Color.black);
        EditorGUILayout.Space();
        EditorGUI.DrawRect(GUILayoutUtility.GetRect(100, 2), Color.black);
        EditorGUILayout.Space();

       

    }

    private void DrawTittle()
    {
        EditorGUILayout.LabelField("My Deck Builder", _tittleStyle);
    }

    private void DrawText()
    {
        GUILayout.Label("Bienvenido a My Deck Builder, con esta ventana principal podras comenzar a crear tu maso de cartas deseado.");
    }

}
