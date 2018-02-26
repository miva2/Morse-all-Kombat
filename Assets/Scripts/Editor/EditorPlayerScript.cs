using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

[CustomEditor(typeof(PlayerScript))]
public class EditorPlayerScript : Editor
{

    private PlayerScript playerScript;

    private bool showAttacks = false;
    private bool[] isAttackFoldout;

    private void OnEnable()
    {
        playerScript = target as PlayerScript;
        if(playerScript.attackProperties == null)
        {
            playerScript.attackProperties = new PlayerScript.AttackProperties[0];
        }
        isAttackFoldout = new bool[playerScript.attackProperties.Length];
    }

    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
        EditorGUI.BeginChangeCheck();
        showAttacks = EditorGUILayout.Foldout(showAttacks, "Attack Properties");
        if (showAttacks)
        {
            int attackLength = EditorGUILayout.IntField(playerScript.attackProperties.Length);
            if(attackLength != playerScript.attackProperties.Length)
            {
                PlayerScript.AttackProperties[] newAttackProperties = new PlayerScript.AttackProperties[attackLength];
                bool[] newIsAttackFoldout = new bool[attackLength];
                for (int i = 0; i < newAttackProperties.Length; i++)
                {
                    if (i < playerScript.attackProperties.Length)
                    {
                        newAttackProperties[i] = playerScript.attackProperties[i];
                        newIsAttackFoldout[i] = isAttackFoldout[i];
                    }
                    //Initialize new attack property
                    if (newAttackProperties[i].attackName == null)
                    {
                        newAttackProperties[i].attackName = "New Attack";
                        newAttackProperties[i].attackLetters = "";
                        newAttackProperties[i].horizontalAnimation = new AnimationCurve(new Keyframe(0, 0));
                        newAttackProperties[i].verticalAnimation = new AnimationCurve(new Keyframe(0, 0));
                    }
                }
                playerScript.attackProperties = newAttackProperties;
                isAttackFoldout = newIsAttackFoldout;
            }
            for (int i = 0; i < playerScript.attackProperties.Length; i++)
            {
                isAttackFoldout[i] = EditorGUILayout.Foldout(isAttackFoldout[i], playerScript.attackProperties[i].attackName);
                if (isAttackFoldout[i])
                {
                    PlayerScript.AttackProperties attackProperties = playerScript.attackProperties[i];

                    attackProperties.attackName = EditorGUILayout.TextField("Attack Name", attackProperties.attackName);
                    string attackLetters = attackProperties.attackLetters = EditorGUILayout.TextField("Attack Letter", attackProperties.attackLetters);
                    string damageLabel = attackLetters.Length == 0 || MorseDictionary.IsAttack(attackLetters[0]) ? "Damage" : "Defence percentage";
                    attackProperties.animationName = EditorGUILayout.TextField("Animation Name", attackProperties.animationName);
                    attackProperties.attackTime = EditorGUILayout.FloatField("AttackTime", attackProperties.attackTime);
                    attackProperties.damage = EditorGUILayout.IntField(damageLabel, attackProperties.damage);
                    attackProperties.DirectionalMultiplier = EditorGUILayout.Vector2Field("Directional multiplier", attackProperties.DirectionalMultiplier);
                    attackProperties.horizontalAnimation = EditorGUILayout.CurveField("Horizontal Curve", attackProperties.horizontalAnimation);
                    attackProperties.verticalAnimation = EditorGUILayout.CurveField("Vertical curve", attackProperties.verticalAnimation);

                    playerScript.attackProperties[i] = attackProperties;
                }
            }
        }
        if (EditorGUI.EndChangeCheck())
        {
            GameObject[] players = GameObject.FindGameObjectsWithTag(PlayerScript.TAG_PLAYER);
            Undo.RecordObjects(players, "edited attacks");
            for (int i = 0; i < players.Length; i++)
            {
                players[i].GetComponent<PlayerScript>().attackProperties = playerScript.attackProperties;
                if (PrefabUtility.GetPrefabParent(playerScript.gameObject) == null &&
                    PrefabUtility.GetPrefabObject(playerScript.gameObject) != null)
                {
                    EditorUtility.SetDirty(playerScript);
                }
                else
                {
                    EditorUtility.SetDirty(players[i]);
                }
            }
        }
    }
}