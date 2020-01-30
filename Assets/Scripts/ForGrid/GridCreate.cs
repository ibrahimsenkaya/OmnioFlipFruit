using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridCreate : MonoBehaviour
{
    GameObject tempchild,temppart;
    [SerializeField] GameObject Particle;
    [SerializeField] GameObject Block, Choco;
    [SerializeField] Material chocomat;
    Vector3 tmppos;
    private void Awake()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            tempchild= transform.GetChild(i).gameObject;
            if (tempchild.tag=="Chocolate")
            {
                tmppos = tempchild.transform.position;

                //Choco
                Instantiate(Choco, new Vector3(tmppos.x , .2f, tmppos.z ), Quaternion.identity);

                //particle 
                temppart=Instantiate(Particle, new Vector3(tmppos.x, .4f, tmppos.z), Quaternion.Euler(270,0,0));
                temppart.transform.parent = tempchild.transform;
                temppart.transform.localScale = new Vector3(.6f, .6f, .6f);

                //Changing Base Material
                tempchild.GetComponent<Renderer>().material = chocomat;
               


            }
            else if (tempchild.tag == "Blocked")
            {
                //Blocked
                tmppos = tempchild.transform.position;
                Instantiate(Block, new Vector3(tmppos.x, .5f, tmppos.z), Quaternion.identity);
            }
        }
    }
}
