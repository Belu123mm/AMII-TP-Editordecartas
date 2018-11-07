using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class CardWindowEditor : EditorWindow {
    static CardWindowEditor window;
    public BaseCard card;
    [MenuItem("Deck Tools/Card Editor")]
    public static void CreateWindow() {
        window = (CardWindowEditor) GetWindow(typeof(CardWindowEditor));

    }
    private void OnEnable() {


    }
    private void OnGUI() {


        EditorGUILayout.LabelField("Grupo");
        card = (BaseCard) EditorGUILayout.ObjectField(card, typeof(BaseCard), true);

        /*COSAS QUE TIENEN QUE ESTAR
         *  Nombre v
         *  Descripciopn
         *  Ilustracion
         *  Stats en general
         *  Boton de guardar
         */


        if ( card ) {
            EditorGUILayout.BeginHorizontal();
            EditorGUILayout.BeginVertical();

            Name();

            Illustration();

            EditorGUILayout.EndVertical();
            EditorGUILayout.BeginVertical();

            Stats();
            
            EditorGUILayout.EndVertical();
            EditorGUILayout.EndHorizontal();
            EditorGUILayout.Space();

            if ( GUILayout.Button("Guardar") ) {
                Debug.Log("Guardadox");
                //Aca va lo de enviar la carta de vuelta a la ventana xd y cerrarla
            }
        }

    }
    public void Name() {
            EditorGUILayout.BeginHorizontal();
        Rect buttonRect = new Rect(position.height / 3, position.width / 5, 0, 0);

        EditorGUILayout.LabelField(card.card.cardname, EditorStyles.boldLabel, GUILayout.Width(150));

            if ( GUILayout.Button("Editar", GUILayout.Width(45)) ) {
                Debug.Log("editadah");
                var popup = new EditNamePopup {
                    bc = card
                };
                PopupWindow.Show(buttonRect, popup);
            }
            EditorGUILayout.EndHorizontal();

    }
    public void Illustration() {
        EditorGUILayout.LabelField("Marco", GUILayout.Width(80));
        card.card.frame = (Texture2D) EditorGUILayout.ObjectField(card.card.frame, typeof(Texture2D), true);
        Texture2D framepreview = AssetPreview.GetAssetPreview(card.frame);
        GUILayout.BeginArea(new Rect(4, 95, 200, 280));
        GUI.DrawTexture(new Rect(35, 0, 112.5f, 175), framepreview);
        GUILayout.EndArea();

    }
    public void Stats() {
        //Title
        EditorGUILayout.LabelField("Estadisticas", EditorStyles.boldLabel);

        EditorGUILayout.BeginHorizontal();

        //Vida
        EditorGUILayout.LabelField("Vida", GUILayout.Width(55));
        card.card.life = EditorGUILayout.IntField(card.card.life);
        //Energia
        EditorGUILayout.LabelField("Energia", GUILayout.Width(55));
        card.card.energy = EditorGUILayout.IntField(card.card.energy);

        EditorGUILayout.EndHorizontal();
        EditorGUILayout.BeginHorizontal();

        //Attack
        EditorGUILayout.LabelField("Ataque", GUILayout.Width(55));
        card.card.attack = EditorGUILayout.IntField(card.card.attack);
        //Defensa
        EditorGUILayout.LabelField("Defensa", GUILayout.Width(55));
        card.card.defense = EditorGUILayout.IntField(card.card.defense);

        EditorGUILayout.EndHorizontal();
        EditorGUILayout.BeginHorizontal();

        //Mana
        EditorGUILayout.LabelField("Mana", GUILayout.Width(55));
        card.card.mana = EditorGUILayout.IntField(card.card.mana);
        //Stars
        EditorGUILayout.LabelField("Estrellas", GUILayout.Width(55));
        card.card.stars = EditorGUILayout.IntField(card.card.stars);

        EditorGUILayout.EndHorizontal();
        EditorGUILayout.BeginHorizontal();

        //Type
        EditorGUILayout.LabelField("Tipo", GUILayout.Width(55));
        card.card.cardtype = EditorGUILayout.TextField(card.card.cardtype);

        EditorGUILayout.EndHorizontal();
        EditorGUILayout.BeginHorizontal();

        //Cost
        EditorGUILayout.LabelField("Costo", GUILayout.Width(55));
        card.card.cost = EditorGUILayout.IntField(card.card.cost);

        EditorGUILayout.EndHorizontal();
        EditorGUILayout.BeginHorizontal();

        //Ability
        EditorGUILayout.LabelField("Habilidad", GUILayout.Width(55));
        card.card.ability = EditorGUILayout.TextField(card.card.ability);

        EditorGUILayout.EndHorizontal();

        //Descripcion fiend
        EditorGUILayout.LabelField("Descripción:", EditorStyles.boldLabel);
        card.card.description = EditorGUILayout.TextArea(card.card.description, GUILayout.Height(80));

    }
}
