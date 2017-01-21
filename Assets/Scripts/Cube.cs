﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Cube : MonoBehaviour {

	public float WaveMax = 1.0f;
	public float WavePower = 4f;

	public Material CubeMaterial;
	public Material GoalMaterial;

	public Action<Cube> OnSelected;

	public int Column { get; private set; }
	public int Row { get; private set; }
	public bool IsGoal { get; private set; }

	public void SetCoordinate(int column, int row) {
		Column = column;
		Row = row;
	}

	public void Wave(float delay) {
		
		var position = gameObject.transform.position;

		var index = 0;
		var path = new Vector3[5];

		var power = WavePower;
		var down = true;

		while (power > 0f && index < path.Length) {

			if (down) {
				position.y -= power;
				if (position.y < -WaveMax) {		
					power = -WaveMax - position.y;
					position.y = -WaveMax;
				} else {
					power = 0f;
				}
			} else { //up
				position.y += power;
				if (position.y > WaveMax) {
					power = position.y - WaveMax;
					position.y = WaveMax;
				}else {
					power = 0f;
				}
			}

			path [index++] = position;
			down = !down;
		}

		while (index < path.Length) {
			path [index++] = position;
		}

		iTween.MoveTo (gameObject, iTween.Hash("path", path, "easetype", iTween.EaseType.linear, "delay", delay, "time", WavePower * 0.5f));

	}

	public void SetAsGoal(bool goal) {

		IsGoal = goal;
		gameObject.GetComponent<Renderer>().material = IsGoal ? GoalMaterial : CubeMaterial;

	}

	void OnMouseOver() {
		if(Input.GetMouseButtonDown(0) 
			&& !UnityEngine.EventSystems.EventSystem.current.IsPointerOverGameObject() 
			&& OnSelected != null){
				OnSelected (this);
		}
	}

}
