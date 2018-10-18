using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class CardWindowEditor : EditorWindow {
    static CardWindowEditor window;
    public BaseCard card;

    [MenuItem("Deck/Card Editor")]
    public static void CreateWindow() {
        window = (CardWindowEditor) GetWindow(typeof(CardWindowEditor));

    }
    private void OnEnable() {


    }
    private void OnGUI() {

        Rect buttonRect = new Rect(position.height / 3, position.width / 5, 0, 0);

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
            EditorGUILayout.BeginHorizontal();
            EditorGUILayout.LabelField(card.cardname, EditorStyles.boldLabel, GUILayout.Width(150));

            if ( GUILayout.Button("Editar", GUILayout.Width(45)) ) {
                Debug.Log("editadah");
                var popup = new EditNamePopup {
                    bc = card
                };
                PopupWindow.Show(buttonRect, popup);
            }
            EditorGUILayout.EndHorizontal();

            EditorGUILayout.LabelField("Marco", GUILayout.Width(80));
            card.frame = (Texture2D) EditorGUILayout.ObjectField(card.frame, typeof(Texture2D), true);
            Texture2D framepreview = AssetPreview.GetAssetPreview(card.frame);
            GUILayout.Box(framepreview, GUILayout.Width(200), GUILayout.Height(280));


            EditorGUILayout.EndVertical();
            EditorGUILayout.BeginVertical();
            EditorGUILayout.LabelField("Estadisticas", EditorStyles.boldLabel);

            EditorGUILayout.BeginHorizontal();
            EditorGUILayout.LabelField("Vida", GUILayout.Width(55));
            card.life = EditorGUILayout.IntField(card.life);
            EditorGUILayout.LabelField("Energia", GUILayout.Width(55));
            card.energy = EditorGUILayout.IntField(card.energy);
            EditorGUILayout.EndHorizontal();
            EditorGUILayout.BeginHorizontal();
            EditorGUILayout.LabelField("Ataque", GUILayout.Width(55));
            card.attack = EditorGUILayout.IntField(card.attack);
            EditorGUILayout.LabelField("Defensa", GUILayout.Width(55));
            card.defense = EditorGUILayout.IntField(card.defense);
            EditorGUILayout.EndHorizontal();
            EditorGUILayout.BeginHorizontal();
            EditorGUILayout.LabelField("Mana", GUILayout.Width(55));
            card.mana = EditorGUILayout.IntField(card.mana);
            EditorGUILayout.LabelField("Estrellas", GUILayout.Width(55));
            card.stars = EditorGUILayout.IntField(card.stars);
            EditorGUILayout.EndHorizontal();
            EditorGUILayout.BeginHorizontal();
            EditorGUILayout.LabelField("Tipo", GUILayout.Width(55));
            card.cardtype = EditorGUILayout.TextField(card.cardtype);
            EditorGUILayout.EndHorizontal();
            EditorGUILayout.BeginHorizontal();
            EditorGUILayout.LabelField("Costo", GUILayout.Width(55));
            card.cost = EditorGUILayout.IntField(card.cost);
            EditorGUILayout.EndHorizontal();
            EditorGUILayout.BeginHorizontal();
            EditorGUILayout.LabelField("Habilidad", GUILayout.Width(55));
            card.ability = EditorGUILayout.TextField(card.ability);
            EditorGUILayout.EndHorizontal();
            EditorGUILayout.LabelField("Descripción:", EditorStyles.boldLabel);
            card.description = EditorGUILayout.TextArea(card.description, GUILayout.Height(80));
            EditorGUILayout.EndVertical();
            EditorGUILayout.EndHorizontal();

            if ( GUILayout.Button("Guardar") ) {
                Debug.Log("Guardadox");
                //Aca va lo de enviar la carta de vuelta a la ventana xd y cerrarla
            }

        }

    }

}
