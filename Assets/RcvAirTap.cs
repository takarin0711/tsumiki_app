using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using HoloToolkit.Unity.InputModule;
using System;

public class RcvAirTap : MonoBehaviour, IInputClickHandler {
    //Cube prefabを扱う変数
    public GameObject original;

    List<GameObject> list = new List<GameObject>();

    //AirTapされたときに呼び出される関数
    public void OnInputClicked(InputClickedEventData eventData)
    {
        //Cube prefabの情報を用いて立方体を実体化
        GameObject cube = GameObject.Instantiate(original);

        //自分からみて前方1.2mの位置を空間内の位置に変換
        cube.transform.position = Camera.main.transform.TransformPoint(0, 0, 1.2f);

        if (list.Count == 10)
        {
            Destroy(list[0]);
            list[0] = null;
            list.RemoveAt(0);
        }
        list.Add(cube);
        Debug.Log("AirTap!");
    }

    

    // Use this for initialization
    void Start () {
        InputManager.Instance.PushFallbackInputHandler(gameObject);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
