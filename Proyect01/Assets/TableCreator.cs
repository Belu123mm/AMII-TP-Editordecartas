﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class TableCreator : EditorWindow
{

    public string Name;
    public float WidthSize;
    public float LongSize;
    public Texture2D Design;
    public Material Material;


    public static void OpenWindow(int times)
    {
        var Table = (TableCreator)GetWindow(typeof(TableCreator));
    }

    private void OnEnable()
    {

    }

    private void OnGUI()
    {
        NameField();
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
        Name = EditorGUILayout.TextField("Nombre:", Name);
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
        GUILayout.BeginHorizontal();
        Design = (Texture2D)EditorGUILayout.ObjectField("Diseño:", Design, typeof(Texture2D), true);
        Material = (Material)EditorGUILayout.ObjectField(Material, typeof(Material), true);
        GUILayout.EndHorizontal();
    }

    private void CreateButton()
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

        if (Name == null)
        {
            EditorGUILayout.HelpBox("El Plano creado debe tener un nombre", MessageType.Warning);
            
        }

        if (WidthSize == 0 || LongSize == 0)
        {
            EditorGUILayout.HelpBox("Las medidas de Ancho y Largo no pueden valer 0.", MessageType.Warning);
            
        }
        
        if (Design != null && Material != null)
        {
            EditorGUILayout.HelpBox("El objeto no puede tener una textura y un material al mismo tiempo", MessageType.Warning);
            
        }
        if (Design == null && Material == null)
        {
            EditorGUILayout.HelpBox("El objeto debe tener o una textura o un material", MessageType.Warning);
            
        }
        Repaint();
    }



}