using Il2CppInterop.Runtime.Attributes;
using MelonLoader;
using System;
using System.Collections;
using UnityEngine.XR.Management;

namespace UnityEngine.XR.OpenXR
{
    // Token: 0x02000018 RID: 24
    [MelonLoader.RegisterTypeInIl2Cpp(true)]
    internal class OpenXRRestarter : MonoBehaviour
    {
        public OpenXRRestarter(IntPtr ptr) : base(ptr) { }
        // Token: 0x06000096 RID: 150 RVA: 0x0000345D File Offset: 0x0000165D
        public void ResetCallbacks()
		{
			this.onAfterRestart = null;
			this.onAfterSuccessfulRestart = null;
			this.onAfterShutdown = null;
			this.onAfterCoroutine = null;
			this.onQuit = null;
			OpenXRRestarter.m_pauseAndRestartAttempts = 0;
		}

		// Token: 0x17000014 RID: 20
		// (get) Token: 0x06000097 RID: 151 RVA: 0x00003488 File Offset: 0x00001688
		public bool isRunning
		{
			get
			{
				return this.m_Coroutine != null;
			}
		}

		// Token: 0x17000015 RID: 21
		// (get) Token: 0x06000098 RID: 152 RVA: 0x00003493 File Offset: 0x00001693
		// (set) Token: 0x06000099 RID: 153 RVA: 0x0000349A File Offset: 0x0000169A
		public static float TimeBetweenRestartAttempts { get; set; } = 5f;

		// Token: 0x17000016 RID: 22
		// (get) Token: 0x0600009A RID: 154 RVA: 0x000034A2 File Offset: 0x000016A2
		public static int PauseAndRestartAttempts
		{
			get
			{
				return OpenXRRestarter.m_pauseAndRestartAttempts;
			}
		}

		// Token: 0x17000017 RID: 23
		// (get) Token: 0x0600009B RID: 155 RVA: 0x000034A9 File Offset: 0x000016A9
		internal static int PauseAndRestartCoroutineCount
		{
			get
			{
				return OpenXRRestarter.m_pauseAndRestartCoroutineCount;
			}
		}

		// Token: 0x17000018 RID: 24
		// (get) Token: 0x0600009C RID: 156 RVA: 0x000034B0 File Offset: 0x000016B0
		public static OpenXRRestarter Instance
		{
			get
			{
				if (OpenXRRestarter.s_Instance == null)
				{
					GameObject go = GameObject.Find("~oxrestarter");
					if (go == null)
					{
						go = new GameObject("~oxrestarter");
						go.hideFlags = HideFlags.HideAndDontSave;
						go.AddComponent<OpenXRRestarter>();
					}
					OpenXRRestarter.s_Instance = go.GetComponent<OpenXRRestarter>();
				}
				return OpenXRRestarter.s_Instance;
			}
		}

		// Token: 0x17000019 RID: 25
		// (get) Token: 0x0600009D RID: 157 RVA: 0x00003508 File Offset: 0x00001708
		// (set) Token: 0x0600009E RID: 158 RVA: 0x0000350F File Offset: 0x0000170F
		internal static bool DisableApplicationQuit { get; set; } = false;

		// Token: 0x0600009F RID: 159 RVA: 0x00003517 File Offset: 0x00001717
		public void Shutdown()
		{
			if (OpenXRLoaderBase.Instance == null)
			{
				return;
			}
			if (this.m_Coroutine != null)
			{
				MelonLogger.Error("Only one shutdown or restart can be executed at a time");
				return;
			}
			this.m_Coroutine = MelonCoroutines.Start(this.RestartCoroutine(false, true));
		}

		// Token: 0x060000A0 RID: 160 RVA: 0x0000354E File Offset: 0x0000174E
		public void ShutdownAndRestart()
		{
			if (OpenXRLoaderBase.Instance == null)
			{
				return;
			}
			if (this.m_Coroutine != null)
			{
				MelonLogger.Error("Only one shutdown or restart can be executed at a time");
				return;
			}
			this.m_Coroutine = MelonCoroutines.Start(this.RestartCoroutine(true, true));
		}

		// Token: 0x060000A1 RID: 161 RVA: 0x00003585 File Offset: 0x00001785
		public void PauseAndShutdownAndRestart()
		{
			if (OpenXRLoaderBase.Instance == null)
			{
				return;
			}
			MelonCoroutines.Start(this.PauseAndShutdownAndRestartCoroutine(OpenXRRestarter.TimeBetweenRestartAttempts));
		}

		// Token: 0x060000A2 RID: 162 RVA: 0x000035A7 File Offset: 0x000017A7
		public void PauseAndRetryInitialization()
		{
			if (OpenXRLoaderBase.Instance == null)
			{
				return;
			}
			MelonCoroutines.Start(this.PauseAndRetryInitializationCoroutine(OpenXRRestarter.TimeBetweenRestartAttempts));
		}

