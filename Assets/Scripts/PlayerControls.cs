using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerControls : MonoBehaviour {
    [Header("�⺻ ����")]
    [Tooltip("������� �Է����� ���� ������� �ӵ�")]
    [SerializeField] float speed = 20f;
    [SerializeField] float xRange = 8f;
    [SerializeField] float yRange = 5f;

    [Header("��ũ�� ��ġ ��� Ʃ��")]
    [SerializeField] float positionPitchFector = -2f;
    [SerializeField] float positionYawFector = 2f;

    [Header("�÷��̾� ��ġ ��� Ʃ��")]
    [SerializeField] float controlPitchFector = -15f;
    [SerializeField] float controllRollFector = -20f;

    [Header("�������� �迭")]
    [SerializeField] GameObject[] lasers;

    float horizontal, vertical;

    void Update() {
        ProcessTranslation();
        ProcessRotation();
        ProcessFiring();
    }

    //�߻�ü �߻�
    private void ProcessFiring() {
        if (Input.GetKey(KeyCode.Space)) {
            SetLasersActive(true);
        } else
            SetLasersActive(false);
    }

    private void SetLasersActive(bool isActive) {
        foreach (GameObject laser in lasers) {
            var emissionModule = laser.GetComponent<ParticleSystem>().emission;
            emissionModule.enabled = isActive;
        }
    }

    //player ship �̵��������� ����̱�
    private void ProcessRotation() {
        float pitch = transform.localPosition.y * positionPitchFector + vertical * controlPitchFector;
        float yaw = transform.localPosition.x * positionYawFector;
        float roll = horizontal * controllRollFector;
        transform.localRotation = Quaternion.Euler(pitch, yaw, roll);
    }

    //player ship �̵�
    private void ProcessTranslation() {
        //float horizontalThrow=movement.ReadValue<Vector2>().x;
        //float verticallThrow = movement.ReadValue<Vector2>().y;
        //print(horizontalThrow);
        //print(verticallThrow);

        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");

        float newHorizontal = horizontal * speed * Time.deltaTime;
        float rawXpos = transform.localPosition.x + newHorizontal;
        float newXpos = Mathf.Clamp(rawXpos, -xRange, xRange);

        float newVertical = vertical * speed * Time.deltaTime;
        float rawYpos = transform.localPosition.y + newVertical;
        float newYpos = Mathf.Clamp(rawYpos, -yRange, yRange);

        transform.localPosition = new Vector3(newXpos, newYpos, 0);
    }
}
