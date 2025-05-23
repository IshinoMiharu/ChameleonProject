using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering.Universal;
using UnityEngine;
using UnityEngine.UI;

public class InfoChange : MonoBehaviour
{
    [SerializeField] private Transform imageGroup;
    private Image[] images;
    private int imageIndex;
    // Start is called before the first frame update
    void Start()
    {
        images = imageGroup.GetComponentsInChildren<Image>();
        imageIndex = images.Length - 1;
        for (int i = 0; i < images.Length; i++)
        {
            if (i != images.Length - 1) images[i].enabled = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            Debug.Log(imageIndex);
            images[imageIndex].enabled = false;
            imageIndex--;
            if (imageIndex < 0) imageIndex = images.Length - 1;
            imageIndex %= images.Length;
            images[imageIndex].enabled = true;
        }
        else if (Input.GetKeyDown(KeyCode.D))
        {
            Debug.Log(imageIndex);
            images[imageIndex].enabled = false;
            imageIndex++;
            imageIndex %= images.Length;
            images[imageIndex].enabled = true;
        }
    }
}
