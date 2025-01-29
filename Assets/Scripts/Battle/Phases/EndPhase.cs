using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndPhase : BattlePhaseBase
{
    public override IEnumerator Execute(BattleContext battleContext, List<Move> moveOfAlly, List<Move> moveOfEnemy)
    {
        yield return null;

        Debug.Log("EndPhase");

        BattleSystemManager sm = GetBattleSystemManager();

        yield return new WaitUntil(() => Input.GetKeyDown(KeyCode.Space));

        if (sm.isCleared)
        {
            DungeonProgressManager.isBattleCompleted[DungeonProgressManager.attemptingBattleNum] = true;
            DungeonProgressManager.attemptingBattleNum++;

            SaveCurrentAllyStatus();
            TransitToDungeonScene();
        }
        else if (sm.isEscaped)
        {
            SaveCurrentAllyStatus();
            TransitToDungeonScene();
        }
        else if (sm.isDefeated)
        {
            ActivateGameOverPanel();

            yield return new WaitUntil(() => Input.GetKeyDown(KeyCode.Space));


        }
    }

    public void SaveCurrentAllyStatus()
    {
        BattleSystemManager sm = GetBattleSystemManager();
        for (int i = 0; i < sm.allies.Count; i++)
        {
            Ally ally = sm.allies[i];
            SystemManager.allyComponents[i].currentHP = ally.currentHP;
            SystemManager.allyComponents[i].currentTP = ally.currentTP;
            SystemManager.allyComponents[i].isDead = ally.isDead;
        }
    }

    public void TransitToDungeonScene()
    {
        GameObject sceneController = GameObject.Find("SceneController");
        sceneController.GetComponent<SceneController>().sceneChange("DungeonScene");
    }

    public void ActivateGameOverPanel()
    {
        GameObject uiCanvasPanelObject = GameObject.Find("UICanvas");
        if ( uiCanvasPanelObject != null)
        {
            // 子オブジェクトを取得
            Transform gameOverPanelTransform = uiCanvasPanelObject.transform.Find("GameOverPanel");

            if (gameOverPanelTransform != null)
            {
                // 子オブジェクトをアクティブにする
                gameOverPanelTransform.gameObject.SetActive(true);
            }
            else
            {
                Debug.LogWarning("子オブジェクトが見つかりませんでした。");
            }
        }
        else
        {
            Debug.LogWarning("親オブジェクトが見つかりませんでした。");
        }
    }
}
