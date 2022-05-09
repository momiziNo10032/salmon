using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class salmon : MonoBehaviour
{

        public static salmon m_instance;
        public float speed=3f;
        bool speed_swich=false;//ドリフトするとtrueになる
        Rigidbody iwasirigid;
        public float MAX_rotate_speed=1.5f;//まわる速度最大
        public float rotate_speed=0.1f;//現在のまわる速度
        float start_rotate;//デフォルトのまわる速度
        public float uemax=-60;//上に向く角度の最大値：負の値
        public float sitamax=60;//下に向く角度の最大値
        float updown=0;//上下
        public float sau=90;//左右
        public float inclination=0;
        public float inclination_speed=5f;
        public float return_speed=6f;
        public float MAX_inclination=30;
        public Timer Timer;//timerスクリプトを取得
        public Flag flag;//timerスクリプトを取得
        public int salmon_flag=0;
        public MP3 mp3;

        void Start()
        {
                start_rotate=rotate_speed;
                m_instance=this;
                iwasirigid = GetComponent<Rigidbody>();
                Timer.timer=false;
                speed=0;
        }

        void Update()
        {
                if(salmon_flag==1) {
                        Timer.timer=true;
                        if(Input.GetKey(KeyCode.UpArrow)&&updown>uemax) {
                                //updown-=rotate_speed;
                        }
                        // 下方向ボタンを押した瞬間にif文の中を実行
                        if(Input.GetKey(KeyCode.DownArrow)&&updown<sitamax) {
                                //updown+=rotate_speed;
                        }
                        // 右方向ボタンを押した瞬間にif文の中を実行
                        if(Input.GetKey(KeyCode.RightArrow)) {
                                sau+=rotate_speed;
                                if(rotate_speed<MAX_rotate_speed) rotate_speed+=0.5f;
                                if(inclination>-MAX_inclination) inclination-=inclination_speed;
                                if(inclination<=-MAX_inclination) {
                                        Spark.spk.GetComponent<ParticleSystem>().Play();//火花を出す
                                        speed_swich=true;
                                }
                        }
                        // 左方向ボタンを押した瞬間にif文の中を実行
                        if(Input.GetKey(KeyCode.LeftArrow)) {
                                sau-=rotate_speed;
                                if(rotate_speed<MAX_rotate_speed) rotate_speed+=0.5f;
                                if(inclination<MAX_inclination) inclination+=inclination_speed;
                                if(inclination>=MAX_inclination) {
                                        Spark.spk.GetComponent<ParticleSystem>().Play();
                                        speed_swich=true;
                                }
                        }
                        if(!Input.anyKey) {//何も押されてないとき
                                Spark.spk.GetComponent<ParticleSystem>().Stop();//火花を止める
                                speed_swich=false;
                                if(inclination<0) inclination+=return_speed;
                                if(inclination>0) inclination-=return_speed;
                                rotate_speed=start_rotate;
                                if(Mathf.Abs(inclination)<5) {
                                        inclination=0;//角度を戻す
                                }
                        }
                }
                //Debug.Log(updown+":"+sau);
                transform.rotation = Quaternion.Euler(updown,sau,inclination);
                if(speed_swich==true) speed+=0.003f;
                iwasirigid.velocity = this.gameObject.transform.forward * speed;
                //print(salmon_flag);
                //print(Spark.spk.GetComponent<ParticleSystem>());
                if(salmon_flag==2) {//リトライが押されたら
                        Timer.countTime=0;//Timer become 0
                        Timer.timer=false;
                        salmon_flag=0;
                        //speed=3f;
                        mp3.Mswich=0;//BGM
                }
        }
        void OnCollisionEnter(Collision other){
                if(other.gameObject.CompareTag("wall")) {
                        this.gameObject.SetActive(false);
                        Spark.spk.GetComponent<ParticleSystem>().Stop();
                        Timer.timer=false;//タイマーを止める
                        Explosion.megumin.GetComponent<ParticleSystem>().Play();//爆発
                        //salmon_flag=1;//
                        speed_swich=false;
                        //ランキング呼び出し
                        naichilab.RankingLoader.Instance.SendScoreAndShowRanking (speed*10);
                        mp3.Mswich=1;//爆発音
                }
        }
        void OnTriggerEnter(Collider other) {
                if(other.gameObject.CompareTag("Flag")) {
                        flag.flag_count+=1;
                        flag.color=1f;
                }
                if(other.gameObject.CompareTag("How_much")) {
                        other.gameObject.SetActive(false);
                        speed+=0.3f;
                        mp3.Mswich=2;
                }
        }
}
