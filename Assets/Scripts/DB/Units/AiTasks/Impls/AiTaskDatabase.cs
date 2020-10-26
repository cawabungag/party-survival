using System;
using UnityEngine;

namespace DB.Units.AiTasks.Impls
{
	[CreateAssetMenu(menuName = "Installers/AiTaskDatabase", fileName = "AiTaskDatabase")]
	public class AiTaskDatabase : ScriptableObject, IAiTaskDatabase
	{
		[SerializeField] private AiTaskVo[] _aiTaskVos;

		public AiTaskVo GetAiTask(EObjectType unitId)
		{
			for (int i = 0; i < _aiTaskVos.Length; i++)
			{
				AiTaskVo aiTaskVo = _aiTaskVos[i];
				if (aiTaskVo.objectType == unitId)
				{
					return aiTaskVo;
				}
			}

			throw new ArgumentException(
				$"[{nameof(AiTaskDatabase)}] No UnitTask for UnitId:{unitId}");
		}
	}
}