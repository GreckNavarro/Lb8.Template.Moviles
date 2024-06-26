using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StaticObjectPooling : MonoBehaviour
{
    public List<GameObject> objectPool;
    public GameObject[] objects;

    public int maxQuantity;

    private void Start()
    {

    }
    public void InstantiateObjects()
    {
        GameObject tmp;
        for (int i = 0; i < maxQuantity; ++i)
        {
            int randomindex = Random.Range(0, objects.Length);
            tmp = Instantiate(objects[randomindex], transform.position, transform.rotation);
            /*
            Configurar un atributo de la clase del prefab
            tmp.GetComponent<ClaseBase>().SetObjectPool(this);
            */
            objectPool.Add(tmp);
            tmp.transform.SetParent(this.transform);
            tmp.SetActive(false);
        }


    }
    public void GetObject()
    {
        if (objectPool.Count > 0)
        {
            GameObject tmp = objectPool[0];
            objectPool.Remove(tmp);
            tmp.SetActive(true);
            /*
            Inicializar las variables de tu clase
            tmp.GetComponent<ClaseBase>().InitVariables();
            */

        }
        else
        {
            print("No hay m�s objetos en el pool");
        }
    }
    public void SetObject(GameObject obj)
    {
        objectPool.Add(obj);
        obj.SetActive(false);
    }
}
