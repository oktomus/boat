//place this script in the Editor folder within Assets.
using UnityEditor;


class WebGLBuilder {
	static void build() {
		string[] scenes = {"Assets/Level.unity"};
		BuildPipeline.BuildPlayer(scenes, "WebGL-Dist", BuildTarget.WebGL, BuildOptions.None);
	}
}