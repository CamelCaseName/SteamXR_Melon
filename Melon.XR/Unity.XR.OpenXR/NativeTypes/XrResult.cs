using System;

namespace UnityEngine.XR.OpenXR.NativeTypes
{
	// Token: 0x02000027 RID: 39
	public enum XrResult
	{
		// Token: 0x040000B2 RID: 178
		Success,
		// Token: 0x040000B3 RID: 179
		[Obsolete("This value is misspelled and therefore deprecated in OpenXR Plug-in version 1.14.0. Use TimeoutExpired instead.", false)]
		TimeoutExpored,
		// Token: 0x040000B4 RID: 180
		TimeoutExpired = 1,
		// Token: 0x040000B5 RID: 181
		LossPending = 3,
		// Token: 0x040000B6 RID: 182
		EventUnavailable,
		// Token: 0x040000B7 RID: 183
		SpaceBoundsUnavailable = 7,
		// Token: 0x040000B8 RID: 184
		SessionNotFocused,
		// Token: 0x040000B9 RID: 185
		FrameDiscarded,
		// Token: 0x040000BA RID: 186
		ValidationFailure = -1,
		// Token: 0x040000BB RID: 187
		RuntimeFailure = -2,
		// Token: 0x040000BC RID: 188
		OutOfMemory = -3,
		// Token: 0x040000BD RID: 189
		ApiVersionUnsupported = -4,
		// Token: 0x040000BE RID: 190
		InitializationFailed = -6,
		// Token: 0x040000BF RID: 191
		FunctionUnsupported = -7,
		// Token: 0x040000C0 RID: 192
		FeatureUnsupported = -8,
		// Token: 0x040000C1 RID: 193
		ExtensionNotPresent = -9,
		// Token: 0x040000C2 RID: 194
		LimitReached = -10,
		// Token: 0x040000C3 RID: 195
		SizeInsufficient = -11,
		// Token: 0x040000C4 RID: 196
		HandleInvalid = -12,
		// Token: 0x040000C5 RID: 197
		InstanceLost = -13,
		// Token: 0x040000C6 RID: 198
		SessionRunning = -14,
		// Token: 0x040000C7 RID: 199
		SessionNotRunning = -16,
		// Token: 0x040000C8 RID: 200
		SessionLost = -17,
		// Token: 0x040000C9 RID: 201
		SystemInvalid = -18,
		// Token: 0x040000CA RID: 202
		PathInvalid = -19,
		// Token: 0x040000CB RID: 203
		PathCountExceeded = -20,
		// Token: 0x040000CC RID: 204
		PathFormatInvalid = -21,
		// Token: 0x040000CD RID: 205
		PathUnsupported = -22,
		// Token: 0x040000CE RID: 206
		LayerInvalid = -23,
		// Token: 0x040000CF RID: 207
		LayerLimitExceeded = -24,
		// Token: 0x040000D0 RID: 208
		SwapchainRectInvalid = -25,
		// Token: 0x040000D1 RID: 209
		SwapchainFormatUnsupported = -26,
		// Token: 0x040000D2 RID: 210
		ActionTypeMismatch = -27,
		// Token: 0x040000D3 RID: 211
		SessionNotReady = -28,
		// Token: 0x040000D4 RID: 212
		SessionNotStopping = -29,
		// Token: 0x040000D5 RID: 213
		TimeInvalid = -30,
		// Token: 0x040000D6 RID: 214
		ReferenceSpaceUnsupported = -31,
		// Token: 0x040000D7 RID: 215
		FileAccessError = -32,
		// Token: 0x040000D8 RID: 216
		FileContentsInvalid = -33,
		// Token: 0x040000D9 RID: 217
		FormFactorUnsupported = -34,
		// Token: 0x040000DA RID: 218
		FormFactorUnavailable = -35,
		// Token: 0x040000DB RID: 219
		ApiLayerNotPresent = -36,
		// Token: 0x040000DC RID: 220
		CallOrderInvalid = -37,
		// Token: 0x040000DD RID: 221
		GraphicsDeviceInvalid = -38,
		// Token: 0x040000DE RID: 222
		PoseInvalid = -39,
		// Token: 0x040000DF RID: 223
		IndexOutOfRange = -40,
		// Token: 0x040000E0 RID: 224
		ViewConfigurationTypeUnsupported = -41,
		// Token: 0x040000E1 RID: 225
		EnvironmentBlendModeUnsupported = -42,
		// Token: 0x040000E2 RID: 226
		NameDuplicated = -44,
		// Token: 0x040000E3 RID: 227
		NameInvalid = -45,
		// Token: 0x040000E4 RID: 228
		ActionsetNotAttached = -46,
		// Token: 0x040000E5 RID: 229
		ActionsetsAlreadyAttached = -47,
		// Token: 0x040000E6 RID: 230
		LocalizedNameDuplicated = -48,
		// Token: 0x040000E7 RID: 231
		LocalizedNameInvalid = -49,
		// Token: 0x040000E8 RID: 232
		GraphicsRequirementsCallMissing = -50,
		// Token: 0x040000E9 RID: 233
		RuntimeUnavailable = -51,
		// Token: 0x040000EA RID: 234
		ExtensionDependencyNotEnabled = -1000710001,
		// Token: 0x040000EB RID: 235
		PermissionInsufficient,
		// Token: 0x040000EC RID: 236
		AndroidThreadSettingsIdInvalidKHR = -1000003000,
		// Token: 0x040000ED RID: 237
		[Obsolete("This enum value is misspelled and therefore deprecated in OpenXR Plug-in version 1.14.0. Use AndroidThreadSettingsFailureKHR instead.", false)]
		AndroidThreadSettingsdFailureKHR = -1000003001,
		// Token: 0x040000EE RID: 238
		AndroidThreadSettingsFailureKHR = -1000003001,
		// Token: 0x040000EF RID: 239
		CreateSpatialAnchorFailedMSFT = -1000039001,
		// Token: 0x040000F0 RID: 240
		SecondaryViewConfigurationTypeNotEnabledMSFT = -1000053000,
		// Token: 0x040000F1 RID: 241
		ControllerModelKeyInvalidMSFT = -1000055000,
		// Token: 0x040000F2 RID: 242
		ReprojectionModeUnsupportedMSFT = -1000066000,
		// Token: 0x040000F3 RID: 243
		ComputeNewSceneNotCompletedMSFT = -1000097000,
		// Token: 0x040000F4 RID: 244
		SceneComponentIdInvalidMSFT = -1000097001,
		// Token: 0x040000F5 RID: 245
		SceneComponentTypeMismatchMSFT = -1000097002,
		// Token: 0x040000F6 RID: 246
		SceneMeshBufferIdInvalidMSFT = -1000097003,
		// Token: 0x040000F7 RID: 247
		SceneComputeFeatureIncompatibleMSFT = -1000097004,
		// Token: 0x040000F8 RID: 248
		SceneComputeConsistencyMismatchMSFT = -1000097005,
		// Token: 0x040000F9 RID: 249
		DisplayRefreshRateUnsupportedFB = -1000101000,
		// Token: 0x040000FA RID: 250
		ColorSpaceUnsupportedFB = -1000108000,
		// Token: 0x040000FB RID: 251
		SpaceComponentNotSupportedFB = -1000113000,
		// Token: 0x040000FC RID: 252
		SpaceComponentNotEnabledFB = -1000113001,
		// Token: 0x040000FD RID: 253
		SpaceComponentStatusPendingFB = -1000113002,
		// Token: 0x040000FE RID: 254
		SpaceComponentStatusAlreadySetFB = -1000113003,
		// Token: 0x040000FF RID: 255
		UnexpectedStatePassthroughFB = -1000118000,
		// Token: 0x04000100 RID: 256
		FeatureAlreadyCreatedPassthroughFB = -1000118001,
		// Token: 0x04000101 RID: 257
		FeatureRequiredPassthroughFB = -1000118002,
		// Token: 0x04000102 RID: 258
		NotPermittedPassthroughFB = -1000118003,
		// Token: 0x04000103 RID: 259
		InsufficientResourcesPassthroughFB = -1000118004,
		// Token: 0x04000104 RID: 260
		UnknownPassthroughFB = -1000118050,
		// Token: 0x04000105 RID: 261
		RenderModelKeyInvalidFB = -1000119000,
		// Token: 0x04000106 RID: 262
		RenderModelUnavailableFB = 1000119020,
		// Token: 0x04000107 RID: 263
		MarkerNotTrackedVARJO = -1000124000,
		// Token: 0x04000108 RID: 264
		MarkerIdInvalidVARJO = -1000124001,
		// Token: 0x04000109 RID: 265
		MarkerDetectorPermissionDeniedML = -1000138000,
		// Token: 0x0400010A RID: 266
		MarkerDetectorLocateFailedML = -1000138001,
		// Token: 0x0400010B RID: 267
		MarkerDetectorInvalidDataQueryML = -1000138002,
		// Token: 0x0400010C RID: 268
		MarkerDetectorInvalidCreateInfoML = -1000138003,
		// Token: 0x0400010D RID: 269
		MarkerInvalidML = -1000138004,
		// Token: 0x0400010E RID: 270
		LocalizationMapIncompatibleML = -1000139000,
		// Token: 0x0400010F RID: 271
		LocalizationMapUnavailableML = -1000139001,
		// Token: 0x04000110 RID: 272
		LocalizationMapFailML = -1000139002,
		// Token: 0x04000111 RID: 273
		LocalizationMapImportExportPermissionDeniedML = -1000139003,
		// Token: 0x04000112 RID: 274
		LocalizationMapPermissionDeniedML = -1000139004,
		// Token: 0x04000113 RID: 275
		LocalizationMapAlreadyExistsML = -1000139005,
		// Token: 0x04000114 RID: 276
		LocalizationMapCannotExportCloudMapML = -1000139006,
		// Token: 0x04000115 RID: 277
		SpatialAnchorNameNotFoundMSFT = -1000142001,
		// Token: 0x04000116 RID: 278
		SpatialAnchorNameInvalidMSFT = -1000142002,
		// Token: 0x04000117 RID: 279
		SceneMarkerDataNotStringMSFT = 1000147000,
		// Token: 0x04000118 RID: 280
		SpaceMappingInsufficientFB = -1000169000,
		// Token: 0x04000119 RID: 281
		SpaceLocalizationFailedFB = -1000169001,
		// Token: 0x0400011A RID: 282
		SpaceNetworkTimeoutFB = -1000169002,
		// Token: 0x0400011B RID: 283
		SpaceNetworkRequestFailedFB = -1000169003,
		// Token: 0x0400011C RID: 284
		SpaceCloudStorageDisabledFB = -1000169004,
		// Token: 0x0400011D RID: 285
		PassthroughColorLutBufferSizeMismatchMETA = -1000266000,
		// Token: 0x0400011E RID: 286
		EnvironmentDepthNotAvailableMETA = 1000291000,
		// Token: 0x0400011F RID: 287
		HintAlreadySetQCOM = -1000306000,
		// Token: 0x04000120 RID: 288
		NotAnAnchorHTC = -1000319000,
		// Token: 0x04000121 RID: 289
		SpaceNotLocatableEXT = -1000429000,
		// Token: 0x04000122 RID: 290
		PlaneDetectionPermissionDeniedEXT = -1000429001,
		// Token: 0x04000123 RID: 291
		FuturePendingEXT = -1000469001,
		// Token: 0x04000124 RID: 292
		FutureInvalidEXT = -1000469002,
		// Token: 0x04000125 RID: 293
		ExtensionDependencyNotEnabledKHR = -1000710001,
		// Token: 0x04000126 RID: 294
		PermissionInsufficientKHR,
		// Token: 0x04000127 RID: 295
		MaxResult = 2147483647
	}
}
