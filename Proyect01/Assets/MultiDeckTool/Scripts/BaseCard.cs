﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

[ExecuteInEditMode]
public class BaseCard : MonoBehaviour {

    public CardSO card;
    public TextMeshPro title;
    public TextMeshPro description;
    public TextMeshPro ability;

    public MeshRenderer frame;
    public MeshRenderer illustration;
    public MeshRenderer back;
    public MeshRenderer icon;

    public List<Material> materials;
    public Shader sh;

    public void Start() {
            materials.Clear();
        if ( card ) {

            title.text = card.cardname;
            description.text = card.description;
            ability.text = card.ability;

            Material frameMaterial = new Material(sh);
            frameMaterial.mainTexture = card.frame;
            materials.Add(frameMaterial);
            frame.GetComponent<Renderer>().material = frameMaterial;
            //yea
            Material illustrationMaterial = new Material(sh);
            illustrationMaterial.mainTexture = card.illustration;
            materials.Add(illustrationMaterial);
            illustration.GetComponent<Renderer>().material = illustrationMaterial;

            Material backMaterial = new Material(sh);
            backMaterial.mainTexture = card.back;
            materials.Add(backMaterial);
            back.GetComponent<Renderer>().material = backMaterial;

            Material iconMaterial = new Material(sh);
            iconMaterial.mainTexture = card.icon;
            materials.Add(iconMaterial);
            icon.GetComponent<Renderer>().material = iconMaterial;
        }

    }
}
