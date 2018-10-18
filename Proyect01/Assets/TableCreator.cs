using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class TableCreator : EditorWindow {

    public int WidthSize;
    public int LongSize;
    public Texture2D Design;


    public static void OpenWindow(int times)
    {
        var Table = (TableCreator)GetWindow(typeof(TableCreator));
    }

    private void OnEnable()
    {
        
    }

    private void OnGUI()
    {
        SizeFields();
        TextureField();
        CreateButton();

    }

    private void SizeFields()
    {
        GUILayout.BeginHorizontal();

        WidthSize = EditorGUILayout.IntField("Ancho",WidthSize);
        LongSize = EditorGUILayout.IntField("Largo", LongSize);

        GUILayout.EndHorizontal();
    }

    private void TextureField()
    {
        Design = (Texture2D)EditorGUILayout.ObjectField("Diseño: ", Design, typeof(Texture2D), true);
    }

    private void CreateButton()
    {
        if (GUILayout.Button("Create", GUILayout.MaxWidth(500), GUILayout.ExpandWidth(false)))
        {
            GameObject plane = GameObject.CreatePrimitive(PrimitiveType.Plane);
            plane.transform.localScale = new Vector3(WidthSize, 1, LongSize);
            plane.GetComponent<MeshRenderer>().material.SetTexture("_MainTex", Design);
        }
        Repaint();
    }



}
