using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace A
{
	public class CoroutineManager : MonoBehaviour
	{
		public CoroutineManager Instance { get; private set; }

		private void Awake()
		{
			Instance = this;
        
		}
		
	}

	public class Coroutine
	{
		// 里面传入一个返回IEnumerator的委托
		// 这个对象交给A_CoroutineManager进行遍历? 但是Unity似乎不是这么做的
	}

	public class CoroutineCondition
	{
		public Func<bool> method;
	}
}