		// Token: 0x060000A3 RID: 163 RVA: 0x000035CC File Offset: 0x000017CC
		private void IncrementPauseAndRestartCoroutineCount()
		{
			Object pauseAndRestartCoroutineCountLock = this.m_PauseAndRestartCoroutineCountLock;
			lock (pauseAndRestartCoroutineCountLock)
			{
				OpenXRRestarter.m_pauseAndRestartCoroutineCount++;
			}
		}

		// Token: 0x060000A4 RID: 164 RVA: 0x00003614 File Offset: 0x00001814
		private void DecrementPauseAndRestartCoroutineCount()
		{
			Object pauseAndRestartCoroutineCountLock = this.m_PauseAndRestartCoroutineCountLock;
			lock (pauseAndRestartCoroutineCountLock)
			{
				OpenXRRestarter.m_pauseAndRestartCoroutineCount--;
			}
		}

		// Token: 0x060000A5 RID: 165 RVA: 0x0000365C File Offset: 0x0000185C
		[HideFromIl2Cpp]
		private IEnumerator PauseAndShutdownAndRestartCoroutine(float pauseTimeInSeconds)
		{
			this.IncrementPauseAndRestartCoroutineCount();
			try
			{
				yield return new WaitForSeconds(pauseTimeInSeconds);
				yield return new WaitForRestartFinish(5f);
				OpenXRRestarter.m_pauseAndRestartAttempts++;
				this.m_Coroutine = MelonCoroutines.Start(this.RestartCoroutine(true, true));
			}
			finally
			{
				Action action = this.onAfterCoroutine;
				if (action != null)
				{
					action();
				}
			}
			this.DecrementPauseAndRestartCoroutineCount();
			yield break;
			yield break;
		}

        // Token: 0x060000A6 RID: 166 RVA: 0x00003672 File Offset: 0x00001872
        [HideFromIl2Cpp]
        private IEnumerator PauseAndRetryInitializationCoroutine(float pauseTimeInSeconds)
		{
			this.IncrementPauseAndRestartCoroutineCount();
			try
			{
				yield return new WaitForSeconds(pauseTimeInSeconds);
				yield return new WaitForRestartFinish(5f);
				if (!(XRGeneralSettings.Instance.Manager.activeLoader != null))
				{
					OpenXRRestarter.m_pauseAndRestartAttempts++;
					this.m_Coroutine = MelonCoroutines.Start(this.RestartCoroutine(true, false));
				}
			}
			finally
			{
				Action action = this.onAfterCoroutine;
				if (action != null)
				{
					action();
				}
			}
			this.DecrementPauseAndRestartCoroutineCount();
			yield break;
		}

        // Token: 0x060000A7 RID: 167 RVA: 0x00003688 File Offset: 0x00001888
        [HideFromIl2Cpp]
        private IEnumerator RestartCoroutine(bool shouldRestart, bool shouldShutdown)
		{
			try
			{
				if (shouldShutdown)
				{
					MelonLogger.Msg("Shutting down OpenXR.");
					yield return null;
					XRGeneralSettings.Instance.Manager.DeinitializeLoader();
					yield return null;
					Action action = this.onAfterShutdown;
					if (action != null)
					{
						action();
					}
				}
				if (shouldRestart && OpenXRRuntime.ShouldRestart())
				{
					MelonLogger.Msg("Initializing OpenXR.");
					yield return XRGeneralSettings.Instance.Manager.InitializeLoader();
					XRGeneralSettings.Instance.Manager.StartSubsystems();
					if (XRGeneralSettings.Instance.Manager.activeLoader != null)
					{
						OpenXRRestarter.m_pauseAndRestartAttempts = 0;
						Action action2 = this.onAfterSuccessfulRestart;
						if (action2 != null)
						{
							action2();
						}
					}
					Action action3 = this.onAfterRestart;
					if (action3 != null)
					{
						action3();
					}
				}
				else if (OpenXRRuntime.ShouldQuit())
				{
					Action action4 = this.onQuit;
					if (action4 != null)
					{
						action4();
					}
					if (!OpenXRRestarter.DisableApplicationQuit)
					{
						Application.Quit();
					}
				}
			}
			finally
			{
				this.m_Coroutine = null;
				Action action5 = this.onAfterCoroutine;
				if (action5 != null)
				{
					action5();
				}
			}
			yield break;
			yield break;
		}

		// Token: 0x04000063 RID: 99
		internal Action onAfterRestart;

		// Token: 0x04000064 RID: 100
		internal Action onAfterShutdown;

		// Token: 0x04000065 RID: 101
		internal Action onQuit;

		// Token: 0x04000066 RID: 102
		internal Action onAfterCoroutine;

		// Token: 0x04000067 RID: 103
		internal Action onAfterSuccessfulRestart;

		// Token: 0x04000068 RID: 104
		private static OpenXRRestarter s_Instance;

		// Token: 0x04000069 RID: 105
		private object m_Coroutine;

		// Token: 0x0400006A RID: 106
		private static int m_pauseAndRestartCoroutineCount;

		// Token: 0x0400006B RID: 107
		private Object m_PauseAndRestartCoroutineCountLock = new Object();

		// Token: 0x0400006C RID: 108
		private static int m_pauseAndRestartAttempts;
	}
}
