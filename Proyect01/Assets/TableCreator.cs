using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class TableCreator : EditorWindow
{

    public float WidthSize;
    public float LongSize;
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

        WidthSize = EditorGUILayout.FloatField("Ancho", WidthSize,GUILayout.ExpandWidth(false));
        EditorGUILayout.Space();
        EditorGUILayout.Space();

        LongSize = EditorGUILayout.FloatField("Largo", LongSize, GUILayout.ExpandWidth(false));

        GUILayout.EndHorizontal();
    }

    private void TextureField()
    {
        Design = (Texture2D)EditorGUILayout.ObjectField("Diseño:", Design, typeof(Texture2D), true);
    }

    private void CreateButton()
    {
        if (GUILayout.Button("Create", GUILayout.MaxWidth(500), GUILayout.ExpandWidth(false)))
        {
            GameObject plane = GameObject.CreatePrimitive(PrimitiveType.Plane);
            plane.transform.localScale = new Vector3(WidthSize, 1, LongSize);
            if (Design != null)
            {
                plane.GetComponent<MeshRenderer>().material.SetTexture("_MainTex", Design);
            }

        }
        Repaint();
    }



}
