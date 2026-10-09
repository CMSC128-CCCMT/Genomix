using System;

namespace Genomix;

public enum SceneName
{
	OVERVIEW,
	SAMPLES,
	TASKLIST,
	SETTINGS
}

public interface INavigation
{
	// to be implemented: Scenes system	
	// public SceneControl? CurrentScene { get; }
	public event Action<SceneName>? SceneChanged;
	
	public void NavigateToScene(SceneName destination);
}
