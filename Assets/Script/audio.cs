using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class audio : MonoBehaviour
{
    [SerializeField] private AudioSource a;//AudioSource�^�̕ϐ�a��錾 �g�p����AudioSource�R���|�[�l���g���A�^�b�`�K�v

    [SerializeField] private AudioClip b1;//AudioClip�^�̕ϐ�b1��錾 �g�p����AudioClip���A�^�b�`�K�v
    [SerializeField] private AudioClip b2;//AudioClip�^�̕ϐ�b2��錾 �g�p����AudioClip���A�^�b�`�K�v 
    [SerializeField] private AudioClip b3;//AudioClip�^�̕ϐ�b3��錾 �g�p����AudioClip���A�^�b�`�K�v 

    //����̊֐�1
    public void SE1()
    {
        a.PlayOneShot(b1);
    }

    //����̊֐�2
    public void SE2()
    {
        a.PlayOneShot(b2);
    }

    //����̊֐�3
    public void SE3()
    {
        a.PlayOneShot(b3);
    }
}
