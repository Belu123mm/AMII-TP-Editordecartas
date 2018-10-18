using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(BaseCard))]
public class CardCustomEditor : Editor {

    public BaseCard card;
    public void OnEnable() {
        card = (BaseCard) target;
    }
    public override void OnInspectorGUI() {
        CardName();
        Images();
        Stats();
        Description();
        //Como agregar iconos?
    }

    void CardName() {
        EditorGUILayout.BeginHorizontal();
        EditorGUILayout.LabelField("Nombre", GUILayout.Width(60));
        card.cardname = EditorGUILayout.TextField(card.cardname);
        EditorGUILayout.EndHorizontal();
    }
    void Images() {
        EditorGUILayout.BeginHorizontal();
        EditorGUILayout.BeginVertical();
        EditorGUILayout.LabelField("Marco", GUILayout.Width(80));
        card.frame = (Texture2D) EditorGUILayout.ObjectField(card.frame, typeof(Texture2D), true);
        Texture2D framepreview = AssetPreview.GetAssetPreview(card.frame);
        GUILayout.Box(framepreview, GUILayout.Width(90), GUILayout.Height(140));
        EditorGUILayout.EndVertical();
        EditorGUILayout.BeginVertical();
        EditorGUILayout.LabelField("Fondo", GUILayout.Width(80));
        card.background = (Texture2D) EditorGUILayout.ObjectField(card.background, typeof(Texture2D), true);
        Texture2D backgroundpreview = AssetPreview.GetAssetPreview(card.background);
        GUILayout.Box(backgroundpreview, GUILayout.Width(90), GUILayout.Height(140));
        EditorGUILayout.EndVertical();
        EditorGUILayout.EndHorizontal();

        EditorGUILayout.BeginHorizontal();
        EditorGUILayout.BeginVertical();
        EditorGUILayout.LabelField("Ilustracion", GUILayout.Width(80));
        card.illustration = (Texture2D) EditorGUILayout.ObjectField(card.illustration, typeof(Texture2D), true);
        Texture2D illustrationpreview = AssetPreview.GetAssetPreview(card.illustration);
        GUILayout.Box(illustrationpreview, GUILayout.Width(90), GUILayout.Height(140));
        EditorGUILayout.EndVertical();
        EditorGUILayout.BeginVertical();
        EditorGUILayout.LabelField("Reverso", GUILayout.Width(80));
        card.back = (Texture2D) EditorGUILayout.ObjectField(card.back, typeof(Texture2D), true);
        Texture2D backpreview = AssetPreview.GetAssetPreview(card.back);
        GUILayout.Box(backpreview, GUILayout.Width(90), GUILayout.Height(140));
        EditorGUILayout.EndVertical();
        EditorGUILayout.EndHorizontal();
        Repaint();
    }
    void Stats() {
        EditorGUILayout.BeginHorizontal();
        EditorGUILayout.LabelField("Vida", GUILayout.Width(60));
        card.life = EditorGUILayout.IntField(card.life);
        EditorGUILayout.LabelField("Costo", GUILayout.Width(60));
        card.cost = EditorGUILayout.IntField(card.cost);
        EditorGUILayout.EndHorizontal();


        EditorGUILayout.BeginHorizontal();
        EditorGUILayout.LabelField("Energia", GUILayout.Width(60));
        card.energy = EditorGUILayout.IntField(card.energy);
        EditorGUILayout.LabelField("Mana", GUILayout.Width(60));
        card.mana = EditorGUILayout.IntField(card.mana);
        EditorGUILayout.EndHorizontal();

        EditorGUILayout.BeginHorizontal();
        EditorGUILayout.LabelField("Ataque", GUILayout.Width(60));
        card.attack = EditorGUILayout.IntField(card.attack);
        EditorGUILayout.LabelField("Defensa", GUILayout.Width(60));
        card.defense = EditorGUILayout.IntField(card.defense);
        EditorGUILayout.EndHorizontal();

        EditorGUILayout.BeginHorizontal();
        EditorGUILayout.LabelField("Estrellas", GUILayout.Width(60));
        card.stars = EditorGUILayout.IntField(card.stars);
        EditorGUILayout.EndHorizontal();

        EditorGUILayout.BeginHorizontal();
        EditorGUILayout.LabelField("Tipo", GUILayout.Width(60));
        card.cardtype = EditorGUILayout.TextField(card.cardtype);
        EditorGUILayout.EndHorizontal();

    }

    void Description() {
        EditorGUILayout.LabelField("Descripcion", GUILayout.Width(80));
        card.description = EditorGUILayout.TextArea(card.description,GUILayout.Height(60));

        EditorGUILayout.LabelField("Habilidad", GUILayout.Width(80));
        card.ability = EditorGUILayout.TextArea(card.ability, GUILayout.Height(60));

        EditorGUILayout.BeginHorizontal();
        EditorGUILayout.LabelField("Firma", GUILayout.Width(60));
        card.autorSign = EditorGUILayout.TextField(card.autorSign);
        EditorGUILayout.EndHorizontal();

    }

}
