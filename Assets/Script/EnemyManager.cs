﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
        // Start is called before the first frame update
        private float m_timer; // 出現タイミングを管理するタイマー
        public float m_intervalFrom; // 出現間隔（秒）（ゲームの経過時間が 0 の時）
        public float m_intervalTo; // 出現間隔（秒）（ゲームの経過時間が m_elapsedTimeMax の時）
        public float m_elapsedTimeMax; // 経過時間の最大値
        public float m_elapsedTime; // 経過時間
        public Enemy[] m_enemyPrefabs; // 敵のプレハブを管理する配列
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
                // 経過時間を更新する
                m_elapsedTime += Time.deltaTime;
                // 出現タイミングを管理するタイマーを更新する
                m_timer += Time.deltaTime;
                // ゲームの経過時間から出現間隔（秒）を算出する
                // ゲームの経過時間が長くなるほど、敵の出現間隔が短くなる
                var t = m_elapsedTime / m_elapsedTimeMax;
                var interval = Mathf.Lerp( m_intervalFrom, m_intervalTo, t );
                // まだ敵が出現するタイミングではない場合、
                // このフレームの処理はここで終える
                if ( m_timer < interval ) return;
                //Debug.Log("enemy_porn");
                // 出現タイミングを管理するタイマーをリセットする
                m_timer = 0;
                // 出現する敵をランダムに決定する
                var enemyIndex = Random.Range( 0, m_enemyPrefabs.Length );
                // 出現する敵のプレハブを配列から取得する
                var enemyPrefab = m_enemyPrefabs[ enemyIndex ];
                // 敵のゲームオブジェクトを生成する
                var enemy = Instantiate( enemyPrefab );
                // 敵を初期化する
                enemy.Init();
        }
}
