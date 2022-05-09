using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Speed_display : MonoBehaviour
{
        // Start is called before the first frame update
        public float speed = 0;
        public bool timer=false;
        public salmon player;
        void Start()
        {
                speed=player.speed*10;
                GetComponent<Text>().text = speed.ToString("F2");//小数2桁にして表示
        }

        // Update is called once per frame
        void Update()
        {
                speed=player.speed*10;
                GetComponent<Text>().text = speed.ToString("F2")+"km";//小数2桁にして表示
        }
}
