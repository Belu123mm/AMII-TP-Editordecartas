using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class MainTableWindow : EditorWindow {

    private GUIStyle _tittleStyle;
    private int newWindowAmount;


    [MenuItem("CustomTools/MyTableBuilder")]
    public static void OpenWindow()
    {
        MainTableWindow myWindow = (MainTableWindow)GetWindow(typeof(MainTableWindow));
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

        minSize = new Vector2(625, 150);
        maxSize = new Vector2(625, 150);
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

        DrawButtonTableCreator();




    }

    private void DrawTittle()
    {
        EditorGUILayout.LabelField("My Table Builder", _tittleStyle);
    }

    private void DrawText()
    {
        GUILayout.Label("Bienvenido a My Table Builder, con esta ventana principal podras comenzar a crear tu tablero deseado.");
    }

    private void DrawButtonTableCreator()
    {
        if (GUILayout.Button("TableCreator"))
        {

            TableCreator.OpenWindow(newWindowAmount);
            newWindowAmount++;
        }

    }

}
