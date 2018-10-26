﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System;

public class TableCreator : EditorWindow
{

    public string Name;
    public float WidthSize;
    public float LongSize;
    public Texture2D Design;
    public Material Material;
    public string Filter = "";
    List<string> found = new List<string>();


    public static void OpenWindow(int times)
    {
        var Table = (TableCreator)GetWindow(typeof(TableCreator));
    }

    public void UpdateDatabase()
    {
        AssetDatabase.Refresh();
    }    

    private void OnEnable()
    {
        minSize = new Vector2(550, 350);
        maxSize = new Vector2(550 ,8000);
    }

    private void OnGUI()
    {
        NameField();
        EditorGUILayout.Space();
        EditorGUILayout.Space();
        EditorGUILayout.Space();
        EditorGUILayout.Space();
        EditorGUILayout.Space();

        SizeFields();
        EditorGUILayout.Space();
        EditorGUILayout.Space();
        EditorGUILayout.Space();

        TextureField();
        EditorGUILayout.Space();
        EditorGUILayout.Space();
        EditorGUILayout.Space();

        CreateButton();
    }

    private void NameField()
    {
        GUILayout.BeginHorizontal();
        Name = EditorGUILayout.TextField("Nombre:", Name);
        GUILayout.EndHorizontal();
        if (Name == null)
        {
            EditorGUILayout.HelpBox("El Plano creado debe tener un nombre", MessageType.Warning);
        }
        //TODO cuando borras el nombre deberia volver a aparecer el warning pero este no reaparece

        Repaint();
    }

    private void SizeFields()
    {
        GUILayout.BeginHorizontal();

        WidthSize = EditorGUILayout.FloatField("Ancho", WidthSize, GUILayout.ExpandWidth(false));
        EditorGUILayout.Space();
        EditorGUILayout.Space();
        LongSize = EditorGUILayout.FloatField("Largo", LongSize, GUILayout.ExpandWidth(false));

        GUILayout.EndHorizontal();

        if (WidthSize == 0 || LongSize == 0)
        {
            EditorGUILayout.HelpBox("Las medidas de Ancho y Largo no pueden valer 0.", MessageType.Warning);
        }
    }

    private void TextureField()
    {
        GUILayout.BeginHorizontal();
        Design = (Texture2D)EditorGUILayout.ObjectField("Diseño:", Design, typeof(Texture2D), true);
        Material = (Material)EditorGUILayout.ObjectField(Material, typeof(Material), true);
        GUILayout.EndHorizontal();
        SearchField();


        if (Design != null && Material != null)
        {
            EditorGUILayout.HelpBox("El objeto no puede tener una textura y un material al mismo tiempo", MessageType.Warning);
        }
        if (Design == null && Material == null)
        {
            EditorGUILayout.HelpBox("El objeto debe tener o una textura o un material", MessageType.Warning);
        }
    }

    private void SearchField()
    {
        UpdateDatabase();
        var prevFilter = Filter;
        Filter = EditorGUILayout.TextField("Buscador", Filter);
        if (Filter != prevFilter)
        {
            found.Clear();
            string[] routes = AssetDatabase.FindAssets(Filter);
            string realPath = AssetDatabase.GUIDToAssetPath(routes[0]);
            for (int i = 0; i < routes.Length; i++)
            {
                found.Add(AssetDatabase.GUIDToAssetPath(routes[i]));
            }
        }

        for (int i = 0; i < found.Count; i++)
        {
            EditorGUILayout.BeginHorizontal();
            EditorGUILayout.LabelField(found[i]);

            if (GUILayout.Button("Seleccionar"))
            {
                AssetDatabase.OpenAsset(AssetDatabase.LoadAssetAtPath(found[i],typeof(Material)));
                AssetDatabase.OpenAsset(AssetDatabase.LoadAssetAtPath(found[i], typeof(Texture2D)));
                
            }
            EditorGUILayout.EndHorizontal();
        }



    }

    private void CreateButton()
    {
        if (Name != null && WidthSize != 0 && LongSize != 0 && ((Design != null && Material == null) || (Design == null && Material != null))) 
        {          
            if (GUILayout.Button("Create", GUILayout.MaxWidth(500), GUILayout.ExpandWidth(false)))
            {
                if (Name != null && WidthSize != 0 && LongSize != 0 && ((Design != null && Material == null) || (Design == null && Material != null)))
                {
                    GameObject plane = GameObject.CreatePrimitive(PrimitiveType.Plane);
                    plane.transform.localScale = new Vector3(WidthSize, 1, LongSize);
                    plane.name = Name;

                    if (Design != null)
                    {
                        plane.GetComponent<MeshRenderer>().sharedMaterial.SetTexture("_MainTex", Design);
                    }

                    if (Material != null)
                    {
                        plane.GetComponent<MeshRenderer>().material = Material;
                    }
                }
                
            }
            Repaint();
        }
    }
}