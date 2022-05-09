using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Close : MonoBehaviour
{
        public GameObject close;
        // Start is called before the first frame update
        // Update is called once per frame
        public void OnClick() {
                close.gameObject.SetActive(false);
                gameObject.SetActive(false);
        }
}
