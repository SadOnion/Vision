using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MouseInput : MonoBehaviour
{
    public GameObject bulb;
    Player player;
    private void Start()
    {
        player = GetComponent<Player>();
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && player.Use())
        {
            Vector2 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            GameObject o = Instantiate(bulb,Vector3.zero,Quaternion.identity);
            FieldOfView field = o.GetComponent<FieldOfView>();
            field.anchor = pos;
        }
        if (Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}
