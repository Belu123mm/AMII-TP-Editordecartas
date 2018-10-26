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
        base.OnInspectorGUI();
        CardName();
        Images();
        Stats();
        Description();
        //Como agregar iconos?
    }

    void CardName() {
        EditorGUILayout.BeginHorizontal();
        EditorGUILayout.LabelField("Nombre", GUILayout.Width(60));
        card.card.cardname = EditorGUILayout.TextField(card.card.cardname);
        EditorGUILayout.EndHorizontal();
    }
    void Images() {
        EditorGUILayout.BeginHorizontal();
        EditorGUILayout.BeginVertical();
        EditorGUILayout.LabelField("Marco", GUILayout.Width(80));
        card.card.frame = (Texture) EditorGUILayout.ObjectField(card.card.frame, typeof(Texture), true);
        Texture2D framepreview = AssetPreview.GetAssetPreview(card.card.frame);
        GUILayout.Box(framepreview, GUILayout.Width(90), GUILayout.Height(140));
        EditorGUILayout.EndVertical();
        EditorGUILayout.BeginVertical();
        EditorGUILayout.LabelField("Fondo", GUILayout.Width(80));
        card.card.background = (Texture) EditorGUILayout.ObjectField(card.card.background, typeof(Texture), true);
        Texture2D backgroundpreview = AssetPreview.GetAssetPreview(card.card.background);
        GUILayout.Box(backgroundpreview, GUILayout.Width(90), GUILayout.Height(140));
        EditorGUILayout.EndVertical();
        EditorGUILayout.EndHorizontal();

        EditorGUILayout.BeginHorizontal();
        EditorGUILayout.BeginVertical();
        EditorGUILayout.LabelField("Ilustracion", GUILayout.Width(80));
        card.card.illustration = (Texture) EditorGUILayout.ObjectField(card.card.illustration, typeof(Texture), true);
        Texture2D illustrationpreview = AssetPreview.GetAssetPreview(card.card.illustration);
        GUILayout.Box(illustrationpreview, GUILayout.Width(90), GUILayout.Height(140));
        EditorGUILayout.EndVertical();
        EditorGUILayout.BeginVertical();
        EditorGUILayout.LabelField("Reverso", GUILayout.Width(80));
        card.card.back = (Texture) EditorGUILayout.ObjectField(card.card.back, typeof(Texture), true);
        Texture2D backpreview = AssetPreview.GetAssetPreview(card.card.back);
        GUILayout.Box(backpreview, GUILayout.Width(90), GUILayout.Height(140));
        EditorGUILayout.EndVertical();
        EditorGUILayout.EndHorizontal();
        Repaint();
    }
    void Stats() {
        EditorGUILayout.BeginHorizontal();
        EditorGUILayout.LabelField("Vida", GUILayout.Width(60));
        card.card.life = EditorGUILayout.IntField(card.card.life);
        EditorGUILayout.LabelField("Costo", GUILayout.Width(60));
        card.card.cost = EditorGUILayout.IntField(card.card.cost);
        EditorGUILayout.EndHorizontal();


        EditorGUILayout.BeginHorizontal();
        EditorGUILayout.LabelField("Energia", GUILayout.Width(60));
        card.card.energy = EditorGUILayout.IntField(card.card.energy);
        EditorGUILayout.LabelField("Mana", GUILayout.Width(60));
        card.card.mana = EditorGUILayout.IntField(card.card.mana);
        EditorGUILayout.EndHorizontal();

        EditorGUILayout.BeginHorizontal();
        EditorGUILayout.LabelField("Ataque", GUILayout.Width(60));
        card.card.attack = EditorGUILayout.IntField(card.card.attack);
        EditorGUILayout.LabelField("Defensa", GUILayout.Width(60));
        card.card.defense = EditorGUILayout.IntField(card.card.defense);
        EditorGUILayout.EndHorizontal();

        EditorGUILayout.BeginHorizontal();
        EditorGUILayout.LabelField("Estrellas", GUILayout.Width(60));
        card.card.stars = EditorGUILayout.IntField(card.card.stars);
        EditorGUILayout.EndHorizontal();

        EditorGUILayout.BeginHorizontal();
        EditorGUILayout.LabelField("Tipo", GUILayout.Width(60));
        card.card.cardtype = EditorGUILayout.TextField(card.card.cardtype);
        EditorGUILayout.EndHorizontal();

    }

    void Description() {
        EditorGUILayout.LabelField("Descripcion", GUILayout.Width(80));
        card.card.description = EditorGUILayout.TextArea(card.card.description,GUILayout.Height(60));

        EditorGUILayout.LabelField("Habilidad", GUILayout.Width(80));
        card.card.ability = EditorGUILayout.TextArea(card.card.ability, GUILayout.Height(60));

        EditorGUILayout.BeginHorizontal();
        EditorGUILayout.LabelField("Firma", GUILayout.Width(60));
        card.card.autorSign = EditorGUILayout.TextField(card.card.autorSign);
        EditorGUILayout.EndHorizontal();

    }

}
